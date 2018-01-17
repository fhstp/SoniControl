package at.ac.fhstp.sonicontrol;


import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

public class SettingsActivity extends BaseActivity {

    MainActivity main = new MainActivity();
    MainActivity nextMain;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.settings_container);

        nextMain = main.getMainIsMain();

        // Display the fragment as the main content.
        getFragmentManager().beginTransaction()
                .replace(R.id.preference_container, new SettingsFragment()) //replace the layout file with the settingsFragment
                .commit();
    }
}
