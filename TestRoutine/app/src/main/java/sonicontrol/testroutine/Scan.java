package sonicontrol.testroutine;

import android.content.SharedPreferences;
import android.os.Handler;
import java.util.Random;

import android.util.Log;
import java.io.File;

public class Scan {

    private static Scan instance;
    private Handler scanHandler = new Handler();

    private Runnable scanRun;

    private Random randomNumGenerator = new Random();
    int randomNumber;

    MainActivity main;
    Location locFinder;
    Spoofer spoof = null;

    double[] position;

    String savedFileUrl;

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

    public void startScanning() {
        if(spoof != null) { //if there is an existing spoofer
            if (spoof.getNoiseGenerated()) { //if a spoofer is already generated
                spoof.setNoiseGeneratedFalse(); //set the boolean for the generation to false
                spoof.setFirstPlayTrue(); //set the firstPlay boolean to true for the next run
                spoof.setPlaytimeZero(); //set the playtime to 0 so that the next spoofer starts immediately
            }
        }

        savedFileUrl = main.getExternalFilesDir(null) + "/detected-files/hooked_on.mp3"; //unfinished variable for the url of the saved file because there is no dynamically created file yet

        locFinder = Location.getInstanceLoc(); //get an instance of location

        scanHandler.postDelayed(scanRun = new Runnable() {
            public void run() {
                android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background

                //random numbers created for testing the random detection of signals
                randomNumber = randomNumGenerator.nextInt(20);
                Log.d("Scanner_Random", Integer.toString(randomNumber));
                if(randomNumber==4){
                    locFinder.saveSignalTypeForLater(4);
                    SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                    boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                    boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                    boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                    if(!locationTrackGps&&!locationTrackNet){
                        locationTrack = false;
                    }
                    if(locationTrack) {
                        position = locFinder.getLocation(); //get the latest position
                    }

                    if(main.getSettingsObject().getBoolean("cbprefContinuousSpoof", false)){ //check if the settings are set to continous spoofing
                        if (!main.getBackgroundStatus()) { //if the app is not in the background
                            main.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof","I spoof oontinuous");
                        if(locationTrack) {
                            locFinder.setPositionForContinuousSpoofing(position); //set the position for distance calculation to the latest position
                        }
                        main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        main.activateSpoofingStatusNotification(); //activate the spoofing-status notification
                        locFinder.tryGettingMicAccessForBlockingMethod(); //try for microphone access and choose the blocking method
                        resetHandler(); //reset the handler
                    }
                    else{
                        if (!checkIfJsonFileIsAvailable()) { //check if the user has a JSON file
                            if (main.getBackgroundStatus()) { //if the app is in the background
                                main.activateDetectionNotification(); //activate the notification for a detection
                            }
                            main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            main.activateOnHoldStatusNotification(); //activate the onHold-status notification
                            openAlert("Google Nearby"); //open the alert message for google nearby
                        } else {
                            if(locationTrack) {
                                locFinder.checkExistingLocatinoDB(position, "Google Nearby"); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            }else{
                                if (main.getBackgroundStatus()) { //if the app is in the background
                                    main.activateDetectionNotification(); //activate the notification for a detection
                                }
                                main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                main.activateOnHoldStatusNotification(); //activate the onHold-status notification
                                openAlert("Google Nearby"); //open the alert message for google nearby
                            }
                            resetHandler(); //reset the handler
                        }
                    }
                }else if(randomNumber==8){
                    locFinder.saveSignalTypeForLater(8);
                    SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                    boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                    boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                    boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                    if(!locationTrackGps&&!locationTrackNet){
                        locationTrack = false;
                    }
                    if(locationTrack) {
                        position = locFinder.getLocation(); //get the latest position
                    }

                    if(main.getSettingsObject().getBoolean("cbprefContinuousSpoof", false)){ //check if the settings are set to continous spoofing
                        if (!main.getBackgroundStatus()) { //if the app is not in the background
                            main.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof","I spoof oontinuous");
                        if(locationTrack) {
                            locFinder.setPositionForContinuousSpoofing(position); //set the position for distance calculation to the latest position
                        }
                        main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        main.activateSpoofingStatusNotification(); //activate the spoofing-status notification
                        locFinder.tryGettingMicAccessForBlockingMethod(); //try for microphone access and choose the blocking method
                        resetHandler(); //reset the handler
                    }
                    else{

                        if(!checkIfJsonFileIsAvailable()){ //check if the user has a JSON file
                            if(main.getBackgroundStatus()) { //if the app is in the background
                                main.activateDetectionNotification(); //activate the notification for a detection
                            }
                            main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            main.activateOnHoldStatusNotification(); //activate the onHold-status notification
                            openAlert("Lisnr"); //open the alert message for lisnr
                        }else {
                            if(locationTrack) {
                                locFinder.checkExistingLocatinoDB(position, "Lisnr"); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            }else {
                                if(main.getBackgroundStatus()) { //if the app is in the background
                                    main.activateDetectionNotification(); //activate the notification for a detection
                                }
                                main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                main.activateOnHoldStatusNotification(); //activate the onHold-status notification
                                openAlert("Lisnr"); //open the alert message for lisnr
                            }
                            resetHandler(); //reset the handler
                        }
                    }
                }else if(randomNumber==2){
                    locFinder.saveSignalTypeForLater(2);
                    SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                    boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                    boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                    boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                    if(!locationTrackGps&&!locationTrackNet){
                        locationTrack = false;
                    }
                    if(locationTrack) {
                        position = locFinder.getLocation(); //get the latest position
                    }

                    if(main.getSettingsObject().getBoolean("cbprefContinuousSpoof", false)){ //check if the settings are set to continous spoofing
                        if (!main.getBackgroundStatus()) { //if the app is not in the background
                            main.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof","I spoof oontinuous");
                        if(locationTrack) {
                            locFinder.setPositionForContinuousSpoofing(position); //set the position for distance calculation to the latest position
                        }
                        main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        main.activateSpoofingStatusNotification(); //activate the spoofing-status notification
                        locFinder.tryGettingMicAccessForBlockingMethod(); //try for microphone access and choose the blocking method
                        resetHandler(); //reset the handler
                    }
                    else{

                        if(!checkIfJsonFileIsAvailable()){ //check if the user has a JSON file
                            if(main.getBackgroundStatus()) { //if the app is in the background
                                main.activateDetectionNotification(); //activate the notification for a detection
                            }
                            main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            main.activateOnHoldStatusNotification(); //activate the onHold-status notification
                            openAlert("Prontoly"); //open the alert message for prontoly
                        }else {
                            if(locationTrack) {
                                locFinder.checkExistingLocatinoDB(position, "Prontoly"); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            }else{
                                if(main.getBackgroundStatus()) { //if the app is in the background
                                    main.activateDetectionNotification(); //activate the notification for a detection
                                }
                                main.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                main.activateOnHoldStatusNotification(); //activate the onHold-status notification
                                openAlert("Prontoly"); //open the alert message for prontoly
                            }
                            resetHandler(); //reset the handler
                        }
                    }
                }else {
                    startScanning(); //start the scanning process again
                }
            }
        }, 500);
    }

    private void openAlert(String signalType){
        main.activateAlert(signalType); //open the alert message on the main-activity with the technology type
        resetHandler(); //reset the handler
    }

    public void resetHandler(){
        scanHandler.removeCallbacks(scanRun); //reset the handler completely
    }

    public boolean checkIfJsonFileIsAvailable(){
        File file = new File(main.getExternalFilesDir(null), "soni.json"); //"make" a new file where the file normally should be
        if(file.exists()){ //if it exists
            Log.d("Filecheck","The file is here");
            return true;
        }else{
            Log.d("Filecheck","here is no file");
            return false;
        }
    }

    public String getDetectedFileUrl(){
        return savedFileUrl; //get the detected file url /at the moment not dynamically working because there is no dynamically saving
    }
}