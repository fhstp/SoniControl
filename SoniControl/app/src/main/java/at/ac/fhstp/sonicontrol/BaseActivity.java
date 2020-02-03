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
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.text.HtmlCompat;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;

import static androidx.core.text.HtmlCompat.FROM_HTML_MODE_LEGACY;

/**
 * Created by aringot on 17.01.2018.
 */

public class BaseActivity extends AppCompatActivity {
    public AlertDialog alertRuleInfo = null;
    public AlertDialog alertSettingsInfo = null;
    public Menu menu;

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.main_menu, menu);
        this.menu = menu;
        Log.d("BaseActivity", "onCrateOptionsMenu");
        menu.findItem(R.id.show_rules_info).setVisible(false);
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
            case R.id.show_rules_info:
                showRulesInfo();
                break;
            case R.id.show_settings_info:
                showSettingsInfo();
                break;
            default:
                return super.onOptionsItemSelected(item);
        }

        return true;
    }

    private void showRulesInfo(){
        final AlertDialog.Builder activateRuleInfoDialog = new AlertDialog.Builder(this);
        LayoutInflater RuleInfoAlertInflater = LayoutInflater.from(this);
        final View alertRuleInfoView = RuleInfoAlertInflater.inflate(R.layout.rule_info, null);
        activateRuleInfoDialog.setView(alertRuleInfoView);
        activateRuleInfoDialog
                .setTitle(getString(R.string.rules_info_title))
                .setCancelable(true)
                .setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        alertRuleInfo.cancel();
                    }
                });
        alertRuleInfo = activateRuleInfoDialog.show();
    }

    private void showSettingsInfo(){
        final AlertDialog.Builder activateSettingsInfoDialog = new AlertDialog.Builder(this);
        LayoutInflater SettingsInfoAlertInflater = LayoutInflater.from(this);
        final View alertSettingsInfoView = SettingsInfoAlertInflater.inflate(R.layout.settings_info, null);
        activateSettingsInfoDialog.setView(alertSettingsInfoView);
        activateSettingsInfoDialog
                .setTitle(getString(R.string.settings_info_title))
                .setCancelable(true)
                .setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        alertSettingsInfo.cancel();
                    }
                });
        alertSettingsInfo = activateSettingsInfoDialog.show();
    }

    private void openPrivacyPolicy() {
        Intent myIntent = new Intent(this.getApplicationContext(), PrivacyPolicyActivity.class);
        startActivityForResult(myIntent, 0);
    }

    public void openHelp(){
        //TODO: add data type to give the users the choice of the viewer they want to use
        Uri uri = Uri.parse("https://docs.google.com/gview?embedded=true&url=https://sonicontrol.fhstp.ac.at/wp-content/uploads/2017/07/sonicontrol_user_doc.pdf"); // missing 'http://' will cause crash
        Intent intent = new Intent(Intent.ACTION_VIEW, uri);
        startActivity(intent);
    }

    public void openInstructions(){
        new AlertDialog.Builder(this)
                .setTitle(R.string.instructionsTitle)
                .setMessage(HtmlCompat.fromHtml(getString(R.string.instructionsText), FROM_HTML_MODE_LEGACY))
                .setPositiveButton("OK", null)
                .show();
    }

    public void openAboutUs(){
        Intent myIntent = new Intent(this.getApplicationContext(), AboutUs.class); //redirect to the stored locations activity
        startActivityForResult(myIntent, 0);
    }

    public void setActiveRuleInfoMenuItem(boolean activate){
        if(menu!=null) menu.findItem(R.id.show_rules_info).setVisible(activate);//.setShowAsAction(MenuItem.SHOW_AS_ACTION_IF_ROOM);
    }

    public void setActiveSettingsInfoMenuItem(boolean activate){
        if(menu!=null) menu.findItem(R.id.show_settings_info).setVisible(activate);//.setShowAsAction(MenuItem.SHOW_AS_ACTION_IF_ROOM);
    }
}
