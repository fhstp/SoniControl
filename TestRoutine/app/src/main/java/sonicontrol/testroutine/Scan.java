package sonicontrol.testroutine;

import android.location.LocationManager;
import android.os.Handler;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

public class Scan {
    private static final String TAG = "Scan";
    public interface DetectionListener {
        public void onDetection(Technology technology);
    }
    private List<DetectionListener> detectionListeners = new ArrayList<>();

    private static Scan instance;
    private Handler scanHandler = new Handler();
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

    public void addDetectionListener(DetectionListener listener) {
        this.detectionListeners.add(listener);
    }

    public void notifyDetectionListeners() {
        if (lastDetectedTechnology != null) {
            for(DetectionListener listener: detectionListeners) {
                listener.onDetection(lastDetectedTechnology);
            }
        }
        else {
            Log.d(TAG, "notifyDetectionListeners: lastDetectedTechnology is null");
        }
    }

    public void detectedSignal(String technology) {
        lastDetectedTechnology = Technology.UNKNOWN;
        notifyDetectionListeners();
    }

    private Runnable scanRun = new Runnable() {
        @Override
        public void run() {
            android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background

            FrequencyDomain(ConfigConstants.SCAN_SAMPLE_RATE, ConfigConstants.SCAN_BUFFER_SIZE);

            // TODO: The CPP should trigger the call to notifyDetectionListeners.
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

        savedFileUrl = main.getExternalFilesDir(null) + "/detected-files/hooked_on.mp3"; //unfinished variable for the url of the saved file because there is no dynamically created file yet

        locFinder = Location.getInstanceLoc(); //get an instance of location
        jsonMan = new JSONManager(main);

        scanHandler.postDelayed(scanRun, 500);
    }


    public void resetHandler(){
        scanHandler.removeCallbacks(scanRun); //reset the handler completely
    }

    public void getTheOldSpoofer(Spoofer spoofing){
        this.spoof = spoofing;
    } //get the spoofer

    public String getDetectedFileUrl(){
        return savedFileUrl; //get the detected file url /at the moment not dynamically working because there is no dynamically saving
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