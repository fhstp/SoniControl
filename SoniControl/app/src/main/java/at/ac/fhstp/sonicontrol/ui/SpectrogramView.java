/**
 * Spectrogram Android application
 * Copyright (c) 2013 Guillaume Adam  http://www.galmiza.net/

 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it freely,
 * subject to the following restrictions:

 * 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * ***
 *
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

package at.ac.fhstp.sonicontrol.ui;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;

import at.ac.fhstp.sonicontrol.utils.Misc;

/**
 * This class displays a full spectrogram from a two dimensional float array spectrum. It is inspired from
 * the class FrequencyView written by Guillaume Adam (see https://bitbucket.org/galmiza/spectrogram-android)
 *
 */
public class SpectrogramView extends View {

    // Attributes
    private Activity activity;
    private Paint paint = new Paint();
    private Bitmap bitmap;
    public Canvas canvas;
    private int pos;
    private int samplingRate;
    private int width, height;

    private float[] magnitudes;
    private float[][] historyBuffer;
    private float maxBuffer;
    private float minBuffer;

    private int fftResolution;
    private int historyBufferLength;

    private int[] colorRainbow = new int[] {    0xFFFFFFFF, 0xFFFF00FF, 0xFFFF0000, 0xFFFFFF00, 0xFF00FF00, 0xFF00FFFF, 0xFF0000FF, 0xFF000000 };
    private int[] colorFire = new int[] {    0xFFFFFFFF, 0xFFFFFF00, 0xFFFF0000, 0xFF000000 };
    private int[] colorIce = new int[] {    0xFFFFFFFF, 0xFF00FFFF, 0xFF0000FF, 0xFF000000 };
    private int[] colorGrey = new int[] {    0xFFFFFFFF, 0xFF000000 };


    // Should be defined according to the values from the settings (same for the FFT resolution)
    private int nFrequencies = 16;
    private int frequencySpace = 100;
    private int frequencyOffsetForSpectrogram = 50;

    private int cutoffFrequency = 18000;
    private int cutoffFrequencyViz  = cutoffFrequency - frequencyOffsetForSpectrogram; // The bit bandwidth is not only 1Hz, and it is nicer to see a bit more
    private int upperCutoffFrequency = cutoffFrequency + frequencySpace*nFrequencies;
    private int upperCutoffFrequencyViz = upperCutoffFrequency + frequencyOffsetForSpectrogram;

    private int binSizeinHz;
    private int cutoffFrequencyIdx;

    private boolean onlyShowUpperFrequencies = true;

    public void setnFrequencies(int nFrequencies) {
        this.nFrequencies = nFrequencies;
    }

    public void setFrequencySpace(int frequencySpace) {
        this.frequencySpace = frequencySpace;
    }

    public void setCutoffFrequency(int cutoffFrequency) {
        this.cutoffFrequency = cutoffFrequency;
        cutoffFrequencyViz  = cutoffFrequency - frequencyOffsetForSpectrogram;
        if (cutoffFrequencyViz < 0)
            cutoffFrequencyViz = 0;
    }

    public void setUpperCutoffFrequency(int upperCutoffFrequency) {
        this.upperCutoffFrequency = upperCutoffFrequency;
        upperCutoffFrequencyViz  = upperCutoffFrequency + frequencyOffsetForSpectrogram;
        if (cutoffFrequencyViz > samplingRate / 2)
            cutoffFrequencyViz = samplingRate / 2;
    }

    /**
     * To be called after updating nFrequencies, frequencySpace or cutoffFrequency
     */
    public void recomputeUpperCutoffFrequency() {
        this.upperCutoffFrequency = cutoffFrequency + frequencySpace*nFrequencies;
        upperCutoffFrequencyViz = upperCutoffFrequency + frequencyOffsetForSpectrogram;
    }

    public void setOnlyShowUpperFrequencies(boolean onlyShowUpperFrequencies) {
        this.onlyShowUpperFrequencies = onlyShowUpperFrequencies;
    }


    public void setFrequencyOffsetForSpectrogram(int frequencyOffsetForSpectrogram) {
        this.frequencyOffsetForSpectrogram = frequencyOffsetForSpectrogram;
    }


    // Window
    float minX, minY, maxX, maxY;
    public SpectrogramView(Context context) {
        super(context);
        activity = (Activity) Misc.getAttribute("activity");
    }
    public SpectrogramView(Context context, AttributeSet attrs) {
        super(context, attrs);
        activity = (Activity) Misc.getAttribute("activity");
    }


    @Override
    protected void onSizeChanged(int w, int h, int oldw, int oldh) {
        width = w;
        height = h;
        if (bitmap!=null)    bitmap.recycle();
        bitmap = Bitmap.createBitmap(width, height, Bitmap.Config.ARGB_8888);
        canvas = new Canvas(bitmap);
    }
    @SuppressLint("ClickableViewAccessibility")
    @Override
    public boolean onTouchEvent(MotionEvent event) {
        //invalidate();
        return true;
    }

