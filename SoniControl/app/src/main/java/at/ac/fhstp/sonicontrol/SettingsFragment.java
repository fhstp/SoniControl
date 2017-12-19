package at.ac.fhstp.sonicontrol;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.preference.PreferenceFragment;
import android.preference.*;
import android.os.Bundle;
import android.util.Log;

public class SettingsFragment extends PreferenceFragment {

    static SettingsFragment settingsFragment;
    MainActivity main = new MainActivity();
    JSONManager jsonMan;
    MainActivity nextMain;
    AlertDialog alertDelete = null;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.settings_container);
        addPreferencesFromResource(R.xml.settings_release); //set the settings.xml as the preferences

        settingsFragment = this;

        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);

        Preference pref = findPreference(ConfigConstants.PREFERENCE_DELETE_JSON);
        pref.setOnPreferenceClickListener(new Preference.OnPreferenceClickListener() {

            @Override
            public boolean onPreferenceClick(Preference preference) {
                final AlertDialog.Builder deleteJsonDialog = new AlertDialog.Builder(getActivity());
                deleteJsonDialog.setTitle(R.string.deleteJsonAlertTitle)
                        .setMessage(R.string.deleteJsonAlertMessage)
                        .setCancelable(false)
                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                jsonMan.deleteJsonFile();
                            }
                        })
                        .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                alertDelete.cancel();
                            }
                        })
                        .setIcon(android.R.drawable.ic_dialog_alert);
                alertDelete = deleteJsonDialog.show();
                return false;
            }
        });

        final Preference prefLocRad = findPreference(ConfigConstants.SETTING_LOCATION_RADIUS);
        prefLocRad.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                prefLocRad.setTitle("Location Radius (" + newValue + " metres)");
                //Log.d("MyApp", "Pref " + preference.getKey() + " " + newValue.toString());
                //Log.d("testfortest",String.valueOf(prefLocRad.getSharedPreferences().getString(prefLocRad.getKey(), ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT)));
                return true;
            }
        });

        final Preference prefPulseDur = findPreference(ConfigConstants.SETTING_PULSE_DURATION);
        prefPulseDur.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                prefPulseDur.setTitle("Pulse Duration (" + newValue + " ms)");
                return true;
            }
        });

        final Preference prefPauseDur = findPreference(ConfigConstants.SETTING_PAUSE_DURATION);
        prefPauseDur.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                prefPauseDur.setTitle("Pause Duration (" + newValue + " ms)");
                return true;
            }
        });

        final Preference prefBandwidth = findPreference(ConfigConstants.SETTING_BANDWIDTH);
        prefBandwidth.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                prefBandwidth.setTitle("Bandwidth (" + newValue + " Hz)");
                return true;
            }
        });

        final Preference prefBlockingDuration = findPreference(ConfigConstants.SETTING_BLOCKING_DURATION);
        prefBlockingDuration.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                if(Integer.valueOf((String)newValue)==1) {
                    prefBlockingDuration.setTitle("Blocking Duration (" + newValue + " Minute)");
                }else{
                    prefBlockingDuration.setTitle("Blocking Duration (" + newValue + " Minutes)");
                }
                return true;
            }
        });
        //Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_LOCATION_RADIUS, "30"))
    }


    @Override
    public void onStart() {
        super.onStart();
        Preference prefLocRad = findPreference(ConfigConstants.SETTING_LOCATION_RADIUS);
        int locationRadius = Integer.valueOf(prefLocRad.getSharedPreferences().getString(prefLocRad.getKey(), ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT));
        prefLocRad.setTitle("Location Radius (" + locationRadius + " metres)");

        Preference prefPulseDur = findPreference(ConfigConstants.SETTING_PULSE_DURATION);
        int pulsingDuration = Integer.valueOf(prefPulseDur.getSharedPreferences().getString(prefPulseDur.getKey(), ConfigConstants.SETTING_PULSE_DURATION_DEFAULT));
        prefPulseDur.setTitle("Pulse Duration (" + pulsingDuration + " ms)");

        Preference prefPauseDur = findPreference(ConfigConstants.SETTING_PAUSE_DURATION);
        int pauseDuration = Integer.valueOf(prefPulseDur.getSharedPreferences().getString(prefPulseDur.getKey(), ConfigConstants.SETTING_PAUSE_DURATION_DEFAULT));
        prefPauseDur.setTitle("Pause Duration (" + pauseDuration + " ms)");

        Preference prefBandwidth = findPreference(ConfigConstants.SETTING_BANDWIDTH);
        int bandwidth = Integer.valueOf(prefBandwidth.getSharedPreferences().getString(prefBandwidth.getKey(), ConfigConstants.SETTING_BANDWIDTH_DEFAULT));
        prefBandwidth.setTitle("Bandwidth (" + bandwidth + " Hz)");

        Preference prefBlockingDuration = findPreference(ConfigConstants.SETTING_BLOCKING_DURATION);
        int blockingDuration = Integer.valueOf(prefBlockingDuration.getSharedPreferences().getString(prefBlockingDuration.getKey(), ConfigConstants.SETTING_BLOCKING_DURATION_DEFAULT));
        if(blockingDuration==1) {
            prefBlockingDuration.setTitle("Blocking Duration (" + blockingDuration + " Minute)");
        }else{
            prefBlockingDuration.setTitle("Blocking Duration (" + blockingDuration + " Minutes)");
        }
    }

    @Override
    public void onResume() {
        super.onResume();
        Preference prefLocRad = findPreference(ConfigConstants.SETTING_LOCATION_RADIUS);
        int locationRadius = Integer.valueOf(prefLocRad.getSharedPreferences().getString(prefLocRad.getKey(), ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT));
        prefLocRad.setTitle("Location Radius (" + locationRadius + " metres)");

        Preference prefPulseDur = findPreference(ConfigConstants.SETTING_PULSE_DURATION);
        int pulsingDuration = Integer.valueOf(prefPulseDur.getSharedPreferences().getString(prefPulseDur.getKey(), ConfigConstants.SETTING_PULSE_DURATION_DEFAULT));
        prefPulseDur.setTitle("Pulse Duration (" + pulsingDuration + " ms)");

        Preference prefPauseDur = findPreference(ConfigConstants.SETTING_PAUSE_DURATION);
        int pauseDuration = Integer.valueOf(prefPauseDur.getSharedPreferences().getString(prefPauseDur.getKey(), ConfigConstants.SETTING_PAUSE_DURATION_DEFAULT));
        prefPauseDur.setTitle("Pause Duration (" + pauseDuration + " ms)");

        Preference prefBandwidth = findPreference(ConfigConstants.SETTING_BANDWIDTH);
        int bandwidth = Integer.valueOf(prefBandwidth.getSharedPreferences().getString(prefBandwidth.getKey(), ConfigConstants.SETTING_BANDWIDTH_DEFAULT));
        prefBandwidth.setTitle("Bandwidth (" + bandwidth + " Hz)");

        Preference prefBlockingDuration = findPreference(ConfigConstants.SETTING_BLOCKING_DURATION);
        int blockingDuration = Integer.valueOf(prefBlockingDuration.getSharedPreferences().getString(prefBlockingDuration.getKey(), ConfigConstants.SETTING_BLOCKING_DURATION_DEFAULT));
        if(blockingDuration==1) {
            prefBlockingDuration.setTitle("Blocking Duration (" + blockingDuration + " Minute)");
        }else{
            prefBlockingDuration.setTitle("Blocking Duration (" + blockingDuration + " Minutes)");
        }
    }


}
