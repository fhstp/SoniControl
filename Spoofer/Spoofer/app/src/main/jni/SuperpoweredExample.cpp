#include "SuperpoweredExample.h"
#include <SuperpoweredSimple.h>
#include <SuperpoweredCPU.h>
#include <jni.h>
#include <stdio.h>
#include <android/log.h>
#include <SuperpoweredWhoosh.h>
#include <SuperpoweredSimple.h>
#include <SLES/OpenSLES.h>
#include <SLES/OpenSLES_AndroidConfiguration.h>
#include <sys/time.h>


#define FFT_LOG_SIZE 11 // 2^11 = 2048
#include <SuperpoweredFrequencyDomain.h>
#include <AndroidIO/SuperpoweredAndroidAudioIO.h>

static SuperpoweredFrequencyDomain *frequencyDomain;
static float *magnitudeLeft, *magnitudeRight, *phaseLeft, *phaseRight, *fifoOutput, *inputBufferFloat;
static int fifoOutputFirstSample, fifoOutputLastSample, stepSize, fifoCapacity;


static size_t magValue;
static float ampliValue, pauValue;
static double pulValue;


bool fadeValue;
unsigned int numberOfSamplesPlay;

unsigned sizeOfBuffer;




FILE *testFile;


static void playerEventCallbackA(void *clientData, SuperpoweredAdvancedAudioPlayerEvent event, void * __unused value) {
    if (event == SuperpoweredAdvancedAudioPlayerEvent_LoadSuccess) {
    	SuperpoweredAdvancedAudioPlayer *playerA = *((SuperpoweredAdvancedAudioPlayer **)clientData);
        playerA->setBpm(126.0f);
        playerA->setFirstBeatMs(353);
        playerA->setPosition(playerA->firstBeatMs, false, false);
    };
}

static void playerEventCallbackB(void *clientData, SuperpoweredAdvancedAudioPlayerEvent event, void * __unused value) {
    if (event == SuperpoweredAdvancedAudioPlayerEvent_LoadSuccess) {
    	SuperpoweredAdvancedAudioPlayer *playerB = *((SuperpoweredAdvancedAudioPlayer **)clientData);
        playerB->setBpm(123.0f);
        playerB->setFirstBeatMs(40);
        playerB->setPosition(playerB->firstBeatMs, false, false);
    };
}

static bool audioProcessing(void *clientdata, short int *audioIO, int numberOfSamples, int __unused samplerate) {
    return ((SuperpoweredExample *)clientdata)->process(audioIO, (unsigned int)numberOfSamples);
}

SuperpoweredExample::SuperpoweredExample(unsigned int samplerate, unsigned int buffersize, const char *path, int fileAoffset, int fileAlength, int fileBoffset, int fileBlength) : activeFx(0), crossValue(0.0f), volB(0.0f), volA(1.0f * headroom) {
    stereoBuffer = (float *)memalign(16, (buffersize + 16) * sizeof(float) * 2);



    playerA = new SuperpoweredAdvancedAudioPlayer(&playerA , playerEventCallbackA, samplerate, 0);
    playerA->open(path, fileAoffset, fileAlength);
    playerB = new SuperpoweredAdvancedAudioPlayer(&playerB, playerEventCallbackB, samplerate, 0);
    playerB->open(path, fileBoffset, fileBlength);

    playerA->syncMode = playerB->syncMode = SuperpoweredAdvancedAudioPlayerSyncMode_TempoAndBeat;

    /*volA = 0.0f;
    volB = 0.0f;*/

    //roll = new SuperpoweredRoll(samplerate);
    //filterLow = new SuperpoweredFilter(SuperpoweredFilter_Resonant_Lowpass, samplerate);
    //filter = new SuperpoweredFilter(SuperpoweredFilter_Resonant_Lowpass, samplerate);
    //filterHigh = new SuperpoweredFilter(SuperpoweredFilter_Resonant_Highpass, samplerate);
    //filterBand1 = new SuperpoweredFilter(SuperpoweredFilter_Bandlimited_Bandpass, samplerate);
    //filterBand2 = new SuperpoweredFilter(SuperpoweredFilter_Bandlimited_Bandpass, samplerate);

    //flanger = new SuperpoweredFlanger(samplerate);


    audioSystem = new SuperpoweredAndroidAudioIO(samplerate, buffersize, false, true, audioProcessing, this, -1, SL_ANDROID_STREAM_MEDIA, buffersize * 2);

    //filterHigh->setResonantParametersAndType(18000.0f, 0.2f, SuperpoweredFilter_Resonant_Highpass);

    whiteNoise = new SuperpoweredWhoosh(samplerate);
    whiteNoise->setFrequency(22000.0f);

}

