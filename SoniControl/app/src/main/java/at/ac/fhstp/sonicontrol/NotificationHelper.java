package at.ac.fhstp.sonicontrol;

import android.app.Notification;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.media.RingtoneManager;
import android.net.Uri;
import android.support.v4.app.NotificationCompat;

/**
 * Created by aringot on 06.02.2018.
 */

public class NotificationHelper {
    private static final int NOTIFICATION_STATUS_REQUEST_CODE = 2;
    private static final int NOTIFICATION_DETECTION_REQUEST_CODE = 1;
/*
    private void initSpoofingStatusNotification(){
        spoofingStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.hearing_block) //adding the icon
                        .setContentTitle(getString(R.string.StatusNotificationSpoofingTitle)) //adding the title
                        .setContentText(getString(R.string.StatusNotificationSpoofingMesssage)) //adding the text
                        //Requires API 21 .setCategory(Notification.CATEGORY_SERVICE)
                        .setOngoing(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                NOTIFICATION_STATUS_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT);

        spoofingStatusBuilder.setContentIntent(resultPendingIntent);

        notificationSpoofingStatus = spoofingStatusBuilder.build(); //build the notiviation
    }

    public void activateSpoofingStatusNotification(){
        if(spoofingStatusNotitificationFirstBuild){ //if it's the first time that it's built
            initSpoofingStatusNotification(); //initialize the notification
        }
        mNotificationManager.notify(spoofingStatusNotificationId, notificationSpoofingStatus); //activate the notification with the notification itself and its id
        spoofingStatusNotitificationFirstBuild = false; //notification is created
    }

    public void cancelSpoofingStatusNotification(){
        mNotificationManager.cancel(spoofingStatusNotificationId); //Cancel the notification with the help of the id
    }

    private void initDetectionAlertStatusNotification(Technology technology){
        Uri alarmSound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);

        detectionAlertStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.hearing_found)
                        .setContentTitle(getString(R.string.StatusNotificationDetectionAlertTitle))
                        .setContentText(getString(R.string.StatusNotificationDetectionAlertMessage))
                        //Requires API 21 .setCategory(Notification.CATEGORY_STATUS)
                        .setOngoing(true) // cannot be dismissed
                        .setPriority(Notification.PRIORITY_HIGH)
                        //Now canceled in activateALert() .setAutoCancel(true) //it's canceled when tapped on it
                        .setSound(alarmSound);

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity
        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
        resultIntent.putExtra(ConfigConstants.EXTRA_TECHNOLOGY_DETECTED, technology);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                NOTIFICATION_DETECTION_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT);//Now canceled in activateALert()  | PendingIntent.FLAG_ONE_SHOT);

        detectionAlertStatusBuilder.setContentIntent(resultPendingIntent);

        notificationDetectionAlertStatus = detectionAlertStatusBuilder.build(); //build the notiviation
    }

    public void activateDetectionAlertStatusNotification(Technology technology){
        initDetectionAlertStatusNotification(technology); //initialize the notification

        mNotificationManager.notify(detectionAlertStatusNotificationId, notificationDetectionAlertStatus); //activate the notification with the notification itself and its id

    }

    public void cancelDetectionAlertStatusNotification(){
        mNotificationManager.cancel(detectionAlertStatusNotificationId); //Cancel the notification with the help of the id Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity
        // Cancel the linked pending intent
        Intent resultIntent = new Intent(this, MainActivity.class);
        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                NOTIFICATION_DETECTION_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_NO_CREATE);
        resultPendingIntent.cancel();
    }

    private void initOnHoldStatusNotification(){
        onHoldStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.hearing_pause) //adding the icon
                        .setContentTitle(getString(R.string.StatusNotificationOnHoldTitle)) //adding the title
                        .setContentText(getString(R.string.StatusNotificationOnHoldMessage)) //adding the text
                        //Requires API 21 .setCategory(Notification.CATEGORY_STATUS)
                        .setOngoing(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(, MainActivity.class); //the intent is still the main-activity
        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                NOTIFICATION_STATUS_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT);

        onHoldStatusBuilder.setContentIntent(resultPendingIntent);

        notificationOnHoldStatus = onHoldStatusBuilder.build(); //build the notiviation
    }

    public void activateOnHoldStatusNotification(){
        if(onHoldStatusNotitificationFirstBuild){ //if it's the first time that it's built
            initOnHoldStatusNotification(); //initialize the notification
        }
        mNotificationManager.notify(onHoldStatusNotificationId, notificationOnHoldStatus); //activate the notification with the notification itself and its id
        onHoldStatusNotitificationFirstBuild = false; //notification is created
    }

    public void cancelOnHoldStatusNotification(){
        mNotificationManager.cancel(onHoldStatusNotificationId); //Cancel the notification with the help of the id
    }

    private void initScanningStatusNotification(){
        scanningStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(this)
                        .setSmallIcon(R.drawable.ic_hearing_white_48dp) //adding the icon
                        .setContentTitle(getString(R.string.StatusNotificationScanningTitle)) //adding the title
                        .setContentText(getString(R.string.StatusNotificationScanningMessage)) //adding the text
                        //Requires API 21 .setCategory(Notification.CATEGORY_SERVICE)
                        .setOngoing(true); //it's canceled when tapped on it

        Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                MainActivity.NOTIFICATION_STATUS_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT);

        scanningStatusBuilder.setContentIntent(resultPendingIntent);

        notificationScanningStatus = scanningStatusBuilder.build(); //build the notiviation
    }

    public void activateScanningStatusNotification(){
        if(scanningStatusNotitificationFirstBuild){ //if it's the first time that it's built
            initScanningStatusNotification(); //initialize the notification
        }
        mNotificationManager.notify(scanningStatusNotificationId, notificationScanningStatus); //activate the notification with the notification itself and its id
        scanningStatusNotitificationFirstBuild = false; //notification is created
    }

    public void cancelScanningStatusNotification(){
        mNotificationManager.cancel(scanningStatusNotificationId); //Cancel the notification with the help of the id
    }
*/
}
