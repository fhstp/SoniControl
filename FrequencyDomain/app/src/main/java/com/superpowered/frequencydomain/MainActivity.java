package com.superpowered.frequencydomain;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.media.AudioManager;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import com.jjoe64.graphview.GraphView;
import com.jjoe64.graphview.series.*;
import android.os.Bundle;
import android.support.v4.app.NotificationCompat;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.os.Handler;
import android.view.View.OnClickListener;
import android.view.View;

public class MainActivity extends AppCompatActivity {


    Handler handler = new Handler();
    int handlerRefreshMs = 20;

    TextView rmsf;
    TextView rmst;

    GraphView graphF;
    GraphView graphT;
    LineGraphSeries<DataPoint> rmsfSeries;
    LineGraphSeries<DataPoint> rmstSeries;
    LineGraphSeries<DataPoint> rmsfTresh;
    LineGraphSeries<DataPoint> rmstTresh;

    int runningX=0;
    int maxRunningX=500;
    float[] rmstFIFO;
    float[] rmsfFIFO;
    int meanOfS = 30;
    int maxFIFO;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        NotificationCompat.Builder mBuilder = new NotificationCompat.Builder(this)
                .setSmallIcon(R.mipmap.ic_launcher)
                .setContentTitle("Title");
        Intent resultIntent = new Intent(this, MainActivity.class);
        PendingIntent resultPendingIntent = PendingIntent.getActivity(
                this,
                0,
                resultIntent,
                PendingIntent.FLAG_UPDATE_CURRENT);
        mBuilder.setContentIntent(resultPendingIntent);
        Notification notification = mBuilder.build();
        notification.flags |= Notification.FLAG_NO_CLEAR | Notification.FLAG_ONGOING_EVENT;

        NotificationManager mNotifyMgr = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
        mNotifyMgr.notify(0, notification);

        graphF = (GraphView) findViewById(R.id.graphF);
        graphT = (GraphView) findViewById(R.id.graphT);

        rmsfSeries = new LineGraphSeries<>();
        rmsfSeries.setTitle("rmsF");
        rmsfSeries.setColor(Color.BLUE);
        rmsfSeries.setThickness(3);

        rmsfTresh = new LineGraphSeries<>();
        rmsfTresh.setTitle("rmsF Treshold");
        rmsfTresh.setColor(Color.BLUE);
        rmsfTresh.setThickness(1);

        rmstSeries = new LineGraphSeries<>();
        rmstSeries.setTitle("rmsT");
        rmstSeries.setColor(Color.GREEN);
        rmstSeries.setThickness(3);

        rmstTresh = new LineGraphSeries<>();
        rmstTresh.setTitle("rmsT Treshold");
        rmstTresh.setColor(Color.GREEN);
        rmstTresh.setThickness(1);

        graphF.addSeries(rmsfSeries);
        graphF.addSeries(rmsfTresh);
        graphF.getViewport().setXAxisBoundsManual(true);
        graphF.getViewport().setMinX(0.0);
        graphF.getViewport().setMaxX(maxRunningX + 50.0);
        graphF.getGridLabelRenderer().setHorizontalLabelsVisible(false);

        graphT.addSeries(rmstSeries);
        graphT.addSeries(rmstTresh);
        graphT.getViewport().setXAxisBoundsManual(true);
        graphT.getViewport().setMinX(0.0);
        graphT.getViewport().setMaxX(maxRunningX + 50.0);
        graphT.getGridLabelRenderer().setHorizontalLabelsVisible(false);

        rmsf = (TextView)findViewById(R.id.textRmsf);
        rmst = (TextView)findViewById(R.id.textRmst);
        TextView buffer = (TextView)findViewById(R.id.textBuffer);
        TextView sampleRate = (TextView)findViewById(R.id.textSampleRate);

        Button clickButton = (Button) findViewById(R.id.SetCutF);
        final EditText inputFreq = (EditText) findViewById(R.id.inputCutF);
        clickButton.setOnClickListener( new OnClickListener() {
            @Override
            public void onClick(View v) {
                SetNewCutFrequency(Integer.parseInt(inputFreq.getText().toString()));
            }
        });

        // Get the device's sample rate and buffer size to enable low-latency Android audio output, if available.
        String samplerateString = null, buffersizeString = null;
        if (Build.VERSION.SDK_INT >= 17) {
            AudioManager audioManager = (AudioManager) this.getSystemService(Context.AUDIO_SERVICE);
            samplerateString = audioManager.getProperty(AudioManager.PROPERTY_OUTPUT_SAMPLE_RATE);
            buffersizeString = audioManager.getProperty(AudioManager.PROPERTY_OUTPUT_FRAMES_PER_BUFFER);
        }
        if (samplerateString == null) samplerateString = "44100";
        if (buffersizeString == null) buffersizeString = "512";

        buffer.setText(buffersizeString);
        sampleRate.setText(samplerateString);
        System.loadLibrary("SuperpoweredExample");

        maxFIFO = (1000/handlerRefreshMs)*meanOfS;
        rmsfFIFO = new float[maxFIFO];
        rmstFIFO = new float[maxFIFO];

        FrequencyDomain(Integer.parseInt(samplerateString), Integer.parseInt(buffersizeString));
        handler.post(runnableCode);
    }

    private Runnable runnableCode = new Runnable() {
        @Override
        public void run() {
            // Do something here on the main thread
            float fReading = GetRmsfReading();
            float tReading = GetRmstReading();
            rmsf.setText(""+fReading);
            rmst.setText(""+tReading);

            rmsfSeries.appendData(new DataPoint(runningX, fReading), false, maxRunningX);
            rmstSeries.appendData(new DataPoint(runningX, tReading), false, maxRunningX);

            rmsfFIFO[runningX%maxFIFO] = fReading;
            rmsfFIFO[runningX%maxFIFO] = fReading;

            if(runningX>=maxFIFO)
            {
                rmsfTresh.appendData(new DataPoint(runningX, Mean(rmsfFIFO)), false, maxRunningX);
                rmstTresh.appendData(new DataPoint(runningX, Mean(rmstFIFO)), false, maxRunningX);
            }

            if(runningX>=maxRunningX)
            {
                graphF.getViewport().setMinX(0.0 + runningX - maxRunningX);
                graphF.getViewport().setMaxX(50.0 + runningX );

                graphT.getViewport().setMinX(0.0 + runningX - maxRunningX);
                graphT.getViewport().setMaxX(50.0 + runningX );
            }
            runningX++;
            handler.postDelayed(runnableCode, handlerRefreshMs);
        }
    };

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public static float Mean(float[] m) {
        float sum = 0;
        for (int i = 0; i < m.length; i++) {
            sum += m[i];
        }
        return sum / m.length;
    }

    private native void FrequencyDomain(int samplerate, int buffersize);
    private native float GetRmsfReading();
    private native float GetRmstReading();
    private native void SetNewCutFrequency(int f);
}
