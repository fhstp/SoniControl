/*
 * Copyright (c) 2018. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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
import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.IBinder;
import android.preference.PreferenceManager;
import android.support.annotation.Nullable;
import android.support.v4.app.NotificationCompat;
import android.support.v4.app.NotificationManagerCompat;
import android.util.Log;
import android.widget.ImageButton;
import android.widget.Toast;

import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;


public class SoniService extends Service {
    private static final String LOG_TAG = "ForegroundService";
    public static boolean IS_SERVICE_RUNNING = false;

    // Thread handling
    private static int NUMBER_OF_CORES = Runtime.getRuntime().availableProcessors();
    public static final ScheduledExecutorService threadPool = Executors.newScheduledThreadPool(NUMBER_OF_CORES + 1);

    private boolean keepPrintingAliveness = true;

    @Override
    public void onCreate() {
        super.onCreate();
    }

    @Override
    public void onTaskRemoved(Intent rootIntent) {
        super.onTaskRemoved(rootIntent);
        //Log.i(LOG_TAG, "Task removed!!!");
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        if(intent == null){
            Intent service = new Intent(getApplicationContext(), SoniService.class);
            service.setAction(ServiceConstants.ACTION.STOPFOREGROUND_ACTION);
            SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
            SharedPreferences.Editor ed = sp.edit();
            ed.putString(ConfigConstants.PREFERENCES_APP_STATE, StateEnum.ON_HOLD.toString());
            ed.apply();
        }else if (ServiceConstants.ACTION.STARTFOREGROUND_ACTION.equals(intent.getAction())) {
            //Log.i(LOG_TAG, "Received Start Foreground Intent ");
            showNotification();
            SoniService.IS_SERVICE_RUNNING = true;
            //Toast.makeText(this, "Service Started!", Toast.LENGTH_SHORT).show();
/*
            threadPool.execute(new Runnable() {
                @Override
                public void run() {
                    boolean interrupted = false;
                    while (keepPrintingAliveness && !interrupted) {
                        Log.d(LOG_TAG, "background thread in Foreground Service alive.");
                        try {
                            Thread.sleep(1000);
                        } catch (InterruptedException e) {
                            interrupted = true;
                            e.printStackTrace();
                        }
                    }
                }
            });
*/
        } else if (ServiceConstants.ACTION.STOPFOREGROUND_ACTION.equals(intent.getAction())) {
            //Log.i(LOG_TAG, "Received Stop Foreground Intent");
            SoniService.IS_SERVICE_RUNNING = false;
            stopForeground(true);
            stopSelf();
        }
        return START_STICKY;
    }

    private void showNotification() {
        NotificationHelper.mNotificationManager = NotificationManagerCompat.from(getApplicationContext());
/*
        Intent notificationIntent = new Intent(this, MainActivity.class);
        notificationIntent.setAction(ServiceConstants.ACTION.MAIN_ACTION);
        notificationIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK
                | Intent.FLAG_ACTIVITY_CLEAR_TASK);
        PendingIntent pendingIntent = PendingIntent.getActivity(this, 0,
                notificationIntent, 0);

        Notification notification = new NotificationCompat.Builder(this)
                .setContentTitle("SoniControl Firewall")
                .setTicker("SoniControl Firewall")
                .setContentText("The Firewall has started.")
                .setSmallIcon(R.drawable.ic_hearing_white_48dp)
                .setContentIntent(pendingIntent)
                .setOngoing(true).build();
*/


        startForeground(NotificationHelper.NOTIFICATION_STATUS_ID,
                NotificationHelper.initScanningStatusNotification(getApplicationContext()));

    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        //Log.i(LOG_TAG, "In onDestroy");
        //Toast.makeText(this, "Service Destroyed!", Toast.LENGTH_SHORT).show();
        keepPrintingAliveness = false;
    }

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
}
