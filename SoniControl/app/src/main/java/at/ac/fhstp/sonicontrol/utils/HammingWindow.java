/*
Copyright 2014 Benjamin Elliott

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

package at.ac.fhstp.sonicontrol.utils;

/**
 * Hamming window class utility.
 */
public class HammingWindow implements WindowFunction {

    private final int windowSize;
    private final double[] hammingWindow;

    public HammingWindow(int windowSize) {
        this.windowSize = windowSize;
        this.hammingWindow = generateHammingWindow(windowSize);
    }


    /**
     * Generates a Hamming Window.
     * @param windowSize - the size of the window (in elements)
     * @return a {@code double[]} of window coefficients.
     */
    private static double[] generateHammingWindow(int windowSize) {
		/*
		 * This method generates an appropriately-sized Hamming window to be used later.
		 */
        int m = windowSize/2;
        double r = Math.PI/(m+1);
        double[] window = new double[windowSize];
        for (int i = -m; i < m; i++) {
            window[m + i] = 0.5 + 0.5 * Math.cos(i * r);
        }
        return window;
    }

    @Override
    public void applyWindow(double[] samples) {
        //apply windowing function through multiplication with time-domain samples
        for (int i = 0; i < windowSize; i++) {
            samples[i] *= hammingWindow[i];
        }
    }

}