SuperpoweredExample::~SuperpoweredExample() {
    delete audioSystem;
    delete playerA;
    delete playerB;
    //delete roll;
    //delete filterLow;
    //delete filterHigh;
    //delete filterBand1;
    //delete filterBand2;
    //delete flanger;
    delete whiteNoise;
    free(stereoBuffer);
}


void SuperpoweredExample::onPlayPause(bool play, bool buttonPressed) {
    if (!play) {
        if(testFile) {
            if(!buttonPressed) {
                if (testFile != NULL) {
                    fclose(testFile);
                    testFile = NULL;
                }
            }
        }
        //SuperpoweredChangeVolume(stereoBuffer,stereoBuffer,1.0f,0.0f,numberOfSamplesPlay);
        playerA->pause();
        playerB->pause();
    } else {
        //SuperpoweredChangeVolume(stereoBuffer,stereoBuffer,0.0f,1.0f,numberOfSamplesPlay);
        if(buttonPressed) {
            sizeOfBuffer = NULL;
            testFile = fopen("/storage/emulated/0/DCIM/superpowered.pcm", "w+");
        }
        bool masterIsA = (crossValue <= 0.5f);
        playerA->play(!masterIsA);
        playerB->play(masterIsA);
    };
    SuperpoweredCPU::setSustainedPerformanceMode(play); // <-- Important to prevent audio dropouts.
}

void SuperpoweredExample::onCutOffFader(int magniValue) {
    magValue = (size_t)magniValue*38;

/*    crossValue = float(value) * 0.01f;
    if (crossValue < 0.01f) {
        volA = 1.0f * headroom;
        volB = 0.0f;
    } else if (crossValue > 0.99f) {
        volA = 0.0f;
        volB = 1.0f * headroom;
    } else { // constant power curve
        volA = cosf(float(M_PI_2) * crossValue) * headroom;
        volB = cosf(float(M_PI_2) * (1.0f - crossValue)) * headroom;
    };*/
}

void SuperpoweredExample::onAmplitudeFader(int amplitudeValue) {
    ampliValue = (float)amplitudeValue/10;
}
/*
void SuperpoweredExample::onPulseFader(int pulseValue) {
    //pulValue = pulseValue/2.5;
}

void SuperpoweredExample::onPauseFader(int pauseValue){
    //pauValue = (float)pauseValue/10;
}*/

void SuperpoweredExample::onFxSelect(int value) {
	__android_log_print(ANDROID_LOG_VERBOSE, "SuperpoweredExample", "FXSEL %i", value);
	activeFx = (unsigned char)value;
    onFxValue();
}

void SuperpoweredExample::onFxOff() {
    //filter->enable(false);
    //roll->enable(false);
    //flanger->enable(false);
    //whitenoise->enable(false);
}

#define MINFREQ 0.0f
#define MAXFREQ 22000.0f

static inline float floatToFrequency(float value) {
    if (value > 0.97f) return MAXFREQ;
    if (value < 0.03f) return MINFREQ;
    value = powf(10.0f, (value + ((0.4f - fabsf(value - 0.4f)) * 0.3f)) * log10f(MAXFREQ - MINFREQ)) + MINFREQ;
    return value < MAXFREQ ? value : MAXFREQ;
}

