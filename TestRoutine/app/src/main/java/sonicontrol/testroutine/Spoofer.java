package sonicontrol.testroutine;


import android.content.Context;
import android.content.SharedPreferences;
import android.media.AudioManager;
import android.media.AudioTrack;
import android.os.Handler;
import android.util.Log;
import java.util.Calendar;

public class Spoofer {

    static Spoofer instance;
    private Handler spoofHandler = new Handler();
    private Runnable spoofRun;

    int helpCounter = 0;

    MainActivity main;

    double[] positionLatest;
    double[] positionOld;
    private Scan detector = Scan.getInstance();
    private Location locFinder = Location.getInstanceLoc();
    NoiseGenerator genNoise;
    double distance;

    private AudioTrack audioTrack;
    private boolean playingGlobal;
    private boolean playingHandler;
    private boolean isFirstPlay;
    private boolean noiseGenerated = false;
    private int playtime = 0;
    private int locationRadius;
    private long startTime;
    private long stopTime;

    private int signalType;

    private Spoofer(){
    }

    public static Spoofer getInstance() { //getInstance method for Singleton pattern
        if(instance == null) { //if no instance of Scan is there create a new one, otherwise return the existing
            instance = new Spoofer();
        }
        return instance;
    }

    public void init(MainActivity main, boolean playingGlobal, boolean playingHandler, int sigType){  //initialize the Scan with a main object
        this.main = main;
        this.genNoise = new NoiseGenerator(main);
        this.playingGlobal = playingGlobal;
        this.playingHandler = playingHandler;
        this.signalType = sigType;
    }

    public void startSpoofing(){
        onPulsing(); //start the onPulsing method
    }


    public void playWhitenoise(){
        audioTrack.play(); //start the player
    }

    public void stopWhitenoise(){
        audioTrack.stop(); //stop the player
    }

    public void startStop(boolean playStatus){ //method for dynamically start and stop the spoofer depending on the playStatus
        if(playStatus){
            playWhitenoise();
        } else{
            stopWhitenoise();
        }
    }

