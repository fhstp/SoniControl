package sonicontrol.testroutine;

import android.content.SharedPreferences;
import android.media.AudioFormat;
import android.media.AudioManager;
import android.media.AudioTrack;
import android.os.Handler;
import android.provider.MediaStore;
import android.util.Log;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Random;

public class NoiseGenerator {

    private int signalTech;
    private String techForFile;

    private int fs = 44100;
    private int winLen;
    private int winLenSamples;
    private double max = 0;

    private double[][] whiteNoiseBands;
    private double[] cutoffFreqDownIdx;
    private double[] cutoffFreqUpIdx;

    private short[] whiteNoise;

    private Random randomGen = new Random();

    private int whiteNoiseVolume;
    private int playertime;
    private boolean noiseGenerated = false;
    private AudioTrack audioTrack = null;
    private MainActivity main;
    private AudioTrack generatedWhitenoisePlayer;

    private double bandWidth; //the bandwith for every specified frequencyband

    public NoiseGenerator(MainActivity main){
        this.main = main;
    }

    public void generateWhitenoise(final int signalType){
        android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background
        signalTech = signalType; //get the technology
        if(signalTech ==4){
            techForFile = "nearby";
            Log.d("Generator", "I generated a whitenoisesignal to spoof Google Nearby");
        }else if(signalTech==8){
            techForFile = "lisnr";
            Log.d("Generator", "I generated a whitenoisesignal to spoof Lisnr");
        }else if(signalTech==2){
            techForFile = "prontoly";
            Log.d("Generator", "I generated a whitenoisesignal to spoof Prontoly");
        }else if(signalTech==12){
            techForFile = "signal360";
            Log.d("Generator", "I generated a whitenoisesignal to spoof Signal 360");
        }else if(signalTech==14){
            techForFile = "shopkick";
            Log.d("Generator", "I generated a whitenoisesignal to spoof Shopkick");
        }else if(signalTech==16){
            techForFile = "silverpush";
            Log.d("Generator", "I generated a whitenoisesignal to spoof Silverpush");
        }else if(signalTech==18){
            techForFile = "unknown";
            Log.d("Generator", "I generated a whitenoisesignal to spoof unknown");
        }
        Log.d("ControlType",techForFile);
        generatedWhitenoisePlayer = whiteNoise(); //get the generated whitenoise for spoofing
    }

