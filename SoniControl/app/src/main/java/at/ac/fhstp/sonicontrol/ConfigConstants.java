package at.ac.fhstp.sonicontrol;


public final class ConfigConstants {
    public static final String JSON_FILENAME = "soni.json";
    public static final String DIR_NAME_SAVED_RECORDINGS = "/detected-files";

    public static final String SETTING_CONTINOUS_SPOOFING = "cbprefContinuousSpoof";
    public static final String PREFERENCE_DELETE_JSON = "deleteJson";
    public static final String SETTING_LOCATION_RADIUS = "etprefLocationRadius";
    public static final String SETTING_LOCATION_RADIUS_DEFAULT = "30";
    public static final String SETTING_PULSE_DURATION = "etprefPulseDuration";
    public static final String SETTING_PULSE_DURATION_DEFAULT = "1000";
    public static final String SETTING_PAUSE_DURATION = "etprefPauseDuration";
    public static final String SETTING_PAUSE_DURATION_DEFAULT = "0";
    public static final String SETTING_BANDWIDTH = "etprefBandwidth";
    public static final String SETTING_BANDWIDTH_DEFAULT = "1";
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

    // Scan constants
    public static final int SCAN_SAMPLE_RATE = 44100;
    public static final String SETTING_PREVENTIVE_SPOOFING = "cbprefPreventiveSpoofing";
    public static final boolean SETTING_PREVENTIVE_SPOOFING_DEFAULT = true;
    public static final int SCAN_BUFFER_SIZE = 2048; //2048 is 46.440ms //2205 is 50 ms (5x 441)

    //Notification ids
    public static final int ON_HOLD_NOTIFICATION_ID = 1;
    public static final int SCANNING_NOTIFICATION_ID = 2;
    public static final int SPOOFING_NOTIFICATION_ID = 3;
    public static final int DETECTION_NOTIFICATION_ID = 4;
    public static final int DETECTION_ALERT_STATUS_NOTIFICATION_ID = 5;


}
