package sonicontrol.testroutine;


import android.content.SharedPreferences;
import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.MediaRecorder;
import android.os.Handler;
import android.util.Log;

import java.util.Calendar;

public class MicCapture {

    static MicCapture instance;
    private Handler captHandler = new Handler();
    private Runnable captRun;
    int waitTime = 0;
    int i = 0;
    private  AudioRecord recorder;

    MainActivity main;

    double[] positionLatest;
    double[] positionOld;
    double distance;
    private Location locFinder;
    private Scan detector;
    private int locationRadius;
    private long startTime = 0;
    private long stopTime;



    private MicCapture(){
    }

    public static MicCapture getInstance() { //getInstance method for Singleton pattern
        if(instance == null) { //if no instance of MicCapture is there create a new one, otherwise return the existing
            instance = new MicCapture();
        }
        return instance;
    }

    public void init(MainActivity main){
        this.main = main;
    }

    public void startCapturing(){
        locFinder = Location.getInstanceLoc(); //get a location instance
        detector = Scan.getInstance(); //get a detector instance
        if(startTime==0) {
            startTime = Calendar.getInstance().getTimeInMillis(); //get the starttime
        }
        captHandler.postDelayed(captRun = new Runnable() {
            public void run() {
                SharedPreferences sharedPref = main.getSettingsObject();
                waitTime = Integer.valueOf(sharedPref.getString("etprefPulseDuration", "1000")); //time for capturing
                android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_URGENT_AUDIO); //set the handler thread to background

                if(recorder == null) {
                    recorder = //create a new recorder
                            new AudioRecord(MediaRecorder.AudioSource.MIC, 4000,
                                    AudioFormat.CHANNEL_IN_MONO,
                                    AudioFormat.ENCODING_DEFAULT, 4000);

                    recorder.startRecording(); //start the recorder
                }
                //i++;
                stopTime = Calendar.getInstance().getTimeInMillis();
                Log.d("StartTime", String.valueOf(startTime));
                Log.d("StopTime",String.valueOf(stopTime));
                Long logLong = (stopTime-startTime)/1000; //get the difference of the start- and stoptime
                String logTime = String.valueOf(logLong);
                Log.d("HowLongBlocked",logTime);
                int blockingTime = Integer.valueOf(sharedPref.getString("etprefSpoofDuration", "1")); //get the spoofingtime in minutes
                if(logLong<(blockingTime*60)/*i<2*/){
                    startCapturing(); //start the capture again
                }else{
                    Log.d("Capture", "I captured the microphonesignal!");
                    startTime = 0;
                    recorder.stop(); //stop the recording
                    recorder.release(); //release the recorder resources
                    recorder = null; //set the recorder to null
                    waitTime = 0; //set the waittime for the next capture to 0
                    i = 0;
                    boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                    boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                    boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                    if(!locationTrackGps&&!locationTrackNet){
                        locationTrack = false;
                    }
                    if(locationTrack) {
                        positionLatest = locFinder.getLocation(); //get the latest position
                        positionOld = locFinder.getDetectedDBEntry(); //get the position saved in the json-file
                        distance = locFinder.getDistanceInMetres(positionOld, positionLatest); //calculate the distance
                        //SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                        locationRadius = Integer.valueOf(sharedPref.getString("etprefLocationRadius", "30")); //get the settings for the locationdistance
                        if (distance < locationRadius) { //if in distance
                            locFinder.tryGettingMicAccessForBlockingMethod(); //start the blocking again with trying to get microphone access
                        } else {
                            main.cancelSpoofingStatusNotification(); //cancel the spoofing status notification
                            main.activateScanningStatusNotification(); //activate the scanning status notification
                            detector.startScanning(); //start scanning again
                        }
                    }else{
                        main.cancelSpoofingStatusNotification(); //cancel the spoofing status notification
                        main.activateScanningStatusNotification(); //activate the scanning status notification
                        detector.startScanning(); //start scanning again
                    }
                }
            }
        }, waitTime); //wait for the waittime

    }

    public void stopMicCapturingComplete(){ //method for stopping the capturing process
        if(instance != null) {
            instance = null; //set instance to null so that there is no miccapture anymore
        }
        if(recorder != null){
            recorder.stop(); //stop the recorder
            recorder.release(); //release the recorder resources
            captHandler.removeCallbacks(captRun); //reset the handler
        }
    }
}
