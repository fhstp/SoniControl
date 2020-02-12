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

import android.Manifest;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.location.LocationManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.preference.PreferenceManager;
//import android.support.annotation.Nullable;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;
import androidx.fragment.app.DialogFragment;
import androidx.fragment.app.FragmentActivity;
//import androidx.core.app.DialogFragment;
//import androidx.core.app.FragmentActivity;
import androidx.appcompat.app.AlertDialog;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ProgressBar;
import android.widget.TextView;

import at.ac.fhstp.sonicontrol.ConfigConstants;
import at.ac.fhstp.sonicontrol.R;
import at.ac.fhstp.sonicontrol.Technology;
import at.ac.fhstp.sonicontrol.utils.Misc;


public class DetectionDialogFragment extends DialogFragment {
    private static final String TAG = "DetectionDialog";

    /* The activity that creates an instance of this dialog fragment must
     * implement this interface in order to receive event callbacks.
     * Each method passes the DialogFragment in case the host needs to query it. */
    public interface DetectionDialogListener {
        public void onAlertDismissAlways(DialogFragment dialog);
        public void onAlertDismissThisTime(DialogFragment dialog);
        public void onAlertBlockAlways(DialogFragment dialog);
        public void onAlertBlockThisTime(DialogFragment dialog);
        public void onAlertPlayDetectedSignal(DialogFragment dialog);
        //public void onAlertSharing(DialogFragment dialog, boolean isChecked);
        //public void onAlertShare(DialogFragment dialog);
    }

    float[][] lastDetectedSpectrum = null;
    public SpectrogramView spectrogramView;
    public ProgressBar progressBar;

    public Button btnAlertReplay;
    //public Button btnAlertBlockAlways;
    public Button btnAlertDismissThisTime;
    //public Button btnAlertDismissAlways;
    public Button btnAlertBlockThisTime;

    public TextView txtSignalType;
    public TextView txtAlertDate;
    public TextView txtAlertLocation;
    public TextView txtNoLocation;
    public TextView txtNoInternet;
    public TextView txtSpectrogramTitle;

    public CheckBox cbSharing;
    public CheckBox cbSaveAsFirewallRule;

    // Use this instance of the interface to deliver action events
    DetectionDialogListener listener;

    // Override the Fragment.onAttach() method to instantiate the DetectionDialogListener
    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        // Verify that the host activity implements the callback interface
        try {
            // Instantiate the DetectionDialogListener so we can send events to the host
            listener = (DetectionDialogListener) context;
        } catch (ClassCastException e) {
            // The activity doesn't implement the interface, throw exception
            throw new ClassCastException(context.toString()
                    + " (activity) must implement DetectionDialogListener");
        }
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        // Note: It should be safe to have the dialog cancellable (it would call dismissThisTime())
        setCancelable(false); // User has to choose an option for the detected signal

        final FragmentActivity currentActivity = getActivity();

        AlertDialog.Builder builder = new AlertDialog.Builder(currentActivity/*, R.style.Theme_Design_Light*/);

        View view = currentActivity.getLayoutInflater().inflate(R.layout.alert_message, null);
        progressBar = (ProgressBar) view.findViewById(R.id.progressBar);

        txtSignalType = (TextView)view.findViewById(R.id.txtSignalType); //this line can be deleted it's only for debug in the alert
        txtAlertDate = (TextView)view.findViewById(R.id.txtAlertDate);
        txtAlertLocation = (TextView)view.findViewById(R.id.txtAlertLocation);
        txtNoLocation = (TextView)view.findViewById(R.id.txtNoLocation);
        txtNoInternet = (TextView)view.findViewById(R.id.txtNoInternet);
        txtSpectrogramTitle = (TextView)view.findViewById(R.id.txtSpectrogramTitle);

        //btnAlertDismissAlways = (Button) view.findViewById(R.id.btnDismissAlwaysHere); //button of the alert for always dismiss the found signal
        btnAlertDismissThisTime = (Button) view.findViewById(R.id.btnDismissThisTime); //button of the alert for only dismiss the found signal this time
        //btnAlertBlockAlways = (Button) view.findViewById(R.id.btnBlockAlways); //button of the alert for starting the spoofing process after finding a signal
        btnAlertBlockThisTime = (Button) view.findViewById(R.id.btnBlockThisTime);
        btnAlertReplay = (Button) view.findViewById(R.id.btnReplay); //button of the alert for playing the found signal with fs/3

