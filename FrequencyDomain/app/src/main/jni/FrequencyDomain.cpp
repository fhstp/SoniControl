#include <jni.h>
#include <stdlib.h>
#include <SuperpoweredFrequencyDomain.h>
#include <SuperpoweredFilter.h>
#include <AndroidIO/SuperpoweredAndroidAudioIO.h>
#include <SuperpoweredSimple.h>
#include <SuperpoweredCPU.h>
#include <SLES/OpenSLES.h>
#include <cmath>
#include <stdio.h>
#include <math.h>
#include <SLES/OpenSLES_AndroidConfiguration.h>

static SuperpoweredFrequencyDomain *frequencyDomain;
static float *magnitudeLeft, *magnitudeRight, *phaseLeft, *phaseRight, *inputBufferFloat;
static int stepSize;

static float rmsF;
static float rmsT;

static float binSizeinHz; //what range of HZ does one Bin occupy
static float cutFrequency=18000.0f; //fq above this treshold will be sued in detection
static float cutBin; //

static int bufferSize; //is consumed in Java

static float bufferSeconds; //how many sampleSets of size buffersize per second

static float *lastSamplesArray; //holds the samplessets of the last x milliseconds
static int *detectionArray; //If the signals in the last samples are above treshhold
static int detectionIndex; //this is the current index of the above arrays
static int detectionSize; //this is the size of the above arrays
static int saveLastMilliseconds = 500; // this is the "size" in ms of the above arrays

static float *rmsHolder; //holds the last RMS values
static int rmsSizeInS = 30; //How many Seconds should be holded for AVG RMS, used for tresholding in detection
static int rmsSize; //the size of the array rmsHolder
static int rmsIndex; //the index of the array rmsHolder
static bool rmsAvgAvailable = false; //is true when there is enough data available (3/4)
static int rmsType=0; //0=Sum, 1=STD DEV, 2=NTIMES, 3=Manual
static int rmsCustom = 20;


static float extremeCutOff = 10.0; //reading 10 times more than the avg are not read
static float extremeCutMinimum = 10.0; //reading under 10 are always read
static float extremeCutBase = 0.02; //AVG is atleast this size
#define FFT_LOG_SIZE 11 // 2^11 = 2048 - minimum viable size

static int advanceSampleArray()
{
    if(detectionIndex < detectionSize -1)
        return ++detectionIndex;
    else
        return detectionIndex=0;
}

static int advanceRMSArray()
{
    if(rmsIndex < rmsSize -1)
        return ++rmsIndex;
    else
        return rmsIndex=0;
}

static float GetAvgRMS(int rmstype)
{
    if(!rmsAvgAvailable)
        return -1.0f;

    if(rmstype == 0) {
        float sum = 0.0f;
        int i;
        for (i = 0; i < rmsSize; ++i) {
            sum += *(rmsHolder + i);
        }
        return sum / i > extremeCutBase ? sum / i  : extremeCutBase;
    }
    if(rmstype == 1)
    {
        float variance = 0.0f;
        float mean = GetAvgRMS(0);

        int i=0;
        for (i = 0; i < rmsSize; ++i) {
            variance += powf((*(rmsHolder + i) - mean),2.0);
        }
        return sqrtf(variance/(i)) > extremeCutBase ? sqrtf(variance/(i)) : extremeCutBase;
    }

    if(rmstype == 2) {
        return GetAvgRMS(0)*rmsCustom;
    }

    if(rmstype == 3) {
        return rmsCustom;
    }
}

static void saveSample(float *samples, int numberOfSamples)
{
    //Copy the data from the samples pointer (which is n entries big, and n*sizeof(float) bytes )
    //into the lastSamples Array after the last entry
    memcpy(lastSamplesArray+(detectionIndex*numberOfSamples), samples, numberOfSamples * sizeof(float));
}

static float* returnSample(int index, int numberOfSamples) //ALWAYS FREE the returned float* when used!
{
    //Returns the samples which have been added at position index
    float* container = (float*)malloc(numberOfSamples*sizeof(float));
    memcpy(container, lastSamplesArray+(index*numberOfSamples), numberOfSamples* sizeof(float));
    return container; //FREE IT
}

