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

/**
 * This class offers a simple pitch shifting audio player based on Superpowered library.
 */
public class PitchShiftPlayer {
    public interface PitchShiftPlayerListener {
        void onPlayCompleted();
    }
    private PitchShiftPlayerListener playerListener = null;
    private boolean playing = false;

    public PitchShiftPlayer() {
        // Superpowered library is loaded in Scan (load library "Superpowered")
        //System.loadLibrary("pitchShiftedPlayer");    // load native library

        // If the application crashes, please disable Instant Run under Build, Execution, Deployment in preferences.
    }

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
