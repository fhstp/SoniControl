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


import android.content.SharedPreferences;
import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.MediaRecorder;

import java.util.Calendar;
import android.util.Log;
import java.util.concurrent.TimeUnit;

public class MicCapture {

    static MicCapture instance;
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

    private boolean stopped = false;

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
        locFinder = Location.getInstanceLoc(); //get a location instance
        detector = Scan.getInstance(); //get a detector instance
    }

    public void startCapturing(){
        if(startTime==0) {
            startTime = Calendar.getInstance().getTimeInMillis(); //get the starttime
        }
        MainActivity.threadPool.schedule(captRun, waitTime, TimeUnit.MILLISECONDS);
    }

    public void stopMicCapturingComplete(){ //method for stopping the capturing process
        if(instance != null) {
            instance = null; //set instance to null so that there is no miccapture anymore
        }
        if(recorder != null){
            recorder.stop(); //stop the recorder
            recorder.release(); //release the recorder resources
            // Now handled with the stopped variable ? captHandler.removeCallbacks(captRun); //reset the handler
            stopped = true;
        }
    }

    private Runnable captRun = new Runnable() {
        public void run() {
            //Log.d("MicCapture", "captRun stopped : " + String.valueOf(stopped));
            if (stopped) {
                // Reinitialize everything, could be in a function.
                startTime = 0;
                waitTime = 0;
                i = 0;
                if (recorder != null) {
                    recorder.stop(); //stop the recording
                    recorder.release(); //release the recorder resources
                    recorder = null; //set the recorder to null
                }
            }
            else {
                SharedPreferences sharedPref = main.getSettingsObject();
                waitTime = Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_PULSE_DURATION, ConfigConstants.SETTING_PULSE_DURATION_DEFAULT)); //time for capturing
                android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_URGENT_AUDIO);

                if (recorder == null) {
                    recorder = //create a new recorder
                            new AudioRecord(MediaRecorder.AudioSource.MIC, 4000,
                                    AudioFormat.CHANNEL_IN_MONO,
                                    AudioFormat.ENCODING_DEFAULT, 4000);

                    recorder.startRecording(); //start the recorder
                }
                stopTime = Calendar.getInstance().getTimeInMillis();
                Long logLong = (stopTime - startTime) / 1000; //get the difference of the start- and stoptime
                String logTime = String.valueOf(logLong);
                //Log.d("HowLongBlocked",logTime);
                int blockingTime = Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_BLOCKING_DURATION, ConfigConstants.SETTING_BLOCKING_DURATION_DEFAULT)); //get the spoofingtime in minutes


                if (logLong < (blockingTime * 60)/*i<2*/) {
                    startCapturing(); //start the capture again
                }
                // TODO: Should this else redirect to some controller ? (MainActivity ?)
                else {
                    executeRoutineAfterExpiredTime(main);
                }
            }
        }
    };

    public void executeRoutineAfterExpiredTime(MainActivity main){
        SharedPreferences sharedPref = main.getSettingsObject();
        //Log.d("Capture", "I captured the microphonesignal!");
        startTime = 0;
        recorder.stop(); //stop the recording
        recorder.release(); //release the recorder resources
        recorder = null; //set the recorder to null
        waitTime = 0; //set the waittime for the next capture to 0
        i = 0;
        boolean locationTrack = false;
        // boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
        boolean locationTrackGps = sharedPref.getBoolean(ConfigConstants.SETTING_GPS, ConfigConstants.SETTING_GPS_DEFAULT);
        boolean locationTrackNet = sharedPref.getBoolean(ConfigConstants.SETTING_NETWORK_USE, ConfigConstants.SETTING_NETWORK_USE_DEFAULT);
                    if (locationTrackGps || locationTrackNet) {
            locationTrack = true;
        }
        if(/*locationTrack||*/(locFinder.getDetectedDBEntry()[0]!=0&&locFinder.getDetectedDBEntry()[1]!=0)) {
            positionLatest = locFinder.getLocation(main); //get the latest position
            positionOld = locFinder.getDetectedDBEntry(); //get the position saved in the json-file
            distance = locFinder.getDistanceInMetres(positionOld, positionLatest); //calculate the distance
            //SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
            locationRadius = Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_LOCATION_RADIUS, ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT)); //get the settings for the locationdistance
            /*Log.d("Distance", Double.toString(distance));
            Log.d("LatestPosition", Double.toString(positionLatest[0]));
            Log.d("LatestPosition", Double.toString(positionLatest[1]));
            Log.d("OldPosition", Double.toString(positionOld[0]));
            Log.d("OldPosition", Double.toString(positionOld[1]));*/
            // TODO: Check if we are thread safe. Are we sure that a spoofer / scan is not already on ?
            if (distance < locationRadius) { //if in distance
                locFinder.blockMicOrSpoof(main); //start the blocking again with trying to get microphone access
            } else {
                // Note: It is okay to update notification from a worker thread, see : https://stackoverflow.com/a/15803726/5232306
                //main.cancelSpoofingStatusNotification();
                NotificationHelper.activateScanningStatusNotification(main.getApplicationContext());
                detector.startScanning(main); //start scanning again
            }
        } else {
            //main.cancelSpoofingStatusNotification();
            NotificationHelper.activateScanningStatusNotification(main.getApplicationContext());
            detector.startScanning(main); //start scanning again
        }
    }
}