// This is called periodically by the media server.
static bool audioProcessing(void * __unused clientdata, short int *audioInputOutput, int numberOfSamples, int __unused samplerate) {
    SuperpoweredShortIntToFloat(audioInputOutput, inputBufferFloat, (unsigned int)numberOfSamples); // Converting the 16-bit integer samples to 32-bit floating point.


    //IMPORTANT: this portion of code is called more frequently per second than the frequency domain
    //this means, that bufferSeconds is the maximum possible amount of calls per second
    //in eality when we call this code 100 times, the code in the while/fq domain is called ~87 times (tested on huawei mate)
    //there is no way to get the actual number of calls (except for runtime calculations)


    frequencyDomain->addInput(inputBufferFloat, numberOfSamples); // Input goes to the frequency domain.

    // In the frequency domain we are working with 1024 magnitudes and phases for every channel (left, right), if the fft size is 2048.
    while (frequencyDomain->timeDomainToFrequencyDomain(magnitudeLeft, magnitudeRight, phaseLeft, phaseRight)) {

        float rmsFi = 0.0f; // 1/n * SUMn[Xn]
        for (int i = (int) cutBin; i < powf(2.0,(float)FFT_LOG_SIZE-1); i++) { //half the size
            if(*(magnitudeLeft+i) >= 0.0f) //if bin above 0
                rmsFi += (*(magnitudeLeft+i) * *(magnitudeLeft+i)); //square them and sum them over
        }
        rmsFi *= 1.0f/ (powf(2.0,(float)FFT_LOG_SIZE-1) - cutBin); //multiply with the number of the elements
        rmsFi = sqrtf(rmsFi); //get the root

        //if(rmsFi > extremeCutMinimum && rmsFi > GetAvgRMS(rmsType) * extremeCutOff )
          //  continue;

        rmsF = rmsFi;
        *(rmsHolder+rmsIndex) = rmsF; //save rms, first in, last out circle
        advanceRMSArray();

        //as soon as there is avg svailable, check if above treshold
        if(rmsAvgAvailable)
        {
            if(rmsF>= GetAvgRMS(rmsType))
                *(detectionArray+detectionIndex) = 1;
            else
                *(detectionArray+detectionIndex) = 0;
        }
        //save samples into sample holder, first in last out circle
        saveSample(inputBufferFloat, numberOfSamples);
        advanceSampleArray();

        frequencyDomain->advance();
    };

    //sets avg availabilty as soon as there are enough entries for the first time
    //subsequent if checks are not intensive because they fail already at !rmsAvgAvailable condition
    if(!rmsAvgAvailable && rmsIndex> ceil(rmsSize*0.8))
        rmsAvgAvailable = true;

    return true;
}


static void createNewRmsBuffer()
{
    float* container = (float*)malloc(rmsSize * sizeof(rmsHolder));
    int oldsize = rmsSize;
    memcpy(container, rmsHolder, rmsSize * sizeof(float));

    rmsSize = (int)bufferSeconds * rmsSizeInS;
    rmsIndex = rmsIndex>=rmsSize?0:rmsIndex;
    rmsHolder = (float*)malloc(rmsSize * sizeof(rmsHolder));

    memcpy(rmsHolder, container, rmsSize>oldsize?oldsize * sizeof(float):rmsSize * sizeof(float));

    free(container);
}

