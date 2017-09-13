package sonicontrol.testroutine;

import android.Manifest;
import android.app.AlertDialog;
import android.content.pm.PackageManager;
import android.media.AudioTrack;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.NotificationCompat;
import android.support.v7.app.AppCompatActivity;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.content.Intent;
import android.widget.TextView;
import android.app.Notification;

import android.content.SharedPreferences;
import android.preference.*;

import java.util.Random;


public class MainActivity extends AppCompatActivity {
    Button btnStorLoc;
    Button btnStart;
    Button btnStop;
    Button btnSettings;
    Button btnExit;

    Scan detector;
    Location locationFinder;
    JSONManager jsonMan = new JSONManager(this);

    AlertDialog alert;
    TextView txtSignalType;
    String sigType;
    View view;

    Random randomNotificationNumberGenerator = new Random();

    NotificationCompat.Builder detectionBuilder;
    NotificationManager mNotificationManager;
    int detectionNotificationId;

    NotificationCompat.Builder spoofingStatusBuilder;
    int spoofingStatusNotificationId;
    NotificationCompat.Builder onHoldStatusBuilder;
    int onHoldStatusNotificationId;
    NotificationCompat.Builder scanningStatusBuilder;
    int scanningStatusNotificationId;

    Notification notificationDetection;
    Notification notificationSpoofingStatus;
    Notification notificationOnHoldStatus;
    Notification notificationScanningStatus;

    private boolean isInBackground = false;

    private boolean detectionNotitificationFirstBuilded = false;
    private boolean spoofingStatusNotitificationFirstBuilded = false;
    private boolean onHoldStatusNotitificationFirstBuilded = false;
    private boolean scanningStatusNotitificationFirstBuilded = false;

    boolean isSignalPlayerGenerated;

    AudioTrack sigPlayer;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        detector = Scan.getInstance(); //Get Scan-object if no object is available yet make a new one
        detector.init(MainActivity.this); //initialize the detector with the main method
        locationFinder = Location.getInstanceLoc(); //Get LocationFinder-object if no object is available yet make a new one
        locationFinder.init(MainActivity.this); //initialize the location-object with the main method

        btnStop = (Button) findViewById(R.id.btnStop); //Main button for stopping the whole process
        btnStart = (Button) findViewById(R.id.btnPlay); //Main button for starting the whole process
        btnStorLoc = (Button) findViewById(R.id.btnStorLoc); //button for getting into the storedLocations activity
        btnSettings = (Button) findViewById(R.id.btnSettings); //button for getting into the settings activity
        btnExit = (Button) findViewById(R.id.btnExit); //button for exiting the application

        btnStop.setEnabled(false); //after the start of the app set the stop button to false because nothing is there to stop yet

        final AlertDialog.Builder openScanner = new AlertDialog.Builder(MainActivity.this); //AlertDialog for getting the alert message after detection
        openScanner.setCancelable(false); //the AlertDialog cannot be canceled because you have to choose an option for the found signal
        LayoutInflater inflater = getLayoutInflater(); //inflator for getting the custom alertDialog over the main activity
        final ViewGroup viewGroup = (ViewGroup) findViewById(android.R.id.content);
        view = inflater.inflate(R.layout.alert_message, viewGroup , false); //put the alert_message layout on the inflator
        openScanner.setView(view); //set the view of the inflater
        alert = openScanner.create(); //create the AlertDialog

        initDetectionNotification(); //initialize the detection notification
        initScanningStatusNotification(); //initialize the scanning-status notification
        initOnHoldStatusNotification(); //initialize the onHold-status notification
        initSpoofingStatusNotification(); //initialize the spoofing-status notification


        txtSignalType = (TextView)view.findViewById(R.id.txtSignalType); //this line can be deleted it's only for debug in the alert
        if(!detector.checkIfJsonFileIsAvailable()){ //check if a JSON File is already there in the storage
            jsonMan.createJsonFile(); //create a JSON file
        }
        if(!jsonMan.checkIfSavefolderIsAvailable()){ //check if a folder for the audio files is already there in the storage
            jsonMan.createSaveFolder(); //create a folder for the audio files
        }

