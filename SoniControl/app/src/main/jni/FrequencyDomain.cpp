/*
 * Copyright (c) 2018. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
 *
 * This file is part of SoniControl app.
 *
 *     SoniControl app is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     SoniControl app is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with SoniControl app.  If not, see <http://www.gnu.org/licenses/>.
 */

#include <jni.h>
#include <stdlib.h>
#include <SuperpoweredFrequencyDomain.h>
#include <AndroidIO/SuperpoweredAndroidAudioIO.h>
#include <SuperpoweredSimple.h>
#include <SuperpoweredCPU.h>
#include <SLES/OpenSLES.h>
#include <cmath>
#include <algorithm>
#include <functional>
#include <deque>
#include <SLES/OpenSLES_AndroidConfiguration.h>
#include <android/log.h>
#include <sstream>
#include <cstring>

#include <iostream>
#include <vector>
#include <numeric>

#include <chrono>
#define  LOG_TAG    "FrequencyDomain"

#define  LOGD(...)  __android_log_print(ANDROID_LOG_DEBUG, LOG_TAG, __VA_ARGS__)

//SUPERPOWERED FFT VARIABLES
static SuperpoweredAndroidAudioIO *audioIO = NULL;
static SuperpoweredFrequencyDomain *frequencyDomain;
static float *magnitudeLeft, *magnitudeRight, *phaseLeft, *phaseRight, *inputBufferFloat;

//ANDROID OUTPUTS
static float androidOut1;
static float androidOut2;
static int maxValueIndex; // Maximum amplitude in the bufferHistory (needed to create a wav)

//HIGHPASS FILTERING
static float binSizeinHz; //{IS SET} what range of HZ does one Bin occupy
static int cutoffFrequencyIdx; //{IS SET} including this bin to the last, these will be considered for the highpass filtering
static float highPassSum = 0.0f; //{IS SET} used in the mainloop calculation

//BUFFER SIZES
static int bufferSizeSmpl; //{IS SET} is set while instantiating, used for reallocation of different buffers
static float bufferPerSeconds; //Not used anymore. {IS SET} how many sampleSets of size bufferSizeSmpl per second - this is the theoretical equivalent of {specs.detector.bufferSizeSmpl}
static int sampleRate;

//RAW SAMPLES ARRAY
static float *bufferHistory; //{IS SET} holds the samples from the inputBufferFloat of the last [medianBufferSizeInSec] milliseconds
static int bufferHistoryIndex; //{IS SET} this is the current index of the float* bufferHistory - Cyclic index

//SONICONTROL DETECTION CONTAINERS TYPES
typedef std::vector<float> fvec;
typedef std::deque<int> ideque;
typedef std::deque<float> fdeque;
typedef std::vector<fdeque> fmat; //fmat consists of deques instead of vectors to profit from pop/push pipeline

//SONICONTROL DETECTION CONTAINERS DEFINITIONS
static fvec normalizedSpectrogram; //one pass of data, contains normalized bins
static fmat backgroundModelBuffer; //contains x times normalizedSpectrogram
static fvec currentBackgroundModel; //is the vertical mean of the backgroundModelBuffer - will be used for comparison
static ideque medianBuffer; //the medianBuffer, contains the detections of the last {medianBufferSizeInSec}milliseconds

//SONICONTROL DETECTION CONTAINERS SIZES
static int normalizedSpectrogramSize; // {IS SET} the length of the fvec normalizedSpectrogram and the fvec currentBackgroundModel, depending on cutoffFrequency, saves normalized values of bins
static int backgroundModelBufferSizeItems; // {IS SET} the length of the fmat backgroundModelBuffer, depending on backgroundModelBufferSizeInSec, saves and specific amount of last normalized Spectra
static int medianBufferSizeItems; // {IS SET} the length of the ideque medianBuffer in regard to medianBufferSizeInSec

