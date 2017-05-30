package com.superpowered.spoofer;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.media.AudioManager;
import android.content.Context;
import android.content.res.AssetFileDescriptor;
import java.io.IOException;
import android.os.Build;
import android.widget.SeekBar;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Button;
import android.view.View;
import android.widget.TextView;


import android.os.SystemClock;
import android.widget.Chronometer;
import android.os.Handler;

import org.w3c.dom.Text;


public class MainActivity extends AppCompatActivity {
    boolean playing = false;

    private int valueOfPulses;

    Chronometer mChronometer;
    private long start = 0;
    private long after = 0;
    private long stop = 0;
    private long totalPauseTime =0;
    private boolean pulsing = false;
    private boolean playTest = false;
    private boolean shouldStart = false;
    private boolean shouldStop = false;
    private boolean shouldPulse = false;
    Handler pulsingHandler = new Handler();



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Get the device's sample rate and buffer size to enable low-latency Android audio output, if available.
        String samplerateString = null, buffersizeString = null;
        if (Build.VERSION.SDK_INT >= 17) {
            AudioManager audioManager = (AudioManager) this.getSystemService(Context.AUDIO_SERVICE);
            samplerateString = audioManager.getProperty(AudioManager.PROPERTY_OUTPUT_SAMPLE_RATE);
            buffersizeString = audioManager.getProperty(AudioManager.PROPERTY_OUTPUT_FRAMES_PER_BUFFER);
        }
        if (samplerateString == null) samplerateString = "44100";
        if (buffersizeString == null) buffersizeString = "512";



        TextView highValue = (TextView)findViewById(R.id.txtHighValue);
        highValue.setText("0 Hz");
        TextView ampValue = (TextView)findViewById(R.id.txtAmpValue);
        ampValue.setText("0 ");
        final TextView pulseValue = (TextView)findViewById(R.id.txtPulseValue);
        pulseValue.setText("10 ms");
        //TextView pauseValue = (TextView)findViewById(R.id.txtPauseValue);
        //pauseValue.setText("0 ms");

        // Files under res/raw are not zipped, just copied into the APK. Get the offset and length to know where our files are located.
        //AssetFileDescriptor fd0 = getResources().openRawResourceFd(R.raw.lycka), fd1 = getResources().openRawResourceFd(R.raw.nuyorica);
        AssetFileDescriptor fd0 = getResources().openRawResourceFd(R.raw.nearby), fd1 = getResources().openRawResourceFd(R.raw.stille);
        int fileAoffset = (int)fd0.getStartOffset(), fileAlength = (int)fd0.getLength(), fileBoffset = (int)fd1.getStartOffset(), fileBlength = (int)fd1.getLength();
        try {
            fd0.getParcelFileDescriptor().close();
            fd1.getParcelFileDescriptor().close();
        } catch (IOException e) {
            android.util.Log.d("", "Close error.");
        }

        // Arguments: path to the APK file, offset and length of the two resource files, sample rate, audio buffer size.
        SuperpoweredExample(Integer.parseInt(samplerateString), Integer.parseInt(buffersizeString), getPackageResourcePath(), fileAoffset, fileAlength, fileBoffset, fileBlength);