    /**
     * Simple sets
     */
    public void setFFTResolution(int res) {
        magnitudes = new float[res];
        fftResolution = res;

        historyBuffer = new float[0][0];
    }
    public void setSamplingRate(int sampling) {
        samplingRate = sampling;
    }
    private void setMagnitudes(float[] m) {
        System.arraycopy(m, 0, magnitudes, 0, m.length);
    }

    public void setHistoryBuffer(float[][] m) {
        //TODO:
        // float[][] historyBufferFloat = new float[Math.round(analysisHistoryBuffer.length/analysisWinLen)][analysisWinLen];
        historyBuffer = m;
        //System.arraycopy(m, 0, historyBuffer, 0, m.length);
        historyBufferLength = historyBuffer.length;

        //storeMinMax(historyBuffer);
    }

    private void storeMinMax(float[][] historyBuffer) {
        minBuffer = Float.MAX_VALUE;
        maxBuffer = Float.MIN_VALUE;
        for (int i = 0; i < historyBuffer.length; i++) {
            for (int j = 0; j < historyBuffer[0].length; j++) {
                float value = (float) (0.009 * Math.max(0, -20 * Math.log10(historyBuffer[i][j])));
                if (value > maxBuffer)
                    maxBuffer = value;
                if (value < minBuffer)
                    minBuffer = value;
            }
        }
        if (minBuffer < 0)
            minBuffer = 0;
        Log.d("stretchContrastTo01", "minBuffer: " + minBuffer);
        Log.d("stretchContrastTo01", "maxBuffer: " + maxBuffer);
    }

    /**
     * Called whenever a redraw is needed
     * Renders spectrogram and scale on the right
     * Frequency scale can be linear or logarithmic
     */
    @Override
    public void onDraw(Canvas canvas) {
        // Do not draw anything if we do not have data.
        if (fftResolution == 0) {
            return;
        }

        //Always overwrite the previous spectrogram
        pos = 0;

        int[] colors = null;
        String colorScale = Misc.getPreference(activity, "color_scale", "Fire");
        if (colorScale.equals("Grey"))     colors = colorGrey;
        else if (colorScale.equals("Fire"))     colors = colorFire;
        else if (colorScale.equals("Ice"))      colors = colorIce;
        else if (colorScale.equals("Rainbow"))  colors = colorRainbow;

        int wColor = 10;
        int wFrequency = 63;
        int rWidth = width-wColor-wFrequency;
        int strokeWidth;
        strokeWidth = rWidth / historyBufferLength;
        Log.d("onDraw", "strokeWidth " + strokeWidth);
        /*if (onlyShowUpperFrequencies) {
            strokeWidth = 4; // 4 for an overlapFactor of 8.
        }
        else {
            strokeWidth = 1; // With no overlap : 1 for the whole range of frequencies, 10 or 20 for the upper frequencies
        }*/
        paint.setStrokeWidth(strokeWidth);

        // Get scale preferences
        String defFrequency = "4416";
        boolean logFrequency = !Misc.getPreference("frequency_scale", defFrequency).equals(defFrequency);

        // Update buffer bitmap
        //paint.setColor(Color.GREEN);
        //this.canvas.drawLine(pos%rWidth, 0, pos%rWidth, height, paint);
        //Log.d("draw", "onlyShowUpperFrequencies " + onlyShowUpperFrequencies);
        for (int winStart=0; winStart < historyBuffer.length; winStart++) {
            System.arraycopy(historyBuffer[winStart], 0, magnitudes, 0, fftResolution);

            for (int i = 0; i < height; i++) {
                float j;
                if (onlyShowUpperFrequencies) {
                    // Displays only upper frequencies
                    j = getValueFromRelativePosition((float) (height - i) / height, cutoffFrequencyViz, upperCutoffFrequencyViz, logFrequency);
                    //Log.d("draw: ", "j:" + j + " . i:" + i + " . height:" + height + " . cutoffFrequency:" + cutoffFrequency + " . upperCutoffFrequency:" + upperCutoffFrequency);
                }
                else {
                    // Version that displays the whole range of frquencies
                    j = getValueFromRelativePosition((float)(height-i)/height, 1, samplingRate/2, logFrequency);
                }

                j /= samplingRate / 2;
                // Currently requires the whole array

                //Log.d("draw", "j:" + j + " . magnitudes.length:" + magnitudes.length);
                float mag = magnitudes[(int) (j * magnitudes.length)];
                float db = (float) Math.max(0, -20 * Math.log10(mag));
                float valueToVisualize = db * 0.009f;

                // Improve contrast by stretching values to fill the [0;1] range
                /*float contrastImprovedValue = stretchContrastTo01(valueToVisualize, minBuffer, maxBuffer);
                */
                int c = getInterpolatedColor(colors, valueToVisualize);//contrastImprovedValue);
                paint.setColor(c);
                int x = pos % rWidth;
                int y = i;
                this.canvas.drawPoint(x, y, paint);
                this.canvas.drawPoint(x, y, paint); // make color brighter
                //this.canvas.drawPoint(pos%rWidth, height-i, paint); // make color even brighter
            }

            // Draw bitmap
            if (pos < rWidth) {
                canvas.drawBitmap(bitmap, wColor, 0, paint);
            } else {
                int drawingSize = strokeWidth * historyBuffer.length;
                canvas.drawBitmap(bitmap, (float) wColor - drawingSize % rWidth, 0, paint);
                canvas.drawBitmap(bitmap, (float) wColor + (rWidth - drawingSize % rWidth), 0, paint);
            }

            pos += strokeWidth;
        }

        // Draw a green line showing the end of the message.
        paint.setColor(Color.GREEN);
        pos -= (strokeWidth/2 - 1);
        paint.setStrokeWidth(1);
        this.canvas.drawLine(pos%rWidth, 0, pos%rWidth, height, paint);
        pos += (strokeWidth/2 + 1);
        paint.setStrokeWidth(strokeWidth);
        // ------------------------------------------------

        // Draw color scale
        paint.setColor(Color.BLACK);
        canvas.drawRect(0, 0, wColor, height, paint);
        for (int i=0; i<height; i++) {
            int c = getInterpolatedColor(colors, ((float) i)/height);
            paint.setColor(c);
            canvas.drawLine(0, i, wColor-5, i, paint);
        }

        // Draw frequency scale
        float ratio = 0.7f*getResources().getDisplayMetrics().density;
        paint.setTextSize(12f*ratio);
        paint.setColor(Color.BLACK);
        // Uncomment "rWidth + wColor" to only draw the content of the buffer, keep "pos" to draw the rest of the space available in black.
        canvas.drawRect(pos/*rWidth + wColor*/, 0, width, height, paint);
        paint.setColor(Color.WHITE);
        canvas.drawText("kHz", rWidth + wColor, 12*ratio, paint);
        if (logFrequency) {
            for (int i=1; i<5; i++) {
                float y = getRelativePosition((float) Math.pow(10,i), 1, samplingRate/2, logFrequency);
                canvas.drawText("1e"+i, rWidth + wColor, (1f-y)*height, paint);
            }
        } else {
            if (onlyShowUpperFrequencies) {
                //To get a scale only for upper frequencies
                for (int i=cutoffFrequencyViz + frequencyOffsetForSpectrogram; i < upperCutoffFrequencyViz - 500; i+=500) {
                    //canvas.drawText(" "+i/1000.0f, rWidth + wColor, height*(1f-(float) (i-cutoffFrequency)/((samplingRate/2)-cutoffFrequency)), paint);
                    canvas.drawText("" + i / 1000.0f, rWidth + wColor, height * (1f - getRelativePosition(i, cutoffFrequencyViz, upperCutoffFrequencyViz, logFrequency)), paint);
                }
            }
            else {
                // To get a scale for the whole range of frequencies
                for (int i=0; i<(samplingRate-500)/2; i+=1000)
                    canvas.drawText(""+i/1000.0, rWidth + wColor, height*(1f-(float) i/(samplingRate/2)), paint);
            }

        }
    }