//SONICONTROL DETECTION PARAMETERS
static float bufferSizeInMs; //the size of one sampleSet in MS. About 46.44ms for a 2048 samples buffer.
static int backgroundModelBufferSizeInSec = 10; //is int equivalent to {specs.detector.backgroundBufferSize}
static float medianBufferSizeInSec = 2.5f; // in seconds, this is the "size" in ms of the float* bufferHistory and the ideque medianBuffer
static float cutoffFrequency=16800.0f; //fq above this treshold will be used in detection
static float decisionThreshold=0.5f; // defines how many values in the ideque medianBuffer have to be 1 so that that a detection is registered
static float decisionThresholdNearby = 3.5; //the decision threshold for nearby signals. If the RMS Energy in the Nearby band is N-times higher than in the neighboring bands above and beneath, then declare a nearby detection.
static float decisionThresholdNearbyAC = 0.05; //the recognition threshold for nearby based on autocorrelation
static int percentSilenceAfterDetection = 10;

// Detector control variables
static bool detection = false; //becomes one, if the current frame is above the decision threshold
static int detectionAfterMedian = 0; //becomes one only if more than the half of the past frames were above the decision threshold
static float backgroundDist = 0; //holds the distance (Kullback Leibler Divergence) between the current frame and the background model
static float scoreNearby = 0; //holds the detection score for nearby messages
static float recogResult = 0; //holds the recognition result
static float scoreNearbyAC = 0; //holds the autocorrelation score for nearby recognition

//SONICONTROL VARIOUS
static bool backgroundModelUpdating = true; //{IS SET} indicates if the background Model should continue to update itself
#define FFT_LOG_SIZE 11 // 2^11 = 2048 - minimum viable size, should stay here
static int counter = 0; //increments in every loop (without exception), helps to find out when backgroundBuffer is full and detection can be started

// Needed to call Java functions
static JavaVM* jvm = 0;
static jobject jniScan = 0; // GlobalRef

static int pauseIO();
static void stopIO();

static int advanceSampleArray()
{
    if(bufferHistoryIndex < medianBufferSizeItems -1)
        return ++bufferHistoryIndex;
    else
        return bufferHistoryIndex=0;
}

// Source: https://stackoverflow.com/a/19695285/5232306
// Get the median of an unordered set of numbers of arbitrary
// type without modifying the underlying dataset.
// Note : When the number of elements is even, we don't get the median, but close enough for us
template <typename It>
static float Median(It begin, It end)
{
    using T = typename std::iterator_traits<It>::value_type;
    std::vector<T> data(begin, end);
    int size = data.size();
    std::nth_element(data.begin(), data.begin() + size / 2, data.end());
    return data[size / 2];
}

static void saveSampleToBufferHistory(float *samples, int numberOfSamples)
{
    //Copy the data from the samples pointer (which is n entries big, and n*sizeof(float) bytes )
    //into the lastSamples Array after the last entry
    memcpy(bufferHistory+(bufferHistoryIndex*numberOfSamples), samples, numberOfSamples * sizeof(float));

    advanceSampleArray();
}

//ALWAYS FREE the returned float* when used!
static float* returnSampleFromBufferHistory(int index, int numberOfSamples) //ALWAYS FREE the returned float* when used!
{
    //Returns the samples which have been added at position index
    float* container = (float*)malloc(numberOfSamples*sizeof(float));
    memcpy(container, bufferHistory+(index*numberOfSamples), numberOfSamples* sizeof(float));
    return container; //FREE IT
}

static void addNormalizedSpectrogramToBackgroundModel()
{
    for(int i=0; i<normalizedSpectrogramSize; ++i)
    {
        //if the backgroundmodel is full, we are dropping the oldest elements
        while(backgroundModelBuffer.at(i).size() >= backgroundModelBufferSizeItems) {
            backgroundModelBuffer.at(i).pop_front();
        }
        //we are adding in such form that all Xit in Vector Xt (where t is a moment in time and i is an element/bin)
        //are in row i at position/column t - essentially transposing the vector
        backgroundModelBuffer.at(i).push_back(normalizedSpectrogram.at(i));
    }
}

