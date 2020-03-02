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

public class StoredLocations extends BaseActivity implements /*ViewPager.OnPageChangeListener*/BottomNavigationView.OnNavigationItemSelectedListener{
    BottomNavigationView navView;
    ViewPager viewPager;

    private static final String[] PERMISSIONS = {Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.INTERNET/*, Manifest.permission.WRITE_EXTERNAL_STORAGE*/, Manifest.permission.ACCESS_NETWORK_STATE};
    //private static final String[] PERMISSION_LOCATION = {Manifest.permission.ACCESS_FINE_LOCATION};
    //private static final String[] PERMISSION_STORAGE = {Manifest.permission.WRITE_EXTERNAL_STORAGE};
    private static final int REQUEST_MAP_PERMISSIONS = 72;

    public Handler uiHandler = new Handler(Looper.getMainLooper());
    /*private static final String JSON_ARRAY_SIGNAL_LONGITUDE = "long";
    private static final String JSON_ARRAY_SIGNAL_LATITUDE = "lat";
    private static final String JSON_ARRAY_SIGNAL_TECHNOLOGY = "technology";
    private static final String JSON_ARRAY_SIGNAL_LAST_DETECTION = "last_detection";
    private static final String JSON_ARRAY_SIGNAL_SPOOFING_STATUS = "spoof";
    private static final String JSON_ARRAY_SIGNAL_ADDRESS = "address";
    private static final String JSON_ARRAY_SIGNAL_URL = "URL";*/

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.stored_locations);
        navView = findViewById(R.id.nav_view);
        navView.setOnNavigationItemSelectedListener(this);
        loadFragment(new DetectionHistoryFragment());

        /*viewPager = findViewById(R.id.viewpager); //Init Viewpager
        setupFragments(getSupportFragmentManager(), viewPager); //Setup Fragment
        viewPager.setCurrentItem(0); //Set Currrent Item When Activity Start
        viewPager.setOnPageChangeListener(this);*/
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        super.onCreateOptionsMenu(menu);
        setActiveRuleInfoMenuItem(true);
        setActiveSettingsInfoMenuItem(false);
        return true;
    }

    /*public static void setupFragments(FragmentManager fragmentManager, ViewPager viewPager){
        FragmentAdapter Adapter = new FragmentAdapter(fragmentManager);
        //Add All Fragment To List
        Adapter.add(new MyRulesFragment(), "My Rules");
        Adapter.add(new ImportedRulesFragment(), "Imported Rules");
        Adapter.add(new DetectionHistoryFragment(), "Detection History");
        Adapter.add(new RulesOnMapFragment(), "Rules on Map");
        viewPager.setAdapter(Adapter);
    }*/


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

    /*private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {

        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            Fragment fragment = null;
            switch (item.getItemId()) {
                case R.id.navigation_my_rules:
                    //viewPager.setCurrentItem(0);
                    fragment = new MyRulesFragment();
                    break;
                    //return true;
                case R.id.navigation_imported_rules:
                    //viewPager.setCurrentItem(1);
                    fragment = new ImportedRulesFragment();
                    break;
                    //return true;
                case R.id.navigation_detection_history:
                    //viewPager.setCurrentItem(2);
                    fragment = new DetectionHistoryFragment();
                    break;
                    //return true;
                case R.id.navigation_rules_map:
                    requestPermissions();
                    //viewPager.setCurrentItem(3);
                    fragment = new RulesOnMapFragment();
                    break;
                    //return true;
            }
            return loadFragment(fragment);
            //return false;
        }
    };*/

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

    /*@Override
    public void onPageScrolled(int i, float v, int i1) {

    }

    @Override
    public void onPageSelected(int position) {
        switch (position) {
            case 0:
                navView.setSelectedItemId(R.id.navigation_my_rules);
                break;
            case 1:
                navView.setSelectedItemId(R.id.navigation_imported_rules);
                break;
            case 2:
                navView.setSelectedItemId(R.id.navigation_detection_history);
                break;
            case 3:
                requestPermissions();
                //navView.setSelectedItemId(R.id.navigation_rules_map);
                break;
        }
    }

    @Override
    public void onPageScrollStateChanged(int i) {

    }*/

    @Override
    public void onRequestPermissionsResult(int requestCode, String permissions[], int[] grantResults) {
        switch (requestCode) {
            case REQUEST_MAP_PERMISSIONS: {
                if (grantResults.length == 0) {
                    //we will show an explanation next time the user click on start
                    showRequestPermissionExplanation();
                    //viewPager.setCurrentItem(3);
                    //navView.setSelectedItemId(R.id.navigation_rules_map);
                } else {
                    for (int i = 0; i < permissions.length; i++) {
                        if (Manifest.permission.ACCESS_FINE_LOCATION.equals(permissions[i])) {
                            if (grantResults[i] == PackageManager.PERMISSION_GRANTED) {
                                /*if (locationFinder.validateMicAvailability()) {
                                    startService();
                                    checkForActivatedLocation();
                                    startDetection();
                                } else {
                                    activateNoMicrophoneAccessAlertDialog();
                                }*/
                                //viewPager.setCurrentItem(3);
                                //navView.setSelectedItemId(R.id.navigation_rules_map);
                            } else if (grantResults[i] == PackageManager.PERMISSION_DENIED) {
                                showRequestPermissionExplanation();
                                break;
                                //viewPager.setCurrentItem(3);
                                //navView.setSelectedItemId(R.id.navigation_rules_map);
                            }
                        }/*else if (Manifest.permission.WRITE_EXTERNAL_STORAGE.equals(permissions[i])) {
                            if (grantResults[i] == PackageManager.PERMISSION_GRANTED) {
                            } else if (grantResults[i] == PackageManager.PERMISSION_DENIED) {
                                showRequestPermissionExplanation();
                                break;
                            }
                        }*/
                    }
                }
            }
            /*case ConfigConstants.REQUEST_GPS_PERMISSION: {
                if (grantResults.length == 0) {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(StoredLocations.this, R.string.toastLocationAccessDenied, Toast.LENGTH_LONG).show();
                        }
                    });
                    showRequestPermissionExplanation();
                    //viewPager.setCurrentItem(3);
                    //navView.setSelectedItemId(R.id.navigation_rules_map);
                } else {
                    for (int i = 0; i < permissions.length; i++) {
                        if (Manifest.permission.ACCESS_FINE_LOCATION.equals(permissions[i])) {
                            if (grantResults[i] == PackageManager.PERMISSION_GRANTED) {
                                //locationFinder.requestGPSUpdates();
                                //viewPager.setCurrentItem(3);
                                //navView.setSelectedItemId(R.id.navigation_rules_map);
                            } else if (grantResults[i] == PackageManager.PERMISSION_DENIED) {
                                runOnUiThread(new Runnable() {
                                    @Override
                                    public void run() {
                                        Toast.makeText(StoredLocations.this, R.string.toastLocationAccessDenied, Toast.LENGTH_LONG).show();
                                    }
                                });
                                showRequestPermissionExplanation();
                                //viewPager.setCurrentItem(3);
                                //navView.setSelectedItemId(R.id.navigation_rules_map);
                            }
                        }
                    }
                }
            }
            case ConfigConstants.REQUEST_WRITE_EXTERNAL_STORAGE_PERMISSION: {
                if (grantResults.length == 0) {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(StoredLocations.this, R.string.toastWritingAccessDenied, Toast.LENGTH_LONG).show();
                        }
                    });
                    showRequestPermissionExplanation();
                    //viewPager.setCurrentItem(3);
                    //navView.setSelectedItemId(R.id.navigation_rules_map);
                } else {
                    for (int i = 0; i < permissions.length; i++) {
                        if (Manifest.permission.WRITE_EXTERNAL_STORAGE.equals(permissions[i])) {
                            if (grantResults[i] == PackageManager.PERMISSION_GRANTED) {
                                //locationFinder.requestGPSUpdates();
                                //viewPager.setCurrentItem(3);
                                //navView.setSelectedItemId(R.id.navigation_rules_map);
                            } else if (grantResults[i] == PackageManager.PERMISSION_DENIED) {
                                runOnUiThread(new Runnable() {
                                    @Override
                                    public void run() {
                                        Toast.makeText(StoredLocations.this, R.string.toastWritingAccessDenied, Toast.LENGTH_LONG).show();
                                    }
                                });
                                showRequestPermissionExplanation();
                                //viewPager.setCurrentItem(3);
                                //navView.setSelectedItemId(R.id.navigation_rules_map);
                            }
                        }
                    }
                }
            }*/
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
            // If an explanation is needed
            /*if (ActivityCompat.shouldShowRequestPermissionRationale(StoredLocations.this,
                        Manifest.permission.WRITE_EXTERNAL_STORAGE)) {
                Log.d("requestPermissions", "WRITE_EXTERNAL_STORAGE");
                Snackbar permissionSnackbar = Snackbar.make(findViewById(android.R.id.content).getRootView(), R.string.permissionMapRequestExplanation,
                        Snackbar.LENGTH_INDEFINITE)
                        .setAction("OK", new View.OnClickListener() {
                            @Override
                            public void onClick(View view) {
                                ActivityCompat.requestPermissions(StoredLocations.this, PERMISSIONS, REQUEST_MAP_PERMISSIONS);
                            }
                        });
                View permissionSnackbarView = permissionSnackbar.getView();
                TextView permissionSnackbarTextView = (TextView) permissionSnackbarView.findViewById(android.support.design.R.id.snackbar_text);
                permissionSnackbarTextView.setMaxLines(6);
                permissionSnackbar.show();
            } else */if (ActivityCompat.shouldShowRequestPermissionRationale(StoredLocations.this,
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

                /*Toast toast = Toast.makeText(StoredLocations.this, R.string.permissionRequestExplanation, Toast.LENGTH_LONG);
                toast.setGravity(Gravity.CENTER,0,0);
                toast.show();*/
                //showRequestPermissionExplanation();

                /*uiHandler.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        ActivityCompat.requestPermissions(StoredLocations.this, PERMISSIONS, REQUEST_MAP_PERMISSIONS);
                    }
                }, 2000);*/
            } else {
                Log.d("requestPermissions", "PERMISSIONS");
                // First time, no explanation needed, we can request the permission.
                ActivityCompat.requestPermissions(StoredLocations.this, PERMISSIONS, REQUEST_MAP_PERMISSIONS);
            }
        }else{
            //viewPager.setCurrentItem(3);
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

    /*private void setupViewPager(ViewPager viewPager)
    {
        ViewPagerAdapter adapter = new ViewPagerAdapter(getSupportFragmentManager());
        Fragment detectionHistoryFragment = new DetectionHistoryFragment();
        Fragment myRulesFragment = new MyRulesFragment();
        Fragment importedRulesFragment = new ImportedRulesFragment();
        Fragment rulesOnMapFragment = new RulesOnMapFragment();
        adapter.addFragment(myRulesFragment);
        adapter.addFragment(importedRulesFragment);
        adapter.addFragment(detectionHistoryFragment);
        adapter.addFragment(rulesOnMapFragment);
        viewPager.setAdapter(adapter);
    }*/

}
