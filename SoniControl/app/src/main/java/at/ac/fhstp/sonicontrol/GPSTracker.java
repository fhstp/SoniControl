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

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.IBinder;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.util.Log;
import android.content.SharedPreferences;
import android.widget.Toast;

import java.io.IOException;
import java.util.List;
import java.util.Locale;


public class GPSTracker extends Service implements LocationListener {

    private static String TAG = GPSTracker.class.getName();
    private final MainActivity main;

    boolean isGPSEnabled = false;
    boolean isNetworkEnabled = false;
    boolean isGPSTrackingEnabled = false;

    Location location;
    double latitude;
    double longitude;

    Location savedLocationOnDetection;

    int geocoderMaxResults = 1;
    private static final float MIN_DISTANCE_CHANGE_FOR_UPDATES = 3.0f;
    private static final long MIN_TIME_BW_UPDATES = 1000 * 5 * 1;

    protected LocationManager locationManager;
    private String provider_info_gps = "";
    private String provider_info_network = "";

    public GPSTracker(MainActivity main) {
        this.main = main;
        initGPSTracker();
    }


    public void initGPSTracker() {
        try {
            //main.displayToast("I am in initGPS", Toast.LENGTH_LONG);
            locationManager = (LocationManager) main.getApplicationContext().getSystemService(LOCATION_SERVICE);

            Location locationNetwork = null;
            Location locationGPS = null;

            isGPSEnabled = locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);

            isNetworkEnabled = locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);

            SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
            boolean locationTrackGps = sharedPref.getBoolean(ConfigConstants.SETTING_GPS, ConfigConstants.SETTING_GPS_DEFAULT);
            boolean locationTrackNet = sharedPref.getBoolean(ConfigConstants.SETTING_NETWORK_USE, ConfigConstants.SETTING_NETWORK_USE_DEFAULT);

            if (isGPSEnabled && locationTrackGps) {
                this.isGPSTrackingEnabled = true;
                //Log.d(TAG, "Application use GPS Service");
                provider_info_gps = LocationManager.GPS_PROVIDER;
            }
            if (isNetworkEnabled && locationTrackNet) {
                //this.isGPSTrackingEnabled = true;
                this.isNetworkEnabled = true;
                //Log.d(TAG, "Application use Network State to get GPS coordinates");
                provider_info_network = LocationManager.NETWORK_PROVIDER;
            }

