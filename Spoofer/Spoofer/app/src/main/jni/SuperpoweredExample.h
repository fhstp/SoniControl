#ifndef Header_SuperpoweredExample
#define Header_SuperpoweredExample

#include <math.h>
#include <pthread.h>

#include "SuperpoweredExample.h"
#include <SuperpoweredAdvancedAudioPlayer.h>
#include <SuperpoweredFilter.h>
#include <SuperpoweredRoll.h>
#include <SuperpoweredFlanger.h>
#include <AndroidIO/SuperpoweredAndroidAudioIO.h>
#include <SuperpoweredWhoosh.h>

#define HEADROOM_DECIBEL 3.0f
static const float headroom = powf(10.0f, -HEADROOM_DECIBEL * 0.025f);

class SuperpoweredExample {
public:

	SuperpoweredExample(unsigned int samplerate, unsigned int buffersize, const char *path, int fileAoffset, int fileAlength, int fileBoffset, int fileBlength);
	~SuperpoweredExample();

	bool process(short int *output, unsigned int numberOfSamples);
	void onPlayPause(bool play, bool buttonPressed);
	void onCutOffFader(int value);

    void onAmplitudeFader(int value);
    /*void onPulseFader(int value);
    void onPauseFader(int value);*/


	void fadeChange(bool value);

	void onFxSelect(int value);
	void onFxOff();
	void onFxValue();
    //void onEQBand(unsigned int index, int gain);

private:
    SuperpoweredAndroidAudioIO *audioSystem;
    SuperpoweredAdvancedAudioPlayer *playerA, *playerB;
    SuperpoweredRoll *roll;
    SuperpoweredFilter *filterHigh, *filterLow, *filterBand1, *filterBand2;
	SuperpoweredWhoosh *whiteNoise;
    SuperpoweredFlanger *flanger;
    float *stereoBuffer;
    unsigned char activeFx;
    float crossValue, volA, volB;
};

#endif