static void createCurrentBackgroundModel()
{
    //TODO: We could change this to a normal loop as it is not "hot" anymore... (we call this much later than before)
    //before this method, the addNormalizedSpectrogramToBackgroundModel finishes with the
    //backgroundModelBuffer last indices still hot -> so we go in reverse for loop
    for(int i=normalizedSpectrogramSize-1 ; i>=0; --i) {
        currentBackgroundModel.at(i) = Median(backgroundModelBuffer.at(i).begin(), backgroundModelBuffer.at(i).end());
    }
}

static float getKullbackLeiblerDivergence() {
    //Approximation of the Kullback Leibler Divergence
    float p;
    float q;
    float sum = 0.0f;

    //Compute sum of background model for later normalization of background model to make it a distribution
    float sumBackground = 0.0f;
    for(int i=0; i<normalizedSpectrogramSize; ++i) {
        sumBackground += currentBackgroundModel.at(i);
    }

    for(int i=0; i<normalizedSpectrogramSize; ++i)
    {
        p = currentBackgroundModel.at(i) / sumBackground; //normalize the value on the fly
        q = normalizedSpectrogram.at(i);
        if(q != 0.0f && p != 0.0f) { //if p or q is zero, the whole component should not contribute to the sum (log of 0 is -infinity)
            sum += p * logf(p / q); //other log functions seem not to work?
        }
    }
    return sum;
}

static void deleteLastBuffersFromBackground(int deleteLastMilliseconds)
{
    //calculates how many indices/elements have to be deleted
    int indices = ceilf((float) deleteLastMilliseconds / bufferSizeInMs);

    for(int i=0; i<normalizedSpectrogramSize; ++i)
    {
        for(int n=0; n<indices; ++n) {
            backgroundModelBuffer.at(i).pop_back();
        }
    }
}

static void addDetectionToMedianBuffer(bool detected)
{
    int erg = detected?1:0;

    while(medianBuffer.size() >= medianBufferSizeItems)
        medianBuffer.pop_front();
    medianBuffer.push_back(erg);
}

/**
 * Returns true if a signal is detected. A signal is detected if at least half of the medianBuffer
 * values are detections, AND if some (percentage of) silence is following the detection (we want to
 * capture the whole message to display it later).
 * @return If a signal was detected
 */
static bool isSignalDetected()
{
    /*int sum = std::accumulate(medianBuffer.begin(), medianBuffer.end(), 0);
    return sum > (int) ceil(medianBufferSizeItems / 2);*/
    bool messageIsOver = false;
    int sum = std::accumulate(medianBuffer.begin(), medianBuffer.end(), 0);
    if (sum > (int) ceil(medianBufferSizeItems / 2)) {
        int postMessageSum = 0;
        int postMessageNbItems = (int) medianBufferSizeItems * percentSilenceAfterDetection / 100.0;
        if (postMessageNbItems > 0 && postMessageNbItems != medianBufferSizeItems) {
            for (int i = medianBuffer.size() - 1; i > medianBuffer.size() - postMessageNbItems; i--) {
                postMessageSum += medianBuffer[i];
            }
            if (postMessageSum < (int) ceil(
                    postMessageNbItems / 4)) { // At least 75% of the post message time is non detection
                messageIsOver = true;
            }
        }
        else { // Either percentSilenceAfterDetection is zero, or it is 100%
            messageIsOver = true;
        }
    }
    return messageIsOver;
}

/***
 * Reset median buffer with zeros
 */
static void resetMedianBuffer() {
    std::fill(medianBuffer.begin(), medianBuffer.end(), 0);
}