            int status = 0;
            if (!provider_info_network.isEmpty() || !provider_info_gps.isEmpty()) {
                status = ActivityCompat.checkSelfPermission(main.getApplicationContext(),
                        Manifest.permission.ACCESS_FINE_LOCATION);
                if (status != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(
                            main,
                            new String[]{Manifest.permission.ACCESS_FINE_LOCATION},
                            ConfigConstants.REQUEST_GPS_PERMISSION);
                }
                else {
                    if (!provider_info_network.isEmpty()) {
                        locationManager.requestLocationUpdates(
                                provider_info_network,
                                MIN_TIME_BW_UPDATES,
                                MIN_DISTANCE_CHANGE_FOR_UPDATES,
                                this,
                                main.uiHandler.getLooper()
                        );
                        if (locationManager != null) {
                            locationNetwork = locationManager.getLastKnownLocation(provider_info_network);
                            //updateGPSCoordinates();
                        }
                    }

                    if (!provider_info_gps.isEmpty()) {
                        locationManager.requestLocationUpdates(
                                provider_info_gps,
                                MIN_TIME_BW_UPDATES,
                                MIN_DISTANCE_CHANGE_FOR_UPDATES,
                                this,
                                main.uiHandler.getLooper()
                        );
                        if (locationManager != null) {
                            locationGPS = locationManager.getLastKnownLocation(provider_info_gps);
                            //updateGPSCoordinates();
                        }
                    }

                    //Log.d("NetworkLoc", String.valueOf(locationNetwork));
                    //Log.d("GPSLoc", String.valueOf(locationGPS));
                    if(locationNetwork==null){
                        //Log.d("GPS", "Yes");
                        location = locationGPS;
                        updateGPSCoordinates();
                    }else if(locationGPS==null){
                        //Log.d("Network", "Yes");
                        location = locationNetwork;
                        updateGPSCoordinates();
                    }else{
                        //Log.d("Will test", "Yes");
                        if(isBetterLocation(locationNetwork,locationGPS)){
                            location = locationNetwork;
                            updateGPSCoordinates();
                        }else{
                            location = locationGPS;
                            updateGPSCoordinates();
                        }
                    }

                    /*
                    if(locationManager != null){
                        if(locationGPS == null) {
                            location = locationNetwork;
                            updateGPSCoordinates();
                        }else if(locationNetwork == null) {
                            location = locationGPS;
                            updateGPSCoordinates();
                        }else if(locationNetwork.getAccuracy() < locationGPS.getAccuracy()){
                            location = locationNetwork;
                            updateGPSCoordinates();
                        }else if(locationGPS.getAccuracy() < locationNetwork.getAccuracy()){
                            location = locationGPS;
                            updateGPSCoordinates();
                        }
                    }*/
                }
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
            Log.e(TAG, "Impossible to connect to LocationManager", e);
            main.displayToast(getResources().getString(R.string.toastMessageNoGeocoderConnection), Toast.LENGTH_LONG);
        }
    }


    public void updateGPSCoordinates() {
        if (location != null) {
            latitude = location.getLatitude();
            longitude = location.getLongitude();
        }
    }

    public double getLatitude() {
        if (location != null) {
            latitude = location.getLatitude();
        }
        return latitude;
    }

    public double getLongitude() {
        if (location != null) {
            longitude = location.getLongitude();
        }
        return longitude;
    }


    public boolean getIsGPSTrackingEnabled() {
        return this.isGPSTrackingEnabled;
    }


    public void stopUsingGPS() {
        if (locationManager != null) {
            locationManager.removeUpdates(GPSTracker.this);
        }
    }

    public List<Address> getGeocoderAddress(Context context) {
        if (location != null) {

            Geocoder geocoder = new Geocoder(context, Locale.ENGLISH);

            try {
                List<Address> addresses = geocoder.getFromLocation(latitude, longitude, this.geocoderMaxResults);

                return addresses;
            } catch (IOException e) {
                e.printStackTrace();
                Log.e(TAG, "Impossible to connect to Geocoder", e);
            }
        }

        return null;
    }


    public String getAddressLine(Context context) {
        List<Address> addresses = getGeocoderAddress(context);

        if (addresses != null && !addresses.isEmpty()) {
            Address address = addresses.get(0);
            String addressLine = address.getAddressLine(0);

            return addressLine;
        } else {
            return main.getApplicationContext().getString(R.string.json_detections_unknown_address);
        }
    }


    public String getLocality(Context context) {
        List<Address> addresses = getGeocoderAddress(context);

        if (addresses != null && addresses.size() > 0) {
            Address address = addresses.get(0);
            String locality = address.getLocality();

            return locality;
        }
        else {
            return null;
        }
    }


    public String getPostalCode(Context context) {
        List<Address> addresses = getGeocoderAddress(context);

        if (addresses != null && addresses.size() > 0) {
            Address address = addresses.get(0);
            String postalCode = address.getPostalCode();

            return postalCode;
        } else {
            return null;
        }
    }


    public String getCountryName(Context context) {
        List<Address> addresses = getGeocoderAddress(context);
        if (addresses != null && addresses.size() > 0) {
            Address address = addresses.get(0);
            String countryName = address.getCountryName();

            return countryName;
        } else {
            return null;
        }
    }

    @Override
    public void onLocationChanged(Location location) {
        /*Location locationNetwork = null;
        Location locationGPS = null;
        int status = 0;
        if (!provider_info_network.isEmpty() || !provider_info_gps.isEmpty()) {
            status = ActivityCompat.checkSelfPermission(main.getApplicationContext(),
                    Manifest.permission.ACCESS_FINE_LOCATION);
            if (status != PackageManager.PERMISSION_GRANTED) {
                ActivityCompat.requestPermissions(
                        main,
                        new String[]{Manifest.permission.ACCESS_FINE_LOCATION},
                        ConfigConstants.REQUEST_GPS_PERMISSION);
            } else {
                if(locationManager != null) {
                    if (!provider_info_network.isEmpty()) {
                        locationGPS = locationManager.getLastKnownLocation(provider_info_gps);
                        updateGPSCoordinates();
                    }
                    if (!provider_info_network.isEmpty()) {
                        locationNetwork = locationManager.getLastKnownLocation(provider_info_network);
                        updateGPSCoordinates();
                    }
                }*/
                if(isBetterLocation(location,this.location)){
                    this.location = location;
                   //updateGPSCoordinates();
                }
            /*}
        }*/
    }

    @Override
    public void onStatusChanged(String provider, int status, Bundle extras) {
    }

    @Override
    public void onProviderEnabled(String provider) {
    }

    @Override
    public void onProviderDisabled(String provider) {
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    /***
     * This method is called directly from the onRequestPermissionsResult. We do have the permission.
     */
    @SuppressLint("MissingPermission")
    public void requestGPSUpdates() {

        if(!provider_info_gps.isEmpty()) {
            locationManager.requestLocationUpdates(
                    provider_info_gps,
                    MIN_TIME_BW_UPDATES,
                    MIN_DISTANCE_CHANGE_FOR_UPDATES,
                    this,
                    main.uiHandler.getLooper()
            );
        }
        if(!provider_info_network.isEmpty()) {
            locationManager.requestLocationUpdates(
                    provider_info_network,
                    MIN_TIME_BW_UPDATES,
                    MIN_DISTANCE_CHANGE_FOR_UPDATES,
                    this,
                    main.uiHandler.getLooper()
            );
        }
    }

    public void removeGPSUpdates(){
        locationManager.removeUpdates(this);
    }


    protected boolean isBetterLocation(Location location, Location currentBestLocation) {
        if (currentBestLocation == null) {
            // A new location is always better than no location
            return true;
        }
        //Log.d("Locationchange", String.valueOf(location));
        // Check whether the new location fix is newer or older
        long timeDelta = location.getTime() - currentBestLocation.getTime();
        boolean isSignificantlyNewer = timeDelta > MIN_TIME_BW_UPDATES;
        boolean isSignificantlyOlder = timeDelta < -MIN_TIME_BW_UPDATES;
        boolean isNewer = timeDelta > 0;

        // If it's been more than two minutes since the current location, use the new location
        // because the user has likely moved
        if (isSignificantlyNewer) {
            return true;
            // If the new location is more than two minutes older, it must be worse
        } else if (isSignificantlyOlder) {
            return false;
        }

        // Check whether the new location fix is more or less accurate
        int accuracyDelta = (int) (location.getAccuracy() - currentBestLocation.getAccuracy());
        boolean isLessAccurate = accuracyDelta > 0;
        boolean isMoreAccurate = accuracyDelta < 0;
        boolean isSignificantlyLessAccurate = accuracyDelta > 200;

        // Check if the old and new location are from the same provider
        boolean isFromSameProvider = isSameProvider(location.getProvider(),
                currentBestLocation.getProvider());

        // Determine location quality using a combination of timeliness and accuracy
        if (isMoreAccurate) {
            return true;
        } else if (isNewer && !isLessAccurate) {
            return true;
        } else if (isNewer && !isSignificantlyLessAccurate && isFromSameProvider) {
            return true;
        }
        return false;
    }

    /** Checks whether two providers are the same */
    private boolean isSameProvider(String provider1, String provider2) {
        if (provider1 == null) {
            return provider2 == null;
        }
        return provider1.equals(provider2);
    }

    public void saveDetectedLocation(){
        savedLocationOnDetection = location;
    }

    public double[] getDetectedLocation(){
        double[] savedLocation = new double[2];
        //Log.d("DetectedLocation", String.valueOf(savedLocationOnDetection));
        if(savedLocationOnDetection == null){
            savedLocation[0] = 0.0;
            savedLocation[1] = 0.0;

        }else{
            savedLocation[0] = savedLocationOnDetection.getLongitude();
            savedLocation[1] = savedLocationOnDetection.getLatitude();
        }

        return savedLocation;
    }
}