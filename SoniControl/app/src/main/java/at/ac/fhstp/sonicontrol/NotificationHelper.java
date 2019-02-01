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

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build;
import android.support.v4.app.NotificationCompat;
import android.support.v4.app.NotificationManagerCompat;

/**
 * Created by aringot on 06.02.2018.
 */

public class NotificationHelper {
    private static final int NOTIFICATION_STATUS_REQUEST_CODE = 2;
    private static final int NOTIFICATION_DETECTION_REQUEST_CODE = 1;

    public static final int NOTIFICATION_STATUS_ID = 2;
    private static final int NOTIFICATION_DETECTION_ID = 1;

    public static final String NOTIFICATION_STATUS_CHANNEL_ID = "2";
    private static final String NOTIFICATION_DETECTION_CHANNEL_ID = "1";

    private static NotificationCompat.Builder spoofingStatusBuilder;
    private static NotificationCompat.Builder detectionAlertStatusBuilder;
    private static NotificationCompat.Builder onHoldStatusBuilder;
    private static NotificationCompat.Builder scanningStatusBuilder;

    private static Notification notificationDetectionAlertStatus;
    private static Notification notificationSpoofingStatus;
    private static Notification notificationOnHoldStatus;
    private static Notification notificationScanningStatus;

    private static boolean spoofingStatusNotitificationFirstBuild = true;
    private static boolean onHoldStatusNotitificationFirstBuild = true;
    private static boolean scanningStatusNotitificationFirstBuild = true;

    private static PendingIntent getPendingIntentDetectionFlagUpdateCurrent(Context context, Technology technology) {
        Intent resultIntent = new Intent(context, MainActivity.class); //the intent is still the main-activity
        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
        resultIntent.putExtra(ConfigConstants.EXTRA_TECHNOLOGY_DETECTED, technology);

        return PendingIntent.getActivity(
                context,
                NOTIFICATION_DETECTION_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT);//Now canceled in activateALert()  | PendingIntent.FLAG_ONE_SHOT);

    }

    /**
     * Used either to cancel the pending intent or to check if it is currently pending.
     * Should always match the intent from {@link #getPendingIntentDetectionFlagUpdateCurrent(Context, Technology)}
     * (same operation, same Intent action, data, categories, and components, and same flags)
     * See : <a href="https://developer.android.com/reference/android/app/PendingIntent.html">Pending Intent documentation</a>
     * @param context
     * @return DetectionPendingIntent if it is pending, null otherwise
     */
    public static PendingIntent getPendingIntentDetectionFlagNoCreate(Context context) {
        Intent resultIntent = new Intent(context, MainActivity.class); //the intent is still the main-activity
        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
        return PendingIntent.getActivity(
                context,
                NOTIFICATION_DETECTION_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_NO_CREATE);
    }

    private static PendingIntent getPendingIntentStatusFlagUpdateCurrent(Context context) {
        Intent resultIntent = new Intent(context, MainActivity.class); //the intent is still the main-activity
        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        return PendingIntent.getActivity(
                context,
                NOTIFICATION_STATUS_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT);
    }

    /**
     * Used either to cancel the pending intent or to check if it is currently pending.
     * Should always match the intent from {@link #getPendingIntentStatusFlagUpdateCurrent(Context)}
     * (same operation, same Intent action, data, categories, and components, and same flags)
     * See : <a href="https://developer.android.com/reference/android/app/PendingIntent.html">Pending Intent documentation</a>
     * @param context
     * @return StatusPendingIntent if it is pending, null otherwise
     */
    public static PendingIntent getPendingIntentStatusNoCreate(Context context) {
        Intent resultIntent = new Intent(context, MainActivity.class); //the intent is still the main-activity
        resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
        return PendingIntent.getActivity(
                context,
                NOTIFICATION_STATUS_REQUEST_CODE,
                resultIntent,
                PendingIntent.FLAG_NO_CREATE);
    }

