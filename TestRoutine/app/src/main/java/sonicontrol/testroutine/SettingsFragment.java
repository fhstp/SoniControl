package sonicontrol.testroutine;

import android.content.SharedPreferences;
import android.preference.CheckBoxPreference;
import android.preference.PreferenceFragment;
import android.preference.*;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;
import android.content.*;

public class SettingsFragment extends PreferenceFragment {

    MainActivity main = new MainActivity();
    JSONManager jsonMan;
    MainActivity nextMain;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.settings_old);
        addPreferencesFromResource(R.xml.settings); //set the settings.xml as the preferences

        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);


        Preference pref = findPreference("deleteJson");
        pref.setOnPreferenceClickListener(new Preference.OnPreferenceClickListener() {

            @Override
            public boolean onPreferenceClick(Preference preference) {
                Log.d("TestPref", "Hi");
                jsonMan.deleteJsonFile();
                return false;
            }
        });


    }




}
