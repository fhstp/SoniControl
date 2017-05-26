package com.superpowered.frequencydomain;

import android.content.Context;
import android.media.AudioManager;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;
import android.os.Handler;


public class MainActivity extends AppCompatActivity {


    Handler handler = new Handler();
    TextView rmsf;
    TextView rmst;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        rmsf = (TextView)findViewById(R.id.textRmsf);
        rmst = (TextView)findViewById(R.id.textRmst);
        TextView buffer = (TextView)findViewById(R.id.textBuffer);
        TextView sampleRate = (TextView)findViewById(R.id.textSampleRate);

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

        FrequencyDomain(Integer.parseInt(samplerateString), Integer.parseInt(buffersizeString));
        handler.post(runnableCode);
    }

    private Runnable runnableCode = new Runnable() {
        @Override
        public void run() {
            // Do something here on the main thread
            rmsf.setText(""+GetRmsfReading());
            rmst.setText(""+GetRmstReading());
            // Repeat this the same runnable code block again another 0.2 seconds
            handler.postDelayed(runnableCode, 100);
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

    private native void FrequencyDomain(int samplerate, int buffersize);
    private native float GetRmsfReading();
    private native float GetRmstReading();
    private native int SetNewCutFrequency(int f);
}
