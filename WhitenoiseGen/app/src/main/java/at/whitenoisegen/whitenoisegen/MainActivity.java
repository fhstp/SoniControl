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
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.os.Bundle;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;
import android.app.AlertDialog;

import java.util.Scanner;



public class MainActivity extends AppCompatActivity {


    int fs = 44100;
    int winLen;
    float[] cutoffFreqDown;
    float[] cutoffFreqUp;
    int freqRes;

    Random randomGen = new Random();

    int winLenSamples;

    int[] cutoffFreqDownIdx;
    int[] cutoffFreqUpIdx;

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

    int numberOfBands;
    int[][] whiteNoiseBands;

    TextView txtBand1;
    TextView txtUpFreqBand1;
    TextView txtDownFreqBand1;
    TextView txtBand2;
    TextView txtUpFreqBand2;
    TextView txtDownFreqBand2;
    TextView txtBand3;
    TextView txtUpFreqBand3;
    TextView txtDownFreqBand3;
    TextView txtBand4;
    TextView txtUpFreqBand4;
    TextView txtDownFreqBand4;

    String signalType;
    String signalTechnology;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        TextView ampValue = (TextView)findViewById(R.id.textView4);
        ampValue.setText("0");

        btnStop = (Button) findViewById(R.id.btnStop);
        btnStart = (Button) findViewById(R.id.btnStart);
        btnStop.setEnabled(false);

        //initializing the textfields and labels of the manually modifiable bands
        txtBand1 = (TextView)findViewById(R.id.textView9);
        txtUpFreqBand1 = (TextView)findViewById(R.id.txtUpFreqBand1);
        txtDownFreqBand1 = (TextView)findViewById(R.id.txtDownFreqBand1);
        txtBand2 = (TextView)findViewById(R.id.textView10);
        txtUpFreqBand2 = (TextView)findViewById(R.id.txtUpFreqBand2);
        txtDownFreqBand2 = (TextView)findViewById(R.id.txtDownFreqBand2);
        txtBand3 = (TextView)findViewById(R.id.textView11);
        txtUpFreqBand3 = (TextView)findViewById(R.id.txtUpFreqBand3);
        txtDownFreqBand3 = (TextView)findViewById(R.id.txtDownFreqBand3);
        txtBand4 = (TextView)findViewById(R.id.textView12);
        txtUpFreqBand4 = (TextView)findViewById(R.id.txtUpFreqBand4);
        txtDownFreqBand4 = (TextView)findViewById(R.id.txtDownFreqBand4);

        //setting the debug helps invisible
        final TextView txtWinLenSamples = (TextView)findViewById(R.id.textViewReal);
        //txtWinLenSamples.setEnabled(false);
        TextView txtcutoffFreqIdx = (TextView)findViewById(R.id.textView);
        txtcutoffFreqIdx.setEnabled(false);
        TextView txtcutoffFreq = (TextView)findViewById(R.id.textView2);
        txtcutoffFreq.setEnabled(false);
        TextView txtfs = (TextView)findViewById(R.id.textView3);
        txtfs.setEnabled(false);


        final Spinner spinnerOfBands = (Spinner)findViewById(R.id.spnNumberOfBands); //finding the dropdown menu with the spoofing choices
        final String[]spinnerChoices = {"Google Nearby","Lisnr","Shopkick","Signal360","Silverpush","1 Band", "2 Bands", "3 Bands", "4 Bands"}; //creating the values of the dropdown menu