        cbSharing = (CheckBox) view.findViewById(R.id.cbSharing);
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(getActivity());
        boolean willBeShared = sp.getBoolean(ConfigConstants.SETTINGS_SHARING_DEFAULT, ConfigConstants.SETTINGS_SHARING_DEFAULT_VALUE);
        cbSharing.setChecked(willBeShared);
        /*if(!checkInternetForSharing(getActivity())){
            cbSharing.setChecked(false);
            cbSharing.setClickable(false);
            cbSharing.setTextColor(Color.parseColor("#A4A4A4"));
        }else{
            cbSharing.setClickable(true);
            cbSharing.setTextColor(Color.parseColor("#000000"));
        }*/

        cbSaveAsFirewallRule = (CheckBox) view.findViewById(R.id.cbSaveAsFirewallRule);

        // Initialize spectrogram view.
        spectrogramView = (SpectrogramView) view.findViewById(R.id.spectrogram_view);
        spectrogramView.setSamplingRate(ConfigConstants.SCAN_SAMPLE_RATE);
        spectrogramView.setFFTResolution(ConfigConstants.SCAN_BUFFER_SIZE / 2);
        spectrogramView.setCutoffFrequency(ConfigConstants.LOWER_CUTOFF_FREQUENCY);
        spectrogramView.setUpperCutoffFrequency(ConfigConstants.UPPER_CUTOFF_FREQUENCY);
        Misc.setPreference(currentActivity, "color_scale", "Fire");

        // If spectrum available show it, else make it invisible and show a loading symbol
        if (lastDetectedSpectrum != null) {
            //onSpectrum();
            progressBar.setVisibility(View.INVISIBLE);
            btnAlertReplay.setEnabled(true);
        }
        else {
            progressBar.setVisibility(View.VISIBLE);
            spectrogramView.setVisibility(View.INVISIBLE);
            btnAlertReplay.setVisibility(View.INVISIBLE);
            btnAlertReplay.setEnabled(false);
        }

        // OnClickListeners --------
/*
        btnAlertDismissAlways.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                setLastSharingDecision(cbSharing.isChecked());
                listener.onAlertDismissAlways(DetectionDialogFragment.this);
            }
        });
        */
        btnAlertDismissThisTime.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                setLastSharingDecision(cbSharing.isChecked());

                if (cbSaveAsFirewallRule.isChecked()) {
                    listener.onAlertDismissAlways(DetectionDialogFragment.this);
                }
                else {
                    listener.onAlertDismissThisTime(DetectionDialogFragment.this);
                }
            }
        });
