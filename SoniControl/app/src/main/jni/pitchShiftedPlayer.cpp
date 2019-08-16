/*
 * Copyright (c) 2018, 2019. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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
#include <SuperpoweredAdvancedAudioPlayer.h>
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
#define  LOG_TAG    "PitchShiftedPlayer"

#define  LOGD(...)  __android_log_print(ANDROID_LOG_DEBUG, LOG_TAG, __VA_ARGS__)

//SUPERPOWERED VARIABLES
static SuperpoweredAndroidAudioIO *audioIO = NULL;
static SuperpoweredAdvancedAudioPlayer *player = NULL;
static float *floatBuffer;

// This is called periodically by the audio engine.
static bool audioProcessing (
        void * __unused clientdata, // custom pointer
        short int *audio,           // buffer of interleaved samples
        int numberOfFrames,         // number of frames to process
        int __unused samplerate     // sampling rate
) {
    player->setTempo(1.0, true); // Needed for the pitch shifting to work
    player->setPitchShift(-12); // Pitch shift one octave down
    if (player->process(floatBuffer, false, (unsigned int)numberOfFrames)) {
        SuperpoweredFloatToShortInt(floatBuffer, audio, (unsigned int)numberOfFrames);
        return true;
    } else {
        return false;
    }
}

// Called by the player.
static void playerEventCallback (
        void * __unused clientData,
        SuperpoweredAdvancedAudioPlayerEvent event,
        void *value
) {
    switch (event) {
        case SuperpoweredAdvancedAudioPlayerEvent_LoadSuccess:
            LOGD("AdvancedAudioPlayerEvent : Load success");
            break;
        case SuperpoweredAdvancedAudioPlayerEvent_LoadError:
            LOGD("AdvancedAudioPlayerEvent", "Open error: %s", (char *)value);
            break;
        case SuperpoweredAdvancedAudioPlayerEvent_EOF:
            LOGD("AdvancedAudioPlayerEvent : EOF");
            player->seek(0);    // loop track
            // Stop playing
            //player->pause();
            //audioIO->onBackground();
            //player->togglePlayback();
            //SuperpoweredCPU::setSustainedPerformanceMode(false);
            break;
        default:;
    };
}

extern "C"
JNIEXPORT void JNICALL
 Java_at_ac_fhstp_sonicontrol_PitchShiftPlayer_StartAudio(JNIEnv * __unused javaEnvironment, jobject __unused obj, jint sampleRateJava, jint bufferSizeJava) {

    //initaudioPlayer();
    // Allocate audio buffer.
    floatBuffer = (float *)malloc(sizeof(float) * 2 * bufferSizeJava);

    // Initialize player and pass callback function.
    player = new SuperpoweredAdvancedAudioPlayer (
            NULL,                           // clientData
            playerEventCallback,            // callback function
            (unsigned int)sampleRateJava,   // sampling rate
            0                               // cachedPointCount
    );

    // Initialize audio with audio callback function.
    audioIO = new SuperpoweredAndroidAudioIO (
            sampleRateJava,                 // sampling rate
            bufferSizeJava,                 // buffer size
            false,                          // enableInput
            true,                           // enableOutput
            audioProcessing,                // process callback function
            NULL,                           // clientData
            -1,                             // inputStreamType (-1 = default)
            SL_ANDROID_STREAM_MEDIA         // outputStreamType (-1 = default)
    );
}

// OpenFile - Open file in player, specifying offset and length.
extern "C" JNIEXPORT void JNICALL
Java_at_ac_fhstp_sonicontrol_PitchShiftPlayer_OpenFile (
        JNIEnv *env,
        jobject __unused obj,
        jstring path,       // path to APK file
        jint offset,        // offset of audio file
        jint length         // length of audio file
) {
    const char *str = env->GetStringUTFChars(path, 0);
    player->open(str, offset, length);
    env->ReleaseStringUTFChars(path, str);
}

// TogglePlayback - Toggle Play/Pause state of the player.
extern "C" JNIEXPORT void JNICALL
Java_at_ac_fhstp_sonicontrol_PitchShiftPlayer_TogglePlayback (
        JNIEnv * __unused env,
        jobject __unused obj
) {
    player->togglePlayback();
    SuperpoweredCPU::setSustainedPerformanceMode(player->playing);  // prevent dropouts
}

// onBackground - Put audio processing to sleep.
extern "C" JNIEXPORT void JNICALL
Java_at_ac_fhstp_sonicontrol_PitchShiftPlayer_onBackground (
        JNIEnv * __unused env,
        jobject __unused obj
) {
    if(audioIO != NULL)
        audioIO->onBackground();
}

// onForeground - Resume audio processing.
extern "C" JNIEXPORT void JNICALL
Java_at_ac_fhstp_sonicontrol_PitchShiftPlayer_onForeground (
        JNIEnv * __unused env,
        jobject __unused obj
) {
    if(audioIO != NULL)
        audioIO->onForeground();
}

// Cleanup - Free resources.
extern "C" JNIEXPORT void JNICALL
Java_at_ac_fhstp_sonicontrol_PitchShiftPlayer_Cleanup (
        JNIEnv * __unused env,
        jobject __unused obj
) {
    delete audioIO;
    audioIO = NULL;
    delete player;
    player = NULL;
    free(floatBuffer);
}