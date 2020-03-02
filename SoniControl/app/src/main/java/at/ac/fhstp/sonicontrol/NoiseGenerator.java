/*
 * Copyright (c) 2018, 2019, 2020. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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

import android.content.SharedPreferences;
import android.media.AudioFormat;
import android.media.AudioManager;
import android.media.AudioTrack;
import android.media.audiofx.LoudnessEnhancer;
import android.util.Log;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Random;

import edu.emory.mathcs.jtransforms.fft.DoubleFFT_1D;

public class NoiseGenerator {

    /***
     * test
     */
    private Technology lastSignalTechDetected;
    private String techForFile;

    private int fs = 44100;
    private int winLen;
    private int winLenSamples;
    private double max = 0;

    private double[][] whiteNoiseBands;
    private double[] cutoffFreqDownIdx;
    private double[] cutoffFreqUpIdx;

    private short[] whiteNoise;

    private Random randomGen = new Random(42);

    private int whiteNoiseVolume;
    private int playertime;
    private boolean noiseGenerated = false;
    private AudioTrack audioTrack = null;
    //private MainActivity main;
    private AudioTrack generatedWhitenoisePlayer;

    private double bandWidth; //the bandwith for every specified frequencyband

    public NoiseGenerator(/*MainActivity main*/){
        //this.main = main;
    }

    public void generateWhitenoise(final Technology signalType, MainActivity main){
        android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_BACKGROUND); //set the handler thread to background
        lastSignalTechDetected = signalType;
        //If Clauses only for Debug
         //Log.d("Generator", "I generated a whitenoisesignal to spoof " + signalType.toString());

        generatedWhitenoisePlayer = generateWhitenoisePlayer(signalType, main); //get the generated whitenoise for spoofing
    }

    public double[] produceWhiteNoise(Technology signalType, MainActivity main){
        SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
        winLen = Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_PULSE_DURATION, ConfigConstants.SETTING_PULSE_DURATION_DEFAULT)); //read the windowLength from the settings - NOTE: This setting will not be updated dynamically once the signal is created. Next update when new Signal is created.
        whiteNoiseBands = importSpecificSignal(signalType, main); //import the frequencies /has to be changed to the detected technology

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

        randomGen = new Random(42);
        for (int j = 0; j < winLenSamples; j++) {
            signal[j] = randomGen.nextDouble(); //generate random double values and store it in the signal array
        }

        double[] complexWhiteNoise = doFFT(winLenSamples, signal); //execute the fft method for creating whitenoisebands

        return complexWhiteNoise;
    }

    private double[] normalizeWhitenoiseSignal(Technology signalType, MainActivity main){
        double[] complexWhiteNoise = produceWhiteNoise(signalType, main);
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

        return helpNoise;
    }

    private double[] makeFadeInAndFadeOut(Technology signalType, MainActivity main){
        double[] helpNoise = normalizeWhitenoiseSignal(signalType, main);
        int fadeAmount = 10;
        int fadeSamples = Math.round(helpNoise.length/fadeAmount);
        //int fadeSamples = Math.round(helpNoise.length / 10); //value for the length of the fade in/fade out
        //int fadeSamples = 500;
        for (int i = 0; i < fadeSamples; i++) { //fade in
            helpNoise[i] = (helpNoise[i] * ((double) i / (double) fadeSamples));
        }

        for (int i = 0; i < fadeSamples; i++) { //fade out
            helpNoise[helpNoise.length - (fadeSamples - (fadeSamples - i)) - 1] = (helpNoise[helpNoise.length - (fadeSamples - (fadeSamples - i)) - 1] * ((double) i / (double) fadeSamples));
        }

        return helpNoise;
    }

    private short[] transformDoubleArrayIntoShortArray(Technology signalType, MainActivity main){
        double[] helpNoise = makeFadeInAndFadeOut(signalType, main);
        if(whiteNoiseVolume == 0){whiteNoiseVolume = 1;}
        for (int i = 0; i < winLenSamples; i++) {
            //helpNoise[i] = (helpNoise[i]*(1+(whiteNoiseVolume/100))); //multiplay every value of the array with numbers between 1.0 to 3.0 (depending on the whiteNoiseValue = Slidervalue)
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

        /*for (int i = 0; i < winLenSamples; i++) {
            whiteNoise[i] = (short) (helpNoise[i] * 32767); //scale the double values up to short by multiplying with 32767
        }*/

        for (int i = 0; i < winLenSamples; i++) {
            whiteNoise[i] = (short) (helpNoise[i] * 32760); //scale the double values up to short by multiplying with 32760
            if(whiteNoise[i] > 32760){ //if new value higher than 1
                whiteNoise[i] = 32760; //change it to 1
            }
            if(whiteNoise[i] < -32760){ //if new value lower than -1
                whiteNoise[i] = -32760; //chang it to -1
            }
        }

        return whiteNoise;
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
            /*for (int k = 0; k < whiteNoiseBands.length-2; k++) {
                for (double l = cutoffFreqDownIdx[k]; l <= cutoffFreqUpIdx[k]; l++) {
                    complexSignal[(int)l] = 10000.0f; //set all frequencies between the higher frequency of one band to the lower frequency of the next band to 0
                }
                int helpSamples = winLenSamples * 2;
                for (double l = helpSamples-cutoffFreqUpIdx[k]; l <= helpSamples-cutoffFreqDownIdx[k]; l++) {
                    complexSignal[(int)l] = 10000.0f; //set all frequencies between the higher frequency of one band to the lower frequency of the next band to 0 mirrored to the doubled winLenSamples size
                }
            }*/

            for (int k = 0; k < whiteNoiseBands.length; k++) {
                for (double l = cutoffFreqDownIdx[k]; l <= cutoffFreqUpIdx[k]; l++) {
                    complexSignal[(int)l] = 1000;
                }
                int helpSamples = winLenSamples * 2;

                for (double l = helpSamples-cutoffFreqUpIdx[k]; l <= helpSamples-cutoffFreqDownIdx[k]; l++) {
                    complexSignal[(int)l] = 1000;
                }
            }
        }

        /*for (int i = 0; i < complexSignal.length - 1; i++) {
            complexSignal[i] = complexSignal[i] * (-1); //invert all algebraic signs
        }

        mFFT.complexForward(complexSignal); //make the fft on the inverted signal
*/
        mFFT.complexInverse(complexSignal,false);
        return complexSignal; //return the signal with the complex values

    }

    /***
     *
     * @param signalTechnology
     * @return
     */
    private double[][] importSpecificSignal(Technology signalTechnology, MainActivity main) {

        double[][] test; //helparray for storing the frequencybands of the technologies
        SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
        bandWidth = 1;//Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_BANDWIDTH, ConfigConstants.SETTING_BANDWIDTH_DEFAULT));

        BufferedReader reader = null;
        try {
            //according to the name of the technology the right file will be scanned and split into lines for each frequency
            switch (signalTechnology) {
                case PRONTOLY:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("prontoly-frequencies.txt"), "UTF-8"));
                    break;
                case GOOGLE_NEARBY:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("nearby-frequencies.txt"), "UTF-8"));
                    break;
                case LISNR:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("lisnr-frequencies.txt"), "UTF-8"));
                    break;
                case SIGNAL360:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("signal360-frequencies.txt"), "UTF-8"));
                    break;
                case SHOPKICK:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("shopkick-frequencies.txt"), "UTF-8"));
                    break;
                case SONITALK:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("sonitalk-frequencies.txt"), "UTF-8"));
                    break;
                case SILVERPUSH:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("silverpush-frequencies.txt"), "UTF-8"));
                    break;
                case SONARAX:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("sonarax-frequencies.txt"), "UTF-8"));
                    break;
                case UNKNOWN:
                    reader = new BufferedReader(new InputStreamReader(main.getAssets().open("unknown-frequencies.txt"), "UTF-8"));
                    bandWidth = 4000;
                    break;
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
                    e.printStackTrace();
                }
            }
        }

        return test; //the array with the frequencybands will be returned

    }

    private AudioTrack generateWhitenoisePlayer(Technology signalType, MainActivity main){
        short[] whiteNoise = transformDoubleArrayIntoShortArray(signalType, main);
        //AudioTrack generatedNoisePlayer;
        //generatedNoisePlayer = generatePlayer(whiteNoise); //create the audiotrack player
        noiseGenerated = true; //after creation of the noise, set the flag to true
        winLenSamples = winLen*fs/1000; //calculating the windowLengthSamples
        audioTrack = new AudioTrack(AudioManager.STREAM_MUSIC,fs, AudioFormat.CHANNEL_CONFIGURATION_MONO, AudioFormat.ENCODING_PCM_16BIT,(winLenSamples/*+(winLenSamples/65)*/)*2,AudioTrack.MODE_STATIC); //creating the audiotrack player with winLenSamples*2 as the buffersize because the constructor wants bytes
        audioTrack.write(whiteNoise, 0, (winLenSamples/*+(winLenSamples/65)*/)); //put the whiteNoise shortarray into the player, buffersize winLenSamples are Shorts here
        return audioTrack;
    }

    public AudioTrack getGeneratedPlayer(){
        return generatedWhitenoisePlayer;
    }

    public void setGeneratedPlayerToNull(){
        if(generatedWhitenoisePlayer!=null){
            generatedWhitenoisePlayer.release();
        } //release the player resources
        /*if(audioTrack!=null){
            audioTrack.release();
        } //release the player resources
        */
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
