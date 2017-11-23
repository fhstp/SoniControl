package sonicontrol.testroutine;

import android.Manifest;
import android.app.AlertDialog;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.location.LocationManager;
import android.media.AudioTrack;
import android.os.Build;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.NotificationCompat;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import java.util.Random;
import java.util.UUID;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;


public class MainActivity extends AppCompatActivity implements Scan.DetectionListener {
    static MainActivity mainIsMain;

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
    NotificationCompat.Builder detectionAlertStatusBuilder;
    int detectionAlertStatusNotificationId;
    NotificationCompat.Builder onHoldStatusBuilder;
    int onHoldStatusNotificationId;
    NotificationCompat.Builder scanningStatusBuilder;
    int scanningStatusNotificationId;

    Notification notificationDetection;
    Notification notificationDetectionAlertStatus;
    Notification notificationSpoofingStatus;
    Notification notificationOnHoldStatus;
    Notification notificationScanningStatus;

    private boolean isInBackground = false;

    private boolean detectionNotitificationFirstBuilded = false;
    private boolean spoofingStatusNotitificationFirstBuilded = false;
    private boolean detectionAlertStatusNotitificationFirstBuilded = false;
    private boolean onHoldStatusNotitificationFirstBuilded = false;
    private boolean scanningStatusNotitificationFirstBuilded = false;

    boolean isSignalPlayerGenerated;

    AudioTrack sigPlayer;

    boolean saveJsonFile;
    String usedBlockingMethod;

    protected LocationManager locationManager;
    boolean isGPSEnabled = false;
    boolean isNetworkEnabled = false;
    double[] lastPosition;

    // Thread handling
    private static int NUMBER_OF_CORES = Runtime.getRuntime().availableProcessors();
    public static final ExecutorService threadPool = Executors.newScheduledThreadPool(NUMBER_OF_CORES + 1);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mainIsMain = this;

        detector = Scan.getInstance(); //Get Scan-object if no object is available yet make a new one
        detector.init(MainActivity.this); //initialize the detector with the main method
        detector.addDetectionListener(this); // MainActivity will be notified of detections (calls onDetection)

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
        initDetectionAlertStatusNotification();
        initScanningStatusNotification(); //initialize the scanning-status notification
        initOnHoldStatusNotification(); //initialize the onHold-status notification
        initSpoofingStatusNotification(); //initialize the spoofing-status notification


        txtSignalType = (TextView)view.findViewById(R.id.txtSignalType); //this line can be deleted it's only for debug in the alert

        Button btnAlertStore = (Button) view.findViewById(R.id.btnDismissAlwaysHere); //button of the alert for always dismiss the found signal
        btnAlertStore.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                stopAutomaticBlockingMethodOnAction();
                /*SharedPreferences sharedPref = getSettingsObject(); //get the settings
                saveJsonFile = sharedPref.getBoolean("cbprefJsonSave", true);

                locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
                isGPSEnabled = locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);
                isNetworkEnabled = locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);

                boolean locationTrack = false;
                //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                if((locationTrackGps&&isGPSEnabled)||(locationTrackNet&&isNetworkEnabled)){
                    locationTrack = true;
                }*/

                saveJsonFile = checkJsonAndLocationPermissions()[0];
                boolean locationTrack = checkJsonAndLocationPermissions()[1];

