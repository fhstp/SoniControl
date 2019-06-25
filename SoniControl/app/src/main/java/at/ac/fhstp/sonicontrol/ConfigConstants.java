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

    public final static String PREFERENCES_APP_STATE = "PREFERENCES_APP_STATE";

    // Scan constants
    public static final int SCAN_SAMPLE_RATE = 44100;
    public static final String SETTING_PREVENTIVE_SPOOFING = "cbprefPreventiveSpoofing";
    public static final boolean SETTING_PREVENTIVE_SPOOFING_DEFAULT = false;
    public static final int SCAN_BUFFER_SIZE = 2048; //2048 is 46.440ms //2205 is 50 ms (5x 441)

    // Spectrogram constants
    public static final int SPECTROGRAM_OVERLAP_FACTOR = 4;
    public static final int SPECTROGRAM_LOWER_CUTOFF_FREQUENCY = 16800;
    public static final int SPECTROGRAM_UPPER_CUTOFF_FREQUENCY = 21000;


    public static final int REQUEST_GPS_PERMISSION = 1337;
    //Notification ids
    public static final int ON_HOLD_NOTIFICATION_ID = 1;
    public static final int SCANNING_NOTIFICATION_ID = 2;
    public static final int SPOOFING_NOTIFICATION_ID = 3;
    public static final int DETECTION_NOTIFICATION_ID = 4;
    public static final int DETECTION_ALERT_STATUS_NOTIFICATION_ID = 5;

    public static String EXTRA_TECHNOLOGY_DETECTED = "at.ac.fhstp.sonicontrol.TECHNOLOGY_DETECTED";

    public static String SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN = "cbAlertLocationDontAskAgain";
    public static boolean SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN_DEFAULT = false;

    public static int DETECTION_TYPE_ALWAYS_DISMISSED_HERE = 0;
    public static int DETECTION_TYPE_ALWAYS_BLOCKED_HERE = 1;
    public static int DETECTION_TYPE_DISMISSED_THIS_TIME = 2;
    public static int DETECTION_TYPE_BLOCKED_THIS_TIME = 3;

}
