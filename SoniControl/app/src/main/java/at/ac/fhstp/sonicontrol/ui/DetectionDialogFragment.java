package at.ac.fhstp.sonicontrol.ui;

import android.Manifest;
import android.app.Activity;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.preference.PreferenceManager;
import android.support.annotation.Nullable;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.FragmentActivity;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import at.ac.fhstp.sonicontrol.ConfigConstants;
import at.ac.fhstp.sonicontrol.R;
import at.ac.fhstp.sonicontrol.Technology;


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
        //public void onAlertShare(DialogFragment dialog);
    }

    float[][] lastDetectedSpectrum = null;
    public SpectrogramView spectrogramView;

    public Button btnAlertReplay;
    public Button btnAlertBlockAlways;
    public Button btnAlertDismissThisTime;
    public Button btnAlertDismissAlways;
    public Button btnAlertBlockThisTime;

    public TextView txtSignalType;
    public TextView txtAlertDate;
    public TextView txtNoLocation;

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
        final FragmentActivity currentActivity = getActivity();

        AlertDialog.Builder builder = new AlertDialog.Builder(currentActivity);
        builder.setCancelable(false); // User has to choose an option for the detected signal

        View view = currentActivity.getLayoutInflater().inflate(R.layout.alert_message, null);

        // Initialize spectrogram view.
        spectrogramView = (SpectrogramView) view.findViewById(R.id.spectrogram_view);
        spectrogramView.setSamplingRate(ConfigConstants.SCAN_SAMPLE_RATE);
        spectrogramView.setFFTResolution(ConfigConstants.SCAN_BUFFER_SIZE / 2);
        spectrogramView.setCutoffFrequency(ConfigConstants.SPECTROGRAM_LOWER_CUTOFF_FREQUENCY);
        spectrogramView.setUpperCutoffFrequency(ConfigConstants.SPECTROGRAM_UPPER_CUTOFF_FREQUENCY);

        //TODO: If spectrum available show it, else make it gone and/or show a loading symbol (progressbar ?)
        //spectrogramView.setVisibility(View.GONE);


        txtSignalType = (TextView)view.findViewById(R.id.txtSignalType); //this line can be deleted it's only for debug in the alert
        txtAlertDate = (TextView)view.findViewById(R.id.txtAlertDate);
        txtNoLocation = (TextView)view.findViewById(R.id.txtNoLocation);

        btnAlertDismissAlways = (Button) view.findViewById(R.id.btnDismissAlwaysHere); //button of the alert for always dismiss the found signal
        btnAlertDismissThisTime = (Button) view.findViewById(R.id.btnDismissThisTime); //button of the alert for only dismiss the found signal this time
        btnAlertBlockAlways = (Button) view.findViewById(R.id.btnBlockAlways); //button of the alert for starting the spoofing process after finding a signal
        btnAlertBlockThisTime = (Button) view.findViewById(R.id.btnBlockThisTime);
        btnAlertReplay = (Button) view.findViewById(R.id.btnReplay); //button of the alert for playing the found signal with fs/3

        btnAlertDismissAlways.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                listener.onAlertDismissAlways(DetectionDialogFragment.this);
            }
        });
        btnAlertDismissThisTime.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                listener.onAlertDismissThisTime(DetectionDialogFragment.this);
            }
        });

        btnAlertBlockAlways.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                listener.onAlertBlockAlways(DetectionDialogFragment.this);
            }
        });

        btnAlertBlockThisTime.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                listener.onAlertBlockThisTime(DetectionDialogFragment.this);
            }
        });

        btnAlertReplay.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v) {
                //listener.onAlertPlayDetectedSignal(DetectionDialogFragment.this);
            }
        });

        /*
        builder.setTitle(permissionLevelQuestion)
                .setItems(R.array.permission_level_texts,
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                switch(which){
                                    case 0:
                                        break;
                                    default:
                                        break;
                                }
                            }
                        });
*/
        // Should be executed after initialization of all buttons AND before setting the view
        setupButtonState(currentActivity);
        builder.setView(view);
        //builder.setTitle(R.string.alertDialog_text_ultrasonic_signal_detected);
        return builder.create();
    }

    private void setTechnologyText(FragmentActivity currentActivity) {
        String storedTechnology = PreferenceManager.getDefaultSharedPreferences(currentActivity).getString(ConfigConstants.LAST_DETECTED_TECHNOLOGY_SHARED_PREF, null);
        if (storedTechnology != null) {
            Technology lastDetectedTechnology = null;
            try {
                lastDetectedTechnology = Technology.fromString(storedTechnology);
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
        boolean gpsEnabled = settings.getBoolean(ConfigConstants.SETTING_GPS, ConfigConstants.SETTING_GPS_DEFAULT);
        boolean networkEnabled = settings.getBoolean(ConfigConstants.SETTING_NETWORK_USE, ConfigConstants.SETTING_NETWORK_USE_DEFAULT);
        LocationManager locationManager = (LocationManager) currentActivity.getSystemService(currentActivity.LOCATION_SERVICE);
        boolean isNetworkEnabled = locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);
        boolean isGPSEnabled = locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);

        boolean saveJsonFile = settings.getBoolean(ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE, ConfigConstants.SETTING_SAVE_DATA_TO_JSON_FILE_DEFAULT);

        int status = ActivityCompat.checkSelfPermission(currentActivity,
                Manifest.permission.ACCESS_FINE_LOCATION);

        if((!(isGPSEnabled && gpsEnabled) && !(isNetworkEnabled && networkEnabled)) || status != PackageManager.PERMISSION_GRANTED){
            currentActivity.runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    btnAlertBlockAlways.setEnabled(false);
                    btnAlertDismissAlways.setEnabled(false);
                    txtNoLocation.setText(R.string.on_alert_no_location_message);
                }
            });
        }else if(!saveJsonFile){
            currentActivity.runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    btnAlertBlockAlways.setEnabled(false);
                    btnAlertDismissAlways.setEnabled(false);
                    txtNoLocation.setText(R.string.alert_no_json_file_message);
                }
            });
        }else{
            currentActivity.runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    btnAlertBlockAlways.setEnabled(true);
                    btnAlertDismissAlways.setEnabled(true);
                    txtNoLocation.setText("");
                }
            });
        }

        setTechnologyText(currentActivity);

        txtAlertDate.setText(getString(R.string.alert_detection_date) + " " + settings.getString(ConfigConstants.LAST_DETECTED_DATE_SHARED_PREF, "unknown"));
    }

    @Override
    public void onDismiss(DialogInterface dialog) {
        super.onDismiss(dialog);
    }

    @Override
    public void onCancel(DialogInterface dialog) {
        super.onCancel(dialog);

        // Forward cancellation? (can we cancel?)
    }

    public void setSpectrum(float[][] spectrum) {
        lastDetectedSpectrum = spectrum;
        if (spectrogramView != null) {
            onSpectrum();
        }
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
                        spectrogramView.invalidate();
                        spectrogramView.setVisibility(View.VISIBLE);
                    }
                }));
            }
        }
        else {
            Log.w(TAG, "onSpectrum: alert not initialized yet !");
        }
    }
}
