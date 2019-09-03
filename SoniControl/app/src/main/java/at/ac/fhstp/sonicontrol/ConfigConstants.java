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

package at.ac.fhstp.sonicontrol;


public final class ConfigConstants {
    public static final String JSON_FILENAME = "soni.json";
    public static final String DIR_NAME_SAVED_RECORDINGS = "/detected-files";

    // Settings shared preferences keys
    public static final String SETTING_CONTINOUS_SPOOFING = "cbprefContinuousSpoof";
    public static final boolean SETTING_CONTINOUS_SPOOFING_DEFAULT = false;
    public static final String PREFERENCE_RESET_PREFERENCES = "resetPreferences";
    public static final String PREFERENCE_DELETE_JSON = "deleteJson";
    public static final String SETTING_LOCATION_RADIUS = "etprefLocationRadius";
    public static final String SETTING_LOCATION_RADIUS_DEFAULT = "30";
    public static final String SETTING_PULSE_DURATION = "etprefPulseDuration";
    public static final String SETTING_PULSE_DURATION_DEFAULT = "4000";
    public static final String SETTING_PAUSE_DURATION = "etprefPauseDuration";
    public static final String SETTING_PAUSE_DURATION_DEFAULT = "0";
    public static final String SETTING_BANDWIDTH = "etprefBandwidth";
    public static final String SETTING_BANDWIDTH_DEFAULT = "10";
    public static final String SETTING_BLOCKING_DURATION = "etprefSpoofDuration";
    public static final String SETTING_BLOCKING_DURATION_DEFAULT = "1";
    public static final String SETTING_GPS = "cbprefGpsUse";
    public static final boolean SETTING_GPS_DEFAULT = true;
    public static final String SETTING_NETWORK_USE = "cbprefNetworkUse";
    public static final boolean SETTING_NETWORK_USE_DEFAULT = true;
    public static final String SETTING_MICROPHONE_FOR_BLOCKING = "cbprefMicBlock";
    public static final boolean SETTING_MICROPHONE_FOR_BLOCKING_DEFAULT = true;
    public static final String SETTING_SAVE_DATA_TO_JSON_FILE = "cbprefJsonSave";
    public static final boolean SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT = true;
    public static final String USED_BLOCKING_METHOD_SPOOFER = "Spoofer";
    public static final String USED_BLOCKING_METHOD_MICROPHONE = "Microphone";
    public static String SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN = "cbAlertLocationDontAskAgain";
    public static final String SETTINGS_FAST_DETECTION = "cbprefFastDetection";
    public static final boolean SETTINGS_FAST_DETECTION_DEFAULT = false;
    public static boolean SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN_DEFAULT = false;
    public static final String SETTING_PREVENTIVE_SPOOFING = "cbprefPreventiveSpoofing";
    public static final boolean SETTING_PREVENTIVE_SPOOFING_DEFAULT = false;
    public static final String SETTINGS_SHARING = "cbSharing";
    public static final boolean SETTINGS_SHARING_DEFAULT = false;

    // Other SharedPreferences keys
    public static final String BUFFER_HISTORY_FILENAME = "bufferHistory.raw";
    public static final String BUFFER_HISTORY_LENGTH_SHARED_PREF = "bufferHistoryLength";
    public static final String MAX_VALUE_INDEX_SHARED_PREF = "bufferHistoryMaxValueIndex";
    public static final String BUFFER_HISTORY_AMPLITUDE_SHARED_PREF = "bufferHistoryAmplitude";
    public static final String LAST_DETECTED_TECHNOLOGY_SHARED_PREF = "lastDetectedTechnology";
    public static final String LAST_DETECTED_DATE_SHARED_PREF = "lastDetectedDateAndTime";
    public static String EXTRA_TECHNOLOGY_DETECTED = "at.ac.fhstp.sonicontrol.TECHNOLOGY_DETECTED";

    public final static String PREFERENCES_APP_STATE = "PREFERENCES_APP_STATE";

    // Scan parameters
    public static final int SCAN_SAMPLE_RATE = 44100;
    public static final int SCAN_BUFFER_SIZE = 2048; //2048 is 46.440ms //2205 is 50 ms (5x 441)

    // Spectrogram parameters
    public static final int VIZ_FFT_SIZE = 4096; //2048 is 46.440ms //2205 is 50 ms (5x 441)
    public static final int SPECTROGRAM_OVERLAP_FACTOR = 8;
    public static final int LOWER_CUTOFF_FREQUENCY = 16800; // ! Redefined in C++ for the detection. Lower limit for prontoly! All other technologies send above 18kHz
    public static final int UPPER_CUTOFF_FREQUENCY = 21000; //Only visual as most phones cannot really use frequencies above 21000Hz, we might detect something higher.

    // Bandpass / Highpass filtering parameters
    public static final int BANDPASS_FILTER_ORDER = 16;
    public static final int HIGHPASS_OFFSET = 700;
    public static final int HIGHPASS_CUTOFF_FREQUENCY = 16800 + HIGHPASS_OFFSET; //highpass is not sharp enough
    public static final int BANDPASS_OFFSET = (SCAN_SAMPLE_RATE / 2) - UPPER_CUTOFF_FREQUENCY;
    public static final double BANDPASS_CENTER_FREQUENCY = BANDPASS_OFFSET + LOWER_CUTOFF_FREQUENCY + (UPPER_CUTOFF_FREQUENCY - LOWER_CUTOFF_FREQUENCY) / 2;
    public static final double BANDPASS_WIDTH = -1000+ 2*BANDPASS_OFFSET + UPPER_CUTOFF_FREQUENCY - LOWER_CUTOFF_FREQUENCY; // The bandpass is rather sharp

    // Recognition parameters
    public static final double DECISION_THRESHOLD_NEARBY = 3.5; //the decision threshold for nearby signals. If the RMS Energy in the Nearby band is N-times higher than in the neighboring bands above and beneath, then declare a nearby detection.
    public static final double DECISION_THRESHOLD_NEARBY_AC = 0.05; //the recognition threshold for nearby based on autocorrelation

    // Technology specifications
    public static final double NEARBY_N_BANDS = 64;
    public static final double NEARBY_BANDWIDTH = (20000.0-18500.0) / NEARBY_N_BANDS / 2.0; //unit Hz
    public static final double LISNR_BANDWIDTH = 40; //unit Hz
    public static final double PRONTOLY_BANDWIDTH = 10; //unit Hz
    public static final double SHOPKICK_BANDWIDTH = 4; //unit Hz
    public static final double SILVERPUSH_BANDWIDTH = 20; //unit Hz
    public static final double SONITALK_BANDWIDTH = 40; //unit Hz
    public static final double SIGNAL360_BANDWIDTH = 40; //unit Hz

    public static final int REQUEST_GPS_PERMISSION = 1337;
    //Notification ids
    public static final int ON_HOLD_NOTIFICATION_ID = 1;
    public static final int SCANNING_NOTIFICATION_ID = 2;
    public static final int SPOOFING_NOTIFICATION_ID = 3;
    public static final int DETECTION_NOTIFICATION_ID = 4;
    public static final int DETECTION_ALERT_STATUS_NOTIFICATION_ID = 5;


    public static int DETECTION_TYPE_ALWAYS_DISMISSED_HERE = 0;
    public static int DETECTION_TYPE_ALWAYS_BLOCKED_HERE = 1;
    public static int DETECTION_TYPE_DISMISSED_THIS_TIME = 2;
    public static int DETECTION_TYPE_BLOCKED_THIS_TIME = 3;
    public static int DETECTION_TYPE_ASK_AGAIN = 4;

}