static jfloatArray *getJavaReorderedBufferHistoryMono(JNIEnv *jniEnv, int numberOfSamples) {
    int numberOfBufferHistoryItems = medianBufferSizeItems * bufferSizeSmpl;
    int bufferHistorySize = numberOfBufferHistoryItems * sizeof(bufferHistory);
    float *container = (float*)malloc(bufferHistorySize);
    if(bufferHistoryIndex==0){
        memcpy(container, bufferHistory, bufferHistorySize);
    }else{
        memcpy(container, bufferHistory+bufferHistoryIndex*numberOfSamples, bufferHistorySize-bufferHistoryIndex*numberOfSamples*sizeof(bufferHistory));
        memcpy(container+numberOfBufferHistoryItems-bufferHistoryIndex*numberOfSamples, bufferHistory, bufferHistoryIndex*numberOfSamples*sizeof(bufferHistory));
    }

    float *containerMono = (float*)malloc(bufferHistorySize/2);
    maxValueIndex = 0;
    for (int i = 0, counter = 0; i < numberOfBufferHistoryItems; i += 2, counter++) {
        *(containerMono + counter) =(*(container + i) + *(container + i + 1)) / 2;
        if(*(containerMono + maxValueIndex) < *(containerMono + counter)) {
            maxValueIndex=counter;
        }

        //TODO: Calculate amplitude of the signal ? (avg)
    }
    free(container);
    
    jfloatArray bufferHistoryArray = jniEnv->NewFloatArray(numberOfBufferHistoryItems/2);
    jniEnv->SetFloatArrayRegion(bufferHistoryArray, 0, numberOfBufferHistoryItems/2, containerMono);

    free(containerMono);

    return &bufferHistoryArray;
}