void SuperpoweredExample::onFxValue() {
    //float value = float(ivalue) * 0.01f;
    switch (activeFx) {
        case 1:
            crossValue = 0.9f;
            volA = 0.0f;
            //volB = 0.0f;
            volB = 1.0f * headroom;
            whiteNoise->enable(true);


            //filter->setResonantParameters(floatToFrequency(1.0f - value), 0.2f);

            //filterLow->enable(false);
            //whiteNoise->enable(false);
            //filterBand1->enable(false);
            //filterBand2->enable(false);

            //filterHigh->setResonantParameters(22000.0f, 0.0f);
            //filterHigh-
            //filterHigh->enable(true);

            //flanger->enable(false);
            //roll->enable(false);
            break;
        default:
            crossValue = 0.1f;
            volA = 1.0f * headroom;
            //volA = 0.0f;
            volB = 0.0f;
            whiteNoise->enable(false);



            //if (value > 0.8f) roll->beats = 0.0625f;
            //else if (value > 0.6f) roll->beats = 0.125f;
            //else if (value > 0.4f) roll->beats = 0.25f;
            //else if (value > 0.2f) roll->beats = 0.5f;
            //else roll->beats = 1.0f;
            //roll->enable(true);

            //filterHigh->enable(false);
            //whiteNoise->enable(false);
            //filterBand1->enable(false);
            //filterBand2->enable(false);

            //filterLow->setResonantParametersAndType(200.0f, 0.0f, SuperpoweredFilter_Resonant_Lowpass);
            //filterLow->enable(true);

            //flanger->enable(false);

            break;
        //case 2:
            //flanger->setWet(value);
            //flanger->enable(true);

            //filterLow->enable(false);


            //filterHigh->enable(false);
            //filterLow->enable(false);
            //whiteNoise->enable(false);


            //filterBand1->setBandlimitedParameters(200.0f, 500.0f);
            //filterBand1->setBandlimitedParametersAndType(18000.0f, 4000.0f, SuperpoweredFilter_Bandlimited_Bandpass);
            //filterBand1->enable(true);

            //filterBand2->setBandlimitedParameters(10000.0f, 2000.0f);
            //filterBand2->enable(true);

            //filterHigh->setResonantParameters(18000.0f, 0.2f);
            //filterHigh->enable(true);




            //filterHigh->enable(false);

            //roll->enable(false);

    };
}

void SuperpoweredExample::fadeChange(bool valueTrue) {
    fadeValue = valueTrue;


}


bool SuperpoweredExample::process(short int *output, unsigned int numberOfSamples) {
    //numberOfSamplesPlay = numberOfSamples;
    bool masterIsA = (crossValue <= 0.5f);
    double masterBpm = masterIsA ? playerA->currentBpm : playerB->currentBpm;
    double msElapsedSinceLastBeatA = playerA->msElapsedSinceLastBeat; // When playerB needs it, playerA has already stepped this value, so save it now.

    bool silence = !playerA->process(stereoBuffer, false, numberOfSamples, volA, masterBpm, playerB->msElapsedSinceLastBeat);
    if (playerB->process(stereoBuffer, !silence, numberOfSamples, volB, masterBpm, msElapsedSinceLastBeatA)){
        silence = false;
        SuperpoweredVolume(stereoBuffer, stereoBuffer, 0.0f, ampliValue, numberOfSamples);
        //SuperpoweredVolumeAdd(stereoBuffer,stereoBuffer,0.0f,ampliValue,numberOfSamples);
    }

    //roll->bpm = flanger->bpm = (float)masterBpm; // Syncing fx is one line.

    //if (roll->process(silence ? NULL : stereoBuffer, stereoBuffer, numberOfSamples) && silence) silence = false;
    if (!silence && !masterIsA) {
        whiteNoise->process(stereoBuffer, stereoBuffer, numberOfSamples);
        SuperpoweredVolume(stereoBuffer, stereoBuffer, 0.0f, ampliValue, numberOfSamples);
        //SuperpoweredVolumeAdd(stereoBuffer,stereoBuffer,0.0f,ampliValue,numberOfSamples);
    }
    if (!silence) {

/*
        //SuperpoweredChangeVolumeAdd(stereoBuffer,stereoBuffer,1.0f,0.02f,numberOfSamples);
        filterHigh->process(stereoBuffer, stereoBuffer, numberOfSamples);
        filterLow->process(stereoBuffer, stereoBuffer, numberOfSamples);
        filterBand1->process(stereoBuffer,stereoBuffer,numberOfSamples);
        //filterBand2->process(stereoBuffer,stereoBuffer,numberOfSamples);


        //filterLow->process(stereoBuffer, stereoBuffer, numberOfSamples);
        //flanger->process(stereoBuffer, stereoBuffer, numberOfSamples);




*/

    frequencyDomain->addInput(stereoBuffer, numberOfSamples); // Input goes to the frequency domain.

    // In the frequency domain we are working with 1024 magnitudes and phases for every channel (left, right), if the fft size is 2048.
    while (frequencyDomain->timeDomainToFrequencyDomain(magnitudeLeft, magnitudeRight, phaseLeft, phaseRight)) {
        // You can work with frequency domain data from this point.

        // This is just a quick example: we remove the magnitude of the first 20 bins, meaning total bass cut between 0-430 Hz.
        //memset(magnitudeLeft, 0, 3350);
        //memset(magnitudeRight, 0, 3350);

        memset(magnitudeLeft, 0, magValue);
        memset(magnitudeRight, 0, magValue);

        // We are done working with frequency domain data. Let's go back to the time domain.

        // Check if we have enough room in the fifo buffer for the output. If not, move the existing audio data back to the buffer's beginning.
        if (fifoOutputLastSample + stepSize >= fifoCapacity) { // This will be true for every 100th iteration only, so we save precious memory bandwidth.
            int samplesInFifo = fifoOutputLastSample - fifoOutputFirstSample;
            if (samplesInFifo > 0) memmove(fifoOutput, fifoOutput + fifoOutputFirstSample * 2, samplesInFifo * sizeof(float) * 2);
            fifoOutputFirstSample = 0;
            fifoOutputLastSample = samplesInFifo;
        };

        // Transforming back to the time domain.
        frequencyDomain->frequencyDomainToTimeDomain(magnitudeLeft, magnitudeRight, phaseLeft, phaseRight, fifoOutput + fifoOutputLastSample * 2);
        frequencyDomain->advance();
        fifoOutputLastSample += stepSize;
    };

    // If we have enough samples in the fifo output buffer, pass them to the audio output.
    if (fifoOutputLastSample - fifoOutputFirstSample >= numberOfSamples) {
        stereoBuffer = (fifoOutput + fifoOutputFirstSample * 2);
        fifoOutputFirstSample += numberOfSamples;

    }

    };

    // The stereoBuffer is ready now, let's put the finished audio into the requested buffers.
    if (!silence){
        sizeOfBuffer = sizeOfBuffer + sizeof(stereoBuffer);
        if(testFile) {
            fwrite(stereoBuffer, 1, sizeOfBuffer, testFile);
        }
        SuperpoweredFloatToShortInt(stereoBuffer, output, numberOfSamples);
    }
    return !silence;
}