    private float stretchContrastTo01(float value, float min, float max) {
        if (value < 0)
            return 0;
        int newMax = 1;
        int newMin = 0;

        //Log.d("stretchContrastTo01", "old: " + value);
        float newValue = (value-min) * ((newMax-newMin) / (max-min)) + newMin;
        //Log.d("stretchContrastTo01", "new: " + newValue);
        return newValue;
    }


    /**
     * Converts relative position of a value within given boundaries
     * Log=true for logarithmic scale
     */
    private float getRelativePosition(float value, float minValue, float maxValue, boolean log) {
        if (log)	return ((float) Math.log10(1+value-minValue) / (float) Math.log10(1+maxValue-minValue));
        else		return (value-minValue)/(maxValue-minValue);
    }

    /**
     * Returns a value from its relative position within given boundaries
     * Log=true for logarithmic scale
     */
    private float getValueFromRelativePosition(float position, float minValue, float maxValue, boolean log) {
        if (log)	return (float) (Math.pow(10, position*Math.log10(1+maxValue-minValue))+minValue-1);
        else		return minValue + position*(maxValue-minValue);
    }

    /**
     * Calculate rainbow colors
     */
    private int ave(int s, int d, float p) {
        return s + Math.round(p * (d - s));
    }
    public int getInterpolatedColor(int[] colors, float unit) {
        if (unit <= 0) return colors[0];
        if (unit >= 1) return colors[colors.length - 1];

        float p = unit * (colors.length - 1);
        int i = (int) p;
        p -= i;

        // now p is just the fractional part [0...1) and i is the index
        int c0 = colors[i];
        int c1 = colors[i + 1];
        int a = ave(Color.alpha(c0), Color.alpha(c1), p);
        int r = ave(Color.red(c0), Color.red(c1), p);
        int g = ave(Color.green(c0), Color.green(c1), p);
        int b = ave(Color.blue(c0), Color.blue(c1), p);

        return Color.argb(a, r, g, b);
    }

}

