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

package at.ac.fhstp.sonicontrol.utils;

import edu.emory.mathcs.jtransforms.fft.DoubleFFT_1D;
import java.util.Arrays;

/**
 * Utilities to get the autocorrelation of an array.
 * Inspired from https://stackoverflow.com/a/12453487 written by Gene (https://stackoverflow.com/users/1161878/gene)
 */
public class Autocorrelation {

    static void print(String msg, double[] x) {
        System.out.println(msg);
        for (double d : x) System.out.println(d);
    }

    /**
     * This is a "wrapped" signal processing-style autocorrelation.
     * For "true" autocorrelation, the data must be zero padded.
     */
    public static void bruteForceAutoCorrelation(double[] x, double[] ac) {
        Arrays.fill(ac, 0);
        int n = x.length;
        for (int j = 0; j < n; j++) {
            for (int i = 0; i < n; i++) {
                ac[j] += x[i] * x[(n + i - j) % n];
            }
        }
    }

    /**
     * This is a "wrapped" signal processing-style autocorrelation.
     * For "true" autocorrelation, the data must be zero padded.
     */
    public static void bruteForceAutoCorrelation(double[] x, double[] ac, int maxLag) {
        Arrays.fill(ac, 0);
        int n = x.length;
        for (int j = 0; j < maxLag; j++) {
            for (int i = 0; i < n; i++) {
                ac[j] += x[i] * x[(n + i - j) % n];
            }
        }
        // For statistical convention, normalize by dividing through with variance
        /*
        for (int i = 1; i < n; i++)
            ac[i] /= ac[0];
        ac[0] = 1;
        */
    }

    private static double sqr(double x) {
        return x * x;
    }

    public static void fftAutoCorrelation(double[] x, double[] ac) {
        int n = x.length;
        // Assumes n is even.
        DoubleFFT_1D fft = new DoubleFFT_1D(n);
        fft.realForward(x);
        ac[0] = sqr(x[0]);
        //ac[0] = 0;  // For statistical convention, zero out the mean
        ac[1] = sqr(x[1]);
        for (int i = 2; i < n; i += 2) {
            ac[i] = sqr(x[i]) + sqr(x[i+1]);
            ac[i+1] = 0;
        }
        DoubleFFT_1D ifft = new DoubleFFT_1D(n);
        ifft.realInverse(ac, true);
        // For statistical convention, normalize by dividing through with variance
        /*
        for (int i = 1; i < n; i++)
            ac[i] /= ac[0];
        ac[0] = 1;
        */
    }

    static void test() {
        double [] data = { 1, -81, 2, -15, 8, 2, -9, 0};
        double [] ac1 = new double [data.length];
        double [] ac2 = new double [data.length];
        bruteForceAutoCorrelation(data, ac1, 3);
        fftAutoCorrelation(data, ac2);
        print("bf", ac1);
        print("fft", ac2);
        double err = 0;
        for (int i = 0; i < ac1.length; i++)
            err += sqr(ac1[i] - ac2[i]);
        System.out.println("err = " + err);
    }

    public static void main(String[] args) {
        Autocorrelation.test();
    }
}