        Button btnAlertStore = (Button) view.findViewById(R.id.btnDismissAlwaysHere); //button of the alert for always dismiss the found signal
        btnAlertStore.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(),sigType,0); //adding the found signal in the JSON file
                detector.startScanning(); //start scanning again
                alert.cancel(); //cancel the alert dialog
                txtSignalType.setText(""); //can be deleted it's only for debugging
                cancelDetectionNotification(); //cancel the detection notification
                cancelOnHoldStatusNotification(); //canceling the onHold notification
                activateScanningStatusNotification(); //activates the notification for the scanning process
            }
        });

        Button btnAlertDismiss = (Button) view.findViewById(R.id.btnDismissThisTime); //button of the alert for only dismiss the found signal this time
        btnAlertDismiss.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                detector.startScanning(); //start scanning again
                alert.cancel(); //cancel the alert dialog
                txtSignalType.setText(""); //can be deleted it's only for debugging
                cancelDetectionNotification(); //cancel the detection notification
                cancelOnHoldStatusNotification(); //canceling the onHold notification
                activateScanningStatusNotification(); //activates the notification for the scanning process
            }
        });

        Button btnAlertSpoof = (Button) view.findViewById(R.id.btnSpoof); //button of the alert for starting the spoofing process after finding a signal
        btnAlertSpoof.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(),sigType,1); //adding the found signal in the JSON file
                locationFinder.tryGettingMicAccessForBlockingMethod(); //try to get the microphone access for choosing the blocking method
                alert.cancel(); //cancel the alert dialog
                cancelDetectionNotification(); //cancel the detection notification
                cancelOnHoldStatusNotification(); //canceling the onHold notification
                activateSpoofingStatusNotification(); //activates the notification for the spoofing process
            }
        });

        final Button btnAlertStart = (Button) view.findViewById(R.id.btnPlay); //button of the alert for playing the found signal with fs/3
        btnAlertStart.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v) {
                if (sigPlayer == null && !isSignalPlayerGenerated){ //if no player for the signal is created yet and the boolean for generating is also false
                    btnAlertStart.setText("Pause"); //set the button for playing/stopping to "stop"
                    sigPlayer = locationFinder.generatePlayer(); //create a new player
                    isSignalPlayerGenerated = true; //player is generated so it's true
                    sigPlayer.play(); //start the player
                }else if(sigPlayer!=null && isSignalPlayerGenerated){ //if a player for the signal is created and the boolean for generating is true
                    sigPlayer.stop(); //stop the player
                    sigPlayer.release(); //release the resources of the player
                    sigPlayer = null; //set the player variable to null
                    btnAlertStart.setText("Play"); //set the button for playing/stopping to "play"
                    isSignalPlayerGenerated = false; //now there is no player anymore so it's false
                }
                txtSignalType.setText(sigType); //can be deleted it's only for debugging
            }
        });

        btnStart.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                //Request permission fot the audio recording
                int status = ActivityCompat.checkSelfPermission(MainActivity.this,
                        Manifest.permission.RECORD_AUDIO);
                if (status != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(
                            MainActivity.this,
                            new String[]{Manifest.permission.RECORD_AUDIO},
                            0);
                }
                //request permission for the location
                int statusLocation = ActivityCompat.checkSelfPermission(MainActivity.this,
                        Manifest.permission.ACCESS_FINE_LOCATION);
                if (statusLocation != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(
                            MainActivity.this,
                            new String[]{Manifest.permission.ACCESS_FINE_LOCATION},
                            0);
                }
                //request permission for the internet access
                int statusInternet = ActivityCompat.checkSelfPermission(MainActivity.this,
                        Manifest.permission.INTERNET);
                if (statusInternet != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(
                            MainActivity.this,
                            new String[]{Manifest.permission.INTERNET},
                            0);
                }
                //request permission for writing to the external storage
                int statusRead = ActivityCompat.checkSelfPermission(MainActivity.this,
                        Manifest.permission.WRITE_EXTERNAL_STORAGE);
                if (statusRead != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(
                            MainActivity.this,
                            new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                            0);
                }
                //request permission for reading the external storage
                int statusWrite = ActivityCompat.checkSelfPermission(MainActivity.this,
                        Manifest.permission.READ_EXTERNAL_STORAGE);
                if (statusWrite != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(
                            MainActivity.this,
                            new String[]{Manifest.permission.READ_EXTERNAL_STORAGE},
                            0);
                }

                cancelOnHoldStatusNotification(); //cancel the onHold notification
                activateScanningStatusNotification(); //start the scanning-status notification
                detector.startScanning(); //start scanning for signals
                btnStart.setEnabled(false); //disable the start button
                btnStop.setEnabled(true); //enable the stop button
            }
        });

        btnStop.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                mNotificationManager.cancelAll(); //cancel all active notifications
                activateOnHoldStatusNotification(); //activate only the onHold-status notification again
                detector.resetHandler(); //reset the handler of the scanning handler
                Spoofer spoof = Spoofer.getInstance(); //get a spoofing object
                spoof.stopSpoofingComplete(); //stop the whole spoofing process
                MicCapture micCap = MicCapture.getInstance(); //get a microphone capture object
                micCap.stopMicCapturingComplete(); //stop the whole capturing process via the microphone
                btnStart.setEnabled(true); //enable the start button again
                btnStop.setEnabled(false); //disable the stop button
            }
        });

        btnStorLoc.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                Intent myIntent = new Intent(MainActivity.this, StoredLocations.class); //redirect to the stored locations activity
                startActivityForResult(myIntent, 0);
            }
        });

        btnSettings.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                Intent myIntent = new Intent(MainActivity.this, Settings.class); //redirect to the settings activity
                startActivityForResult(myIntent, 0);
            }
        });

        btnExit.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                mNotificationManager.cancelAll(); //cancel all notifications
                System.exit(0); //exit the application
            }
        });

        activateOnHoldStatusNotification(); //activate the onHold-status notification
        getSettingsObject(); //get the settings
    }

    public void activateAlert(String signalType){
        alert.show(); //open the alert
        sigType = signalType; //set the technology variable to the latest detected one
    }

    public void initDetectionNotification(){
        detectionBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.ic_info_outline_white_48dp) //adding the icon
                        .setContentTitle("Detection") //adding the title
                        .setContentText("I found a signal!") //adding the text
                        .setOngoing(true) //can't be canceled
                        .setPriority(Notification.PRIORITY_HIGH) //high priority in the notification system
                        .setAutoCancel(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                0,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_ONE_SHOT);

        detectionBuilder.setContentIntent(resultPendingIntent);

        mNotificationManager =
                (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

        notificationDetection = detectionBuilder.build(); //build the notiviation

        detectionNotificationId = randomNotificationNumberGenerator.nextInt(1000)+2; //set an id for the notification

    }

    public void activateDetectionNotification(){
        if(detectionNotitificationFirstBuilded){ //if it's the first time that it's built
            initDetectionNotification(); //initialize the notification
        }
        mNotificationManager.notify(detectionNotificationId, notificationDetection); //activate the notification with the notification itself and its id
        detectionNotitificationFirstBuilded = true; //notification is created
    }

    public void cancelDetectionNotification(){
        mNotificationManager.cancel(detectionNotificationId); //Cancel the notification with the help of the id
    }

    public void initSpoofingStatusNotification(){
        spoofingStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.ic_volume_up_white_48dp) //adding the icon
                        .setContentTitle("Blocking") //adding the title
                        .setContentText("I am blocking the signal now!") //adding the text
                        .setOngoing(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                0,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_ONE_SHOT);

        spoofingStatusBuilder.setContentIntent(resultPendingIntent);

        mNotificationManager =
                (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

        notificationSpoofingStatus = spoofingStatusBuilder.build(); //build the notiviation

        spoofingStatusNotificationId = randomNotificationNumberGenerator.nextInt(1000)+2; //set an id for the notification
    }

    public void activateSpoofingStatusNotification(){
        if(spoofingStatusNotitificationFirstBuilded){ //if it's the first time that it's built
            initSpoofingStatusNotification(); //initialize the notification
        }
        mNotificationManager.notify(spoofingStatusNotificationId, notificationSpoofingStatus); //activate the notification with the notification itself and its id
        spoofingStatusNotitificationFirstBuilded = true; //notification is created
    }

    public void cancelSpoofingStatusNotification(){
        mNotificationManager.cancel(spoofingStatusNotificationId); //Cancel the notification with the help of the id
    }

    public void initOnHoldStatusNotification(){
        onHoldStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.ic_pause_white_48dp) //adding the icon
                        .setContentTitle("On Hold") //adding the title
                        .setContentText("I am waiting for input!") //adding the text
                        .setOngoing(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                0,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_ONE_SHOT);

        onHoldStatusBuilder.setContentIntent(resultPendingIntent);

        mNotificationManager =
                (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

        notificationOnHoldStatus = onHoldStatusBuilder.build(); //build the notiviation

        onHoldStatusNotificationId = randomNotificationNumberGenerator.nextInt(1000)+2; //set an id for the notification
    }

    public void activateOnHoldStatusNotification(){
        if(onHoldStatusNotitificationFirstBuilded){ //if it's the first time that it's built
            initOnHoldStatusNotification(); //initialize the notification
        }
        mNotificationManager.notify(onHoldStatusNotificationId, notificationOnHoldStatus); //activate the notification with the notification itself and its id
        onHoldStatusNotitificationFirstBuilded = true; //notification is created
    }

    public void cancelOnHoldStatusNotification(){
        mNotificationManager.cancel(onHoldStatusNotificationId); //Cancel the notification with the help of the id
    }

    public void initScanningStatusNotification(){
        scanningStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.ic_hearing_white_48dp) //adding the icon
                        .setContentTitle("Scanner is active") //adding the title
                        .setContentText("I am scanning now!") //adding the text
                        .setOngoing(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                0,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_ONE_SHOT);

        scanningStatusBuilder.setContentIntent(resultPendingIntent);

        mNotificationManager =
                (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

        notificationScanningStatus = scanningStatusBuilder.build(); //build the notiviation

        scanningStatusNotificationId = randomNotificationNumberGenerator.nextInt(1000)+2; //set an id for the notification
    }

    public void activateScanningStatusNotification(){
        if(scanningStatusNotitificationFirstBuilded){ //if it's the first time that it's built
            initScanningStatusNotification(); //initialize the notification
        }
        mNotificationManager.notify(scanningStatusNotificationId, notificationScanningStatus); //activate the notification with the notification itself and its id
        scanningStatusNotitificationFirstBuilded = true; //notification is created
    }

    public void cancelScanningStatusNotification(){
        mNotificationManager.cancel(scanningStatusNotificationId); //Cancel the notification with the help of the id
    }

    public SharedPreferences getSettingsObject(){
        SharedPreferences sharedPref = PreferenceManager.getDefaultSharedPreferences(this); //get the object with the settings
        return sharedPref;
    }

    @Override
    public void onResume(){ //override the onResume method for setting a variable for checking the background-status
        super.onResume();
        isInBackground = false;
    }

    @Override
    public void onPause(){ //override the onPause method for setting a variable for checking the background-status
        super.onPause();
        isInBackground = true;
    }

    public boolean getBackgroundStatus(){
        return isInBackground;
    } //get the background-status


    public native String stringFromJNI();

    // Used to load the 'native-lib' library on application startup.
    static {
        System.loadLibrary("native-lib");
    }

}
