package com.superpowered.spoofer;

import android.Manifest;
import android.content.pm.PackageManager;
import android.content.res.Resources;
import android.net.Uri;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
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

import java.io.*;
import java.nio.*;
import android.media.*;

import android.os.SystemClock;
import android.widget.Chronometer;
import android.os.Handler;
import java.util.Timer;
import java.util.TimerTask;

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
    Handler fadeInHandler = new Handler();


    int x=0;


    Uri path;
    MediaPlayer _player = null;
    boolean isReadyForInternPlayer = false;
    boolean isPlayerGenerated = false;

    Context helpContext;


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



        helpContext = this;




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





        int status = ActivityCompat.checkSelfPermission(MainActivity.this,
                Manifest.permission.WRITE_EXTERNAL_STORAGE);
        if (status != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(
                    MainActivity.this,
                    new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                    0);
        }



    }




    public void onPulsing(){

        if(shouldPulse) {
            if(valueOfPulses==0){valueOfPulses= 10;}
            if (start == 0) {
                start = SystemClock.elapsedRealtime();
                after = SystemClock.elapsedRealtime();

                if(isReadyForInternPlayer && !isPlayerGenerated){
                    path = Uri.parse("android.resource://com.superpowered.spoofer/raw/");
                    File f1 = new File("/storage/emulated/0/DCIM/superpowered.pcm"); // The location of your PCM file
                    //File f2 = new File("android.resource://com.superpowered.spoofer/raw/superpowered.wav");
                    //File f2 = new File("android.resource://"+getPackageName() + "/superpowered.wav");
                    File f2 = new File("/storage/emulated/0/DCIM/superpowered.wav"); // The location where you want your WAV file
                    try {
                        rawToWave(f1, f2);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    Uri newPath = Uri.parse(f2.getAbsolutePath());
                    //boolean deleted = f1.delete();
                    //_player = MediaPlayer.create(this, R.raw.superpowered);
                    //_player = MediaPlayer.create(getApplicationContext(), newPath);
                    _player = MediaPlayer.create(helpContext, newPath);
                    _player.setLooping(true);
                    isPlayerGenerated = true;
                }

                onPulsing();
            } else {
                //SystemClock.sleep(valueOfPulses);
                pulsingHandler.postDelayed(new Runnable() {
                    public void run() {
                        if(playing) {
                            after = SystemClock.elapsedRealtime();

                            if (isReadyForInternPlayer){
                                playTest = !playTest;
                                startStopPlayer(playTest);
                            }


                            if ((after - start) >= valueOfPulses && !isReadyForInternPlayer) {
                                playTest = !playTest;
                                //fadeChange(true);
                                onPlayPause(playTest, false);



                                isReadyForInternPlayer = true;

                                //fadeChange(0.0f);
                                        //fadeChange(0.7f);


                            }

                            start = 0;

                            }
                            onPulsing();
                    }

                }, valueOfPulses);
            }


/*            if (playTest) {



                for(int i = 0; i == valueOfPulses; i++ ) {
                    x++;
                    fadeInHandler.postDelayed(new Runnable() {
                        public void run() {
                            fadeChange(((1/valueOfPulses)*x));
                        }
                    }, 1);
                }


            }*/
        }
    }

    public void stopPulsing(){
        try {
            //onPlayPause(false, false);
            startStopPlayer(false);
            isReadyForInternPlayer = false;
            isPlayerGenerated = false;



            start = 0;
            onFxOff();

        }catch (Exception e){
            e.printStackTrace();
        }
    }


    public void SuperpoweredExample_PlayPause(View button) {  // Play/pause.
        playing = !playing;
        onPlayPause(playing, true);
        Button b = (Button) findViewById(R.id.PlayPause);
        if (b != null) b.setText(playing ? "PAUSE" : "PLAY");

        SeekBar sp = (SeekBar)findViewById(R.id.pulseFader);
        SeekBar sb = (SeekBar)findViewById(R.id.bpHighFader);
        SeekBar sa = (SeekBar)findViewById(R.id.ampFader);





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

                if(sp!= null && sb!= null && sa!= null){
                    sp.setEnabled(false);
                    sb.setEnabled(false);
                    sa.setEnabled(false);
                }
            }
            if(!playing){
                shouldPulse = false;
                stopPulsing();

                if(sp!= null && sb!= null && sa!= null){
                    sp.setEnabled(true);
                    sb.setEnabled(true);
                    sa.setEnabled(true);
                }
            }


    }

    public void SuperpoweredExample_spamPlay(View button) {  // Play/pause.
        playing = !playing;
        onPlayPause(playing, true);
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


    //hier wav code

    private void rawToWave(final File rawFile, final File waveFile) throws IOException {
        byte[] rawData = new byte[(int) rawFile.length()];
        DataInputStream input = null;
        try {
            input = new DataInputStream(new FileInputStream(rawFile));
            input.read(rawData);
        } finally {
            if (input != null) {
                input.close();
            }
        }

        DataOutputStream output = null;
        try {
            output = new DataOutputStream(new FileOutputStream(waveFile));
            // WAVE header
            // see http://ccrma.stanford.edu/courses/422/projects/WaveFormat/
            writeString(output, "RIFF"); // chunk id
            writeInt(output, 36 + rawData.length); // chunk size
            writeString(output, "WAVE"); // format
            writeString(output, "fmt "); // subchunk 1 id
            writeInt(output, 16); // subchunk 1 size
            writeShort(output, (short) 1); // audio format (1 = PCM)
            writeShort(output, (short) 1); // number of channels
            writeInt(output, 44100); // sample rate
            final int RECORDER_SAMPLERATE = 44100;
            writeInt(output, RECORDER_SAMPLERATE * 2); // byte rate
            writeShort(output, (short) 2); // block align
            writeShort(output, (short) 16); // bits per sample
            writeString(output, "data"); // subchunk 2 id
            writeInt(output, rawData.length); // subchunk 2 size
            // Audio data (conversion big endian -> little endian)
            short[] shorts = new short[rawData.length / 2];
            ByteBuffer.wrap(rawData).order(ByteOrder.LITTLE_ENDIAN).asShortBuffer().get(shorts);
            ByteBuffer bytes = ByteBuffer.allocate(shorts.length * 2);
            for (short s : shorts) {
                bytes.putShort(s);
            }

            output.write(fullyReadFileToBytes(rawFile));
        } finally {
            if (output != null) {
                output.close();
            }
        }
    }
    byte[] fullyReadFileToBytes(File f) throws IOException {
        int size = (int) f.length();
        byte bytes[] = new byte[size];
        byte tmpBuff[] = new byte[size];
        FileInputStream fis= new FileInputStream(f);
        try {

            int read = fis.read(bytes, 0, size);
            if (read < size) {
                int remain = size - read;
                while (remain > 0) {
                    read = fis.read(tmpBuff, 0, remain);
                    System.arraycopy(tmpBuff, 0, bytes, size - remain, read);
                    remain -= read;
                }
            }
        }  catch (IOException e){
            throw e;
        } finally {
            fis.close();
        }

        return bytes;
    }
    private void writeInt(final DataOutputStream output, final int value) throws IOException {
        output.write(value >> 0);
        output.write(value >> 8);
        output.write(value >> 16);
        output.write(value >> 24);
    }

    private void writeShort(final DataOutputStream output, final short value) throws IOException {
        output.write(value >> 0);
        output.write(value >> 8);
    }

    private void writeString(final DataOutputStream output, final String value) throws IOException {
        for (int i = 0; i < value.length(); i++) {
            output.write(value.charAt(i));
        }
    }




    //hier Javaplayer

    private void startStopPlayer(boolean startStop){
        if (startStop) {
            _player.start();
            //startFadeIn();
        }
        if (!startStop){
            //startFadeOut();
            _player.pause();
            //_player.release();
        }
    }







    //hier fadeinout methods

    int volume = 0;

    private void startFadeIn(){
        final int FADE_DURATION = valueOfPulses/10; //The duration of the fade
        //The amount of time between volume changes.
        final int FADE_INTERVAL = 1;
        final int MAX_VOLUME = 1; //The volume will increase from 0 to 1
        int numberOfSteps = FADE_DURATION/FADE_INTERVAL; //Calculate the number of fade steps
        //Calculate by how much the volume changes each step
        final float deltaVolume = MAX_VOLUME / (float)numberOfSteps;

        //Create a new Timer and Timer task to run the fading outside the main UI thread
        final Timer timer = new Timer(true);
        TimerTask timerTask = new TimerTask() {
            @Override
            public void run() {
                fadeInStep(deltaVolume); //Do a fade step
                //Cancel and Purge the Timer if the desired volume has been reached
                if(volume>=1f){
                    timer.cancel();
                    timer.purge();
                }
            }
        };

        timer.schedule(timerTask,FADE_INTERVAL,FADE_INTERVAL);
    }

    private void fadeInStep(float deltaVolume){
        _player.setVolume(volume, volume);
        volume += deltaVolume;

    }

    private void startFadeOut(){
        final int FADE_DURATION = valueOfPulses/10; //The duration of the fade
        //The amount of time between volume changes.
        final int FADE_INTERVAL = 1;
        final int MAX_VOLUME = 0; //The volume will decresae from 1 to 0
        int numberOfSteps = FADE_DURATION/FADE_INTERVAL; //Calculate the number of fade steps
        //Calculate by how much the volume changes each step
        final float deltaVolume = MAX_VOLUME / (float)numberOfSteps;

        //Create a new Timer and Timer task to run the fading outside the main UI thread
        final Timer timer = new Timer(true);
        TimerTask timerTask = new TimerTask() {
            @Override
            public void run() {
                fadeOutStep(deltaVolume); //Do a fade step
                //Cancel and Purge the Timer if the desired volume has been reached
                if(volume<=0f){
                    timer.cancel();
                    timer.purge();
                }
            }
        };

        timer.schedule(timerTask,FADE_INTERVAL,FADE_INTERVAL);
    }

    private void fadeOutStep(float deltaVolume){
        _player.setVolume(volume, volume);
        volume -= deltaVolume;

    }













    private native void SuperpoweredExample(int samplerate, int buffersize, String apkPath, int fileAoffset, int fileAlength, int fileBoffset, int fileBlength);
    private native void onPlayPause(boolean play, boolean buttonPressed);
    private native void onCutOffFader(int value);

    private native void onAmplitudeFader(int value);
    /*private native void onPulseFader(int value);
    private native void onPauseFader(int value);*/

    private native void onFxSelect(int value);
    private native void onFxOff();
    private native void onFxValue(int value);
    private native void fadeChange(boolean value);

    static {
        System.loadLibrary("SuperpoweredExample");
    }
}
