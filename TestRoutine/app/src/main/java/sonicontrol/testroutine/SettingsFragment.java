package sonicontrol.testroutine;

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
        //setContentView(R.layout.settings_old);
        addPreferencesFromResource(R.xml.settings); //set the settings.xml as the preferences

        settingsFragment = this;

        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);


        Preference pref = findPreference("deleteJson");
        pref.setOnPreferenceClickListener(new Preference.OnPreferenceClickListener() {

            @Override
            public boolean onPreferenceClick(Preference preference) {
                Log.d("TestPref", "Hi");
                final AlertDialog.Builder deleteJsonDialog = new AlertDialog.Builder(getActivity());
                deleteJsonDialog.setTitle("Delete JSON-File")
                        .setMessage("Are you sure you want to delete the JSON-File?")
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

        final Preference prefLocRad = findPreference("etprefLocationRadius");
        prefLocRad.setOnPreferenceChangeListener(new Preference.OnPreferenceChangeListener() {
            public boolean onPreferenceChange(Preference preference, Object newValue) {
                prefLocRad.setTitle("Location Radius (" + newValue + " metres)");
                Log.d("MyApp", "Pref " + preference.getKey() + " " + newValue.toString());
                Log.d("testfortest",String.valueOf(prefLocRad.getSharedPreferences().getString(prefLocRad.getKey(), "30")));
                return true;
            }
        });
        //Integer.valueOf(sharedPref.getString("etprefLocationRadius", "30"))
    }


    @Override
    public void onStart() {
        super.onStart();
        Preference prefLocRad = findPreference("etprefLocationRadius");
        int locationRadius = Integer.valueOf(prefLocRad.getSharedPreferences().getString(prefLocRad.getKey(), "30"));
        prefLocRad.setTitle("Location Radius (" + locationRadius + " metres)");
    }

    @Override
    public void onResume() {
        super.onResume();
        Preference prefLocRad = findPreference("etprefLocationRadius");
        int locationRadius = Integer.valueOf(prefLocRad.getSharedPreferences().getString(prefLocRad.getKey(), "30"));
        prefLocRad.setTitle("Location Radius (" + locationRadius + " metres)");
    }


}
