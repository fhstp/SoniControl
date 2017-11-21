package sonicontrol.testroutine;

import android.location.LocationManager;
import android.os.Handler;
import android.util.Log;

import java.util.Random;

public class Scan {

    private static Scan instance;
    private Handler scanHandler = new Handler();
    private JSONManager jsonMan;

    MainActivity main;
    Location locFinder;
    Spoofer spoof = null;

    double[] position;

    String savedFileUrl;

    boolean saveJsonFile;
    protected LocationManager locationManager;
    boolean isGPSEnabled = false;
    boolean isNetworkEnabled = false;

    boolean paused = false; // Is the Scan paused ?

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
    }

    public void getTheOldSpoofer(Spoofer spoofing){
        this.spoof = spoofing;
    } //get the spoofer


    private Runnable scanRun = new Runnable() {
        @Override
        public void run() {
            android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background

            //TODO: Put as constants, or as settings somewhere.
            int samplerateString = 44100;
            int buffersizeString = 2048; //2048 is 46.440ms //"2205"; //2205 is 50 ms (5x 441)
            
            FrequencyDomain(samplerateString, buffersizeString);
            Technology detectedTechnology = Technology.UNKNOWN;

            //TODO: Actively check for detection from the CPP or implements a callback system.

            checkTechnologyAndDoAccordingly(detectedTechnology);
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



    private void checkTechnologyAndDoAccordingly(Technology detectedTechnology){
        boolean locationTrack;
        if(detectedTechnology == null) {
            startScanning();
        }
        else {
            switch (detectedTechnology) {
                case GOOGLE_NEARBY:
                    locFinder.saveSignalTypeForLater(Technology.GOOGLE_NEARBY.toString());
                        /*SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                        //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                        boolean locationTrack = false;
                        boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                        boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);

                        if(locationTrackGps||locationTrackNet){
                            locationTrack = true;
                        }*/

                    locationTrack = main.checkJsonAndLocationPermissions()[1];

                    if (locationTrack) {
                        position = locFinder.getLocation(); //get the latest position
                    }

                    if (main.getSettingsObject().getBoolean(ConfigConstants.SETTING_CONTINOUS_SPOOFING, false)) { //check if the settings are set to continous spoofing
                        if (!main.getBackgroundStatus()) { //if the app is not in the background
                            main.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof", "I spoof oontinuous");
                        if (locationTrack) {
                            locFinder.setPositionForContinuousSpoofing(position); //set the position for distance calculation to the latest position
                        }
                        main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        main.activateSpoofingStatusNotification(); //activate the spoofing-status notification

                        saveJsonFile = main.checkJsonAndLocationPermissions()[0];

                        JSONManager jsonMan = new JSONManager(main);
                        if (saveJsonFile && locationTrack) {
                            jsonMan.addJsonObject(locFinder.getDetectedDBEntry(), Technology.GOOGLE_NEARBY.toString(), 1, locFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                        }
                        if (saveJsonFile && !locationTrack) {
                            double[] noLocation = new double[2];
                            noLocation[0] = 0;
                            noLocation[1] = 0;
                            jsonMan.addJsonObject(noLocation, Technology.GOOGLE_NEARBY.toString(), 1, main.getResources().getString(R.string.addressData));
                        }

                        locFinder.blockMicOrSpoof(); //try for microphone access and choose the blocking method
                        resetHandler(); //reset the handler
                    } else {
                        if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if the user has a JSON file
                            if (main.getBackgroundStatus()) { //if the app is in the background
                                main.activateDetectionNotification(); //activate the notification for a detection
                            }
                            main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            main.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                            openAlert(Technology.GOOGLE_NEARBY.toString()); //open the alert message for google nearby
                        } else {
                            if (locationTrack) {
                                locFinder.checkExistingLocationDB(position, Technology.GOOGLE_NEARBY.toString()); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            } else {
                                if (main.getBackgroundStatus()) { //if the app is in the background
                                    main.activateDetectionNotification(); //activate the notification for a detection
                                }
                                main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                main.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                                openAlert(Technology.GOOGLE_NEARBY.toString()); //open the alert message for google nearby
                                resetHandler(); //reset the handler
                            }
                        }
                    }
                case LISNR:
                    locFinder.saveSignalTypeForLater(Technology.LISNR.toString());
                        /*SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                        boolean locationTrack = false;
                        //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                        boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                        boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                        if(locationTrackGps||locationTrackNet){
                            locationTrack = true;
                        }*/
                    locationTrack = main.checkJsonAndLocationPermissions()[1];

                    if (locationTrack) {
                        position = locFinder.getLocation(); //get the latest position
                    }

                    if (main.getSettingsObject().getBoolean(ConfigConstants.SETTING_CONTINOUS_SPOOFING, false)) { //check if the settings are set to continous spoofing
                        if (!main.getBackgroundStatus()) { //if the app is not in the background
                            main.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof", "I spoof oontinuous");
                        if (locationTrack) {
                            locFinder.setPositionForContinuousSpoofing(position); //set the position for distance calculation to the latest position
                        }
                        main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        main.activateSpoofingStatusNotification(); //activate the spoofing-status notification

                        saveJsonFile = main.checkJsonAndLocationPermissions()[0];

                        JSONManager jsonMan = new JSONManager(main);
                        if (saveJsonFile && locationTrack) {
                            jsonMan.addJsonObject(locFinder.getDetectedDBEntry(), Technology.LISNR.toString(), 1, locFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                        }
                        if (saveJsonFile && !locationTrack) {
                            double[] noLocation = new double[2];
                            noLocation[0] = 0;
                            noLocation[1] = 0;
                            jsonMan.addJsonObject(noLocation, Technology.GOOGLE_NEARBY.toString(), 1, main.getResources().getString(R.string.addressData));
                        }

                        locFinder.blockMicOrSpoof(); //try for microphone access and choose the blocking method
                        resetHandler(); //reset the handler
                    } else {

                        if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if the user has a JSON file
                            if (main.getBackgroundStatus()) { //if the app is in the background
                                main.activateDetectionNotification(); //activate the notification for a detection
                            }
                            main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            main.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                            openAlert(Technology.LISNR.toString()); //open the alert message for lisnr
                        } else {
                            if (locationTrack) {
                                locFinder.checkExistingLocationDB(position, Technology.LISNR.toString()); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            } else {
                                if (main.getBackgroundStatus()) { //if the app is in the background
                                    main.activateDetectionNotification(); //activate the notification for a detection
                                }
                                main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                main.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                                openAlert(Technology.LISNR.toString()); //open the alert message for lisnr
                                resetHandler(); //reset the handler
                            }
                        }
                    }
                case PRONTOLY:
                    locFinder.saveSignalTypeForLater(Technology.PRONTOLY.toString());
                        /*SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                        boolean locationTrack = false;
                        //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                        boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                        boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                        if(locationTrackGps||locationTrackNet){
                            locationTrack = true;
                        }*/
                    locationTrack = main.checkJsonAndLocationPermissions()[1];

                    if (locationTrack) {
                        position = locFinder.getLocation(); //get the latest position
                    }

                    if (main.getSettingsObject().getBoolean(ConfigConstants.SETTING_CONTINOUS_SPOOFING, false)) { //check if the settings are set to continous spoofing
                        if (!main.getBackgroundStatus()) { //if the app is not in the background
                            main.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof", "I spoof oontinuous");
                        if (locationTrack) {
                            locFinder.setPositionForContinuousSpoofing(position); //set the position for distance calculation to the latest position
                        }
                        main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        main.activateSpoofingStatusNotification(); //activate the spoofing-status notification

                        saveJsonFile = main.checkJsonAndLocationPermissions()[0];

                        JSONManager jsonMan = new JSONManager(main);
                        if (saveJsonFile && locationTrack) {
                            jsonMan.addJsonObject(locFinder.getDetectedDBEntry(), Technology.PRONTOLY.toString(), 1, locFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                        }
                        if (saveJsonFile && !locationTrack) {
                            double[] noLocation = new double[2];
                            noLocation[0] = 0;
                            noLocation[1] = 0;
                            jsonMan.addJsonObject(noLocation, Technology.PRONTOLY.toString(), 1, main.getResources().getString(R.string.addressData));
                        }

                        locFinder.blockMicOrSpoof(); //try for microphone access and choose the blocking method
                        resetHandler(); //reset the handler
                    } else {

                        if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if the user has a JSON file
                            if (main.getBackgroundStatus()) { //if the app is in the background
                                main.activateDetectionNotification(); //activate the notification for a detection
                            }
                            main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            main.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                            openAlert(Technology.PRONTOLY.toString()); //open the alert message for prontoly
                        } else {
                            if (locationTrack) {
                                locFinder.checkExistingLocationDB(position, Technology.PRONTOLY.toString()); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            } else {
                                if (main.getBackgroundStatus()) { //if the app is in the background
                                    main.activateDetectionNotification(); //activate the notification for a detection
                                }
                                main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                main.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                                openAlert(Technology.PRONTOLY.toString()); //open the alert message for prontoly
                                resetHandler(); //reset the handler
                            }
                        }
                    }
                case UNKNOWN:
                    Log.d("Detected:", "Unknown ultrasonic signal");
            }
        }
    }

    private void openAlert(String signalType){
        main.activateAlert(signalType); //open the alert message on the main-activity with the technology type
        resetHandler(); //reset the handler
    }

    public void resetHandler(){
        scanHandler.removeCallbacks(scanRun); //reset the handler completely
    }

    public String getDetectedFileUrl(){
        return savedFileUrl; //get the detected file url /at the moment not dynamically working because there is no dynamically saving
    }

    private native void FrequencyDomain(int samplerate, int buffersize);
    private native float GetAndroidOut1();
    private native int GetAndroidOut2();
    private native boolean GetBackgroundModelUpdating();

    private native void Pause();
    private native void Resume();
}