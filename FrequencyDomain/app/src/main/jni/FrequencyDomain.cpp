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
static SuperpoweredFilter *spfilter;
static float *magnitudeLeft, *magnitudeRight, *phaseLeft, *phaseRight, *fifoOutput, *fifoOutputHighPass, *inputBufferFloat;
static int fifoOutputFirstSample, fifoOutputLastSample, stepSize, fifoCapacity;

static float rmsF;
static float rmsT;
static float binSizeinHz;
static float cutFrequency=18000.0f;
static float cutBin;
static int bufferSize;

#define FFT_LOG_SIZE 11 // 2^11 = 2048

// This is called periodically by the media server.
static bool audioProcessing(void * __unused clientdata, short int *audioInputOutput, int numberOfSamples, int __unused samplerate) {
    SuperpoweredShortIntToFloat(audioInputOutput, inputBufferFloat, (unsigned int)numberOfSamples); // Converting the 16-bit integer samples to 32-bit floating point.


    int samplesInFifo = 0;
    frequencyDomain->addInput(inputBufferFloat, numberOfSamples); // Input goes to the frequency domain.

    // In the frequency domain we are working with 1024 magnitudes and phases for every channel (left, right), if the fft size is 2048.
    while (frequencyDomain->timeDomainToFrequencyDomain(magnitudeLeft, magnitudeRight, phaseLeft, phaseRight)) {



        // Check if we have enough room in the fifo buffer for the output. If not, move the existing audio data back to the buffer's beginning.
        if (fifoOutputLastSample + stepSize >= fifoCapacity) { // This will be true for every 100th iteration only, so we save precious memory bandwidth.
            samplesInFifo = fifoOutputLastSample - fifoOutputFirstSample;
            if (samplesInFifo > 0) memmove(fifoOutput, fifoOutput + fifoOutputFirstSample * 2, samplesInFifo * sizeof(float) * 2);
            fifoOutputFirstSample = 0;
            fifoOutputLastSample = samplesInFifo;
        };

        rmsF = 0.0f;
        for (int i = (int) cutBin; i < 1024; i++) {
            if(*(magnitudeLeft+i) >= 0.0f && *(magnitudeRight+i) >= 0.0f)
            rmsF += (*(magnitudeLeft+i) * *(magnitudeLeft+i)) + (*(magnitudeRight+i) * *(magnitudeRight+i));
        }
        rmsF *= 1.0f/ (1024.0f - cutBin);
        rmsF = sqrtf(rmsF);

        // Transforming back to the time domain.
        frequencyDomain->frequencyDomainToTimeDomain(magnitudeLeft, magnitudeRight, phaseLeft, phaseRight, fifoOutput + fifoOutputLastSample * 2);
        frequencyDomain->advance();
        fifoOutputLastSample += stepSize;
    };

    spfilter->setResonantParameters(cutFrequency, 0.2f);
    spfilter->process(fifoOutput, fifoOutput, fifoCapacity);
    spfilter->enable(true);

    rmsT = 0.0f;
    for (int i = 0; i < fifoCapacity; ++i) {
        //if(*(fifoOutput+i) >= 0.0f)
            rmsT += (*(fifoOutput+i) * *(fifoOutput+i));
    }
    rmsT *= 1.0f/ ((float)fifoCapacity);
    rmsT = sqrtf(sqrtf(sqrtf(rmsT)));



    // If we have enough samples in the fifo output buffer, pass them to the audio output.
    if (fifoOutputLastSample - fifoOutputFirstSample >= numberOfSamples) {
        SuperpoweredFloatToShortInt(fifoOutput + fifoOutputFirstSample * 2, audioInputOutput, (unsigned int)numberOfSamples);
        fifoOutputFirstSample += numberOfSamples;
        return true;
    } else return false;
}

extern "C" JNIEXPORT void Java_com_superpowered_frequencydomain_MainActivity_FrequencyDomain(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint samplerate, jint buffersize) {
    frequencyDomain = new SuperpoweredFrequencyDomain(FFT_LOG_SIZE); // This will do the main "magic".
    spfilter = new SuperpoweredFilter(SuperpoweredFilter_Resonant_Highpass, samplerate);
    stepSize = frequencyDomain->fftSize / 4; // The default overlap ratio is 4:1, so we will receive this amount of samples from the frequency domain in one step.

    // Frequency domain data goes into these buffers:
    magnitudeLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    magnitudeRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));

    // Time domain result goes into a FIFO (first-in, first-out) buffer
    fifoOutputFirstSample = fifoOutputLastSample = 0;
    fifoCapacity = stepSize * 10; // Let's make the fifo's size 100 times more than the step size, so we save memory bandwidth.
    fifoOutput = (float *)malloc(fifoCapacity * sizeof(float) * 2 + 128);

    inputBufferFloat = (float *)malloc(buffersize * sizeof(float) * 2 + 128);

    SuperpoweredCPU::setSustainedPerformanceMode(true);
    binSizeinHz = samplerate/ powf(2.0,11.0);
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

extern "C" JNIEXPORT float Java_com_superpowered_frequencydomain_MainActivity_SetNewCutFrequency(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint cutF){
    cutFrequency = cutF;
    cutBin = cutFrequency / binSizeinHz;
}