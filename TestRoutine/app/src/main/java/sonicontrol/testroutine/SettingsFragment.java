package sonicontrol.testroutine;

import android.content.SharedPreferences;
import android.preference.CheckBoxPreference;
import android.preference.PreferenceFragment;
import android.preference.*;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;
import android.content.*;

public class SettingsFragment extends PreferenceFragment {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.settings_old);
        addPreferencesFromResource(R.xml.settings); //set the settings.xml as the preferences


    }




}
