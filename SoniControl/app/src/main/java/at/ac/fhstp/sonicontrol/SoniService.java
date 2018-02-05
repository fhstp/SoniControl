package at.ac.fhstp.sonicontrol;

import android.app.Notification;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.support.annotation.Nullable;
import android.support.v4.app.NotificationCompat;
import android.util.Log;
import android.widget.Toast;


public class SoniService extends Service {
    private static final String LOG_TAG = "ForegroundService";
    public static boolean IS_SERVICE_RUNNING = false;

    @Override
    public void onCreate() {
        super.onCreate();
    }

    @Override
    public void onTaskRemoved(Intent rootIntent) {
        super.onTaskRemoved(rootIntent);
        Log.i(LOG_TAG, "Task removed!!!");
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        if (ServiceConstants.ACTION.STARTFOREGROUND_ACTION.equals(intent.getAction())) {
            Log.i(LOG_TAG, "Received Start Foreground Intent ");
            showNotification();
            Toast.makeText(this, "Service Started!", Toast.LENGTH_SHORT).show();

        } else if (ServiceConstants.ACTION.STOPFOREGROUND_ACTION.equals(intent.getAction())) {
            Log.i(LOG_TAG, "Received Stop Foreground Intent");
            stopForeground(true);
            stopSelf();
        }
        return START_STICKY;
    }

    private void showNotification() {
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

        startForeground(ServiceConstants.NOTIFICATION_ID.FOREGROUND_SERVICE,
                notification);

    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        Log.i(LOG_TAG, "In onDestroy");
        Toast.makeText(this, "Service Detroyed!", Toast.LENGTH_SHORT).show();
    }

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
}
