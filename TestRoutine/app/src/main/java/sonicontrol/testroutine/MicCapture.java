package sonicontrol.testroutine;


import android.content.SharedPreferences;
import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.MediaRecorder;
import android.os.Handler;
import android.util.Log;

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
        captHandler.postDelayed(captRun = new Runnable() {
            public void run() {
                waitTime = 8000; //time for capturing /has to be adjusted
                android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_URGENT_AUDIO); //set the handler thread to background

                if(recorder == null) {
                    recorder = //create a new recorder
                            new AudioRecord(MediaRecorder.AudioSource.MIC, 4000,
                                    AudioFormat.CHANNEL_IN_MONO,
                                    AudioFormat.ENCODING_DEFAULT, 4000);

                    recorder.startRecording(); //start the recorder
                }
                i++;
                if(i<2){ //has to be adjusted
                    startCapturing(); //start the capture again
                }else{
                    Log.d("Capture", "I captured the microphonesignal!");
                    recorder.stop(); //stop the recording
                    recorder.release(); //release the recorder resources
                    recorder = null; //set the recorder to null
                    waitTime = 0; //set the waittime for the next capture to 0
                    i = 0;
                    positionLatest = locFinder.getLocation(); //get the latest position
                    positionOld = locFinder.getDetectedDBEntry(); //get the position saved in the json-file
                    distance = locFinder.getDistanceInMetres(positionOld, positionLatest); //calculate the distance
                    SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                    locationRadius = Integer.valueOf(sharedPref.getString("etprefLocationRadius", "30")); //get the settings for the locationdistance
                    if(distance<locationRadius){ //if in distance
                        locFinder.tryGettingMicAccessForBlockingMethod(); //start the blocking again with trying to get microphone access
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