    public void onPulsing() {
        spoofHandler.postDelayed(spoofRun = new Runnable() {
            public void run() {
                android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background
                AudioManager audioManager = (AudioManager) main.getSystemService(Context.AUDIO_SERVICE);
                int currentVolume = audioManager.getStreamVolume(AudioManager.STREAM_ALARM);
                Log.d("Streamtype", String.valueOf(AudioManager.STREAM_MUSIC));
                audioManager.setStreamVolume(3, (int)Math.round((audioManager.getStreamMaxVolume(AudioManager.STREAM_MUSIC)/*0.75D*/)),0);

                if(playingHandler) {
                    playtime = genNoise.getPlayertime(); //get the playertime depending on the generated whitenoise
                }else{
                    playtime = Integer.valueOf(main.getSettingsObject().getString("etprefPauseDuration", "1000")); //get the pause value from the settings
                }
                if (!noiseGenerated) { //if no whitenoise is available generate a new one
                    genNoise.generateWhitenoise(signalType); //generate noise
                    audioTrack = genNoise.getGeneratedPlayer(); //get the generated player
                    noiseGenerated = true; //noise and player are generated so its true
                    startTime = Calendar.getInstance().getTimeInMillis(); //get the starttime
                }
                if (isFirstPlay) { //if it is the first play after starting the spoofer
                    startStop(playingHandler); //starting it depending on the playingHandler boolean
                    playingHandler = !playingHandler; //change the variable for the next run
                    isFirstPlay = false; //set the first play to false
                    onPulsing(); //execute the method again
                } else {
                            if (playingGlobal) {
                                startStop(playingHandler); //starting it depending on the playingHandler boolean
                                playingHandler = !playingHandler; //change the variable for the next run
                                Log.d("Spoofer", "I spoof now!");
                                SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                                locationRadius = Integer.valueOf(sharedPref.getString("etprefLocationRadius", "30")); //get the location radius in metres
                                int spoofingTime = Integer.valueOf(sharedPref.getString("etprefSpoofDuration", "1")); //get the spoofingtime in minutes
                                stopTime = Calendar.getInstance().getTimeInMillis(); //get the stoptime
                                Log.d("StartTime", String.valueOf(startTime));
                                Log.d("StopTime",String.valueOf(stopTime));
                                Long logLong = (stopTime-startTime)/1000; //get the difference of the start- and stoptime
                                String logTime = String.valueOf(logLong);
                                Log.d("HowLongSpoofed",logTime);
                                if(logLong>(spoofingTime*60)){ //check if its over the spoofing time from the settings
                                    startStop(false); //stop the spoofer
                                    //helpCounter = 0;
                                    playingGlobal = false; //set to false because its not playing anymore
                                    //SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                                    boolean locationTrack = false;
                                    //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                                    boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                                    boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                                    if(locationTrackGps||locationTrackNet){
                                        locationTrack = true;
                                    }
                                    if(locationTrack||(locFinder.getDetectedDBEntry()[0]==0&&locFinder.getDetectedDBEntry()[1]==0)) {
                                        positionLatest = locFinder.getLocation(); //get the latest position
                                        positionOld = locFinder.getDetectedDBEntry(); //get the position saved in the json-file
                                        distance = locFinder.getDistanceInMetres(positionOld, positionLatest); //calculate the distance
                                        Log.d("Distance", Double.toString(distance));
                                        Log.d("LatestPosition", Double.toString(positionLatest[0]));
                                        Log.d("LatestPosition", Double.toString(positionLatest[1]));
                                        Log.d("OldPosition", Double.toString(positionOld[0]));
                                        Log.d("OldPosition", Double.toString(positionOld[1]));
                                        if (distance < locationRadius) { //if we are still in the locationRadius
                                            genNoise.setGeneratedPlayerToNull(); //set the noiseplayer to null
                                            audioTrack.release(); //release the player resources
                                            audioTrack = null; //set the player to null
                                            genNoise = null; //set the the noisegenerator object to null
                                            setInstanceNull(); //set the NoiseGenerator instance to null
                                            locFinder.tryGettingMicAccessForBlockingMethod(); //try again to get access to the microphone and then choose the spoofing method
                                            spoofHandler.removeCallbacks(spoofRun); //reset the handler
                                        } else {
                                            setInstanceNull(); //set the NoiseGenerator instance to null
                                            main.cancelSpoofingStatusNotification(); //cancel the spoofing status notification
                                            main.activateScanningStatusNotification(); //activate the scanning status notification
                                            detector.getTheOldSpoofer(Spoofer.this); //update the spoofer object in the detector
                                            detector.startScanning(); //start scanning again
                                            spoofHandler.removeCallbacks(spoofRun); //reset handler
                                        }
                                    }else {
                                        setInstanceNull(); //set the NoiseGenerator instance to null
                                        main.cancelSpoofingStatusNotification(); //cancel the spoofing status notification
                                        main.activateScanningStatusNotification(); //activate the scanning status notification
                                        detector.getTheOldSpoofer(Spoofer.this); //update the spoofer object in the detector
                                        detector.startScanning(); //start scanning again
                                        spoofHandler.removeCallbacks(spoofRun); //reset handler
                                    }
                                }else{
                                    onPulsing(); //start the pulsing again
                                }
                            } else {
                                playingGlobal = true; //set the variable for playing to true again
                                //helpCounter = 0;
                            }
                        }

                }
        }, playtime);
    }

    public boolean getNoiseGenerated(){
        return noiseGenerated;
    }

    public void setNoiseGeneratedFalse(){
        noiseGenerated = false;
    }

    public void setFirstPlayTrue(){
        isFirstPlay = true;
    }

    public void setPlaytimeZero(){
        playtime = 0;
    }

    public void setInstanceNull(){
        instance = null;
    }

    public void stopSpoofingComplete(){
        if(instance != null) { //if there is an instance
            setInstanceNull(); //set the instance of the spoofer null
        }
        if(audioTrack != null){ //if there is an audioplayer
            spoofHandler.removeCallbacks(spoofRun); //reset the handler of the spoofer
            audioTrack.stop(); //stop playing
            genNoise.setGeneratedPlayerToNull(); //set the player of the generator null
            audioTrack.release(); //release the player resources
            audioTrack = null; //set the player to null
            genNoise = null; //set the NoiseGenerator object to null
        }
    }
}
