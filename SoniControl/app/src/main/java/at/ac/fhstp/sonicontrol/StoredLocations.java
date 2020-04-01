/*
 * Copyright (c) 2018, 2019, 2020. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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

import android.Manifest;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Build;
import android.os.Handler;
import android.os.Looper;
import androidx.annotation.NonNull;
import com.google.android.material.bottomnavigation.BottomNavigationView;
//import android.support.annotation.NonNull;
//import android.support.design.widget.BottomNavigationView;
import android.os.Bundle;
import com.google.android.material.snackbar.Snackbar;
//import android.support.design.widget.Snackbar;
import androidx.core.app.ActivityCompat;
import androidx.fragment.app.Fragment;
import androidx.viewpager.widget.ViewPager;
//import androidx.core.app.Fragment;
//import androidx.core.view.ViewPager;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;

import at.ac.fhstp.sonicontrol.detetion_fragments.DetectionHistoryFragment;
import at.ac.fhstp.sonicontrol.detetion_fragments.ImportedRulesFragment;
import at.ac.fhstp.sonicontrol.detetion_fragments.MyRulesFragment;
import at.ac.fhstp.sonicontrol.detetion_fragments.RulesOnMapFragment;

import static android.provider.Settings.ACTION_APPLICATION_DETAILS_SETTINGS;

public class StoredLocations extends BaseActivity implements BottomNavigationView.OnNavigationItemSelectedListener{
    BottomNavigationView navView;
    ViewPager viewPager;

    private static final String[] PERMISSIONS = {Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.INTERNET, Manifest.permission.ACCESS_NETWORK_STATE};
    private static final int REQUEST_MAP_PERMISSIONS = 72;

    public Handler uiHandler = new Handler(Looper.getMainLooper());

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.stored_locations);
        navView = findViewById(R.id.nav_view);
        navView.setOnNavigationItemSelectedListener(this);
        loadFragment(new DetectionHistoryFragment());
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        super.onCreateOptionsMenu(menu);
        setActiveRuleInfoMenuItem(true);
        setActiveSettingsInfoMenuItem(false);
        return true;
    }

    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {
        Fragment fragment = null;
        switch (menuItem.getItemId()) {
            case R.id.navigation_my_rules:
                fragment = new MyRulesFragment();
                break;
            case R.id.navigation_imported_rules:
                fragment = new ImportedRulesFragment();
                break;
            case R.id.navigation_detection_history:
                fragment = new DetectionHistoryFragment();
                break;
            case R.id.navigation_rules_map:
                requestPermissions();
                fragment = new RulesOnMapFragment();
                break;
        }
        return loadFragment(fragment);
    }

    private boolean loadFragment(Fragment fragment) {
        //switching fragment
        if (fragment != null) {
            Log.d("StoredLocations", "loadsFragment");
            getSupportFragmentManager()
                    .beginTransaction()
                    .replace(R.id.fragment_container, fragment)
                    .commit();
            return true;
        }
        return false;
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, String permissions[], int[] grantResults) {
        switch (requestCode) {
            case REQUEST_MAP_PERMISSIONS: {
                if (grantResults.length == 0) {
                    //we will show an explanation next time the user click on start
                    showRequestPermissionExplanation();
                } else {
                    for (int i = 0; i < permissions.length; i++) {
                        if (Manifest.permission.ACCESS_FINE_LOCATION.equals(permissions[i])) {
                            if (grantResults[i] == PackageManager.PERMISSION_GRANTED) {

                            } else if (grantResults[i] == PackageManager.PERMISSION_DENIED) {
                                showRequestPermissionExplanation();
                                break;

                            }
                        }
                    }
                }
            }
        }
    }

    public static boolean hasPermissions(Context context, String... permissions) {
        if (android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && context != null && permissions != null) {
            for (String permission : permissions) {
                if (ActivityCompat.checkSelfPermission(context, permission) != PackageManager.PERMISSION_GRANTED) {
                    return false;
                }
            }
        }
        return true;
    }

    public void requestPermissions(){
        if(!hasPermissions(StoredLocations.this, PERMISSIONS)){
            if (ActivityCompat.shouldShowRequestPermissionRationale(StoredLocations.this,
                    Manifest.permission.ACCESS_FINE_LOCATION)) {
                Log.d("requestPermissions", "ACCESS_FINE_LOCATION");

                Snackbar permissionSnackbar = Snackbar.make(findViewById(android.R.id.content).getRootView(), R.string.permissionMapRequestExplanation,
                        Snackbar.LENGTH_INDEFINITE)
                        .setAction("OK", new View.OnClickListener() {
                            @Override
                            public void onClick(View view) {
                                ActivityCompat.requestPermissions(StoredLocations.this, PERMISSIONS, REQUEST_MAP_PERMISSIONS);
                            }
                        });
                View permissionSnackbarView = permissionSnackbar.getView();
                TextView permissionSnackbarTextView = (TextView) permissionSnackbarView.findViewById(com.google.android.material.R.id.snackbar_text);
                permissionSnackbarTextView.setMaxLines(4);
                permissionSnackbar.show();
            } else {
                Log.d("requestPermissions", "PERMISSIONS");
                // First time, no explanation needed, we can request the permission.
                ActivityCompat.requestPermissions(StoredLocations.this, PERMISSIONS, REQUEST_MAP_PERMISSIONS);
            }
        }else{

        }
    }

    private void showRequestPermissionExplanation() {
        AlertDialog.Builder builder = new AlertDialog.Builder(StoredLocations.this);
        builder.setMessage(R.string.permissionMapRequestExplanation);
        builder.setPositiveButton(getString(R.string.permission_explanation_map_button_positive),new DialogInterface.OnClickListener() {

                    public void onClick(DialogInterface dialog, int which) {
                        Intent intent = new Intent();
                        intent.setAction(ACTION_APPLICATION_DETAILS_SETTINGS);
                        Uri uri = Uri.fromParts("package", getPackageName(), null);
                        intent.setData(uri);
                        startActivity(intent);
                    }
                }
        );
        builder.setNegativeButton(getString(R.string.permission_explanation_map_button_negative), null);
        builder.show();
    }
}
