package at.ac.fhstp.sonicontrol;


import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

public class Settings extends ActionBarActivity {

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

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.main_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            // action with ID action_refresh was selected
            case R.id.open_help:
                Toast.makeText(this, "Help selected", Toast.LENGTH_SHORT)
                        .show();
                break;
            // action with ID action_settings was selected
            case R.id.open_about_us:
                Toast.makeText(this, "About Us selected", Toast.LENGTH_SHORT)
                        .show();
                break;
            default:
                return super.onOptionsItemSelected(item);
        }

        return true;
    }

    @Override
    public void onDestroy(){
        super.onDestroy();
        nextMain.getUpdatedSettings();
    }
}
