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

import android.content.Context;
import android.content.SharedPreferences;
import android.location.LocationManager;
import android.preference.PreferenceManager;

/**
 * This class makes the link with the native scanner/detector based on Superpowered library.
 */
public class Scan {
    private static final String TAG = "Scan";
    public interface DetectionListener {
        public void onDetection(Technology technology, float[] stereoRawData);//, int maxValueIndex);
        public void onDetectorInitialized();
    }
    //private List<DetectionListener> detectionListeners = new ArrayList<>();
    private DetectionListener mainDetectionListener = null;

    private static Scan instance;
    private JSONManager jsonMan;

    Context applicationContext;
    MainActivity main;
    Location locFinder;
    Spoofer spoof = null;

    String savedFileUrl;

    boolean saveJsonFile;
    protected LocationManager locationManager;
    boolean isGPSEnabled = false;
    boolean isNetworkEnabled = false;

    private boolean paused = false; // Is the Scan paused ?
    private Technology lastDetectedTechnology = null;
    private int extendedDiagnostics;

    private boolean consistentState = true; // Allows to detect wrong termination of the app

    private Scan(){
    }

    public static Scan getInstance() { //getInstance method for Singleton pattern
        if(instance == null) { //if no instance of Scan is there create a new one, otherwise return the existing
            instance = new Scan();
        }
        return instance;
    }

    public void init(MainActivity main){
        this.applicationContext = main.getApplicationContext();
        //TODO: Remove references to main
        this.main = main; //initialize the Scan with a main object
        System.loadLibrary("Superpowered");
    }

/*    public void addDetectionListener(DetectionListener listener) {
        this.detectionListeners.add(listener);
    }*/
    public void setDetectionListener(DetectionListener listener) {
        this.mainDetectionListener = listener;
    }

    public void notifyDetectionListeners(Technology technology, float[] bufferHistory) {//, int maxValueIndex) {
        if (technology != null) {
            /*for(DetectionListener listener: detectionListeners) {
                listener.onDetection(lastDetectedTechnology);
            }*/
            mainDetectionListener.onDetection(technology, bufferHistory); //, maxValueIndex);
        }
        else {
            //Log.d(TAG, "notifyDetectionListeners: lastDetectedTechnology is null");
        }
    }

    /**
     * Notify listeners after translating the String received from CPP to a Technology value.
     * Note: This is called from the native code every time there is a detection
     * @param technology String corresponding to a Technology Enum value
     * @param bufferHistory raw buffer captured via Superpowered
     */
    public void detectedSignal(String technology, float[] bufferHistory) { //}, int maxValueIndex) {
        //float[] bufferHistoryFloatArrayMono = bufferHistory;
        //SignalConverter.writeToCSV(bufferHistoryFloatArrayMono, main.getApplicationContext());

        try {
            lastDetectedTechnology = Technology.fromString(technology);
        }
        catch (IllegalArgumentException e) {
            //Log.d(TAG, "detectedSignal: " + e.getMessage());
            lastDetectedTechnology = Technology.UNKNOWN;
        }
        paused = true;
        notifyDetectionListeners(lastDetectedTechnology, bufferHistory); //, maxValueIndex);
    }

    /**
     * Notify listeners once the detector is initiliazed (background model buffer is full).
     * Note: This is called from the native code once after each start/resume of the detector.
     */
    public void onDetectorInitialized() {
        // Update initialized state, and then callback the main activity for GUI update
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(main);
        SharedPreferences.Editor ed = sp.edit();
        ed.putBoolean(ConfigConstants.PREFERENCES_SCANNER_INITIALIZED, true);
        ed.apply();
        mainDetectionListener.onDetectorInitialized();
    }

    private Runnable scanRun = new Runnable() {
        @Override
        public void run() {
            android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background

            FrequencyDomain(ConfigConstants.SCAN_SAMPLE_RATE, ConfigConstants.SCAN_BUFFER_SIZE, extendedDiagnostics);
        }
    };

    public void startScanning() {
        if(spoof != null) { //if there is an existing spoofer
            if (spoof.isNoiseGenerated()) { //if a spoofer is already generated
                spoof.setNoiseGeneratedFalse(); //set the boolean for the generation to false
                spoof.setFirstPlayTrue(); //set the firstPlay boolean to true for the next run
                spoof.setPlaytimeZero(); //set the playtime to 0 so that the next spoofer starts immediately
            }
        }

        this.extendedDiagnostics = PreferenceManager.getDefaultSharedPreferences(this.applicationContext).getBoolean(ConfigConstants.SETTINGS_EXTENDED_DIAGNOSTICS, ConfigConstants.SETTINGS_EXTENDED_DIAGNOSTICS_DEFAULT) ? 1 : 0;

        savedFileUrl = applicationContext.getFilesDir() + "/detected-files/hooked_on.mp3"; //unfinished variable for the url of the saved file because there is no dynamically created file yet

        locFinder = Location.getInstanceLoc(); //get an instance of location
        jsonMan = JSONManager.getInstanceJSONManager();//new JSONManager(main);

        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(main);
        SharedPreferences.Editor ed = sp.edit();
        ed.putBoolean(ConfigConstants.PREFERENCES_SCANNER_INITIALIZED, false);
        ed.apply();

        if (paused && consistentState) {
            //Log.d(TAG, "Resume scanning");
            resume();
        }
        else { // Most probably only the first call
            //Log.d(TAG, "startScanning");
            MainActivity.threadPool.execute(scanRun);
        }
        consistentState = true; // Handles wrong termination of the app

        // Stores the app state : SCANNING
        ed.putString(ConfigConstants.PREFERENCES_APP_STATE, StateEnum.SCANNING.toString());
        ed.apply();
        main.updateStateText();
    }

    public void getTheOldSpoofer(Spoofer spoofing){
        this.spoof = spoofing;
    } //get the spoofer

    public String getDetectedFileUrl(){
        return savedFileUrl; //get the detected file url /at the moment not dynamically working because there is no dynamically saving
    }

    public void pause() {
        paused = true;
        int result = Pause();

        if (result == -1) {
            // We are in an inconsistent state, audioIO was not initialized. Might be needed to restart...
            consistentState = false;
        }
    }

    public void resume() {
        paused = false;
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(main);
        SharedPreferences.Editor ed = sp.edit();
        ed.putBoolean(ConfigConstants.PREFERENCES_SCANNER_INITIALIZED, false);
        ed.apply();
        Resume(extendedDiagnostics);
    }

    /**
     * Will delete the audioIO object, thus releasing audio resources
     */
    public void stopIO() {
        paused = false; // False, it is actually stopped. Should not be resumed but restarted.
        StopIO();
    }

    // ------
    // Native functions to find in jni/FrequencyDomain.cpp
    private native void FrequencyDomain(int samplerate, int buffersize, int extendedDiagnostics);
    private native float GetAndroidOut1();
    private native int GetAndroidOut2();
    private native boolean GetBackgroundModelUpdating();
    private native int Pause();
    private native void Resume(int extendedDiagnostics);
    private native void StopIO();
    //private  native void setExtendedDiagnostics(int extendedDiagnostics);
}