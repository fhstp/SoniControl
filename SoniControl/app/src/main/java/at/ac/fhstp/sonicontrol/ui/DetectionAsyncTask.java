/*
 * Copyright (c) 2018, 2019. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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

package at.ac.fhstp.sonicontrol.ui;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.View;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.ref.WeakReference;
import java.util.Arrays;

import at.ac.fhstp.sonicontrol.ConfigConstants;
import at.ac.fhstp.sonicontrol.SignalConverter;
import at.ac.fhstp.sonicontrol.Technology;
import at.ac.fhstp.sonicontrol.utils.Autocorrelation;
import at.ac.fhstp.sonicontrol.utils.HammingWindow;
import edu.emory.mathcs.jtransforms.fft.DoubleFFT_1D;

public class DetectionAsyncTask extends AsyncTask<Context, Integer, Boolean> {
    private static final String TAG = "DetectionAsyncTask";
    private WeakReference<DetectionDialogFragment> detectionDialogFragment;

    // only retain a weak reference to the activity
    public DetectionAsyncTask(DetectionDialogFragment dialogFragment) {
        detectionDialogFragment = new WeakReference<>(dialogFragment);
    }

    // Runs in UI before background thread is called
    @Override
    protected void onPreExecute() {
        super.onPreExecute();

        // Do something like display a progress bar
        DetectionDialogFragment dialog = detectionDialogFragment.get();
        if (dialog != null) {
            if (dialog.progressBar != null)
                dialog.progressBar.setVisibility(View.VISIBLE);
            if(dialog.spectrogramView != null)
                dialog.spectrogramView.setVisibility(View.INVISIBLE);
            if (dialog.btnAlertReplay != null)
                dialog.btnAlertReplay.setEnabled(false);
        }
    }

    // This is run in a background thread
    @Override
    protected Boolean doInBackground(Context... params) {
        Log.d("DetectionTask", "doInBackground");
        // get the float[] from params, which is an array
        Context context = params[0];
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(context);
        int bufferHistoryLength = sp.getInt(ConfigConstants.BUFFER_HISTORY_LENGTH_SHARED_PREF, -1);
        if (bufferHistoryLength == -1) {
            Log.e("DetectionTask", "bufferHistoryLength not stored ?!");
            return false;
        }
        else {
            Log.d("DetectionTask", "Start readingBufferHistory");
            float[] bufferHistory = SignalConverter.readFloatArray(context.getFilesDir() + File.separator + ConfigConstants.BUFFER_HISTORY_FILENAME, bufferHistoryLength);

            if (bufferHistory != null) {
                // Compute the spectrum
                Log.d("DetectionTask", "Start computing spectrogram");
                float[][] spectrum = computeSpectrum(bufferHistory, context); // TODO: Call onSpectrum on return !!!
                Log.d("DetectionTask", "Done computing spectrogram, will show it in the alert if still open");
                // Update spectrum
                //onSpectrum(); This is already called in setSpectrum

                //TODO: Should this be done in all cases ? When ? (do we send detections automatically if user agreed?)
                int maxValueIndex = sp.getInt(ConfigConstants.MAX_VALUE_INDEX_SHARED_PREF, -1);
                if (maxValueIndex == -1) {
                    Log.e("DetectionTask", "maxValueIndex not stored ?!");
                }
                else {
                    SignalConverter.writeWAVHeaderToFile(bufferHistory, context, maxValueIndex);
                }

                DetectionDialogFragment dialog = detectionDialogFragment.get();
                if (dialog != null) {
                    dialog.setSpectrum(spectrum);
                }
                return true;
            }
            else {
                Log.w("DetectionTask", "Could not read buffer history ?!");
                return false;
            }
        }
    }

/*
    // This is called from background thread but runs in UI
    @Override
    protected void onProgressUpdate(Integer... values) {
        super.onProgressUpdate(values);

        // Do things like update the progress bar
    }*/

    // This runs in UI when background thread finishes
    @Override
    protected void onPostExecute(Boolean result) {
        super.onPostExecute(result);

        if (result) {
            // Do things like hide the progress bar or change a TextView
            DetectionDialogFragment dialog = detectionDialogFragment.get();
            if (dialog != null) {
                if (dialog.progressBar != null) {
                    dialog.progressBar.setVisibility(View.GONE);
                }
                if(dialog.spectrogramView != null) {
                    dialog.spectrogramView.setVisibility(View.VISIBLE);
                    dialog.onSpectrum();
                }
                if (dialog.btnAlertReplay != null) {
                    dialog.btnAlertReplay.setEnabled(true);
                }
                if (dialog.txtSignalType != null) {
                    String storedTechnology = PreferenceManager.getDefaultSharedPreferences(dialog.getContext()).getString(ConfigConstants.LAST_DETECTED_TECHNOLOGY_SHARED_PREF, null);
                    dialog.setTechnologyText(storedTechnology);
                }
            }
        }
    }