    /**
     * Creates the status notification channel for Android O and above. Ignored on older versions.
     * @param context
     */
    private static void createStatusNotificationChannel(Context context) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            NotificationManager notificationManagerOreoAbove = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
            int channelImportance = NotificationManager.IMPORTANCE_LOW;
            NotificationChannel statusChannel = new NotificationChannel(NOTIFICATION_STATUS_CHANNEL_ID, context.getString(R.string.statusChannelName), channelImportance);
            notificationManagerOreoAbove.createNotificationChannel(statusChannel);
        }
    }

    /**
     * Creates the detection notification channel for Android O and above. Ignored on older versions.
     * @param context
     */
    private static void createDetectionNotificationChannel(Context context) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            NotificationManager notificationManagerOreoAbove = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
            int channelImportance = NotificationManager.IMPORTANCE_HIGH;
            NotificationChannel detectionChannel = new NotificationChannel(NOTIFICATION_DETECTION_CHANNEL_ID, context.getString(R.string.detectionChannelName), channelImportance);
            notificationManagerOreoAbove.createNotificationChannel(detectionChannel);
        }
    }

    private static void initSpoofingStatusNotification(Context context){
        createStatusNotificationChannel(context);

        // Notification Channel Id is ignored for Android pre O (26).
        spoofingStatusBuilder =
                new NotificationCompat.Builder(context, NOTIFICATION_STATUS_CHANNEL_ID)
                        .setSmallIcon(R.drawable.hearing_block) //adding the icon
                        .setContentTitle(context.getString(R.string.StatusNotificationSpoofingTitle)) //adding the title
                        .setContentText(context.getString(R.string.StatusNotificationSpoofingMesssage)) //adding the text
                        .setPriority(NotificationCompat.PRIORITY_LOW) // Required for Android 7.1 and lower
                        //Requires API 21 .setCategory(Notification.CATEGORY_SERVICE)
                        .setOngoing(true); //it's canceled when tapped on it

        PendingIntent resultPendingIntent = getPendingIntentStatusFlagUpdateCurrent(context);

        spoofingStatusBuilder.setContentIntent(resultPendingIntent);

        notificationSpoofingStatus = spoofingStatusBuilder.build(); //build the notification
    }

    public static void activateSpoofingStatusNotification(Context context){
        if(spoofingStatusNotitificationFirstBuild){ //if it's the first time that it's built
            initSpoofingStatusNotification(context); //initialize the notification
        }

        getNotificationManager(context).notify(NOTIFICATION_STATUS_ID, notificationSpoofingStatus); //activate the notification with the notification itself and its id

        spoofingStatusNotitificationFirstBuild = false; //notification is created
    }

    private static void initDetectionAlertStatusNotification(Context context, Technology technology){
        createDetectionNotificationChannel(context);

        Uri alarmSound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);

        detectionAlertStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(context, NOTIFICATION_DETECTION_CHANNEL_ID)
                        .setSmallIcon(R.drawable.hearing_found)
                        .setContentTitle(context.getString(R.string.StatusNotificationDetectionAlertTitle))
                        .setContentText(context.getString(R.string.StatusNotificationDetectionAlertMessage))
                        //Requires API 21 .setCategory(Notification.CATEGORY_STATUS)
                        .setOngoing(true) // cannot be dismissed
                        .setPriority(Notification.PRIORITY_HIGH)
                        //Now canceled in activateALert() .setAutoCancel(true) //it's canceled when tapped on it
                        .setSound(alarmSound);

        PendingIntent resultPendingIntent = getPendingIntentDetectionFlagUpdateCurrent(context, technology);

        detectionAlertStatusBuilder.setContentIntent(resultPendingIntent);

        notificationDetectionAlertStatus = detectionAlertStatusBuilder.build(); //build the notiviation
    }

    public static void activateDetectionAlertStatusNotification(Context context, Technology technology){
        initDetectionAlertStatusNotification(context, technology); //initialize the notification

        getNotificationManager(context).notify(NOTIFICATION_DETECTION_ID, notificationDetectionAlertStatus); //activate the notification with the notification itself and its id
    }

    public static void cancelDetectionAlertStatusNotification(Context context){
        getNotificationManager(context).cancel(NOTIFICATION_DETECTION_ID); //Cancel the notification with the help of the id Intent resultIntent = new Intent(this, MainActivity.class); //the intent is still the main-activity

        // Cancel the linked pending intent
        PendingIntent resultPendingIntent = getPendingIntentDetectionFlagNoCreate(context);
        if (resultPendingIntent != null)
            resultPendingIntent.cancel();
    }

    private static void initOnHoldStatusNotification(Context context){
        createStatusNotificationChannel(context);

        onHoldStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(context, NOTIFICATION_STATUS_CHANNEL_ID)
                        .setSmallIcon(R.drawable.hearing_pause) //adding the icon
                        .setContentTitle(context.getString(R.string.StatusNotificationOnHoldTitle)) //adding the title
                        .setContentText(context.getString(R.string.StatusNotificationOnHoldMessage)) //adding the text
                        .setPriority(NotificationCompat.PRIORITY_LOW) // Required for Android 7.1 and lower
                        //Requires API 21 .setCategory(Notification.CATEGORY_STATUS)
                        .setOngoing(true); //it's canceled when tapped on it

        PendingIntent resultPendingIntent = getPendingIntentStatusFlagUpdateCurrent(context);

        onHoldStatusBuilder.setContentIntent(resultPendingIntent);

        notificationOnHoldStatus = onHoldStatusBuilder.build(); //build the notification
    }

    public static void activateOnHoldStatusNotification(Context context){
        if(onHoldStatusNotitificationFirstBuild){ //if it's the first time that it's built
            initOnHoldStatusNotification(context); //initialize the notification
        }

        getNotificationManager(context).notify(NOTIFICATION_STATUS_ID, notificationOnHoldStatus); //activate the notification with the notification itself and its id

        onHoldStatusNotitificationFirstBuild = false; //notification is created
    }

    public static void cancelStatusNotification(Context context){
        getNotificationManager(context).cancel(NOTIFICATION_STATUS_ID); //Cancel the notification with the help of the id
    }

    public static Notification initScanningStatusNotification(Context context){
        createStatusNotificationChannel(context);

        scanningStatusBuilder = //create a builder for the detection notification
                new NotificationCompat.Builder(context, NOTIFICATION_STATUS_CHANNEL_ID)
                        .setSmallIcon(R.drawable.ic_hearing_white_48dp) //adding the icon
                        .setContentTitle(context.getString(R.string.StatusNotificationScanningTitle)) //adding the title
                        .setContentText(context.getString(R.string.StatusNotificationScanningMessage)) //adding the text
                        .setPriority(NotificationCompat.PRIORITY_LOW) // Required for Android 7.1 and lower
                        //Requires API 21 .setCategory(Notification.CATEGORY_SERVICE)
                        .setOngoing(true); //it's canceled when tapped on it

        PendingIntent resultPendingIntent = getPendingIntentStatusFlagUpdateCurrent(context);

        scanningStatusBuilder.setContentIntent(resultPendingIntent);

        notificationScanningStatus = scanningStatusBuilder.build(); //build the notification
        return notificationScanningStatus;
    }

    public static void activateScanningStatusNotification(Context context){
        if(scanningStatusNotitificationFirstBuild){ //if it's the first time that it's built
            initScanningStatusNotification(context); //initialize the notification
        }

        getNotificationManager(context).notify(NOTIFICATION_STATUS_ID, notificationScanningStatus); //activate the notification with the notification itself and its id

        scanningStatusNotitificationFirstBuild = false; //notification is created
    }

    private static NotificationManagerCompat getNotificationManager(Context context) {
        return NotificationManagerCompat.from(context.getApplicationContext());
    }
}
