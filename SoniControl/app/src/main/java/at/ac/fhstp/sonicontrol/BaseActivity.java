/*
 * Copyright (c) 2018. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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
import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

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
        Uri uri = Uri.parse("http://sonicontrol.fhstp.ac.at"); // missing 'http://' will cause crashed
        Intent intent = new Intent(Intent.ACTION_VIEW, uri);
        startActivity(intent);
    }

    public void openInstructions(){
        new AlertDialog.Builder(this).setTitle(R.string.instructionsTitle).setMessage(R.string.instructionsText).setPositiveButton("OK", null).show();
    }

    public void openAboutUs(){
        Intent myIntent = new Intent(this.getApplicationContext(), AboutUs.class); //redirect to the stored locations activity
        startActivityForResult(myIntent, 0);
    }
}
