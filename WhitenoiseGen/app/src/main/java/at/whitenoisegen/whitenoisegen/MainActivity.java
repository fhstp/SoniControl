package at.whitenoisegen.whitenoisegen;

import android.Manifest;
import android.content.pm.PackageManager;
import android.media.AudioFormat;
import android.media.AudioManager;
import android.media.AudioTrack;
import android.os.Handler;
import android.os.SystemClock;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.os.Bundle;
import android.widget.SeekBar;
import android.widget.TextView;
import java.util.Random;



public class MainActivity extends AppCompatActivity {


    int fs = 44100;
    int winLen;
    float cutoffFreq = 18000;
    int freqRes;

    Random randomGen = new Random();

    int winLenSamples;

    int cutoffFreqIdx;

    double max = 0;

    double[] complexWhiteNoise;
    double[] helpNoise;
    short[] whiteNoise;
    boolean noiseGenerated = false;

    Handler pulsingHandler = new Handler();
    private long start = 0;
    private long after = 0;
    private boolean playingGlobal = false;
    private boolean playingHandler = false;
    private boolean isFirstPlay;

    AudioTrack audioTrack;

    Button btnStop;
    Button btnStart;

    int whiteNoiseVolume;

    int spoofValue;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        TextView ampValue = (TextView)findViewById(R.id.textView4);
        ampValue.setText("0");

        btnStop = (Button) findViewById(R.id.btnStop);
        btnStart = (Button) findViewById(R.id.btnStart);
        btnStop.setEnabled(false);

        isFirstPlay = true;