                if(saveJsonFile && locationTrack) {
                    jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(), sigType, 0, locationFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                }
                if(saveJsonFile&&!locationTrack){
                    double[] noLocation = new double[2];
                    noLocation[0] = 0;
                    noLocation[1] = 0;
                    jsonMan.addJsonObject(noLocation, sigType, 0, getString(R.string.noAddressForJsonFile));
                }
                detector.startScanning(); //start scanning again
                alert.cancel(); //cancel the alert dialog
                txtSignalType.setText(""); //can be deleted it's only for debugging
                cancelDetectionNotification(); //cancel the detection notification
                cancelDetectionAlertStatusNotification(); //canceling the onHold notification
                activateScanningStatusNotification(); //activates the notification for the scanning process
            }
        });

        Button btnAlertDismiss = (Button) view.findViewById(R.id.btnDismissThisTime); //button of the alert for only dismiss the found signal this time
        btnAlertDismiss.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                stopAutomaticBlockingMethodOnAction();

                saveJsonFile = checkJsonAndLocationPermissions()[0];
                boolean locationTrack = checkJsonAndLocationPermissions()[1];

                if(saveJsonFile && locationTrack) {
                    jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(), sigType, 2, locationFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                }
                if(saveJsonFile&&!locationTrack){
                    double[] noLocation = new double[2];
                    noLocation[0] = 0;
                    noLocation[1] = 0;
                    jsonMan.addJsonObject(noLocation, sigType, 2, getString(R.string.noAddressForJsonFile));
                }

                detector.startScanning(); //start scanning again
                alert.cancel(); //cancel the alert dialog
                txtSignalType.setText(""); //can be deleted it's only for debugging
                cancelDetectionNotification(); //cancel the detection notification
                cancelDetectionAlertStatusNotification(); //canceling the onHold notification
                activateScanningStatusNotification(); //activates the notification for the scanning process
            }
        });

        Button btnAlertSpoof = (Button) view.findViewById(R.id.btnSpoof); //button of the alert for starting the spoofing process after finding a signal
        btnAlertSpoof.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                stopAutomaticBlockingMethodOnAction();
                /*SharedPreferences sharedPref = getSettingsObject(); //get the settings
                saveJsonFile = sharedPref.getBoolean("cbprefJsonSave", true);


                locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
                isGPSEnabled = locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);
                isNetworkEnabled = locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);


                boolean locationTrack = false;
                //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                if((locationTrackGps&&isGPSEnabled)||(locationTrackNet&&isNetworkEnabled)){
                    locationTrack = true;
                }*/
                saveJsonFile = checkJsonAndLocationPermissions()[0];
                boolean locationTrack = checkJsonAndLocationPermissions()[1];

                if(saveJsonFile&&locationTrack) {
                    jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(), sigType, 1, locationFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                }
                if(saveJsonFile&&!locationTrack){
                    double[] noLocation = new double[2];
                    noLocation[0] = 0;
                    noLocation[1] = 0;
                    jsonMan.addJsonObject(noLocation, sigType, 1, getString(R.string.noAddressForJsonFile));
                }
                locationFinder.blockMicOrSpoof(); //try to get the microphone access for choosing the blocking method
                alert.cancel(); //cancel the alert dialog
                cancelDetectionNotification(); //cancel the detection notification
                cancelDetectionAlertStatusNotification(); //canceling the onHold notification
                activateSpoofingStatusNotification(); //activates the notification for the spoofing process
            }
        });

        final Button btnAlertStart = (Button) view.findViewById(R.id.btnPlay); //button of the alert for playing the found signal with fs/3
        btnAlertStart.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v) {
                if (sigPlayer == null && !isSignalPlayerGenerated){ //if no player for the signal is created yet and the boolean for generating is also false
                    /*File f1 = new File(getExternalFilesDir(null) + "/detected-files/savedSignal.pcm"); // The location of your PCM file
                    File f2 = new File(getExternalFilesDir(null) + "/detected-files/savedSignal.wav"); // The location where you want your WAV file
                    try {
                        SignalConverter sigCon = new SignalConverter();
                        sigCon.rawToWave(f1, f2);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }*/
                    btnAlertStart.setText(R.string.ButtonStopSignal); //set the button for playing/stopping to "stop"
                    sigPlayer = locationFinder.generatePlayer(); //create a new player
                    isSignalPlayerGenerated = true; //player is generated so it's true
                    sigPlayer.play(); //start the player
                }else if(sigPlayer!=null && isSignalPlayerGenerated){ //if a player for the signal is created and the boolean for generating is true
                    sigPlayer.stop(); //stop the player
                    sigPlayer.release(); //release the resources of the player
                    sigPlayer = null; //set the player variable to null
                    btnAlertStart.setText(R.string.ButtonPlaySignal); //set the button for playing/stopping to "play"
                    isSignalPlayerGenerated = false; //now there is no player anymore so it's false
                }
                txtSignalType.setText(sigType); //can be deleted it's only for debugging
            }
        });

        btnStart.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                SharedPreferences sharedPref = getSettingsObject(); //get the settings
                saveJsonFile = sharedPref.getBoolean(ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE, ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT);

                if(saveJsonFile) {
                    if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if a JSON File is already there in the storage
                        jsonMan.createJsonFile(); //create a JSON file
                    }
                    if (!jsonMan.checkIfSavefolderIsAvailable()) { //check if a folder for the audio files is already there in the storage
                        jsonMan.createSaveFolder(); //create a folder for the audio files
                    }
                }