static void createNewDetectionBuffers()
{
    int bufferSizeInMs = (int) ceil((1000.0f / bufferSeconds));
    float *lastSamplesArrayContainer = (float*)malloc(detectionSize * bufferSize * sizeof(lastSamplesArray));;
    int *detectionArrayContainer = (int*)malloc(detectionSize * sizeof(detectionArray));
    int oldsize = detectionSize;

    memcpy(lastSamplesArrayContainer, lastSamplesArray, detectionSize * bufferSize * sizeof(lastSamplesArray));
    memcpy(detectionArrayContainer, detectionArray, detectionSize * sizeof(detectionArray));

    detectionSize = (int) ceil(saveLastMilliseconds/bufferSizeInMs) + 1;
    detectionIndex = detectionIndex>=detectionSize?0:detectionIndex;

    lastSamplesArray = (float*)malloc(detectionSize * bufferSize * sizeof(lastSamplesArray));
    detectionArray = (int*)malloc(detectionSize * sizeof(detectionArray));

    memcpy(lastSamplesArray, lastSamplesArrayContainer, detectionSize>oldsize? oldsize * bufferSize * sizeof(lastSamplesArray) : detectionSize * bufferSize * sizeof(lastSamplesArray));
    memcpy(detectionArray, detectionArrayContainer, detectionSize>oldsize? oldsize * sizeof(detectionArray) : detectionSize * sizeof(detectionArray));

    free(lastSamplesArrayContainer);
    free(detectionArrayContainer);
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_MainActivity_FrequencyDomain(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint samplerate, jint buffersize) {
    frequencyDomain = new SuperpoweredFrequencyDomain(FFT_LOG_SIZE); // This will do the main "magic".
    stepSize = frequencyDomain->fftSize / 4; // The default overlap ratio is 4:1, so we will receive this amount of samples from the frequency domain in one step.

    // Frequency domain data goes into these buffers:
    magnitudeLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    magnitudeRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));


    bufferSeconds = (int) ceil(samplerate / buffersize); //how many sampleSets of size buffersize per Second
    int bufferSizeInMs = (int) ceil((1000.0f / bufferSeconds)); //the size of one sampleSet in MS
    detectionSize = (int) ceil(saveLastMilliseconds/bufferSizeInMs) + 1; //how big are the arrays, depnding on wanted LastMilliSeconds and Size of one sampleset in MS
    detectionIndex = 0;

    lastSamplesArray = (float*)malloc(detectionSize * buffersize * sizeof(lastSamplesArray)); //fits upto x ms of samples
    detectionArray = (int*)malloc(detectionSize * sizeof(detectionArray)); //fits x detections

    rmsSize = (int)bufferSeconds * rmsSizeInS;
    rmsHolder = (float*)malloc(rmsSize * sizeof(rmsHolder));
    rmsIndex = 0;
    
    inputBufferFloat = (float *)malloc(buffersize * sizeof(float) * 2 + 128);

    SuperpoweredCPU::setSustainedPerformanceMode(true);
    binSizeinHz = samplerate/ powf(2.0,(float)FFT_LOG_SIZE);
    cutBin = cutFrequency / binSizeinHz;
    bufferSize = buffersize;

    new SuperpoweredAndroidAudioIO(samplerate, buffersize, true, false, audioProcessing, NULL, -1, SL_ANDROID_STREAM_MEDIA, buffersize * 2); // Start audio input/output.
}

extern "C" JNIEXPORT float Java_com_superpowered_frequencydomain_MainActivity_GetRmsfReading(JNIEnv * __unused javaEnvironment, jobject __unused obj){
    return rmsF;
}

extern "C" JNIEXPORT float Java_com_superpowered_frequencydomain_MainActivity_GetRmstReading(JNIEnv * __unused javaEnvironment, jobject __unused obj){
    return  rmsT;
}

extern "C" JNIEXPORT float Java_com_superpowered_frequencydomain_MainActivity_GetAvgRMSReading(JNIEnv * __unused javaEnvironment, jobject __unused obj){
    if(rmsAvgAvailable)
        return GetAvgRMS(rmsType);
    else
        return -1.0f;
}

extern "C" JNIEXPORT float Java_com_superpowered_frequencydomain_MainActivity_GetRmstBinary(JNIEnv * __unused javaEnvironment, jobject __unused obj){
    if(rmsT > ceil(detectionSize/2))
        return 1;
    else
        return 0;
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewCutFrequency(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint cutF){
    cutFrequency = cutF;
    cutBin = cutFrequency / binSizeinHz;
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewBufferSize(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint buffer){

}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewRmsCustomVar(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint ntimes){
    rmsCustom = ntimes;
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewExtremeMinimum(JNIEnv * __unused javaEnvironment, jobject __unused obj, jfloat min){
    extremeCutMinimum = min;
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewExtremeCut(JNIEnv * __unused javaEnvironment, jobject __unused obj, jfloat cut){
    extremeCutOff = cut;
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewExtremeBase(JNIEnv * __unused javaEnvironment, jobject __unused obj, jfloat base){
    extremeCutBase = base;
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewDetectionTime(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint lastms){
    saveLastMilliseconds = lastms;
    createNewDetectionBuffers();
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewRmsBuffer(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint lasts){
    rmsSizeInS = lasts;
    createNewRmsBuffer();
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_SettingsActivity_SetNewAverageRmsType(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint type){
    rmsType = type;
}

extern "C" JNIEXPORT jintArray Java_com_superpowered_frequencydomain_MainActivity_GetDetectionArray(JNIEnv *javaEnvironment, jobject __unused obj) {

    jintArray detection = javaEnvironment->NewIntArray(detectionSize);
    //jintArray fi  = javaEnvironment->NewIntArray(2);

    int dete[detectionSize];
    for (int i = 0; i < detectionSize; ++i) {
        dete[i] = *(detectionArray+i);
    }

    javaEnvironment->SetIntArrayRegion(detection, 0, detectionSize, dete);
    return detection;
}