        btnStart.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){

                int status = ActivityCompat.checkSelfPermission(MainActivity.this,
                        Manifest.permission.WRITE_EXTERNAL_STORAGE);
                if (status != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(
                            MainActivity.this,
                            new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                            0);
                }
                btnStart.setEnabled(false);
                btnStop.setEnabled(true);
                playingGlobal = true;
                playingHandler = false;
                isFirstPlay = true;
                onPulsing();
            }
        });

        btnStop.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                btnStop.setEnabled(false);
                btnStart.setEnabled(true);
                playingGlobal = false;
                isFirstPlay = false;
                startStop(false);
            }
        });

        final SeekBar pulseFader = (SeekBar)findViewById(R.id.pulseFader);
        if (pulseFader != null) pulseFader.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                winLen = (progress*30);
                spoofValue = progress;
                TextView pulseValue = (TextView)findViewById(R.id.textView4);
                pulseValue.setText(String.valueOf(progress*10));
                if(spoofValue==100){
                    pulseValue.setText("continuous spoofing");
                }
                if(playingGlobal) {
                    btnStop.setEnabled(false);
                    btnStart.setEnabled(true);
                    playingGlobal = false;
                    playingHandler = false;
                    start = 0;
                    stopWhitenoise();
                }
                noiseGenerated = false;
            }

            public void onStartTrackingTouch(SeekBar seekBar) {}

            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        final SeekBar volumeFader = (SeekBar)findViewById(R.id.volumeFader);
        if (volumeFader != null) volumeFader.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                whiteNoiseVolume = progress;
                TextView volumeValue = (TextView)findViewById(R.id.textView5);
                volumeValue.setText("Volume: " + String.valueOf(progress/10));
                if(playingGlobal) {
                    btnStop.setEnabled(false);
                    btnStart.setEnabled(true);
                    playingGlobal = false;
                    playingHandler = false;
                    start = 0;
                    stopWhitenoise();
                }
                noiseGenerated = false;
            }

            public void onStartTrackingTouch(SeekBar seekBar) {}

            public void onStopTrackingTouch(SeekBar seekBar) {}
        });

        final SeekBar cutoffFader = (SeekBar)findViewById(R.id.cutoffFader);
        if (cutoffFader != null) cutoffFader.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                cutoffFreq = (float)(progress*38*5.8026315);
                TextView cutoffValue = (TextView)findViewById(R.id.textView6);
                cutoffValue.setText("Cutoff: " + String.valueOf((int)(progress*38*5.8026315)));
                if(playingGlobal) {
                    btnStop.setEnabled(false);
                    btnStart.setEnabled(true);
                    playingGlobal = false;
                    playingHandler = false;
                    start = 0;
                    stopWhitenoise();
                }
                noiseGenerated = false;
            }

            public void onStartTrackingTouch(SeekBar seekBar) {}

            public void onStopTrackingTouch(SeekBar seekBar) {}
        });
    }

    public void onPulsing(){
        if(!noiseGenerated) {
            generateWhitenoise();
        }

        if (start == 0) {
            start = SystemClock.elapsedRealtime();
            after = SystemClock.elapsedRealtime();

            if (isFirstPlay) {
                playingHandler = !playingHandler;
                if(spoofValue == 100){ //Check if continuous spoofing active
                    startStop(true);
                }else {
                    startStop(playingHandler);
                }
                isFirstPlay = false;
            }

            onPulsing();
        } else {

            pulsingHandler.postDelayed(new Runnable() {
                public void run() {
                    if (playingGlobal) {
                        after = SystemClock.elapsedRealtime();

                        if ((after - start) >= winLen / 3) {
                            playingHandler = !playingHandler;
                            if(spoofValue == 100){ //Check if continuous spoofing active
                                startStop(false);
                                startStop(true);
                            }else {
                                startStop(playingHandler);
                            }
                        }

                        start = 0;
                        onPulsing();
                    }

                }
            }, winLen / 3);
        }
    }

    public void generateWhitenoise(){
        if (winLen==0){winLen= 10;}
        freqRes = (fs/2)/(winLen*(fs/1000));

        cutoffFreqIdx = Math.round(cutoffFreq/(fs/2)*(winLen*fs/1000)+1);
        winLenSamples = winLen*fs/1000;

        if(winLenSamples%2 == 1){
            winLenSamples+=1;
        }

        TextView txtWinLenSamples = (TextView)findViewById(R.id.textViewReal);
        txtWinLenSamples.setText("WinLenSamples: " + String.valueOf(winLenSamples));
        TextView txtcutoffFreqIdx = (TextView)findViewById(R.id.textView);
        txtcutoffFreqIdx.setText("CutoffFreqIdx: " + String.valueOf(cutoffFreqIdx));
        TextView txtcutoffFreq = (TextView)findViewById(R.id.textView2);
        txtcutoffFreq.setText("CutoffFreq: " + String.valueOf(cutoffFreq));
        TextView txtfs = (TextView)findViewById(R.id.textView3);
        txtfs.setText("FS: " + String.valueOf(fs));

        double[] signal = new double[winLenSamples];

        //randomGen.setSeed(123123); //fixed seed, without setSeed completely random numbers

        for(int j=0;j<winLenSamples;j++){
            signal[j] = randomGen.nextDouble();
        }

        complexWhiteNoise = doFFT(winLenSamples, signal);

        for(int i = 0; i < (winLenSamples*2); i++){
            if(Math.abs(complexWhiteNoise[i]) > max){
                max = Math.abs(complexWhiteNoise[i]);
            }
        }

        helpNoise = new double[winLenSamples];
        int noiseCounter = 0;
        for(int l = 0; l < (winLenSamples*2); l++){
            if(l%2==0){
                helpNoise[noiseCounter] = (complexWhiteNoise[l]/max);
                noiseCounter++;
            }
        }

        whiteNoise = new short[winLenSamples];

        for(int i = 0; i < winLenSamples; i++){
            whiteNoise[i] = (short)(helpNoise[i]*32767);
        }

/*
        int fadeSamples = whiteNoise.length/2;
        //int fadeSamples = 1000;
        for(int i = 0; i < fadeSamples; i++){
            whiteNoise[i] = (short)(whiteNoise[i]*(i/(double)fadeSamples));
            whiteNoise[whiteNoise.length - 1 - i] = (short)(whiteNoise[whiteNoise.length - 1 - i]*(i/(double)fadeSamples));
        }
*/
        generatePlayer();
        changeWhiteNoiseVolume();
        noiseGenerated = true;
    }

    public void generatePlayer(){
        audioTrack = new AudioTrack(AudioManager.STREAM_MUSIC,fs, AudioFormat.CHANNEL_CONFIGURATION_MONO, AudioFormat.ENCODING_PCM_16BIT,winLenSamples,AudioTrack.MODE_STATIC);
        audioTrack.write(whiteNoise,0,winLenSamples);
    }

    private double[] doFFT(int fftSize, double[] inputSignal) {

        DoubleFFT_1D mFFT = new DoubleFFT_1D(fftSize);

        double[] complexSignal = new double[winLenSamples * 2];

        System.arraycopy(inputSignal, 0, complexSignal, 0, winLenSamples);

        mFFT.realForwardFull(complexSignal);

        for(int j=0;j<=cutoffFreqIdx;j++){
            complexSignal[j]= 0.0f;
        }

        int helpWinLenSamples = winLenSamples*2;
        for(int j=(helpWinLenSamples-cutoffFreqIdx);j<helpWinLenSamples;j++){
            complexSignal[j]= 0.0f;
        }

        for(int i = 0; i < complexSignal.length-1;i++){
            complexSignal[i] = complexSignal[i]*(-1);
        }

        mFFT.complexForward(complexSignal);

        return complexSignal;
    }

    private void playWhitenoise(){
        audioTrack.play();
    }

    private void stopWhitenoise(){
        audioTrack.stop();
    }

    public void startStop(boolean playStatus){
        if(playStatus){
            playWhitenoise();;
        } else{
            stopWhitenoise();
        }
    }

    private void changeWhiteNoiseVolume(){
        audioTrack.setVolume(whiteNoiseVolume);
    }
}
