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

import static at.ac.fhstp.sonicontrol.utils.Recognition.computeRecognition;
import static at.ac.fhstp.sonicontrol.utils.Recognition.getComplexAbsolute;

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

        // Recognition specific [using an avg of the VIZ spectrum]---
        /*double[] historySignalFFT = new double[historyBufferDoubleAbsolute[0].length];
        Arrays.fill(historySignalFFT, 0.0);
        */// ---

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
                // Recognition specific [using an avg of the VIZ spectrum] ---
                //historySignalFFT[helpCounter] = historySignalFFT[helpCounter] + absolute;
                // ---

                highPassFftSum += absolute;
                if (absolute > maxValue)
                    maxValue = absolute;
                if (absolute < minValue)
                    minValue = absolute;

                helpCounter++;
            }
        }

        // Recognition specific [using an avg of the VIZ spectrum] ---
        /*Log.d("computeSpectrum", "Start computing recognition");

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
        */// ---


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

}