static SuperpoweredExample *example = NULL;

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_SuperpoweredExample(JNIEnv *javaEnvironment, jobject __unused obj, jint samplerate, jint buffersize, jstring apkPath, jint fileAoffset, jint fileAlength, jint fileBoffset, jint fileBlength) {
    const char *path = javaEnvironment->GetStringUTFChars(apkPath, JNI_FALSE);
    example = new SuperpoweredExample((unsigned int)samplerate, (unsigned int)buffersize, path, fileAoffset, fileAlength, fileBoffset, fileBlength);
    javaEnvironment->ReleaseStringUTFChars(apkPath, path);





    frequencyDomain = new SuperpoweredFrequencyDomain(FFT_LOG_SIZE); // This will do the main "magic".
    stepSize = frequencyDomain->fftSize / 4; // The default overlap ratio is 4:1, so we will receive this amount of samples from the frequency domain in one step.

    // Frequency domain data goes into these buffers:
    magnitudeLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    magnitudeRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseLeft = (float *)malloc(frequencyDomain->fftSize * sizeof(float));
    phaseRight = (float *)malloc(frequencyDomain->fftSize * sizeof(float));

    // Time domain result goes into a FIFO (first-in, first-out) buffer
    fifoOutputFirstSample = fifoOutputLastSample = 0;
    fifoCapacity = stepSize * 100; // Let's make the fifo's size 100 times more than the step size, so we save memory bandwidth.
    fifoOutput = (float *)malloc(fifoCapacity * sizeof(float) * 2 + 128);

    inputBufferFloat = (float *)malloc(buffersize * sizeof(float) * 2 + 128);

    SuperpoweredCPU::setSustainedPerformanceMode(true);
    //new SuperpoweredAndroidAudioIO(samplerate, buffersize, true, true, audioProcessing, NULL, -1, SL_ANDROID_STREAM_MEDIA, buffersize * 2); // Start audio input/output.
}

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onPlayPause(JNIEnv * __unused javaEnvironment, jobject __unused obj, jboolean play, jboolean buttonPressed) {
	example->onPlayPause(play, buttonPressed);
}

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onCutOffFader(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint value) {
	example->onCutOffFader(value);
}

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onFxSelect(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint value) {
	example->onFxSelect(value);
}

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onFxOff(JNIEnv * __unused javaEnvironment, jobject __unused obj) {
	example->onFxOff();
}

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onFxValue(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint value) {
    example->onFxValue();
}

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onAmplitudeFader(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint value) {
    example->onAmplitudeFader(value);
}/*
extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onPulseFader(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint value) {
    example->onPulseFader(value);
}
extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_onPauseFader(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint value) {
    example->onPauseFader(value);
}*/

extern "C" JNIEXPORT void Java_com_superpowered_spoofer_MainActivity_fadeChange(JNIEnv * __unused javaEnvironment, jobject __unused obj, jboolean value) {
    example->fadeChange(value);
}