// This is called periodically by the media server.
static bool audioProcessing(void * __unused clientdata, short int *audioInputOutput, int numberOfSamples, int __unused samplerate) {
    SuperpoweredShortIntToFloat(audioInputOutput, inputBufferFloat, (unsigned int)numberOfSamples); // Converting the 16-bit integer samples to 32-bit floating point.
    counter++; // Increment in every iteration (will start at 1)

    //IMPORTANT: this portion of code is called more frequently per second than the frequency domain
    //this means, that bufferPerSeconds is the maximum possible amount of calls per second
    //in reality when we call this code 100 times, the code in the while/fq domain is called ~87 times (tested on huawei mate)
    //there is no way to get the actual number of calls (except for runtime calculations)

    frequencyDomain->addInput(inputBufferFloat, numberOfSamples); // Input goes to the frequency domain.

    // In the frequency domain we are working with 1024 magnitudes and phases for every channel (left, right), if the fft size is 2048.
    while (frequencyDomain->timeDomainToFrequencyDomain(magnitudeLeft, magnitudeRight, phaseLeft, phaseRight)) {
        //init
        std::fill(normalizedSpectrogram.begin(), normalizedSpectrogram.end(), 0.0f);
        detectionAfterMedian = 0;
        detection = 0;

        highPassSum = 0.0f;
        //Calculate the Sum of high-pass coefficients
        for (int i = cutoffFrequencyIdx; i < powf(2.0,(float)FFT_LOG_SIZE-1); ++i) { // loop through half the values (as the result is symmetrical)
            if(*(magnitudeLeft+i) > 0.0f) { //if bin above 0
                highPassSum += *(magnitudeLeft + i); //sum
            }
        }

        //Normalize Spectrum
        //Optimize, by removing k and calculating substraction of i minus bin difference
        for (int i = cutoffFrequencyIdx, k = -1; i < powf(2.0,(float)FFT_LOG_SIZE-1); ++i) { // loop through half the values (as the result is symmetrical)
            if(*(magnitudeLeft+i) > 0.0f) {//if bin above 0
                normalizedSpectrogram.at(++k) = *(magnitudeLeft + i) / highPassSum; // normalize
            }
        }

        //if the background model is full, start with detection, i.e. start with filling the median buffer
        if(counter > backgroundModelBufferSizeItems) {
            //Save the raw input buffer samples to our history
            saveSampleToBufferHistory(inputBufferFloat, numberOfSamples);

            createCurrentBackgroundModel(); // this computes the median of the background model buffer
            backgroundDist = getKullbackLeiblerDivergence();
            androidOut1 = backgroundDist;

            /*
            TODO: Integrate Nearby as follow
      %detect nearby signals (by RMS detector). IMPORTANT: this detector needsthe entire spectrogram (normalized) as input!
      scoreNearby = detectNearbyFast(bufferFFT/(sum(bufferFFT)+eps), specs.nearby, fs, specs.detector.bufferSizeSmpl, frequencies);
             */
            // Detection condition:
            // is the current buffer different from the background model (backgroundDist>threshold)
            // OR: the nearby detector is above its threshold.
            detection = backgroundDist > decisionThreshold; // TODO: Add condition for Nearby // || scoreNearby > specs.detector.decisionThresholdNearby
            addDetectionToMedianBuffer(detection);

            // if backgroundBuffer and medianBuffer are full, start with the actual detection:
            if(counter > backgroundModelBufferSizeItems + medianBufferSizeItems) {
                 //Are there more detections than non-detection in the buffer, then declare a detection (--> median over the past medianBufferSizeItems buffer-based detections)
                 //See function documentation, now also require the detection to be over.
                if(isSignalDetected()) {
                    detectionAfterMedian = 1;
                }
                else {
                    detectionAfterMedian=0;
                    recogResult = 0;
                    scoreNearbyAC=0;
                }
                androidOut2 = detectionAfterMedian;
                /*if (counter % 10 == 0) {
                    LOGD("detectionAfterMedian: %d", detectionAfterMedian);
                }*/
            }
        }


        // ----------
        // Could be moved under the recognition because cleaning the buffers can be done while we start spoofing.

        /* If currently a detection (after temporal median filter) is active, do not further update the background model
          This avoids that the model learns wrong information and keeps the background threshold robust and stable
          When a detection (after median) is issued then, however, the background model already contains some information (frames) from the detected sound
          The reason is that the temporal median delays the detection a bit.
          To correct this error, we remove the last medianBufferSizeItems samples
          and replace them with the samples that came before (they are at position: currentPos-2*medianBufferSizeItems:currentPos-medianBufferSizeItems)
        */
        if (backgroundModelUpdating && detectionAfterMedian == 1) { //There are 2 conditions, because otherwise we delete every time we pass here.
            // Should replace the last medianBufferSizeItems values with the medianBufferSizeItems that were captured before!
            // Currently delete the last
            backgroundModelUpdating = false;
            deleteLastBuffersFromBackground(medianBufferSizeInSec * 1000);
            resetMedianBuffer(); // Otherwise we keep detecting the signal for medianBufferSizeItems / 2 times
        }
        else if (!backgroundModelUpdating && detectionAfterMedian != 1) {
            backgroundModelUpdating = true;
        }
        //if no detection: standard update (kick the oldest value out of the buffer and replace by most current one
        if (backgroundModelUpdating) {
            //append current normalized spectral distribution to background model
            addNormalizedSpectrogramToBackgroundModel();
            //TODO: acBuffer(:,cyclicBackgroundBufferIndex+1) = bufferAC;
        }

        // ----------

        /*TODO: DO THE RECOGNITION HERE
         * if detection lasts for at least the duration of the median buffer, start with the analysis
         */
        if(detectionAfterMedian == 1) {
            /* Note: in the final implementation, the loop must be stopped here,
             * The following should be done:
             * 1. take the buffers stored in bufferHistory (concatenate all together IN THE RIGHT ORDER)
             * This buffer has length medianBufferSize (e.g. 1s)
             * */



            /* 2. make an FFT over the entire buffer.
             * 3. Perform recognition of the individual technologies
             * ??? Is there a 4. ???
             */

             // Following is handled in Java
            /*
             * 5. Show an alert to the user
             * 6. Store the type of sound for future spoofing and start the spoofer if requested (for some time, e.g. 5s)
             * 7. When spoofing is done, continue with this loop. Note: while spoofing is done, the background
             * model is not updated (otherwise we would model our own spoofing signals!)
             * Important: the detector must retain its state, i.e. the background model must be stored during the spoofer is active.
             * */

            // Source: https://stackoverflow.com/a/12901159
            JNIEnv * jniEnv;
            // double check if it's all ok
            int getEnvStat = jvm->GetEnv((void **)&jniEnv, JNI_VERSION_1_6);
            if (getEnvStat == JNI_EDETACHED) {
                //LOGD("GetEnv: not attached");
                if (jvm->AttachCurrentThread(&jniEnv, NULL) != 0) {
                    LOGD("Failed to attach");
                }
                //LOGD("Attached thread from audio callback");
            } else if (getEnvStat == JNI_OK) {
                //LOGD("Audio callback thread already attached ");
            } else if (getEnvStat == JNI_EVERSION) {
                LOGD("GetEnv: version not supported");
            }

            // Construct a String
            jstring technologyString = jniEnv->NewStringUTF("Unknown");


            // This also updates the global maxValueIndex
            jfloatArray bufferHistoryArray = *(getJavaReorderedBufferHistoryMono(jniEnv,
                                                                                 numberOfSamples));
            // First get the class that contains the method you need to call
            jclass scanClass = jniEnv->GetObjectClass(jniScan);
            // Get the method that you want to call
            jmethodID detectedSignalMethod = jniEnv->GetMethodID(scanClass, "detectedSignal", "(Ljava/lang/String;[FI)V");
            // Call the method on the object
            jniEnv->CallVoidMethod(jniScan, detectedSignalMethod, technologyString, bufferHistoryArray, maxValueIndex);
            //TODO: Are we suppose to delete references on our side or is detaching enough ?
            //jniEnv->DeleteLocalRef(bufferHistoryArray);
            //jniEnv->DeleteLocalRef(technologyString);

            if (jniEnv->ExceptionCheck()) {
                jniEnv->ExceptionDescribe();
            }

            jvm->DetachCurrentThread();

            pauseIO();
        }
        frequencyDomain->advance(numberOfSamples);
    };

    return true;
}