        ArrayAdapter<String>adapter = new ArrayAdapter<String>(MainActivity.this, android.R.layout.simple_spinner_dropdown_item, spinnerChoices); //creating an adapter for the dropdown menu

        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerOfBands.setAdapter(adapter); //adding the adapter to the spinner/dropdown menu
        spinnerOfBands.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() { //add a listener for the selection of the items/values
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                switch (position){ //accoring to the position the right text elements get enabled or disabled and the signaltype and the technologytype/number of used bands get stored
                    case 0:
                        txtBand1.setEnabled(false);
                        txtUpFreqBand1.setEnabled(false);
                        txtDownFreqBand1.setEnabled(false);
                        txtUpFreqBand1.setText("");
                        txtDownFreqBand1.setText("");
                        txtBand2.setEnabled(false);
                        txtUpFreqBand2.setEnabled(false);
                        txtDownFreqBand2.setEnabled(false);
                        txtUpFreqBand2.setText("");
                        txtDownFreqBand2.setText("");
                        txtBand3.setEnabled(false);
                        txtUpFreqBand3.setEnabled(false);
                        txtDownFreqBand3.setEnabled(false);
                        txtUpFreqBand3.setText("");
                        txtDownFreqBand3.setText("");
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        signalTechnology = "nearby";
                        signalType = "specified";
                        txtWinLenSamples.setText(signalTechnology);
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 1:
                        txtBand1.setEnabled(false);
                        txtUpFreqBand1.setEnabled(false);
                        txtDownFreqBand1.setEnabled(false);
                        txtUpFreqBand1.setText("");
                        txtDownFreqBand1.setText("");
                        txtBand2.setEnabled(false);
                        txtUpFreqBand2.setEnabled(false);
                        txtDownFreqBand2.setEnabled(false);
                        txtUpFreqBand2.setText("");
                        txtDownFreqBand2.setText("");
                        txtBand3.setEnabled(false);
                        txtUpFreqBand3.setEnabled(false);
                        txtDownFreqBand3.setEnabled(false);
                        txtUpFreqBand3.setText("");
                        txtDownFreqBand3.setText("");
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        signalTechnology = "lisnr";
                        signalType = "specified";
                        txtWinLenSamples.setText(signalTechnology);
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 2:
                        txtBand1.setEnabled(false);
                        txtUpFreqBand1.setEnabled(false);
                        txtDownFreqBand1.setEnabled(false);
                        txtUpFreqBand1.setText("");
                        txtDownFreqBand1.setText("");
                        txtBand2.setEnabled(false);
                        txtUpFreqBand2.setEnabled(false);
                        txtDownFreqBand2.setEnabled(false);
                        txtUpFreqBand2.setText("");
                        txtDownFreqBand2.setText("");
                        txtBand3.setEnabled(false);
                        txtUpFreqBand3.setEnabled(false);
                        txtDownFreqBand3.setEnabled(false);
                        txtUpFreqBand3.setText("");
                        txtDownFreqBand3.setText("");
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        signalTechnology = "shopkick";
                        signalType = "specified";
                        txtWinLenSamples.setText(signalTechnology);
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 3:
                        txtBand1.setEnabled(false);
                        txtUpFreqBand1.setEnabled(false);
                        txtDownFreqBand1.setEnabled(false);
                        txtUpFreqBand1.setText("");
                        txtDownFreqBand1.setText("");
                        txtBand2.setEnabled(false);
                        txtUpFreqBand2.setEnabled(false);
                        txtDownFreqBand2.setEnabled(false);
                        txtUpFreqBand2.setText("");
                        txtDownFreqBand2.setText("");
                        txtBand3.setEnabled(false);
                        txtUpFreqBand3.setEnabled(false);
                        txtDownFreqBand3.setEnabled(false);
                        txtUpFreqBand3.setText("");
                        txtDownFreqBand3.setText("");
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        signalTechnology = "signal360";
                        signalType = "specified";
                        txtWinLenSamples.setText(signalTechnology);
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 4:
                        txtBand1.setEnabled(false);
                        txtUpFreqBand1.setEnabled(false);
                        txtDownFreqBand1.setEnabled(false);
                        txtUpFreqBand1.setText("");
                        txtDownFreqBand1.setText("");
                        txtBand2.setEnabled(false);
                        txtUpFreqBand2.setEnabled(false);
                        txtDownFreqBand2.setEnabled(false);
                        txtUpFreqBand2.setText("");
                        txtDownFreqBand2.setText("");
                        txtBand3.setEnabled(false);
                        txtUpFreqBand3.setEnabled(false);
                        txtDownFreqBand3.setEnabled(false);
                        txtUpFreqBand3.setText("");
                        txtDownFreqBand3.setText("");
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        signalTechnology = "silverpush";
                        signalType = "specified";
                        txtWinLenSamples.setText(signalTechnology);
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 5:
                        txtBand1.setEnabled(true);
                        txtUpFreqBand1.setEnabled(true);
                        txtDownFreqBand1.setEnabled(true);
                        txtBand2.setEnabled(false);
                        txtUpFreqBand2.setEnabled(false);
                        txtDownFreqBand2.setEnabled(false);
                        txtUpFreqBand2.setText("");
                        txtDownFreqBand2.setText("");
                        txtBand3.setEnabled(false);
                        txtUpFreqBand3.setEnabled(false);
                        txtDownFreqBand3.setEnabled(false);
                        txtUpFreqBand3.setText("");
                        txtDownFreqBand3.setText("");
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        numberOfBands = 1;
                        signalType = "custom";
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 6:
                        txtBand1.setEnabled(true);
                        txtUpFreqBand1.setEnabled(true);
                        txtDownFreqBand1.setEnabled(true);
                        txtBand2.setEnabled(true);
                        txtUpFreqBand2.setEnabled(true);
                        txtDownFreqBand2.setEnabled(true);
                        txtBand3.setEnabled(false);
                        txtUpFreqBand3.setEnabled(false);
                        txtDownFreqBand3.setEnabled(false);
                        txtUpFreqBand3.setText("");
                        txtDownFreqBand3.setText("");
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        numberOfBands = 2;
                        signalType = "custom";
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 7:
                        txtBand1.setEnabled(true);
                        txtUpFreqBand1.setEnabled(true);
                        txtDownFreqBand1.setEnabled(true);
                        txtBand2.setEnabled(true);
                        txtUpFreqBand2.setEnabled(true);
                        txtDownFreqBand2.setEnabled(true);
                        txtBand3.setEnabled(true);
                        txtUpFreqBand3.setEnabled(true);
                        txtDownFreqBand3.setEnabled(true);
                        txtBand4.setEnabled(false);
                        txtUpFreqBand4.setEnabled(false);
                        txtDownFreqBand4.setEnabled(false);
                        txtUpFreqBand4.setText("");
                        txtDownFreqBand4.setText("");
                        numberOfBands = 3;
                        signalType = "custom";
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                    case 8:
                        txtBand1.setEnabled(true);
                        txtUpFreqBand1.setEnabled(true);
                        txtDownFreqBand1.setEnabled(true);
                        txtBand2.setEnabled(true);
                        txtUpFreqBand2.setEnabled(true);
                        txtDownFreqBand2.setEnabled(true);
                        txtBand3.setEnabled(true);
                        txtUpFreqBand3.setEnabled(true);
                        txtDownFreqBand3.setEnabled(true);
                        txtBand4.setEnabled(true);
                        txtUpFreqBand4.setEnabled(true);
                        txtDownFreqBand4.setEnabled(true);
                        numberOfBands = 4;
                        signalType = "custom";
                        if(playingGlobal) {
                            btnStop.setEnabled(false);
                            btnStart.setEnabled(true);
                            playingGlobal = false;
                            playingHandler = false;
                            start = 0;
                            stopWhitenoise();
                        }
                        break;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
                numberOfBands = 1;
            } //if nothing is selected the default value is one band in use
        });

        isFirstPlay = true; //after creating the whole spoofer it is never started so the first play is still true


        //old alert
        final AlertDialog.Builder wrongSliderPosition = new AlertDialog.Builder(MainActivity.this);
        wrongSliderPosition.setCancelable(true);
        wrongSliderPosition.setMessage("The Cutoffdownfreuqency is higher than the Cutoffupfrequency! Please change the frequencies!");

        //adding a listener for clicking on the startbutton
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