    public AudioTrack whiteNoise(){
        SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
        winLen = Integer.valueOf(sharedPref.getString("etprefPulseDuration", "1000")); //read the windowLength from the settings - NOTE: This setting will not be updated dynamically once the signal is created. Next update when new Signal is created.
        whiteNoiseBands = importSpecificSignal(techForFile); //import the frequencies /has to be changed to the detected technology

        if (winLen==0){winLen= 80;} //if the windowLength is still 0 after the start, set to 80
        winLenSamples = winLen*fs/1000; //windowSamples according to the windowLength

        if(winLenSamples%2 == 1){
            winLenSamples+=1; //if the windowSamples are odd, we have to add 1 sample because audiotrack later needs an even buffersize
        }

        //sort the bands with a bubblesort
        if(whiteNoiseBands.length>1) {
            double[][] temp = new double[1][2];
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

        cutoffFreqUpIdx = new double[whiteNoiseBands.length]; //initializing the array for all upper bandfrequencies
        cutoffFreqDownIdx = new double[whiteNoiseBands.length]; //initializing the array for all lower bandfrequencies

        for(int i = 0; i<whiteNoiseBands.length; i++) { //filling the arrays with the bandfrequencyindexes
            double freqDown = whiteNoiseBands[i][0]; //lower frequency
            double freqUp = whiteNoiseBands[i][1]; //higher frequency
            cutoffFreqDownIdx[i] = Math.round(freqDown / (fs / 2) * (winLen * fs / 1000) + 1); //calculate the index of the lower frequency
            cutoffFreqUpIdx[i] = Math.round(freqUp / (fs / 2) * (winLen * fs / 1000) + 1); //calculate the index of the higher frequency
        }

        double[] signal = new double[winLenSamples]; //initializing the double array for the signal

        for (int j = 0; j < winLenSamples; j++) {
            signal[j] = randomGen.nextDouble(); //generate random double values and store it in the signal array
        }

        double[] complexWhiteNoise = doFFT(winLenSamples, signal); //execute the fft method for creating whitenoisebands

        for (int i = 0; i < (winLenSamples * 2); i++) {
            if (Math.abs(complexWhiteNoise[i]) > max) {
                max = Math.abs(complexWhiteNoise[i]); //searching for the maximum value of the whitenoisesignal
            }
        }

        double[] helpNoise = new double[winLenSamples]; //creating a help array for the real values of the generated noise
        int noiseCounter = 0; //helpvariable for counting the real values
        for (int l = 0; l < (winLenSamples * 2); l++) {
            if (l % 2 == 0) { //every array row with no remain has real values
                helpNoise[noiseCounter] = (complexWhiteNoise[l] / max); //divide the complexNoise by the maximum value and then store it in the realNoise array
                noiseCounter++; //counter plus one for every real value
            }
        }


        int fadeSamples = Math.round(helpNoise.length / 10); //value for the length of the fade in/fade out
        //int fadeSamples = 500;
        for (int i = 0; i < fadeSamples; i++) { //fade in
            helpNoise[i] = (helpNoise[i] * ((double) i / (double) fadeSamples));
        }

        for (int i = 0; i < fadeSamples; i++) { //fade out
            helpNoise[helpNoise.length - (fadeSamples - (fadeSamples - i)) - 1] = (helpNoise[helpNoise.length - (fadeSamples - (fadeSamples - i)) - 1] * ((double) i / (double) fadeSamples));
        }

        if(whiteNoiseVolume == 0){whiteNoiseVolume = 1;}
        for (int i = 0; i < winLenSamples; i++) {
            helpNoise[i] = (helpNoise[i]*(1+(whiteNoiseVolume/100))); //multiplay every value of the array with numbers between 1.0 to 3.0 (depending on the whiteNoiseValue = Slidervalue)
            if(helpNoise[i] > 1){ //if new value higher than 1
                helpNoise[i] = 1; //change it to 1
            }
            if(helpNoise[i] < -1){ //if new value lower than -1
                helpNoise[i] = -1; //chang it to -1
            }
        }
/*
        double[] noClickNoise = new double[(winLenSamples+(winLenSamples/65))]; //create new array with the length of windowSamples + buffer for zeroes => Fade out help

        for(int i = 0; i<(winLenSamples+(winLenSamples/65)); i++){
            if(i<winLenSamples) {
                noClickNoise[i] = helpNoise[i]; //for the length of winLenSamples the old values
            }else{
                noClickNoise[i] = 0; //for everything above 0 as new value
            }
        }
*/
        playertime = (winLen/*+((winLenSamples/65)*1000/fs)*/); //time for the pulsing spoofer => windowLength + Length of the added 0-buffer

        whiteNoise = new short[winLenSamples/*+(winLenSamples/65)*/]; //short array for the whitenoise

        for (int i = 0; i < winLenSamples/*+(winLenSamples/65)*/; i++) {
            whiteNoise[i] = (short) (helpNoise[i] * 32767); //scale the double values up to short by multiplying with 32767
        }

        AudioTrack generatedNoisePlayer;
        generatedNoisePlayer = generatePlayer(); //create the audiotrack player
        noiseGenerated = true; //after creation of the noise, set the flag to true
        return generatedNoisePlayer;
    }

    private double[] doFFT(int fftSize, double[] inputSignal) {

        DoubleFFT_1D mFFT = new DoubleFFT_1D(fftSize); //creating a new fft object

        double[] complexSignal = new double[winLenSamples * 2]; //creating and initializing a new double array for the complex numbers

        System.arraycopy(inputSignal, 0, complexSignal, 0, winLenSamples); //copy the array with the random numbers into the new one

        mFFT.realForwardFull(complexSignal); //make the fft on the complex signal

        double minFreq = cutoffFreqDownIdx[0]; //get the lowest frequency after the sort
        double maxFreq = cutoffFreqUpIdx[whiteNoiseBands.length-1]; //get the highest frequency after the sort

        for (double j = 0; j < minFreq; j++) {
            complexSignal[(int)j] = 0.0f; //set all values up to the lowest frequency to 0
        }

        double helpWinLenSamples = winLenSamples * 2;
        for (double j = (helpWinLenSamples - (minFreq-1)); j < helpWinLenSamples; j++) {
            complexSignal[(int)j] = 0.0f; //set all values up to the lowest frequency to 0 mirrored to the doubled winLenSamples size
        }

        double helpUpSamples = winLenSamples - (maxFreq+1);
        for (double j = winLenSamples - helpUpSamples; j < winLenSamples + helpUpSamples; j++) {
            complexSignal[(int)j] = 0.0f; //set all frequencies from the highest frequency up to the mirrored frequency of the doubled winLenSamples size
        }

        if(whiteNoiseBands.length>1) {
            for (int k = 0; k < whiteNoiseBands.length-1; k++) {
                for (double l = cutoffFreqUpIdx[k]+1; l < cutoffFreqDownIdx[k+1]; l++) {
                    complexSignal[(int)l] = 0.0f; //set all frequencies between the higher frequency of one band to the lower frequency of the next band to 0
                }
                int helpSamples = winLenSamples * 2;
                for (double l = helpSamples-cutoffFreqDownIdx[k+1]+1; l < helpSamples-cutoffFreqUpIdx[k]; l++) {
                    complexSignal[(int)l] = 0.0f; //set all frequencies between the higher frequency of one band to the lower frequency of the next band to 0 mirrored to the doubled winLenSamples size
                }
            }
        }

        for (int i = 0; i < complexSignal.length - 1; i++) {
            complexSignal[i] = complexSignal[i] * (-1); //invert all algebraic signs
        }

        mFFT.complexForward(complexSignal); //make the fft on the inverted signal

        return complexSignal; //return the signal with the complex values

    }

    private double[][] importSpecificSignal(String signalTechnology) {

        double[][] test; //helparray for storing the frequencybands of the technologies
        SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
        bandWidth = Integer.valueOf(sharedPref.getString("etprefBandwidth", "1"));

        BufferedReader reader = null;
        try {
            if(signalTechnology.equals("nearby")) { //according to the name of the technology the right file will be scanned and split into lines for each frequency
                reader = new BufferedReader(new InputStreamReader(main.getAssets().open("nearby-frequencies.txt"), "UTF-8"));
            }
            if(signalTechnology.equals("lisnr")) {
                reader = new BufferedReader(new InputStreamReader(main.getAssets().open("lisnr-frequencies.txt"), "UTF-8"));
            }
            if(signalTechnology.equals("shopkick")) {
                reader = new BufferedReader(new InputStreamReader(main.getAssets().open("shopkick-frequencies.txt"), "UTF-8"));
            }
            if(signalTechnology.equals("signal360")) {
                reader = new BufferedReader(new InputStreamReader(main.getAssets().open("signal360-frequencies.txt"), "UTF-8"));
            }
            if(signalTechnology.equals("silverpush")) {
                reader = new BufferedReader(new InputStreamReader(main.getAssets().open("silverpush-frequencies.txt"), "UTF-8"));
            }
            if(signalTechnology.equals("prontoly")) {
                reader = new BufferedReader(new InputStreamReader(main.getAssets().open("prontoly-frequencies.txt"), "UTF-8"));
            }
            if(signalTechnology.equals("unknown")){
                reader = new BufferedReader(new InputStreamReader(main.getAssets().open("unknown-frequencies.txt"), "UTF-8"));
                bandWidth = 2250;
            }

            String[] mLine = new String[0];
            mLine = reader.readLine().split(",");


            test = new double[mLine.length][2]; //initialize the array with half of the frequencies => each band has two frequencies
            for(int j = 0; j<mLine.length; j++) {
                test[j][0] = (Integer.parseInt(mLine[j])-(bandWidth/2)); //lower frequencyparts of one band are stored in the first place of each arrayrow
                test[j][1] = (Integer.parseInt(mLine[j])+(bandWidth/2)); //higher frequencyparts of one band are stored in the second place of each arrayrow
            }
        } catch (IOException e) {
            test = new double[0][0]; //if the scanning of the file goes wrong, an array with zero/zero will be initialized
        } finally {
            if (reader != null) {
                try {
                    reader.close();
                } catch (IOException e) {
                    //log the exception
                }
            }
        }

        return test; //the array with the frequencybands will be returned

    }

    private AudioTrack generatePlayer(){
        winLenSamples = winLen*fs/1000; //calculating the windowLengthSamples
        audioTrack = new AudioTrack(AudioManager.STREAM_MUSIC,fs, AudioFormat.CHANNEL_CONFIGURATION_MONO, AudioFormat.ENCODING_PCM_16BIT,(winLenSamples/*+(winLenSamples/65)*/)*2,AudioTrack.MODE_STATIC); //creating the audiotrack player with winLenSamples*2 as the buffersize because the constructor wants bytes
        audioTrack.write(whiteNoise, 0, (winLenSamples/*+(winLenSamples/65)*/)); //put the whiteNoise shortarray into the player, buffersize winLenSamples are Shorts here
        return audioTrack;
    }

    public AudioTrack getGeneratedPlayer(){
        return generatedWhitenoisePlayer;
    }

    public void setGeneratedPlayerToNull(){
        generatedWhitenoisePlayer.release(); //release the player resources
        audioTrack.release(); //release the player resources
        generatedWhitenoisePlayer = null; //set the player to null
        audioTrack = null; //set the player to null
    }

    public short[] getWhiteNoise(){
        return whiteNoise;
    }

    public int getPlayertime(){
        return playertime;
    }


}
