package at.ac.fhstp.sonicontrol;

import android.content.SharedPreferences;
import android.location.LocationManager;
import android.preference.PreferenceManager;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

public class Scan {
    private static final String TAG = "Scan";
    public interface DetectionListener {
        public void onDetection(Technology technology);
    }
    //private List<DetectionListener> detectionListeners = new ArrayList<>();
    private DetectionListener mainDetectionListener = null;

    private static Scan instance;
    private JSONManager jsonMan;

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

    private Scan(){
    }

    public static Scan getInstance() { //getInstance method for Singleton pattern
        if(instance == null) { //if no instance of Scan is there create a new one, otherwise return the existing
            instance = new Scan();
        }
        return instance;
    }

    public void init(MainActivity main){
        this.main = main; //initialize the Scan with a main object
        System.loadLibrary("Superpowered");
    }

/*    public void addDetectionListener(DetectionListener listener) {
        this.detectionListeners.add(listener);
    }*/
    public void setDetectionListener(DetectionListener listener) {
        this.mainDetectionListener = listener;
    }

    public void notifyDetectionListeners() {
        if (lastDetectedTechnology != null) {
            /*for(DetectionListener listener: detectionListeners) {
                listener.onDetection(lastDetectedTechnology);
            }*/
            mainDetectionListener.onDetection(lastDetectedTechnology);
        }
        else {
            Log.d(TAG, "notifyDetectionListeners: lastDetectedTechnology is null");
        }
    }

    /***
     * Translates the String received from CPP to a Technology value and notifies the listeners of the detection.
     * Note: This is called from the native code every time there is a detection
     * @param technology String corresponding to a Technology Enum value
     */
    public void detectedSignal(String technology) {
        try {
            lastDetectedTechnology = Technology.fromString(technology);
        }
        catch (IllegalArgumentException e) {
            Log.d(TAG, "detectedSignal: " + e.getMessage());
            lastDetectedTechnology = Technology.UNKNOWN;
        }
        paused = true;
        notifyDetectionListeners();
    }

    private Runnable scanRun = new Runnable() {
        @Override
        public void run() {
            android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background

            FrequencyDomain(ConfigConstants.SCAN_SAMPLE_RATE, ConfigConstants.SCAN_BUFFER_SIZE);
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

        savedFileUrl = main.getFilesDir() + "/detected-files/hooked_on.mp3"; //unfinished variable for the url of the saved file because there is no dynamically created file yet

        locFinder = Location.getInstanceLoc(); //get an instance of location
        jsonMan = new JSONManager(main);

        if (paused) {
            Log.d(TAG, "Resume scanning");
            resume();
        }
        else { // Most probably only the first call
            Log.d(TAG, "startScanning");
            MainActivity.threadPool.execute(scanRun);
        }
        // Stores the app state : SCANNING
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(main);
        SharedPreferences.Editor ed = sp.edit();
        ed.putString(ConfigConstants.PREFERENCES_APP_STATE, StateEnum.SCANNING.toString());
        ed.apply();
    }

    public void getTheOldSpoofer(Spoofer spoofing){
        this.spoof = spoofing;
    } //get the spoofer

    public String getDetectedFileUrl(){
        return savedFileUrl; //get the detected file url /at the moment not dynamically working because there is no dynamically saving
    }

    public void pause() {
        paused = true;
        Pause();
    }

    public void resume() {
        paused = false;
        Resume();
    }

    // ------
    // Native functions to find in jni/FrequencyDomain.cpp
    private native void FrequencyDomain(int samplerate, int buffersize);
    private native float GetAndroidOut1();
    private native int GetAndroidOut2();
    private native boolean GetBackgroundModelUpdating();
    private native void Pause();
    private native void Resume();
}