/*
                if(cutoffFreqDown>=cutoffFreqUp){
                    AlertDialog wrongFrequency = wrongSliderPosition.create();
                    wrongFrequency.show();
                }else {*/
                if(whiteNoiseBands!=null) {
                    if (bandsChanged()) {
                        noiseGenerated = false;
                    }
                }

                //hier fillBands Method
                if(signalType.equals("specified")) {
                    whiteNoiseBands = null;
                    whiteNoiseBands = importSpecificSignal(); //import frequencybands of a certain technology
                    noiseGenerated = false;
                }
                if(signalType.equals("custom")) {
                    whiteNoiseBands = getBands(); //get the manually created frequencybands
                }

                btnStart.setEnabled(false); //the startbutton gets disabled
                btnStop.setEnabled(true); //the stopbutton gets enabled for stopping the spoofing
                playingGlobal = true; //the global play status is now true after the start
                playingHandler = false; //helpboolean for switching the playstatus in the puslinghandler
                isFirstPlay = true; //because the spoofer is not running it is the first time it starts with new values
                onPulsing(); //start the iterating function for pulsing the signal
                //}
            }
        });

        //adding a listener for clicking on the startbutton
        btnStop.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                btnStop.setEnabled(false); //the stopbutton gets disabled
                btnStart.setEnabled(true); //the startbutton gets enabled for starting the spoofing again
                playingGlobal = false; //the global playstatus is now false after the stop
                isFirstPlay = false; //to be sure after stopping that it is not the first play
                startStop(false); //direct stopping
            }
        });

        final SeekBar pulseFader = (SeekBar)findViewById(R.id.pulseFader);
        if (pulseFader != null) pulseFader.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                winLen = (progress*10);
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

