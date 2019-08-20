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

package at.ac.fhstp.sonicontrol;

import android.app.AlertDialog;
import android.content.ActivityNotFoundException;
import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

/**
 * Created by aringot on 17.01.2018.
 */

public class BaseActivity extends AppCompatActivity {

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
                openHelp();
                break;
            // action with ID action_settings was selected
            case R.id.open_about_us:
                openAboutUs();
                break;
            case R.id.open_instructions:
                openInstructions();
                break;
            case R.id.open_privacy_policy:
                openPrivacyPolicy();
                break;
            default:
                return super.onOptionsItemSelected(item);
        }

        return true;
    }

    private void openPrivacyPolicy() {
        Intent myIntent = new Intent(this.getApplicationContext(), PrivacyPolicyActivity.class);
        startActivityForResult(myIntent, 0);
    }

    public void openHelp(){
        // Should we use a chooser to give the users the choice of the viewer they want to use?
        Uri uri = Uri.parse("https://sonicontrol.fhstp.ac.at/wp-content/uploads/2017/07/sonicontrol_user_doc.pdf"); // missing 'http://' will cause crash
        Intent intent = new Intent(Intent.ACTION_VIEW, uri);
        // Verify the intent will resolve to at least one activity (browser)
        if (intent.resolveActivity(getPackageManager()) != null) {
            startActivity(intent);
        }
        else {
            try {
                intent.setType("application/pdf text/html");
                startActivity(intent);
            } catch (ActivityNotFoundException e) {
                Toast.makeText(this, "No application to open the pdf help file", Toast.LENGTH_LONG).show();
            }
        }
    }

    public void openInstructions(){
        new AlertDialog.Builder(this).setTitle(R.string.instructionsTitle).setMessage(R.string.instructionsText).setPositiveButton("OK", null).show();
    }

    public void openAboutUs(){
        Intent myIntent = new Intent(this.getApplicationContext(), AboutUs.class); //redirect to the stored locations activity
        startActivityForResult(myIntent, 0);
    }
}