static void initFrequencyDomain(jint sampleRateJava, jint bufferSizeSmplJava) {
    counter = 0; //increments in every loop (without exception), helps to find out when backgroundBuffer is full and detection can be started

    frequencyDomain = new SuperpoweredFrequencyDomain(FFT_LOG_SIZE); // This will do the main "magic".

    bufferSizeSmpl = bufferSizeSmplJava;
    sampleRate = sampleRateJava;

    // Frequency domain data goes into these buffers:
    magnitudeLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    magnitudeRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));

    inputBufferFloat = (float *)malloc(bufferSizeSmplJava * sizeof(float) * 2 + 128); // TODO: why  +128 ???

    bufferPerSeconds = (float) sampleRateJava / (float) bufferSizeSmplJava; //how many sampleSets of size bufferSizeSmplJava per Second
    bufferSizeInMs = 1000.0f / ((float) sampleRateJava / bufferSizeSmplJava); //the size of one sampleSet in MS
    binSizeinHz = sampleRateJava/ powf(2.0,(float)FFT_LOG_SIZE);
    cutoffFrequencyIdx = roundf(cutoffFrequency / binSizeinHz); // No +1 compared to Octave

    medianBufferSizeItems = (int) round(medianBufferSizeInSec*1000/bufferSizeInMs); // Match with Octave
    medianBuffer.resize(medianBufferSizeItems);

    bufferHistoryIndex = 0;
    bufferHistory = (float*)malloc(medianBufferSizeItems * bufferSizeSmplJava * sizeof(bufferHistory)); //fits upto x ms of samples - Match with Octave

    normalizedSpectrogramSize = (int)(powf(2.0,(float)FFT_LOG_SIZE-1) - cutoffFrequencyIdx); //Removed +1 to match Octave
    backgroundModelBufferSizeItems = (int) round(backgroundModelBufferSizeInSec*1000/bufferSizeInMs); // Match with Octave
    backgroundModelBuffer.resize(normalizedSpectrogramSize);
    normalizedSpectrogram.resize(normalizedSpectrogramSize);
    currentBackgroundModel.resize(normalizedSpectrogramSize);

    SuperpoweredCPU::setSustainedPerformanceMode(false);
}

int pauseIO() {
    // Check if the app got in an inconsistent state
    if (audioIO != NULL) {
        // onBackground only sets internals->foreground = false;
        // Which stops the queues only when you use the output, so I also stop manually
        audioIO->onBackground();
        audioIO->stop();
        return 0;
    }
    else {
        return -1;
    }
}

static void resumeIO() {
    if (audioIO != NULL) { // Safety check to avoid a crash, but should never be needed
        audioIO->onForeground(); // Starts the queues again
    }
}

void stopIO() {
    delete(audioIO);
}

