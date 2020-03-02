/*
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

package at.ac.fhstp.sonicontrol;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.preference.PreferenceFragment;
import android.preference.*;
import android.os.Bundle;
import android.util.Log;
import java.text.NumberFormat;
import java.text.ParseException;

public class SettingsFragment extends PreferenceFragment {

    //TODO: remove references to Fragment and Activity
    static SettingsFragment settingsFragment;
    MainActivity main = new MainActivity();
    JSONManager jsonMan;
    MainActivity nextMain;
    AlertDialog alertDelete = null;
    AlertDialog alertReset = null;

    private CheckBoxPreference cbContinuousSpoofing;
    private CheckBoxPreference cbGPSUse;
    private CheckBoxPreference cbNetworkUse;
    private CheckBoxPreference cbMicrophone;
    private CheckBoxPreference cbSaveJson;
    private CheckBoxPreference cbPreventiveSpoofing;
    private CheckBoxPreference cbAlertLocationDontAsk;
    private CheckBoxPreference cbExtendedDiagnostics;
    private EditTextPreference etLocationRadius;
    private EditTextPreference etPulseDuration;
    private EditTextPreference etPauseDuration;
    private EditTextPreference etBandwidth;
    private EditTextPreference etBlockingDuration;
    private CheckBoxPreference cbSharing;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.settings_container);
        addPreferencesFromResource(R.xml.settings_release); //set the settings.xml as the preferences

        settingsFragment = this;

        nextMain = main.getMainIsMain();
        jsonMan = JSONManager.getInstanceJSONManager();//new JSONManager(nextMain);

        cbContinuousSpoofing = (CheckBoxPreference) findPreference(ConfigConstants.SETTING_CONTINOUS_SPOOFING);
        cbGPSUse = (CheckBoxPreference) findPreference(ConfigConstants.SETTING_GPS);
        cbNetworkUse = (CheckBoxPreference) findPreference(ConfigConstants.SETTING_NETWORK_USE);
        cbMicrophone = (CheckBoxPreference) findPreference(ConfigConstants.SETTING_MICROPHONE_FOR_BLOCKING);
        cbSaveJson = (CheckBoxPreference) findPreference(ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE);
        cbPreventiveSpoofing = (CheckBoxPreference) findPreference(ConfigConstants.SETTING_PREVENTIVE_SPOOFING);
        cbAlertLocationDontAsk = (CheckBoxPreference) findPreference(ConfigConstants.SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN);
        cbExtendedDiagnostics = (CheckBoxPreference) findPreference(ConfigConstants.SETTINGS_EXTENDED_DIAGNOSTICS);
        etLocationRadius = (EditTextPreference) findPreference(ConfigConstants.SETTING_LOCATION_RADIUS);
        etPulseDuration = (EditTextPreference) findPreference(ConfigConstants.SETTING_PULSE_DURATION);
        etPauseDuration = (EditTextPreference) findPreference(ConfigConstants.SETTING_PAUSE_DURATION);
        etBandwidth = (EditTextPreference) findPreference(ConfigConstants.SETTING_BANDWIDTH);
        etBlockingDuration = (EditTextPreference) findPreference(ConfigConstants.SETTING_BLOCKING_DURATION);
        cbSharing = (CheckBoxPreference) findPreference(ConfigConstants.SETTINGS_SHARING_DEFAULT);

        // Initialize the preferences with the last values saved or the default ones
        setPreferenceValues();

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

        final Preference prefReset = findPreference(ConfigConstants.PREFERENCE_RESET_PREFERENCES);
        prefReset.setOnPreferenceClickListener(new Preference.OnPreferenceClickListener() {
            @Override
            public boolean onPreferenceClick(Preference preference) {
                final AlertDialog.Builder resetSettingsDialog = new AlertDialog.Builder(getActivity());
                resetSettingsDialog.setTitle(R.string.action_reset_settings_title)
                        .setMessage(R.string.action_reset_settings_message)
                        .setCancelable(false)
                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                resetSettings();
                            }
                        })
                        .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                alertReset.cancel();
                            }
                        })
                        .setIcon(android.R.drawable.ic_dialog_alert);
                alertReset = resetSettingsDialog.show();
                return false;
            }
        });

        final Preference prefLocRad = findPreference(ConfigConstants.SETTING_LOCATION_RADIUS);
        prefLocRad.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                if(newValue.toString().trim().equals("")){
                    return false;
                }
                String prefLocRadStr = String.format(getString(R.string.settings_location_radius_title), String.valueOf(newValue));
                prefLocRad.setTitle(prefLocRadStr);
                //Log.d("MyApp", "Pref " + preference.getKey() + " " + newValue.toString());
                //Log.d("testfortest",String.valueOf(prefLocRad.getSharedPreferences().getString(prefLocRad.getKey(), ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT)));
                return true;
            }
        });

        final Preference prefPulseDur = findPreference(ConfigConstants.SETTING_PULSE_DURATION);
        prefPulseDur.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                if(newValue.toString().trim().equals("")){
                    return false;
                }
                String prefPulseDurStr = String.format(getString(R.string.settings_pulse_duration_title), String.valueOf(newValue));
                prefPulseDur.setTitle(prefPulseDurStr);
                return true;
            }
        });

        final Preference prefPauseDur = findPreference(ConfigConstants.SETTING_PAUSE_DURATION);
        prefPauseDur.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                if(newValue.toString().trim().equals("")){
                    return false;
                }
                String prefPauseDurStr = String.format(getString(R.string.settings_pause_duration_title), String.valueOf(newValue));
                prefPauseDur.setTitle(prefPauseDurStr);
                return true;
            }
        });

        final Preference prefBandwidth = findPreference(ConfigConstants.SETTING_BANDWIDTH);
        prefBandwidth.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                if(newValue.toString().trim().equals("")){
                    return false;
                }
                String prefBandwidthStr = String.format(getString(R.string.settings_bandwidth_title), String.valueOf(newValue));
                prefBandwidth.setTitle(prefBandwidthStr);
                return true;
            }
        });

        final Preference prefBlockingDuration = findPreference(ConfigConstants.SETTING_BLOCKING_DURATION);
        prefBlockingDuration.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                if(newValue.toString().trim().equals("")){
                    return false;
                }
                if(Integer.valueOf((String)newValue)==1) {
                    String prefBlockingDurationStr = String.format(getString(R.string.settings_blocking_duration_singular), String.valueOf(newValue));
                    prefBlockingDuration.setTitle(prefBlockingDurationStr);
                }else{
                    String prefBlockingDurationStr = String.format(getString(R.string.settings_blocking_duration_plural), String.valueOf(newValue));
                    prefBlockingDuration.setTitle(prefBlockingDurationStr);
                }
                return true;
            }
        });
        //Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_LOCATION_RADIUS, "30"))
    }

    private void resetSettings() {
        // Reinitialize SharedPreferences values
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(nextMain.getApplicationContext());
        SharedPreferences.Editor editor = preferences.edit();
        editor.putBoolean(ConfigConstants.SETTING_CONTINOUS_SPOOFING, ConfigConstants.SETTING_CONTINOUS_SPOOFING_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTING_GPS, ConfigConstants.SETTING_GPS_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTING_NETWORK_USE, ConfigConstants.SETTING_NETWORK_USE_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTING_MICROPHONE_FOR_BLOCKING, ConfigConstants.SETTING_MICROPHONE_FOR_BLOCKING_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE, ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTING_PREVENTIVE_SPOOFING, ConfigConstants.SETTING_PREVENTIVE_SPOOFING_DEFAULT);
        editor.putString(ConfigConstants.SETTING_LOCATION_RADIUS,ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT);
        editor.putString(ConfigConstants.SETTING_PULSE_DURATION,ConfigConstants.SETTING_PULSE_DURATION_DEFAULT);
        editor.putString(ConfigConstants.SETTING_PAUSE_DURATION,ConfigConstants.SETTING_PAUSE_DURATION_DEFAULT);
        editor.putString(ConfigConstants.SETTING_BANDWIDTH,ConfigConstants.SETTING_BANDWIDTH_DEFAULT);
        editor.putString(ConfigConstants.SETTING_BLOCKING_DURATION,ConfigConstants.SETTING_BLOCKING_DURATION_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN,ConfigConstants.SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTINGS_EXTENDED_DIAGNOSTICS, ConfigConstants.SETTINGS_EXTENDED_DIAGNOSTICS_DEFAULT);
        editor.putBoolean(ConfigConstants.SETTINGS_SHARING_DEFAULT, ConfigConstants.SETTINGS_SHARING_DEFAULT_VALUE);
        editor.apply();

        // Re-set the view content
        setPreferenceValues();
    }


    @Override
    public void onStart() {
        super.onStart();
    }

    @Override
    public void onResume() {
        super.onResume();
        // Maybe to add again when we support orientation change
        /*
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
        */
    }

    private void setPreferenceValues(){
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(getActivity().getApplicationContext());
        // TODO: Add localization to all numbers shown ?
        NumberFormat nf = NumberFormat.getInstance();
        nf.setParseIntegerOnly(true);

        cbContinuousSpoofing.setChecked(sp.getBoolean(cbContinuousSpoofing.getKey(), ConfigConstants.SETTING_CONTINOUS_SPOOFING_DEFAULT));
        cbGPSUse.setChecked(sp.getBoolean(cbGPSUse.getKey(), ConfigConstants.SETTING_GPS_DEFAULT));
        cbNetworkUse.setChecked(sp.getBoolean(cbNetworkUse.getKey(), ConfigConstants.SETTING_NETWORK_USE_DEFAULT));
        cbMicrophone.setChecked(sp.getBoolean(cbMicrophone.getKey(), ConfigConstants.SETTING_MICROPHONE_FOR_BLOCKING_DEFAULT));
        cbSaveJson.setChecked(sp.getBoolean(cbSaveJson.getKey(), ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT));
        cbPreventiveSpoofing.setChecked(sp.getBoolean(cbPreventiveSpoofing.getKey(), ConfigConstants.SETTING_PREVENTIVE_SPOOFING_DEFAULT));
        cbAlertLocationDontAsk.setChecked(sp.getBoolean(cbAlertLocationDontAsk.getKey(), ConfigConstants.SETTINGS_ALERT_LOCATION_IS_OFF_DONT_ASK_AGAIN_DEFAULT));
        cbExtendedDiagnostics.setChecked(sp.getBoolean(cbExtendedDiagnostics.getKey(), ConfigConstants.SETTINGS_EXTENDED_DIAGNOSTICS_DEFAULT));
        cbSharing.setChecked(sp.getBoolean(cbSharing.getKey(), ConfigConstants.SETTINGS_SHARING_DEFAULT_VALUE));

        String locationRadius = sp.getString(etLocationRadius.getKey(), ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT);
        String prefLocRadTitle = String.format(getString(R.string.settings_location_radius_title), locationRadius);
        etLocationRadius.setTitle(prefLocRadTitle);

        String pulsingDuration = sp.getString(etPulseDuration.getKey(), ConfigConstants.SETTING_PULSE_DURATION_DEFAULT);
        String prefPulseDurTitle = String.format(getString(R.string.settings_pulse_duration_title), String.valueOf(pulsingDuration));
        etPulseDuration.setTitle(prefPulseDurTitle);

        String pauseDuration = sp.getString(etPauseDuration.getKey(), ConfigConstants.SETTING_PAUSE_DURATION_DEFAULT);
        String prefPauseDurTitle = String.format(getString(R.string.settings_pause_duration_title), String.valueOf(pauseDuration));
        etPauseDuration.setTitle(prefPauseDurTitle);

        String bandwidth = sp.getString(etBandwidth.getKey(), ConfigConstants.SETTING_BANDWIDTH_DEFAULT);
        String prefBandwidthTitle = String.format(getString(R.string.settings_bandwidth_title), String.valueOf(bandwidth));
        etBandwidth.setTitle(prefBandwidthTitle);

        String blockingDurationString = sp.getString(etBlockingDuration.getKey(), ConfigConstants.SETTING_BLOCKING_DURATION_DEFAULT);
        String prefBlockingDurationTitle = null;
        try {
            Number blockingDuration = nf.parse(blockingDurationString);

            if(blockingDuration.intValue() == 1) {
                prefBlockingDurationTitle = String.format(getString(R.string.settings_blocking_duration_singular), String.valueOf(blockingDuration));
            } else {
                prefBlockingDurationTitle = String.format(getString(R.string.settings_blocking_duration_plural), String.valueOf(blockingDuration));
            }
        } catch (ParseException e) {
            prefBlockingDurationTitle = String.format(getString(R.string.settings_blocking_duration_plural), blockingDurationString);
            Log.d("SettingsFragment", "ParseException: " + e.getMessage());
        } finally {
            etBlockingDuration.setTitle(prefBlockingDurationTitle);
        }
    }
}