/*
        btnAlertBlockAlways.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                setLastSharingDecision(cbSharing.isChecked());
                listener.onAlertBlockAlways(DetectionDialogFragment.this);
            }
        });
*/
        btnAlertBlockThisTime.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                setLastSharingDecision(cbSharing.isChecked());

                if (cbSaveAsFirewallRule.isChecked()) {
                    listener.onAlertBlockAlways(DetectionDialogFragment.this);
                }
                else {
                    listener.onAlertBlockThisTime(DetectionDialogFragment.this);
                }
            }
        });

        btnAlertReplay.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v) {
                listener.onAlertPlayDetectedSignal(DetectionDialogFragment.this);
            }
        });


        // OnCheckedChangeListener ---

        /*cbSharing.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                listener.onAlertSharing(DetectionDialogFragment.this, isChecked);
            }
        });*/

        // Should be executed after initialization of all buttons AND before setting the view
        setupButtonState(currentActivity);
        builder.setView(view);
        builder.setTitle(R.string.alertDialog_text_ultrasonic_signal_detected);
        return builder.create();
    }

    private void setTechnologyText(FragmentActivity currentActivity) {
        String storedTechnology = PreferenceManager.getDefaultSharedPreferences(currentActivity).getString(ConfigConstants.LAST_DETECTED_TECHNOLOGY_SHARED_PREF, null);
        if(Technology.GOOGLE_NEARBY.toString().equals(storedTechnology)){
            storedTechnology = "Google Nearby";
        }
        setTechnologyText(storedTechnology);
    }

    private void setLastSharingDecision(boolean isChecked){
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(getActivity());
        SharedPreferences.Editor editor = sp.edit();
        editor.putBoolean(ConfigConstants.LAST_DECISION_ON_SHARING, isChecked);
        editor.apply();
    }

    /*package-private*/void setTechnologyText(String technology) {
        if (technology != null) {
            Technology lastDetectedTechnology = null;
            try {
                lastDetectedTechnology = Technology.fromString(technology);
            }
            catch (IllegalArgumentException e) {
                //Log.d(TAG, "onResume: " + e.getMessage());
            }
            if (lastDetectedTechnology != null) {
                txtSignalType.setText(getString(R.string.gui_technology) + " " + lastDetectedTechnology.toString());
            }
        }
        else {
            Log.w("DetectionDialog", "Technology not stored correctly ?");
        }
    }

    private void setupButtonState(FragmentActivity currentActivity) {
        SharedPreferences settings = PreferenceManager.getDefaultSharedPreferences(currentActivity);
        boolean gpsAllowed = settings.getBoolean(ConfigConstants.SETTING_GPS, ConfigConstants.SETTING_GPS_DEFAULT);
        boolean networkAllowed = settings.getBoolean(ConfigConstants.SETTING_NETWORK_USE, ConfigConstants.SETTING_NETWORK_USE_DEFAULT);
        LocationManager locationManager = (LocationManager) currentActivity.getSystemService(currentActivity.LOCATION_SERVICE);
        boolean isNetworkEnabled = locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);
        boolean isGPSEnabled = locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);

        boolean saveJsonFile = settings.getBoolean(ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE, ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT);

        int status = ActivityCompat.checkSelfPermission(currentActivity,
                Manifest.permission.ACCESS_FINE_LOCATION);

        // Set rule saving state
        if((!(isGPSEnabled && gpsAllowed) && !(isNetworkEnabled && networkAllowed)) || status != PackageManager.PERMISSION_GRANTED){
            //btnAlertBlockAlways.setEnabled(false);
            //btnAlertDismissAlways.setEnabled(false);
            cbSaveAsFirewallRule.setEnabled(false);
            txtNoLocation.setVisibility(View.VISIBLE);
            txtNoLocation.setText(R.string.on_alert_no_location_message);
        }else if(!saveJsonFile){
            //btnAlertBlockAlways.setEnabled(false);
            //btnAlertDismissAlways.setEnabled(false);
            cbSaveAsFirewallRule.setEnabled(false);
            txtNoLocation.setVisibility(View.VISIBLE);
            txtNoLocation.setText(R.string.alert_no_json_file_message);
        }else{
            //btnAlertBlockAlways.setEnabled(true);
            //btnAlertDismissAlways.setEnabled(true);
            cbSaveAsFirewallRule.setEnabled(true);
            txtNoLocation.setVisibility(View.GONE);
            txtNoLocation.setText("");
        }

        // Set sharing state
        if (checkInternetForSharing(getActivity())) {
            cbSharing.setEnabled(true);
            txtNoInternet.setVisibility(View.GONE);
        }
        else {
            cbSharing.setEnabled(false);
            txtNoInternet.setVisibility(View.VISIBLE);
            txtNoInternet.setText(R.string.on_alert_network_not_enabled);
        }

        setTechnologyText(currentActivity);

        //txtAlertDate.setText(getString(R.string.alert_detection_date) + " " + settings.getString(ConfigConstants.LAST_DETECTED_DATE_SHARED_PREF, "unknown"));
        txtAlertDate.setText(settings.getString(ConfigConstants.LAST_DETECTED_DATE_SHARED_PREF, getString(R.string.alert_unknown_date)));
        txtAlertLocation.setText(settings.getString(ConfigConstants.LAST_DETECTED_LOCATION_SHARED_PREF, getString(R.string.json_detections_unknown_address)));
    }

    @Override
    public void onDismiss(DialogInterface dialog) {
        super.onDismiss(dialog);
    }

    @Override
    public void onCancel(DialogInterface dialog) {
        super.onCancel(dialog);

        //Log.d(TAG, "onCancel : Will dismiss this time.");
        //Note: Currently the dialog is not cancellable. This is a safety in case it would be.
        listener.onAlertDismissThisTime(DetectionDialogFragment.this);
    }

    public void setSpectrum(float[][] spectrum) {
        lastDetectedSpectrum = spectrum;
        /*if (spectrogramView != null) {
            onSpectrum();
        }*/
    }

    public void onSpectrum() {
        if (spectrogramView != null) {
            if (lastDetectedSpectrum == null) {
                spectrogramView.setFFTResolution(0);
                Log.w("TAG", "Received a null spectrum.");
                return;
            }
            Log.d(TAG, "fft resolution: " + String.valueOf(lastDetectedSpectrum[0].length));
            spectrogramView.setFFTResolution(lastDetectedSpectrum[0].length);
            spectrogramView.setHistoryBuffer(lastDetectedSpectrum);
            Log.d(TAG, "spectrum set");

            if (this.getDialog() != null
                    && getDialog().isShowing()
                    && !isRemoving()) {
                new Handler(Looper.getMainLooper()).post((new Runnable() {
                    @Override
                    public void run() {
                        // Update spectrogram
                        //spectrogramView.invalidate(); // Does not seem to be needed, probably already redrawn by setting to visible
                        spectrogramView.setVisibility(View.VISIBLE);
                    }
                }));
            }
        }
        else {
            Log.w(TAG, "onSpectrum: alert not initialized yet !");
        }
    }

    public boolean checkInternetForSharing(FragmentActivity currentActivity){
        ConnectivityManager connectivityManager = (ConnectivityManager) currentActivity.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null && activeNetworkInfo.isConnected();
    }
}