static void startIO() {
    audioIO = new SuperpoweredAndroidAudioIO(sampleRate, bufferSizeSmpl, true, false, audioProcessing, NULL, -1, SL_ANDROID_STREAM_MEDIA); // Start audio input/output.
}

extern "C" JNIEXPORT void Java_at_ac_fhstp_sonicontrol_Scan_FrequencyDomain(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint sampleRateJava, jint bufferSizeSmplJava) {
    // Source: https://stackoverflow.com/a/26534926
    javaEnvironment->GetJavaVM(&jvm); // Keep a global reference to the jvm
    jniScan = javaEnvironment->NewGlobalRef(obj); // Keep a global reference to the Scan activity

    initFrequencyDomain(sampleRateJava, bufferSizeSmplJava);
    audioIO = new SuperpoweredAndroidAudioIO(sampleRateJava, bufferSizeSmplJava, true, false, audioProcessing, NULL, -1, SL_ANDROID_STREAM_MEDIA); // Start audio input/output.
}

// Update Median Buffer size and buffer history (detection time) after update from SettingsActivity
static void createNewDetectionsDequeAndSamplesBuffer()
{
    //this container has the size of the old bufferHistory
    float *lastSamplesArrayContainer = (float*)malloc(medianBufferSizeItems * bufferSizeSmpl * sizeof(bufferHistory));;
    int oldSize = medianBufferSizeItems;
    // Copy the old bufferHistory to the temporary container (because we need to re-initializethe bufferHistory
    memcpy(lastSamplesArrayContainer, bufferHistory, medianBufferSizeItems * bufferSizeSmpl * sizeof(bufferHistory));

    // Update medianBufferSizeItems
    medianBufferSizeItems = (int) round(medianBufferSizeInSec*1000/bufferSizeInMs); // Match with Octave
    // Update size of bufferHistory. bufferHistoryIndex is a cyclic index which provides the locations where the current buffer is inserted into the bufferHistory
    bufferHistoryIndex = bufferHistoryIndex>=medianBufferSizeItems?0:bufferHistoryIndex;
    // initialize the new buffer
    bufferHistory = (float*)malloc(medianBufferSizeItems * bufferSizeSmpl * sizeof(bufferHistory));

    // TODO: If the new size is smaller we should copy the most recent buffers from the historyBuffer (depends on where index points)
    // Currently it might miss some intermediate buffers due to the cyclic construction.

    //copy the old values back to bufferHistory
    memcpy(bufferHistory, lastSamplesArrayContainer, medianBufferSizeItems>oldSize? oldSize * bufferSizeSmpl * sizeof(bufferHistory) : medianBufferSizeItems * bufferSizeSmpl * sizeof(bufferHistory));
    //free the temporal container
    free(lastSamplesArrayContainer);
    // update the median buffer vector
    medianBuffer.resize(medianBufferSizeItems);
}

extern "C" JNIEXPORT jfloat JNICALL Java_at_ac_fhstp_sonicontrol_Scan_GetAndroidOut1(JNIEnv *__unused javaEnvironment, jobject __unused obj){
    return androidOut1;
}

extern "C" JNIEXPORT jint JNICALL Java_at_ac_fhstp_sonicontrol_Scan_GetAndroidOut2(JNIEnv * __unused javaEnvironment, jobject __unused obj){
    return  androidOut2;
}

extern "C" JNIEXPORT jboolean Java_at_ac_fhstp_sonicontrol_Scan_GetBackgroundModelUpdating(JNIEnv * __unused javaEnvironment, jobject __unused obj){
    return backgroundModelUpdating;
}

extern "C" JNIEXPORT jint JNICALL Java_at_ac_fhstp_sonicontrol_Scan_Pause(JNIEnv * __unused javaEnvironment, jobject __unused obj) {
    return pauseIO();
}

extern "C" JNIEXPORT void Java_at_ac_fhstp_sonicontrol_Scan_Resume(JNIEnv * __unused javaEnvironment, jobject __unused obj) {
    resumeIO();
}

extern "C" JNIEXPORT void Java_at_ac_fhstp_sonicontrol_Scan_StopIO(JNIEnv * __unused javaEnvironment, jobject __unused obj) {
    stopIO();
}