        // high fader
        final SeekBar bpHighFader = (SeekBar)findViewById(R.id.bpHighFader);
        if (bpHighFader != null) bpHighFader.setOnSeekBarChangeListener(new OnSeekBarChangeListener() {
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                onCutOffFader(progress);
                TextView highValue = (TextView)findViewById(R.id.txtHighValue);
                highValue.setText(String.valueOf((int)(progress*38*5.8026315)) + " Hz");
            }

            public void onStartTrackingTouch(SeekBar seekBar) {}
            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        // amplitude fader
        final SeekBar ampFader = (SeekBar)findViewById(R.id.ampFader);
        if (ampFader != null) ampFader.setOnSeekBarChangeListener(new OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                onAmplitudeFader(progress);
                TextView ampValue = (TextView)findViewById(R.id.txtAmpValue);
                ampValue.setText(String.valueOf(progress/10) + " ");

            }

            public void onStartTrackingTouch(SeekBar seekBar) {}

            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        // pulse fader
        final SeekBar pulseFader = (SeekBar)findViewById(R.id.pulseFader);
        if (pulseFader != null) pulseFader.setOnSeekBarChangeListener(new OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                valueOfPulses = (progress*10);
                //onPulseFader(progress);
                TextView pulseValue = (TextView)findViewById(R.id.txtPulseValue);
                pulseValue.setText(String.valueOf(progress*10) + " ms");
            }

            public void onStartTrackingTouch(SeekBar seekBar) {}

            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        //pause fader
        /*final SeekBar pauseFader = (SeekBar)findViewById(R.id.pauseFader);
        if (pauseFader != null) pauseFader.setOnSeekBarChangeListener(new OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                //onPauseFader(progress);
                TextView pauseFader = (TextView)findViewById(R.id.txtPauseValue);
                pauseFader.setText(String.valueOf(progress*10) + " ms");
            }

            public void onStartTrackingTouch(SeekBar seekBar) {
                onFxValue(seekBar.getProgress());
            }

            public void onStopTrackingTouch(SeekBar seekBar) {
                onFxOff();
            }
        });*/


        final RadioGroup group = (RadioGroup)findViewById(R.id.radioGroup1);
        if (group != null) group.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            public void onCheckedChanged(RadioGroup radioGroup, int checkedId) {
                RadioButton checkedRadioButton = (RadioButton)radioGroup.findViewById(checkedId);
                onFxSelect(radioGroup.indexOfChild(checkedRadioButton));
                //TextView HighFader = (TextView)findViewById(R.id.txtHighFader);
                //HighFader.setText(String.valueOf(radioGroup.indexOfChild(checkedRadioButton)));
            }
        });

    }




    public void onPulsing(){

        if(shouldPulse) {
            if(valueOfPulses==0){valueOfPulses= 10;}
            if (start == 0) {
                start = SystemClock.elapsedRealtime();
                after = SystemClock.elapsedRealtime();
                onPulsing();
            } else {
                //SystemClock.sleep(valueOfPulses);
                pulsingHandler.postDelayed(new Runnable() {
                    public void run() {
                        if(playing) {
                            after = SystemClock.elapsedRealtime();

                            if ((after - start) >= valueOfPulses) {
                                playTest = !playTest;
                                onPlayPause(playTest);
                                start = 0;
                            }
                            onPulsing();
                        }
                    }
                }, valueOfPulses);
            }
        }
    }

    public void stopPulsing(){
        try {
            onPlayPause(false);
            start = 0;
        }catch (Exception e){
            e.printStackTrace();
        }
    }


    public void SuperpoweredExample_PlayPause(View button) {  // Play/pause.
        playing = !playing;
        onPlayPause(playing);
        Button b = (Button) findViewById(R.id.PlayPause);
        if (b != null) b.setText(playing ? "PAUSE" : "PLAY");

        Button e = (Button)findViewById(R.id.spamPlay);
        if(playing && e!= null){
            e.setEnabled(false);
        }
        if(!playing && e!= null){
            e.setEnabled(true);
        }

            if(playing) {
                shouldPulse = true;
                playTest = true;
                onPulsing();

            }
            if(!playing){
                shouldPulse = false;
                stopPulsing();
            }


    }

    public void SuperpoweredExample_spamPlay(View button) {  // Play/pause.
        playing = !playing;
        onPlayPause(playing);
        Button b = (Button) findViewById(R.id.spamPlay);
        if (b != null) b.setText(playing ? "STOP" : "SPAM");

        Button e = (Button)findViewById(R.id.PlayPause);
        TextView pv = (TextView)findViewById(R.id.txtPulseValue);
        TextView pt = (TextView)findViewById(R.id.textView3);
        SeekBar s = (SeekBar)findViewById(R.id.pulseFader);
        if(playing && e!= null && pv!= null && pt!= null && s!= null){
            e.setEnabled(false);
            pv.setEnabled(false);
            pt.setEnabled(false);
            s.setEnabled(false);
        }
        if(!playing && e!= null && pv!= null && pt!= null && s!= null){
            e.setEnabled(true);
            pv.setEnabled(true);
            pt.setEnabled(true);
            s.setEnabled(true);
        }
    }

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

    private native void SuperpoweredExample(int samplerate, int buffersize, String apkPath, int fileAoffset, int fileAlength, int fileBoffset, int fileBlength);
    private native void onPlayPause(boolean play);
    private native void onCutOffFader(int value);

    private native void onAmplitudeFader(int value);
    /*private native void onPulseFader(int value);
    private native void onPauseFader(int value);*/

    private native void onFxSelect(int value);
    private native void onFxOff();
    private native void onFxValue(int value);

    static {
        System.loadLibrary("SuperpoweredExample");
    }
}
