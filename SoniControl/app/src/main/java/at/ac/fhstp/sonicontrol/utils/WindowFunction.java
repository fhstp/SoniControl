/*
Copyright 2014 Benjamin Elliott

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

package at.ac.fhstp.sonicontrol.utils;

/**
 * Generic windowing interface utility to process spectrum.
 */
public interface WindowFunction {

    /**
     * Apply the windowing function to the provided input data in-place.
     * @param samples - the array of audio samples
     */
    void applyWindow(double[] samples);
}