/*
        if (cutoffDownFader != null) cutoffDownFader.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                //cutoffFreqDown = (float)(progress*38*5.8026315);
                TextView cutoffValue = (TextView)findViewById(R.id.textView6);
                cutoffValue.setText("CutoffDown: " + String.valueOf((int)(progress*38*5.8026315)));
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


        if (cutoffUpFader != null) cutoffUpFader.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                TextView cutoffValue = (TextView)findViewById(R.id.textView7);
                //cutoffFreqUp = (float) (progress * 38 * 5.8026315);
                cutoffValue.setText("CutoffUp: " + String.valueOf((int) (progress * 38 * 5.8026315)));

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
        });*/
    }

    public void onPulsing(){
        if(!noiseGenerated) { //if no whitenoise is available generate a new one
            generateWhitenoise();
        }

        if (start == 0) {
            start = SystemClock.elapsedRealtime(); //storing the time
            after = SystemClock.elapsedRealtime(); //storing the time

            if (isFirstPlay) { //if it is the first play after starting the spoofer
                playingHandler = !playingHandler; //switch helpvariable for playing
                if(spoofValue == 100){ //Check if continuous spoofing is active (=Slider on value 100)
                    startStop(true); //starting it not depending on the playingHandler variable
                }else {
                    startStop(playingHandler); //starting it depending on the playingHandler boolean
                }
                isFirstPlay = false; //set the first play to false
            }

            onPulsing(); //execute the method again
        } else { //if start isn't 0 anymore

            pulsingHandler.postDelayed(new Runnable() {
                public void run() { //Handler for delaying the next play/stop
                    if (playingGlobal) {
                        after = SystemClock.elapsedRealtime(); //get the latest time

                        if ((after - start) >= winLen / 3) { //if the difference between the start and the delayed after-value is over windowLength/3
                            playingHandler = !playingHandler; //switch helpvariable for playing
                            if(spoofValue == 100){ //Check if continuous spoofing active
                                startStop(false); //stop the spoofer only for starting it again immediately
                                startStop(true); //starting it not depending on the playingHandler variable
                            }else {
                                startStop(playingHandler); //starting it depending on the playingHandler boolean
                            }
                        }

                        start = 0; //set start to 0 for a new basic value
                        onPulsing(); //execute the method again
                    }

                }
            }, winLen / 3); //delay time is windowLength/3
        }
    }

    public void generateWhitenoise(){
        if (winLen==0){winLen= 10;} //if the slider for the windowLength is still 0 after the start, set to 10, otherwise it won't work
        //freqRes = (fs/2)/(winLen*(fs/1000));
        winLenSamples = winLen*fs/1000; //windowSamples according to the windowLength

        if(winLenSamples%2 == 1){
            winLenSamples+=1; //if the windowSamples are odd, we have to add 1 sample because audiotrack later needs an even buffersize
        }

/*
        cutoffFreqDownIdx = Math.round(cutoffFreqDown / (fs / 2) * (winLen * fs / 1000) + 1);
        cutoffFreqUpIdx = Math.round(cutoffFreqUp / (fs / 2) * (winLen * fs / 1000) + 1);
*/

        //sort the bands with a bubblesort
        if(whiteNoiseBands.length>1) {
            int[][] temp = new int[1][2];
            for (int i = 1; i < whiteNoiseBands.length; i++) {
                for (int j = 0; j < whiteNoiseBands.length - i; j++) {
                    if (whiteNoiseBands[j][0] > whiteNoiseBands[j + 1][0]) {
                        temp[0][0] = whiteNoiseBands[j][0];
                        temp[0][1] = whiteNoiseBands[j][1];
                        whiteNoiseBands[j][0] = whiteNoiseBands[j + 1][0];
                        whiteNoiseBands[j][1] = whiteNoiseBands[j + 1][1];
                        whiteNoiseBands[j + 1][0] = temp[0][0];
                        whiteNoiseBands[j + 1][1] = temp[0][1];
                    }
                }
            }
        }

        cutoffFreqUpIdx = new int[whiteNoiseBands.length]; //initializing the array for all upper bandfrequencies
        cutoffFreqDownIdx = new int[whiteNoiseBands.length]; //initializing the array for all lower bandfrequencies

        for(int i = 0; i<whiteNoiseBands.length; i++) { //filling the arrays with the bandfrequencyindexes
            float freqDown = whiteNoiseBands[i][0]; //lower frequency
            float freqUp = whiteNoiseBands[i][1]; //higher frequency
            cutoffFreqDownIdx[i] = Math.round(freqUp / (fs / 2) * (winLen * fs / 1000) + 1); //calculate the index of the lower frequency
            cutoffFreqUpIdx[i] = Math.round(freqDown / (fs / 2) * (winLen * fs / 1000) + 1); //calculate the index of the higher frequency
        }

/*old debug
        TextView txtWinLenSamples = (TextView)findViewById(R.id.textViewReal);
        txtWinLenSamples.setText("WinLenSamples: " + String.valueOf(winLenSamples));
        TextView txtcutoffFreqIdx = (TextView)findViewById(R.id.textView);
        txtcutoffFreqIdx.setText("CutoffFreqIdx: " + String.valueOf(cutoffFreqDownIdx));
        TextView txtcutoffFreq = (TextView)findViewById(R.id.textView2);
        txtcutoffFreq.setText("CutoffFreqDown: " + String.valueOf(cutoffFreqDown));
        TextView txtfs = (TextView)findViewById(R.id.textView3);
        txtfs.setText("CutoffFreqUpIdx: " + String.valueOf(cutoffFreqUpIdx));
        */
            double[] signal = new double[winLenSamples]; //initializing the double array for the signal

            //randomGen.setSeed(123123); //fixed seed, without setSeed completely random numbers

            for (int j = 0; j < winLenSamples; j++) {
                signal[j] = randomGen.nextDouble(); //generate random double values and store it in the signal array
            }

            complexWhiteNoise = doFFT(winLenSamples, signal); //execute the fft method for creating whitenoisebands

            for (int i = 0; i < (winLenSamples * 2); i++) {
                if (Math.abs(complexWhiteNoise[i]) > max) {
                    max = Math.abs(complexWhiteNoise[i]); //searching for the maximum value of the whitenoisesignal
                }
            }

            helpNoise = new double[winLenSamples]; //creating a help array for the real values of the generated noise
            int noiseCounter = 0; //helpvariable for counting the real values
            for (int l = 0; l < (winLenSamples * 2); l++) {
                if (l % 2 == 0) { //every array row with no remain has real values
                    helpNoise[noiseCounter] = (complexWhiteNoise[l] / max); //divide the complexNoise by the maximum value and then store it in the realNoise array
                    noiseCounter++; //counter plus one for every real value
                }
            }
            /*
            int fadeSamples = Math.round(helpNoise.length/3);
            //int fadeSamples = 1000;
            for(int i = 0; i < fadeSamples; i++){
                helpNoise[i] = (helpNoise[i]*((double)i/(double)fadeSamples));

            }*/
            /*
            for(int i = fadeSamples; i >= 0; i--) {
                helpNoise[helpNoise.length-(fadeSamples-i)-1] = (helpNoise[helpNoise.length-(fadeSamples-i)-1] * ((double)i / (double) fadeSamples));
            }*/
            /*
            for(int i = 0; i < fadeSamples; i++) {
                helpNoise[helpNoise.length-(fadeSamples-(fadeSamples-i))-1] = (helpNoise[helpNoise.length-(fadeSamples-(fadeSamples-i))-1] * ((double)i / (double) fadeSamples));
            }*/
            /*
            for(int i = 0; i < fadeSamples*2; i++) {
                helpNoise[helpNoise.length-((fadeSamples*2)-((fadeSamples*2)-i))-1] = (helpNoise[helpNoise.length-((fadeSamples*2)-((fadeSamples*2)-i))-1] * ((double)i / (double) (fadeSamples*2)));
            }*/


            //hier multiplizieren und schauen ob über 1 oder unter -1, dann runtercroppen, dann auf short

        for (int i = 0; i < winLenSamples; i++) {
            helpNoise[i] = (helpNoise[i]); //scale the double values up to short by multiplying with 32767
                if(helpNoise[i] > 1){
                    helpNoise[i] = 1;
                }
                if(helpNoise[i] < -1){
                    helpNoise[i] = -1;
                }
        }

            whiteNoise = new short[winLenSamples]; //short array for the whitenoise

            for (int i = 0; i < winLenSamples; i++) {
                whiteNoise[i] = (short) (helpNoise[i] * 32767); //scale the double values up to short by multiplying with 32767
                /*if(whiteNoise[i] > 32767){
                    whiteNoise[i] = 32767;
                }
                if(whiteNoise[i] < -32767){
                    whiteNoise[i] = -32767;
                }*/
            }



            generatePlayer(); //create the audiotrack player
            //changeWhiteNoiseVolume(); //changing the volume level of the player
            noiseGenerated = true; //after creation of the noise, set the flag to true

    }

    public void generatePlayer(){
        audioTrack = new AudioTrack(AudioManager.STREAM_MUSIC,fs, AudioFormat.CHANNEL_CONFIGURATION_MONO, AudioFormat.ENCODING_PCM_16BIT,winLenSamples,AudioTrack.MODE_STATIC); //creating the audiotrack player with winLenSamples as the buffersize
        audioTrack.write(whiteNoise, 0, winLenSamples); //put the whiteNoise shortarray into the player
    }

    private double[] doFFT(int fftSize, double[] inputSignal) {

        DoubleFFT_1D mFFT = new DoubleFFT_1D(fftSize); //creating a new fft object

        double[] complexSignal = new double[winLenSamples * 2]; //creating and initializing a new double array for the complex numbers

        System.arraycopy(inputSignal, 0, complexSignal, 0, winLenSamples); //copy the array with the random numbers into the new one

        mFFT.realForwardFull(complexSignal); //make the fft on the complex signal



/*old version of finding the min and max
        int maxFreq = 0;
        for (int n = 0; n < whiteNoiseBands.length; n++) {
            for(int m = 0; m < whiteNoiseBands[n].length; m++) {
                if (Math.abs(whiteNoiseBands[n][m]) > maxFreq) {
                    maxFreq = Math.abs(whiteNoiseBands[n][m]);
                }
            }
        }

        int minFreq = 99999999;
        for (int n = 0; n < whiteNoiseBands.length; n++) {
            for(int m = 0; m < whiteNoiseBands[n].length; m++) {
                if (Math.abs(whiteNoiseBands[n][m]) < minFreq) {
                    minFreq = Math.abs(whiteNoiseBands[n][m]);
                }
            }
        }*/

        int minFreq = cutoffFreqDownIdx[0]; //get the lowest frequency after the sort
        int maxFreq = cutoffFreqUpIdx[whiteNoiseBands.length-1]; //get the highest frequency after the sort

        for (int j = 0; j <= minFreq; j++) {
            complexSignal[j] = 0.0f; //set all values up to the lowest frequency to 0
        }

        int helpWinLenSamples = winLenSamples * 2;
        for (int j = (helpWinLenSamples - minFreq); j < helpWinLenSamples; j++) {
            complexSignal[j] = 0.0f; //set all values up to the lowest frequency to 0 mirrored to the doubled winLenSamples size
        }

        int helpUpSamples = winLenSamples - maxFreq;
        for (int j = winLenSamples - helpUpSamples; j <= winLenSamples + helpUpSamples; j++) {
            complexSignal[j] = 0.0f; //set all frequencies from the highest frequency up to the mirrored frequency of the doubled winLenSamples size
        }

        if(whiteNoiseBands.length>1) {
            for (int k = 0; k < whiteNoiseBands.length-1; k++) {
                for (int l = cutoffFreqUpIdx[k+1]; l <= cutoffFreqDownIdx[k]; l++) {
                    complexSignal[l] = 0.0f; //set all frequencies between the higher frequency of one band to the lower frequency of the next band to 0
                }
                int helpSamples = winLenSamples * 2;
                for (int l = helpSamples-cutoffFreqDownIdx[k]; l <= helpSamples-cutoffFreqUpIdx[k+1]; l++) {
                    complexSignal[l] = 0.0f; //set all frequencies between the higher frequency of one band to the lower frequency of the next band to 0 mirrored to the doubled winLenSamples size
                }

/*
                File txtWhiteNoise1 = new File("/storage/emulated/0/DCIM/whitenoise"+ k +".txt");
                BufferedWriter outputWriter1 = null;
                try {
                    outputWriter1 = new BufferedWriter(new FileWriter(txtWhiteNoise1));
                } catch (IOException e){
                }

                for(int j=0;j<winLenSamples;j++){
                    try {
                        outputWriter1.write(Double.toString(complexSignal[j])+", ");
                    } catch (IOException e){
                    }
                }
                try {
                    outputWriter1.close();
                } catch (IOException e){
                }*/
                /*old bands static work at 500
                for (int l = whiteNoiseBands[k][0]; l <= whiteNoiseBands[k+1][1]; l++) {
                    complexSignal[l] = 0.0f;
                }
                int helpSamples = winLenSamples * 2;
                for (int l = helpSamples-whiteNoiseBands[k+1][1]; l <= helpSamples-whiteNoiseBands[k][0]; l++) {
                    complexSignal[l] = 0.0f;
                }
                */
            }
        }

        /*dynamic version with sliders
            for (int j = 0; j <= cutoffDown; j++) {
                complexSignal[j] = 0.0f;
            }

            int helpWinLenSamples = winLenSamples * 2;
            for (int j = (helpWinLenSamples - cutoffDown); j < helpWinLenSamples; j++) {
                complexSignal[j] = 0.0f;
            }

            int helpUpSamples = winLenSamples - cutoffUp;
            for (int j = winLenSamples - helpUpSamples; j <= winLenSamples + helpUpSamples; j++) {
                complexSignal[j] = 0.0f;
            }
        */



            for (int i = 0; i < complexSignal.length - 1; i++) {
                complexSignal[i] = complexSignal[i] * (-1); //invert all algebraic signs
            }




        mFFT.complexForward(complexSignal); //make the fft on the inverted signal

        return complexSignal; //return the signal with the complex values

    }

    private void playWhitenoise(){
        audioTrack.play();
    } //Start the created Audiotrack

    private void stopWhitenoise(){
        audioTrack.stop();
    } //Stop the created Audiotrack

    //used Method for starting and stopping the Player
    public void startStop(boolean playStatus){
        if(playStatus){
            playWhitenoise();;
        } else{
            stopWhitenoise();
        }
    }
    //old Version of changing the volume
    private void changeWhiteNoiseVolume(){
        audioTrack.setVolume(AudioTrack.getMaxVolume());
    }

    //reading the manually written bands
    public int[][] getBands(){
        int[][] bands = new int[numberOfBands][2]; //initialize the array for storing the bands
        switch (numberOfBands) { //according to the amount of bands which are filled, the array gets filled with the right values
            case(1):
                bands[0][0] = Integer.parseInt(txtUpFreqBand1.getText().toString()); //getting the upper border of one band
                bands[0][1] = Integer.parseInt(txtDownFreqBand1.getText().toString()); //getting the lower border of one band
                break;
            case(2):
                bands[0][0] = Integer.parseInt(txtUpFreqBand1.getText().toString());
                bands[0][1] = Integer.parseInt(txtDownFreqBand1.getText().toString());
                bands[1][0] = Integer.parseInt(txtUpFreqBand2.getText().toString());
                bands[1][1] = Integer.parseInt(txtDownFreqBand2.getText().toString());
                break;
            case(3):
                bands[0][0] = Integer.parseInt(txtUpFreqBand1.getText().toString());
                bands[0][1] = Integer.parseInt(txtDownFreqBand1.getText().toString());
                bands[1][0] = Integer.parseInt(txtUpFreqBand2.getText().toString());
                bands[1][1] = Integer.parseInt(txtDownFreqBand2.getText().toString());
                bands[2][0] = Integer.parseInt(txtUpFreqBand3.getText().toString());
                bands[2][1] = Integer.parseInt(txtDownFreqBand3.getText().toString());
                break;
            case(4):
                bands[0][0] = Integer.parseInt(txtUpFreqBand1.getText().toString());
                bands[0][1] = Integer.parseInt(txtDownFreqBand1.getText().toString());
                bands[1][0] = Integer.parseInt(txtUpFreqBand2.getText().toString());
                bands[1][1] = Integer.parseInt(txtDownFreqBand2.getText().toString());
                bands[2][0] = Integer.parseInt(txtUpFreqBand3.getText().toString());
                bands[2][1] = Integer.parseInt(txtDownFreqBand3.getText().toString());
                bands[3][0] = Integer.parseInt(txtUpFreqBand4.getText().toString());
                bands[3][1] = Integer.parseInt(txtDownFreqBand4.getText().toString());
                break;
        }

        return bands; //the array with the right bands will be returned
    }

    //checking if bands have changed between start and stop - help of bubblesort
    private boolean bandsChanged(){
        int[][]oldBands = whiteNoiseBands; //helparray for old band array
        int[][]newBands = getBands(); //getting the new array of bands

        //sort the bands with a bubblesort
        if(newBands.length>1) {
            int[][] temp = new int[1][2];
            for (int i = 1; i < newBands.length; i++) {
                for (int j = 0; j < newBands.length - i; j++) {
                    if (newBands[j][0] > newBands[j + 1][0]) {
                        temp[0][0] = newBands[j][0];
                        temp[0][1] = newBands[j][1];
                        newBands[j][0] = newBands[j + 1][0];
                        newBands[j][1] = newBands[j + 1][1];
                        newBands[j + 1][0] = temp[0][0];
                        newBands[j + 1][1] = temp[0][1];
                    }
                }
            }
        }

        //checking if the bands are the same
        for(int i = 0; i < newBands.length; i++){
            for(int j = 0; j < newBands[i].length; j++){
                if(oldBands.length<i && newBands[i]!=null){ //if the old array has less bands than the new one the bands have changed and we return true
                    return true;
                }else if(oldBands[i][j]!=newBands[i][j]){ //if one of the old values is different than the values of the new array, we return true
                    return true;
                }
            }
        }
        return false; //if nothing has changed we return false
    }

    /*in progress
    private boolean checkBands(){
        return false;
    }*/

    //import the frequencies from the technologies via txt-files
    private int[][] importSpecificSignal(){
        int[][] test; //helparray for storing the frequencybands of the technologies
        String[] line = new String[0]; //helparray for caching each line of the frequencies
        try{
            if(signalTechnology.equals("nearby")) { //according to the name of the technology the right file will be scanned and split into lines for each frequency
                Scanner in = new Scanner(new File("/storage/emulated/0/DCIM/nearby-frequencies.txt"));
                line = in.nextLine().split(",");
            }
            if(signalTechnology.equals("lisnr")) {
                Scanner in = new Scanner(new File("/storage/emulated/0/DCIM/lisnr-frequencies.txt"));
                line = in.nextLine().split(",");
            }
            if(signalTechnology.equals("shopkick")) {
                Scanner in = new Scanner(new File("/storage/emulated/0/DCIM/shopkick-frequencies.txt"));
                line = in.nextLine().split(",");
            }
            if(signalTechnology.equals("signal360")) {
                Scanner in = new Scanner(new File("/storage/emulated/0/DCIM/signal360-frequencies.txt"));
                line = in.nextLine().split(",");
            }
            if(signalTechnology.equals("silverpush")) {
                Scanner in = new Scanner(new File("/storage/emulated/0/DCIM/silverpush-frequencies.txt"));
                line = in.nextLine().split(",");
            }
            int rowCounter=0; //helpvariable for counting the rows (=>bands)
            test = new int[line.length/2][2]; //initialize the array with half of the frequencies => each band has two frequencies
            for(int j = 0; j<line.length; j++) {
                if(j%2 == 0) { //when there is one as a remain, the frequency is the higher part of one band
                    test[rowCounter][0] = (Integer.parseInt(line[j])); //higher frequencyparts of one band are stored in the first place of each arrayrow
                }
                if(j%2 == 1) { //when there is no remain, the frequency is the lower part of one band
                    test[rowCounter][1] = (Integer.parseInt(line[j])); //lower frequencyparts of one band are stored in the second place of each arrayrow
                    rowCounter++;
                }
            }

        }catch (IOException e) {
            e.printStackTrace();
            test = new int[0][0]; //if the scanning of the file goes wrong, an array with zero/zero will be initialized
        }


        return test; //the array with the frequencybands will be returned
    }

}
