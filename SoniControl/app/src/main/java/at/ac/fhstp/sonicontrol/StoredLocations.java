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

import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.view.MenuItem;

import at.ac.fhstp.sonicontrol.detetion_fragments.DetectionHistoryFragment;
import at.ac.fhstp.sonicontrol.detetion_fragments.FragmentAdapter;
import at.ac.fhstp.sonicontrol.detetion_fragments.ImportedRulesFragment;
import at.ac.fhstp.sonicontrol.detetion_fragments.MyRulesFragment;
import at.ac.fhstp.sonicontrol.detetion_fragments.RulesOnMapFragment;

public class StoredLocations extends BaseActivity implements ViewPager.OnPageChangeListener{
    BottomNavigationView navView;
    ViewPager viewPager;
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
        navView.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);
        //loadFragment(new DetectionHistoryFragment());

        viewPager = findViewById(R.id.viewpager); //Init Viewpager
        setupFragments(getSupportFragmentManager(), viewPager); //Setup Fragment
        viewPager.setCurrentItem(0); //Set Currrent Item When Activity Start
        viewPager.setOnPageChangeListener(this);
    }

    public static void setupFragments(FragmentManager fragmentManager, ViewPager viewPager){
        FragmentAdapter Adapter = new FragmentAdapter(fragmentManager);
        //Add All Fragment To List
        Adapter.add(new MyRulesFragment(), "My Rules");
        Adapter.add(new ImportedRulesFragment(), "Imported Rules");
        Adapter.add(new DetectionHistoryFragment(), "Detection History");
        Adapter.add(new RulesOnMapFragment(), "Rules on Map");
        viewPager.setAdapter(Adapter);
    }

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {

        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            //Fragment fragment = null;
            switch (item.getItemId()) {
                case R.id.navigation_my_rules:
                    viewPager.setCurrentItem(0);
                    //fragment = new MyRulesFragment();
                    //break;
                    return true;
                case R.id.navigation_imported_rules:
                    viewPager.setCurrentItem(1);
                    //fragment = new ImportedRulesFragment();
                    //break;
                    return true;
                case R.id.navigation_detection_history:
                    viewPager.setCurrentItem(2);
                    //fragment = new DetectionHistoryFragment();
                    //break;
                    return true;
                case R.id.navigation_rules_map:
                    viewPager.setCurrentItem(3);
                    //fragment = new RulesOnMapFragment();
                    //break;
                    return true;
            }
            //return loadFragment(fragment);
            return false;
        }
    };

    /*private boolean loadFragment(Fragment fragment) {
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
    }*/

    @Override
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
                navView.setSelectedItemId(R.id.navigation_rules_map);
                break;
        }
    }

    @Override
    public void onPageScrollStateChanged(int i) {

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