/*
    public void onSpectrum() {
        alert.onSpectrum();
    }
*/
    private float[][] computeSpectrum(float[] bufferHistory, Context context) {
        float[] bufferHistoryMono = bufferHistory;
        /*
        // Convert from stereo to mono
        float[] bufferHistoryMono = new float[bufferHistory.length / 2];
        for (int i = 0, counter = 0; i < bufferHistory.length; i += 2, counter++) {
            bufferHistoryMono[counter] = (bufferHistory[i] + bufferHistory[i+1]) / 2;
        }
        */

        // Spectrogram / Recognition parameters
        //float winLenForSpectrogram = 46.44; //ms
        //winLenForSpectrogramInSamples = Math.round(Fs * (float) winLenForSpectrogram/1000);
        int winLenForSpectrogramInSamples = ConfigConstants.VIZ_FFT_SIZE;
        int Fs = ConfigConstants.SCAN_SAMPLE_RATE;
        int overlapFactor = ConfigConstants.SPECTROGRAM_OVERLAP_FACTOR;

        if (winLenForSpectrogramInSamples % 2 != 0) {
            winLenForSpectrogramInSamples ++; // Make sure winLenForSpectrogramInSamples is even
        }
        int nbWinLenForSpectrogram = Math.round(overlapFactor * (float) bufferHistoryMono.length / (float) winLenForSpectrogramInSamples);


        int lowerCutoffFrequency = ConfigConstants.LOWER_CUTOFF_FREQUENCY; // Defined in the CPP, should it be a setting ?
        int upperCutoffFrequency = ConfigConstants.UPPER_CUTOFF_FREQUENCY;

        int lowerCutoffFrequencyIdx = (int)((float)lowerCutoffFrequency/(float)Fs*(float)winLenForSpectrogramInSamples);// + 1;
        int upperCutoffFrequencyIdx = (int)((float)upperCutoffFrequency/(float)Fs*(float)winLenForSpectrogramInSamples);// + 1;

        Log.d("computeSpectrum", "Creating historyBufferDouble");
        double[][] historyBufferDouble = new double[nbWinLenForSpectrogram][winLenForSpectrogramInSamples];
        for(int j = 0; j<historyBufferDouble.length;j++ ) {
            int helpArrayCounter = 0;

            for (int i = (j/overlapFactor)*winLenForSpectrogramInSamples + ((j%overlapFactor) * winLenForSpectrogramInSamples/overlapFactor); i < bufferHistoryMono.length && i < (1 + j/overlapFactor)*winLenForSpectrogramInSamples + ((j%overlapFactor) * winLenForSpectrogramInSamples/overlapFactor); i++) {
                historyBufferDouble[j][helpArrayCounter] = (double) bufferHistoryMono[i];
                helpArrayCounter++;
            }
        }
        HammingWindow hammWin = new HammingWindow(winLenForSpectrogramInSamples);
        DoubleFFT_1D mFFT = new DoubleFFT_1D(winLenForSpectrogramInSamples);
        /*int normalizedSpectrogramSize = upperCutoffFrequencyIdx - lowerCutoffFrequencyIdx; // No +1 as we start with index 0
        double[][] historyBufferDoubleAbsolute = new double[nbWinLenForSpectrogram][normalizedSpectrogramSize];
        float[][] historyBufferFloatNormalized = new float[nbWinLenForSpectrogram][normalizedSpectrogramSize];*/
        double[][] historyBufferDoubleAbsolute = new double[nbWinLenForSpectrogram][winLenForSpectrogramInSamples / 2];
        float[][] historyBufferFloatNormalized = new float[nbWinLenForSpectrogram][historyBufferDoubleAbsolute[0].length];

        // Recognition specific ---
        double[] historySignalFFT = new double[historyBufferDoubleAbsolute[0].length];
        Arrays.fill(historySignalFFT, 0.0);
        // ---

        double highPassFftSum = 0;
        double minValue = Double.MAX_VALUE;
        double maxValue = Double.MIN_VALUE;
        int helpCounter;
        for(int j = 0; j<historyBufferDoubleAbsolute.length;j++ ) {
            //Log.d("computeSpectrum", "Iteration : " + j);
            // n is even [DONE on winLenForSpectrogramInSamples]
            //Log.d("computeSpectrum", "Applying Hamming window");
            hammWin.applyWindow(historyBufferDouble[j]);

            //Log.d("computeSpectrum", "Applying FFT");
            mFFT.realForward(historyBufferDouble[j]);

            // Get absolute value of the complex FFT result (only upper frequencies)
            helpCounter = 0;
            //highPassFftSum = 0;
            //Log.d("computeSpectrum", "Compute absolute and sum, lowerCutoffFrequencyIdx " + lowerCutoffFrequencyIdx + " upperCutoffFrequencyIdx " + upperCutoffFrequencyIdx);
            //for (int l = 2 * lowerCutoffFrequencyIdx; l < 2 * upperCutoffFrequencyIdx; l += 2) {
            for (int l = 0; l < historyBufferDouble[0].length; l += 2) {
                // Start at 2 times lowerCutoffFrequencyIdx to skip values (real and complex) under the ultrasound threshold
                // Increment by 2 to always get the real value

                double absolute = 0;
                if (l >= 2 * lowerCutoffFrequencyIdx && l < 2 * upperCutoffFrequencyIdx) {
                    absolute = getComplexAbsolute(historyBufferDouble[j][l], historyBufferDouble[j][l + 1]);
                }
                // Logarithmizing does not seem to improve the visualization because it is done by the visualization class.
                /*double log = 0.0000001;
                if(absolute != 0) {
                    log = Math.log(absolute);
                }*/
                historyBufferDoubleAbsolute[j][helpCounter] = absolute;
                // Recognition specific ---
                historySignalFFT[helpCounter] = historySignalFFT[helpCounter] + absolute;
                // ---

                highPassFftSum += absolute;
                if (absolute > maxValue)
                    maxValue = absolute;
                if (absolute < minValue)
                    minValue = absolute;

                helpCounter++;
            }
        }

        // Recognition specific ---
        Log.d("computeSpectrum", "Start computing recognition");

        int nSamplesHistory = historySignalFFT.length;
        // Averaging the STFT, if this does not give the same result as an FFT over the whole
        // buffer history then we will need to recompute the FFT.
        for (int i = 0; i < nSamplesHistory; i++) {
            historySignalFFT[i] = historySignalFFT[i] / nSamplesHistory;
        }
        //double fftMax = maxValue; // In the recognition we only use one FFT for the whole buffer history.

        Technology detectedTechnology = computeRecognition(historySignalFFT, winLenForSpectrogramInSamples, maxValue, context);
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(context);
        sp.edit().putString(ConfigConstants.LAST_DETECTED_TECHNOLOGY_SHARED_PREF, detectedTechnology.toString()).apply();
        Log.d("computeSpectrum", "Done computing recognition");
        // ---


        // Normalize over the whole spectrum as it seems to give better results than over each column
        //[NOTE: In previous experiments as well (see SoniTalk) it looked like results are better
        // with a normalization over the whole spectrum, maybe because of the overlap]
        Log.d("computeSpectrum", "Normalizing");
        for(int j = 0; j < historyBufferFloatNormalized.length; j++) {
            for (int l = 0; l < historyBufferDoubleAbsolute[j].length; l++) {
                float normalized = 0.00001f;
                if (highPassFftSum != 0 && historyBufferDoubleAbsolute[j][l] != 0) {
/*
                    // Reduce noise
                    normalized = (float) (historyBufferDoubleAbsolute[j][l] / highPassFftSum);
                    minValue = minValue / highPassFftSum;
                    maxValue = maxValue / highPassFftSum;
                    // Shift values to [0;1]
                    normalized = (float) ((normalized - minValue) / (maxValue - minValue));
                    */

                    // Shift values to [0;1]
                    normalized = (float) ((historyBufferDoubleAbsolute[j][l] - minValue) / (maxValue - minValue));

                    int workaroundFactor = 4; // Reduce the impact of dividing by the whole highPassFftSum
                    // Noise reduction / "Dimming"
                    normalized = (float) (workaroundFactor * normalized / highPassFftSum);


                } // Else all the values are 0 so we do not really care ?
                historyBufferFloatNormalized[j][l] = normalized;
            }
        }
        Log.d("computeSpectrum", "Done normalizing, return");
        return historyBufferFloatNormalized;
    }

    private static Technology computeRecognition(double[] historySignalFFT, int nSamplesHistory, double fftMax, Context context) {
        Technology recogResult = Technology.UNKNOWN;

        int[] nearbyCenterFrequencies = getCenterFrequencies(Technology.GOOGLE_NEARBY, context);
        int[] lisnrCenterFrequencies = getCenterFrequencies(Technology.LISNR, context);
        int[] prontolyCenterFrequencies = getCenterFrequencies(Technology.PRONTOLY, context);
        int[] shopkickCenterFrequencies = getCenterFrequencies(Technology.SHOPKICK, context);
        int[] silverpushCenterFrequencies = getCenterFrequencies(Technology.SILVERPUSH, context);

        // 3. Perform recognition of the individual technologies
        Technology[] technologies = {Technology.GOOGLE_NEARBY, Technology.LISNR, Technology.PRONTOLY, Technology.SHOPKICK, Technology.SILVERPUSH, Technology.UNKNOWN};

        // Recognition is hierarchical:
        // First check if the signal is a nearby message with the autocorrelation detector:
        Log.d(TAG, "Compute score Nearby");
        double scoreNearbyAC = detectNearby(historySignalFFT, nearbyCenterFrequencies, ConfigConstants.SCAN_SAMPLE_RATE, nSamplesHistory);
        double scoreLisnr = 0.0;
        double scoreProntoly = 0.0;
        double scoreShopkick = 0.0;
        double scoreSilverpush = 0.0;
        if (scoreNearbyAC > ConfigConstants.DECISION_THRESHOLD_NEARBY_AC) {
            recogResult = Technology.GOOGLE_NEARBY;
        }
        else { //Second: try out all other technologies
            Log.d(TAG, "Compute score Lisnr");
            scoreLisnr = detectActivity(historySignalFFT, fftMax, lisnrCenterFrequencies, ConfigConstants.LISNR_BANDWIDTH, ConfigConstants.SCAN_SAMPLE_RATE, nSamplesHistory, ConfigConstants.LOWER_CUTOFF_FREQUENCY);
            Log.d(TAG, "Compute score Prontoly");
            scoreProntoly = detectActivity(historySignalFFT, fftMax, prontolyCenterFrequencies, ConfigConstants.PRONTOLY_BANDWIDTH, ConfigConstants.SCAN_SAMPLE_RATE, nSamplesHistory, ConfigConstants.LOWER_CUTOFF_FREQUENCY);
            Log.d(TAG, "Compute score Shopkick");
            scoreShopkick = detectActivity(historySignalFFT, fftMax, shopkickCenterFrequencies, ConfigConstants.SHOPKICK_BANDWIDTH, ConfigConstants.SCAN_SAMPLE_RATE, nSamplesHistory, ConfigConstants.LOWER_CUTOFF_FREQUENCY);
            Log.d(TAG, "Compute score Silverpush");
            scoreSilverpush = detectActivity(historySignalFFT, fftMax, silverpushCenterFrequencies, ConfigConstants.SILVERPUSH_BANDWIDTH, ConfigConstants.SCAN_SAMPLE_RATE, nSamplesHistory, ConfigConstants.LOWER_CUTOFF_FREQUENCY);

            double[] scores = {0, scoreLisnr, scoreProntoly, scoreShopkick, scoreSilverpush}; //the 0 stands for nearby
            double maxScore = 0.0;
            for (int i = 0; i < scores.length; i++) {
                if (scores[i] > maxScore) {
                    maxScore = scores[i];
                    recogResult = technologies[i];
                }
                Log.d(TAG, "Score " + technologies[i].toString() + ": " + scores[i]);
            }
            if (maxScore < 1) { //no technology achieved a high score -> declare the message as unknown message
                 recogResult = Technology.UNKNOWN;
            }
        }
//
//      %make some debug output:
//    %  disp(['detected: ' num2str(techniques{recogResult}) ' message']);
//    %  scores
        Log.d(TAG, "recogResult: " + recogResult);
        return recogResult;
    }

    private static double detectActivity(double[] fftSpectrum, double fftMax, int[] centerFreq, double bandwidth, int fs, int nSamples, int cutOffFrequency) {
        double score = 0.0;

        for (int i = 0; i < fftSpectrum.length; i++) {
            fftSpectrum[i] = fftSpectrum[i] / fftMax; // divide by the maximum, so that the theoretical max value of the resulting score can be 1 (minimum = 0)
        }

        int nBands = centerFreq.length;
        //TODO: What happens if some frequencies are under the cutoff or above fs/2 ?
        int nOffBands = nBands + 1; // Starts at cutoff frequency and stops at the highest frequency

        double[] bandEnergy = new double[nBands];
        Arrays.fill(bandEnergy, 0.0);
        for (int i = 0; i < nBands; i++) {
            int bandStartFreqIdx = freq2idx((centerFreq[i] - bandwidth), fs, nSamples);
            int bandEndFreqIdx = freq2idx((centerFreq[i] + bandwidth), fs, nSamples);

            for (int j = bandStartFreqIdx; j < bandEndFreqIdx; j++) {
                if (fftSpectrum[j] > bandEnergy[i]) {
                    bandEnergy[i] = fftSpectrum[j];
                }
            }
            Log.d(TAG, "bandEnergy[" + i + "]: " + String.format("%.12f", bandEnergy[i]));
        }

        double[] offBandEnergy = new double[nOffBands];
        Arrays.fill(offBandEnergy, 0.0);
        double sumOffBandEnergy = 0.0;
        for (int i = 0; i < nOffBands; i++) {
            int bandStartFreqIdx = 0;
            int bandEndFreqIdx = 0;

            if (i == 0) {
                bandStartFreqIdx = freq2idx(cutOffFrequency, fs, nSamples); //Starts at cutoffFrequency
                bandEndFreqIdx = freq2idx(centerFreq[0] - bandwidth + 1, fs, nSamples); //add 1 to avoid overlap with the "on"-frequency bands
            }
            else if (i == nOffBands-1) {
                bandStartFreqIdx = freq2idx(centerFreq[centerFreq.length - 1] + bandwidth - 1, fs, nSamples); //remove 1 to avoid overlap with the "on"-frequency bands
                bandEndFreqIdx = freq2idx(Math.floor(fs/2) - 1, fs, nSamples); // Ends at the highest frequency possible
            }
            else {
                bandStartFreqIdx = freq2idx((centerFreq[i-1] + bandwidth - 1), fs, nSamples); //remove 1 to avoid overlap with the "on"-frequency bands
                bandEndFreqIdx = freq2idx((centerFreq[i] - bandwidth + 1), fs, nSamples); //add 1 to avoid overlap with the "on"-frequency bands
            }

            for (int j = bandStartFreqIdx; j < bandEndFreqIdx; j++) {
                if (fftSpectrum[j] > offBandEnergy[i]) {
                    offBandEnergy[i] = fftSpectrum[j];
                }
            }
            sumOffBandEnergy += offBandEnergy[i];
            Log.d(TAG, "offBandEnergy[" + i + "]: " + String.format("%.12f", offBandEnergy[i]));
        }

        //get the highest quarter of the in band frequencies (in case not all are present)
        Arrays.sort(bandEnergy);
        double quantileToKeep = 0.75; //Keep the 75% highest values (in case some frequencies were not sent this time)
        int startQuantileIdx = (int) Math.ceil(nBands * (1-quantileToKeep));

        double sumInBandEnergy = 0.0;
        for (int i = startQuantileIdx; i < nBands; i++) {
            sumInBandEnergy += bandEnergy[i];
        }

        double inBandScore = sumInBandEnergy / (nBands-startQuantileIdx);
        double outBandScore = sumOffBandEnergy / nOffBands;

        score = inBandScore/outBandScore;

        return score;
    }

    /**
     * Returns the autocorrelation score for Google Nearby.
     *
     * Absolute lower limit for nearby detection is: 50ms windows
     * Below that the frequencies of nearby are not at all separable
     * For a good AC estimate 200ms winSize are necessary
     * Additionally, to get a good frequency distribution, a long-time analysis needs to be performed.
     * This means, that at least 1s (better 2s) should be analyzed at once, to make sure that all
     * nearby frequencies are contained in the analysis.
     *
     *
     * To do: try out zero padding for shorter analysis windows? Does it improve the detection for e.g. 50ms
     *
     * Note: For the pure detection of nearby, an RMS-based method (detectNearbyFast()) is much more robust and  computationally more efficient
     *
     * @param fftSpectrum fft spectrum of the history buffer to be analyzed
     * @param nearbyCenterFrequencies integer array containing the center frequencies used by Nearby
     * @param fs sample rate
     * @param nSamples number of samples in the fftSpectrum
     * @return autocorrelation score for nearby
     */
    private static double detectNearby(double[] fftSpectrum, int[] nearbyCenterFrequencies, int fs, int nSamples) {
        double score = 0.0;

        // Compute the spacing between center frequencies into centerFreqIdxDiff
        int[] centerFreqIdx = new int[nearbyCenterFrequencies.length];
        int[] centerFreqIdxDiffs = new int[centerFreqIdx.length - 1];
        for (int i = 0; i < centerFreqIdx.length; i++) {
            centerFreqIdx[i] = freq2idx((double) nearbyCenterFrequencies[i], fs, nSamples);
            if (i > 0) {
                centerFreqIdxDiffs[i-1] = centerFreqIdx[i] - centerFreqIdx[i-1];
            }
        }
        Arrays.sort(centerFreqIdxDiffs);
        int centerFreqIdxDiff = centerFreqIdxDiffs[centerFreqIdxDiffs.length/2]; // If the length is even we take the upper index (indexes cannot be split in two anyways).

        // We work only on the relevant part of the spectrum (Nearby frequencies)
        final int nbIdxOfInterest = centerFreqIdx[centerFreqIdx.length - 1] + 1 - centerFreqIdx[0];
        double[] fftSpectrumOfInterest = new double[nbIdxOfInterest];
        /*for (int i = centerFreqIdx[0]; i <= centerFreqIdx[centerFreqIdx.length - 1]; i++) {
            fftSpectrumOfInterest[helpCounter] = fftSpectrum[i];
        }
        */
        // IDE suggested to replace the loop with System.arraycopy:
        if (nbIdxOfInterest >= 0)
            System.arraycopy(fftSpectrum, centerFreqIdx[0], fftSpectrumOfInterest, 0, nbIdxOfInterest);

        // We compute the autocorrelation for a frequency range (maxLag) of 5 Nearby center frequencies so that we can calculate the energy at these frequencies versus in between (18500,18524,18548,18571,18595)
        int maxLag = centerFreqIdxDiff*5;
        double[] ac = new double[maxLag];
        Autocorrelation.bruteForceAutoCorrelation(fftSpectrumOfInterest, ac, maxLag);

        // Normalize (first value is the max as it is 100% correlating)
        for (int i = 1; i < maxLag; i++) {
            ac[i] /= ac[0];
        }
        ac[0] = 1;

        double inFrequencyScore  = ac[centerFreqIdxDiff] * ac[2*centerFreqIdxDiff] * ac[3*centerFreqIdxDiff] * ac[4*centerFreqIdxDiff];
        double outFrequencyScore = ac[(int) Math.floor(centerFreqIdxDiff*1.5)] * ac[(int) Math.floor(centerFreqIdxDiff*2.5)] * ac[(int) Math.floor(centerFreqIdxDiff*3.5)] * ac[(int) Math.floor(centerFreqIdxDiff*4.5)]; //round might give an index out of bound (e.g. if the diff is 1)

        Log.d(TAG, "inFrequencyScore: " + inFrequencyScore);
        Log.d(TAG, "outFrequencyScore: " + outFrequencyScore);

        if (inFrequencyScore > outFrequencyScore)
            score = (inFrequencyScore-outFrequencyScore);
        else
            score = 0;

        return score;
    }

    /**
     * Calculates an absolute value of a complex number
     * @param real
     * @param imaginary
     * @return the absolute value of the real and imaginary parts passed
     */
    public static double getComplexAbsolute(double real, double imaginary) {
        return Math.sqrt(real*real + (imaginary*imaginary));
    }

    private static int[] getCenterFrequencies(Technology technology, Context context) {
        String fileName = "";
        //according to the name of the technology the right file will be scanned and split into lines for each frequency
        switch (technology) {
            case PRONTOLY:
                fileName = "prontoly-frequencies.txt";
                break;
            case GOOGLE_NEARBY:
                fileName = "nearby-frequencies.txt";
                break;
            case LISNR:
                fileName = "lisnr-frequencies.txt";
                break;
            case SIGNAL360:
                fileName = "signal360-frequencies.txt";
                break;
            case SHOPKICK:
                fileName = "shopkick-frequencies.txt";
                break;
            case SILVERPUSH:
                fileName = "silverpush-frequencies.txt";
                break;
            case UNKNOWN:
                fileName = "unknown-frequencies.txt";
                break;
        }

        BufferedReader reader = null;
        int[] frequencies = null;

        try {
            reader = new BufferedReader(new InputStreamReader(context.getAssets().open(fileName), "UTF-8"));

            String[] stringFrequencies = reader.readLine().split(",");
            frequencies = new int[stringFrequencies.length];
            for (int i = 0; i < frequencies.length; i++) {
                frequencies[i] = Integer.parseInt(stringFrequencies[i]);
            }
        } catch (IOException e) {
            Log.e(TAG, "Problem when accessing the technology frequencies file: " + e.getMessage());
            return null;
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
        return frequencies;
    }

    public static int freq2idx(double freq, int fs, int winLen) {
        return (int) Math.round(freq/fs*winLen);
    }

}
