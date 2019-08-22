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

package at.ac.fhstp.sonicontrol;

public class PitchShiftPlayer {
    public interface PitchShiftPlayerListener {
        void onPlayCompleted();
    }
    private PitchShiftPlayerListener playerListener = null;
    private boolean playing = false;

    public PitchShiftPlayer() {
        // Not needed, done in Scan (load library "Superpowered")
        //System.loadLibrary("pitchShiftedPlayer");    // load native library
        /*
        // Get the device's sample rate and buffer size to enable
        // low-latency Android audio output, if available.
        String samplerateString = null, buffersizeString = null;
        if (Build.VERSION.SDK_INT >= 17) {
            AudioManager audioManager = (AudioManager) this.getSystemService(Context.AUDIO_SERVICE);
            if (audioManager != null) {
                samplerateString = audioManager.getProperty(AudioManager.PROPERTY_OUTPUT_SAMPLE_RATE);
                buffersizeString = audioManager.getProperty(AudioManager.PROPERTY_OUTPUT_FRAMES_PER_BUFFER);
            }
        }
        if (samplerateString == null) samplerateString = "48000";
        if (buffersizeString == null) buffersizeString = "480";
        int samplerate = Integer.parseInt(samplerateString);
        int buffersize = Integer.parseInt(buffersizeString);
        */
        // If the application crashes, please disable Instant Run under Build, Execution, Deployment in preferences.
    }
    // Handle Play/Pause button toggle.
    /*
    public void PlayerExample_PlayPause (View button) {
        TogglePlayback();
        playing = !playing;
        Button b = findViewById(R.id.playPause);
        b.setText(playing ? "Pause" : "Play");
    }
    */

    public void setDetectionListener(PitchShiftPlayerListener listener) {
        this.playerListener = listener;
    }

    public void removeDetectionListener() {
        this.playerListener = null;
    }

    private void notifyPitchShiftPlayerListeners() {
        if (playerListener != null) {
            playerListener.onPlayCompleted();
        }
        else {
            //Log.d(TAG, "notifyPitchShiftPlayerListeners: playerListener is null");
        }
    }

    public void playPause() {
        TogglePlayback();
        playing = !playing;
    }

    public void startAudio(int samplerate, int buffersize) {
        StartAudio(samplerate, buffersize);             // start audio engine
    }

    public void openFile(String path, int fileOffset, int fileLength) {
        OpenFile(path, fileOffset, fileLength);
    }

    public void onPause() {
        onBackground();
    }

    public void onResume() {
        onForeground();
    }

    protected void cleanup() {
        playing = false;
        Cleanup();
    }

    public boolean isPlaying() {
        return playing;
    }

    /**
     * Notify listener when called from the CPP (pitch shifting replay completed and was stopped).
     */
    public void onPlayCompleted() {
        playing = false;
        notifyPitchShiftPlayerListeners();
    }

    // Functions implemented in the native library.
    private native void StartAudio(int samplerate, int buffersize);
    private native void OpenFile(String path, int offset, int length);
    private native void TogglePlayback();
    private native void onForeground();
    private native void onBackground();
    private native void Cleanup();
}