/*
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
                */
                int PERMISSION_ALL = 1;
                String[] PERMISSIONS = {Manifest.permission.RECORD_AUDIO, Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.INTERNET, Manifest.permission.WRITE_EXTERNAL_STORAGE, Manifest.permission.READ_EXTERNAL_STORAGE};

                if(!hasPermissions(MainActivity.this, PERMISSIONS)){
                    ActivityCompat.requestPermissions(MainActivity.this, PERMISSIONS, PERMISSION_ALL);
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
                alert.cancel();
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
                //myIntent.putExtra("json", );
                startActivityForResult(myIntent, 0);
            }
        });

        btnSettings.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                Intent myIntent = new Intent(MainActivity.this, Settings.class); //redirect to the settings activity
                startActivityForResult(myIntent, 0);
                String uniqueID = UUID.randomUUID().toString();
                Log.d("UUID", uniqueID);
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

    public static boolean hasPermissions(Context context, String... permissions) {
        if (android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && context != null && permissions != null) {
            for (String permission : permissions) {
                if (ActivityCompat.checkSelfPermission(context, permission) != PackageManager.PERMISSION_GRANTED) {
                    return false;
                }
            }
        }
        return true;
    }

    public void activateAlertAndBlock(String signalType){
        usedBlockingMethod = locationFinder.blockMicOrSpoof();
        alert.show(); //open the alert
        sigType = signalType; //set the technology variable to the latest detected one
    }

    private void stopAutomaticBlockingMethodOnAction(){
        if(usedBlockingMethod.equals(ConfigConstants.USED_BLOCKING_METHOD_SPOOFER)){
            Spoofer spoofBlock = Spoofer.getInstance();
            spoofBlock.stopSpoofingComplete();
        }else if(usedBlockingMethod.equals(ConfigConstants.USED_BLOCKING_METHOD_MICROPHONE)){
            MicCapture micBlock = MicCapture.getInstance();
            micBlock.stopMicCapturingComplete();
        }
    }

    public void initDetectionNotification(){
        detectionBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        //.setSmallIcon(R.drawable.ic_info_outline_white_48dp) //adding the icon
                        .setSmallIcon(R.drawable.hearing_found) //adding the icon
                        .setContentTitle(getString(R.string.NotificationDetectionTitle)) //adding the title
                        .setContentText(getString(R.string.NotificationDetectionMessage)) //adding the text
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
                        //.setSmallIcon(R.drawable.ic_volume_up_white_48dp) //adding the icon
                        .setSmallIcon(R.drawable.hearing_block) //adding the icon
                        .setContentTitle(getString(R.string.StatusNotificationSpoofingTitle)) //adding the title
                        .setContentText(getString(R.string.StatusNotificationSpoofingMesssage)) //adding the text
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

    public void initDetectionAlertStatusNotification(){
        detectionAlertStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        //.setSmallIcon(R.drawable.ic_info_outline_white_48dp) //adding the icon
                        .setSmallIcon(R.drawable.hearing_found) //adding the icon
                        .setContentTitle(getString(R.string.StatusNotificationDetectionAlertTitle)) //adding the title
                        .setContentText(getString(R.string.StatusNotificationDetectionAlertMessage)) //adding the text
                        .setOngoing(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                0,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_ONE_SHOT);

        detectionAlertStatusBuilder.setContentIntent(resultPendingIntent);

        mNotificationManager =
                (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

        notificationDetectionAlertStatus = detectionAlertStatusBuilder.build(); //build the notiviation

        detectionAlertStatusNotificationId = randomNotificationNumberGenerator.nextInt(1000)+2; //set an id for the notification
    }

    public void activateDetectionAlertStatusNotification(){
        if(detectionAlertStatusNotitificationFirstBuilded){ //if it's the first time that it's built
            initDetectionAlertStatusNotification(); //initialize the notification
        }
        mNotificationManager.notify(detectionAlertStatusNotificationId, notificationDetectionAlertStatus); //activate the notification with the notification itself and its id
        detectionAlertStatusNotitificationFirstBuilded = true; //notification is created
    }

    public void cancelDetectionAlertStatusNotification(){
        mNotificationManager.cancel(detectionAlertStatusNotificationId); //Cancel the notification with the help of the id
    }

    public void initOnHoldStatusNotification(){
        onHoldStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        //.setSmallIcon(R.drawable.ic_pause_white_48dp) //adding the icon
                        .setSmallIcon(R.drawable.hearing_pause) //adding the icon
                        .setContentTitle(getString(R.string.StatusNotificationOnHoldTitle)) //adding the title
                        .setContentText(getString(R.string.StatusNotificationOnHoldMessage)) //adding the text
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
                        .setContentTitle(getString(R.string.StatusNotificationScanningTitle)) //adding the title
                        .setContentText(getString(R.string.StatusNotificationScanningMessage)) //adding the text
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

        SharedPreferences sharedPref = getSettingsObject(); //get the settings
        saveJsonFile = sharedPref.getBoolean(ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE, ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT);

        if(saveJsonFile) {
            if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if a JSON File is already there in the storage
                jsonMan.createJsonFile(); //create a JSON file
            }
            if (!jsonMan.checkIfSavefolderIsAvailable()) { //check if a folder for the audio files is already there in the storage
                jsonMan.createSaveFolder(); //create a folder for the audio files
            }
        }

        /*
        if(!saveJsonFile) {
            if (jsonMan.checkIfJsonFileIsAvailable()) { //check if a JSON File is already there in the storage
                jsonMan.deleteJsonFile();
            }
        }*/
    }

    @Override
    public void onPause(){ //override the onPause method for setting a variable for checking the background-status
        super.onPause();
        isInBackground = true;
    }

    public static MainActivity getMainIsMain(){
        return mainIsMain;
    }

    public boolean getBackgroundStatus(){
        return isInBackground;
    } //get the background-status

    public boolean[] checkJsonAndLocationPermissions() {
        boolean[] saveJsonAndLocation = new boolean[2];
        SharedPreferences sharedPref = getSettingsObject(); //get the settings
        saveJsonFile = sharedPref.getBoolean(ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE, ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT);

        locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        isGPSEnabled = locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);
        isNetworkEnabled = locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);

        boolean locationTrack = false;
        //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
        boolean locationTrackGps = sharedPref.getBoolean(ConfigConstants.SETTING_GPS, ConfigConstants.SETTING_GPS_DEFAULT);
        boolean locationTrackNet = sharedPref.getBoolean(ConfigConstants.SETTING_NETWORK_USE, ConfigConstants.SETTING_NETWORK_USE_DEFAULT);

        if((locationTrackGps&&isGPSEnabled)||(locationTrackNet&&isNetworkEnabled)){
            locationTrack = true;
        }

        saveJsonAndLocation[0] = saveJsonFile;
        saveJsonAndLocation[1] = locationTrack;

        return saveJsonAndLocation;
    }

    public AlertDialog.Builder createAlertDialog(){
        AlertDialog.Builder builder;
        builder = new AlertDialog.Builder(MainActivity.this);
        return builder;
/*
        builder.setTitle("Delete entry")
            .setMessage("Are you sure you want to delete this entry?")
            .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialog, int which) {
                    // continue with delete
                }
            })
            .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialog, int which) {
                    // do nothing
                }
            })
            .setIcon(android.R.drawable.ic_dialog_alert)
            .show();*/
    }

    @Override
    public void onDetection(final Technology technology) {
        //TODO: someHandler.post(checkTechnologyAndDoAccordingly(technology));
        threadPool.execute(new Runnable() {
            @Override
            public void run() {
                checkTechnologyAndDoAccordingly(technology);
            }
        });
    }


    private void checkTechnologyAndDoAccordingly(Technology detectedTechnology){
        boolean locationTrack;
        if(detectedTechnology == null) {
            detector.startScanning();
        }
        else {
            switch (detectedTechnology) {
                case GOOGLE_NEARBY:
                    locationFinder.saveSignalTypeForLater(Technology.GOOGLE_NEARBY.toString());
                        /*SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                        //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                        boolean locationTrack = false;
                        boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                        boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);

                        if(locationTrackGps||locationTrackNet){
                            locationTrack = true;
                        }*/

                    locationTrack = this.checkJsonAndLocationPermissions()[1];

                    if (locationTrack) {
                        lastPosition = locationFinder.getLocation(); //get the latest position
                    }

                    if (this.getSettingsObject().getBoolean(ConfigConstants.SETTING_CONTINOUS_SPOOFING, false)) { //check if the settings are set to continous spoofing
                        if (!this.getBackgroundStatus()) { //if the app is not in the background
                            this.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof", "I spoof oontinuous");
                        if (locationTrack) {
                            locationFinder.setPositionForContinuousSpoofing(lastPosition); //set the position for distance calculation to the latest position
                        }
                        this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        this.activateSpoofingStatusNotification(); //activate the spoofing-status notification

                        saveJsonFile = this.checkJsonAndLocationPermissions()[0];

                        JSONManager jsonMan = new JSONManager(this);
                        if (saveJsonFile && locationTrack) {
                            jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(), Technology.GOOGLE_NEARBY.toString(), 1, locationFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                        }
                        if (saveJsonFile && !locationTrack) {
                            double[] noLocation = new double[2];
                            noLocation[0] = 0;
                            noLocation[1] = 0;
                            jsonMan.addJsonObject(noLocation, Technology.GOOGLE_NEARBY.toString(), 1, this.getResources().getString(R.string.addressData));
                        }

                        locationFinder.blockMicOrSpoof(); //try for microphone access and choose the blocking method
                        //resetHandler(); // Should be handled by the cpp (just stop scanning)
                    } else {
                        if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if the user has a JSON file
                            if (this.getBackgroundStatus()) { //if the app is in the background
                                this.activateDetectionNotification(); //activate the notification for a detection
                            }
                            this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            this.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                            this.activateAlertAndBlock(Technology.GOOGLE_NEARBY.toString()); //open the alert message for google nearby
                        } else {
                            if (locationTrack) {
                                locationFinder.checkExistingLocationDB(lastPosition, Technology.GOOGLE_NEARBY.toString()); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            } else {
                                if (this.getBackgroundStatus()) { //if the app is in the background
                                    this.activateDetectionNotification(); //activate the notification for a detection
                                }
                                this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                this.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                                this.activateAlertAndBlock(Technology.GOOGLE_NEARBY.toString()); //open the alert message for google nearby
                                //resetHandler(); // Should be handled by the cpp (just stop scanning)
                            }
                        }
                    }
                case LISNR:
                    locationFinder.saveSignalTypeForLater(Technology.LISNR.toString());
                        /*SharedPreferences sharedPref = this.getSettingsObject(); //get the settings
                        boolean locationTrack = false;
                        //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                        boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                        boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                        if(locationTrackGps||locationTrackNet){
                            locationTrack = true;
                        }*/
                    locationTrack = this.checkJsonAndLocationPermissions()[1];

                    if (locationTrack) {
                        lastPosition = locationFinder.getLocation(); //get the latest position
                    }

                    if (this.getSettingsObject().getBoolean(ConfigConstants.SETTING_CONTINOUS_SPOOFING, false)) { //check if the settings are set to continous spoofing
                        if (!this.getBackgroundStatus()) { //if the app is not in the background
                            this.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof", "I spoof oontinuous");
                        if (locationTrack) {
                            locationFinder.setPositionForContinuousSpoofing(lastPosition); //set the position for distance calculation to the latest position
                        }
                        this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        this.activateSpoofingStatusNotification(); //activate the spoofing-status notification

                        saveJsonFile = this.checkJsonAndLocationPermissions()[0];

                        JSONManager jsonMan = new JSONManager(this);
                        if (saveJsonFile && locationTrack) {
                            jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(), Technology.LISNR.toString(), 1, locationFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                        }
                        if (saveJsonFile && !locationTrack) {
                            double[] noLocation = new double[2];
                            noLocation[0] = 0;
                            noLocation[1] = 0;
                            jsonMan.addJsonObject(noLocation, Technology.GOOGLE_NEARBY.toString(), 1, this.getResources().getString(R.string.addressData));
                        }

                        locationFinder.blockMicOrSpoof(); //try for microphone access and choose the blocking method
                        //resetHandler(); // Should be handled by the cpp (just stop scanning)
                    } else {

                        if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if the user has a JSON file
                            if (this.getBackgroundStatus()) { //if the app is in the background
                                this.activateDetectionNotification(); //activate the notification for a detection
                            }
                            this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            this.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                            this.activateAlertAndBlock(Technology.LISNR.toString()); //open the alert message for lisnr
                        } else {
                            if (locationTrack) {
                                locationFinder.checkExistingLocationDB(lastPosition, Technology.LISNR.toString()); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            } else {
                                if (this.getBackgroundStatus()) { //if the app is in the background
                                    this.activateDetectionNotification(); //activate the notification for a detection
                                }
                                this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                this.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                                this.activateAlertAndBlock(Technology.LISNR.toString()); //open the alert message for lisnr
                                //resetHandler(); // Should be handled by the cpp (just stop scanning)
                            }
                        }
                    }
                case PRONTOLY:
                    locationFinder.saveSignalTypeForLater(Technology.PRONTOLY.toString());
                        /*SharedPreferences sharedPref = this.getSettingsObject(); //get the settings
                        boolean locationTrack = false;
                        //boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
                        boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
                        boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);
                        if(locationTrackGps||locationTrackNet){
                            locationTrack = true;
                        }*/
                    locationTrack = this.checkJsonAndLocationPermissions()[1];

                    if (locationTrack) {
                        lastPosition = locationFinder.getLocation(); //get the latest position
                    }

                    if (this.getSettingsObject().getBoolean(ConfigConstants.SETTING_CONTINOUS_SPOOFING, false)) { //check if the settings are set to continous spoofing
                        if (!this.getBackgroundStatus()) { //if the app is not in the background
                            this.cancelDetectionNotification(); //cancel the detection notification
                        }
                        Log.d("Spoof", "I spoof oontinuous");
                        if (locationTrack) {
                            locationFinder.setPositionForContinuousSpoofing(lastPosition); //set the position for distance calculation to the latest position
                        }
                        this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                        this.activateSpoofingStatusNotification(); //activate the spoofing-status notification

                        saveJsonFile = this.checkJsonAndLocationPermissions()[0];

                        JSONManager jsonMan = new JSONManager(this);
                        if (saveJsonFile && locationTrack) {
                            jsonMan.addJsonObject(locationFinder.getDetectedDBEntry(), Technology.PRONTOLY.toString(), 1, locationFinder.getDetectedDBEntryAddres()); //adding the found signal in the JSON file
                        }
                        if (saveJsonFile && !locationTrack) {
                            double[] noLocation = new double[2];
                            noLocation[0] = 0;
                            noLocation[1] = 0;
                            jsonMan.addJsonObject(noLocation, Technology.PRONTOLY.toString(), 1, this.getResources().getString(R.string.addressData));
                        }

                        locationFinder.blockMicOrSpoof(); //try for microphone access and choose the blocking method
                        //resetHandler(); // Should be handled by the cpp (just stop scanning)
                    } else {

                        if (!jsonMan.checkIfJsonFileIsAvailable()) { //check if the user has a JSON file
                            if (this.getBackgroundStatus()) { //if the app is in the background
                                this.activateDetectionNotification(); //activate the notification for a detection
                            }
                            this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                            this.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                            this.activateAlertAndBlock(Technology.PRONTOLY.toString()); //open the alert message for prontoly
                        } else {
                            if (locationTrack) {
                                locationFinder.checkExistingLocationDB(lastPosition, Technology.PRONTOLY.toString()); //if a JSON file is available we check if the signal is a new one with position and technologytype
                            } else {
                                if (this.getBackgroundStatus()) { //if the app is in the background
                                    this.activateDetectionNotification(); //activate the notification for a detection
                                }
                                this.cancelScanningStatusNotification(); //cancel the scanning-status notification
                                this.activateDetectionAlertStatusNotification(); //activate the onHold-status notification
                                this.activateAlertAndBlock(Technology.PRONTOLY.toString()); //open the alert message for prontoly
                                //resetHandler(); // Should be handled by the cpp (just stop scanning)
                            }
                        }
                    }
                case UNKNOWN:
                    Log.d("Detected", "Unknown ultrasonic signal");
            }
        }
    }

}
