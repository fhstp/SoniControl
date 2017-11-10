package sonicontrol.testroutine;

import android.Manifest;
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
import android.support.v4.app.ActivityCompat;
import android.util.Log;
import android.content.SharedPreferences;

import java.io.IOException;
import java.util.List;
import java.util.Locale;


public class GPSTracker extends Service implements LocationListener {

    private static String TAG = GPSTracker.class.getName();
    private final Context mContext;
    private final MainActivity main;

    boolean isGPSEnabled = false;
    boolean isNetworkEnabled = false;
    boolean isGPSTrackingEnabled = false;

    Location location;
    double latitude;
    double longitude;

    int geocoderMaxResults = 1;
    private static final long MIN_DISTANCE_CHANGE_FOR_UPDATES = 3;
    private static final long MIN_TIME_BW_UPDATES = 1000 * 5 * 1;

    protected LocationManager locationManager;
    private String provider_info;

    public GPSTracker(Context context, MainActivity main) {
        this.mContext = context;
        this.main = main;
        getLocation();
    }


    public void getLocation() {

        try {
            locationManager = (LocationManager) mContext.getSystemService(LOCATION_SERVICE);

            isGPSEnabled = locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);

            isNetworkEnabled = locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);

            SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
            boolean locationTrack = sharedPref.getBoolean("cbprefLocationTracking", true);
            boolean locationTrackGps = sharedPref.getBoolean("cbprefGpsUse", true);
            boolean locationTrackNet = sharedPref.getBoolean("cbprefNetworkUse", true);

            if (isGPSEnabled && locationTrackGps) {
                this.isGPSTrackingEnabled = true;
                Log.d(TAG, "Application use GPS Service");
                provider_info = LocationManager.GPS_PROVIDER;
            } else if (isNetworkEnabled && locationTrackNet) {
                //this.isGPSTrackingEnabled = true;
                this.isNetworkEnabled = true;
                Log.d(TAG, "Application use Network State to get GPS coordinates");
                provider_info = LocationManager.NETWORK_PROVIDER;
            }

            int status = ActivityCompat.checkSelfPermission(main,
                    Manifest.permission.RECORD_AUDIO);
            if (status != PackageManager.PERMISSION_GRANTED) {
                ActivityCompat.requestPermissions(
                        main,
                        new String[]{Manifest.permission.RECORD_AUDIO},
                        0);
            }

            if (!provider_info.isEmpty()) {
                locationManager.requestLocationUpdates(
                        provider_info,
                        MIN_TIME_BW_UPDATES,
                        MIN_DISTANCE_CHANGE_FOR_UPDATES,
                        this
                );

                if (locationManager != null) {
                    location = locationManager.getLastKnownLocation(provider_info);
                    updateGPSCoordinates();
                }
            }
        }
        catch (Exception e)
        {
            Log.e(TAG, "Impossible to connect to LocationManager", e);
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
                Log.e(TAG, "Impossible to connect to Geocoder", e);
            }
        }

        return null;
    }


    public String getAddressLine(Context context) {
        List<Address> addresses = getGeocoderAddress(context);

        if (addresses != null && addresses.size() > 0) {
            Address address = addresses.get(0);
            String addressLine = address.getAddressLine(0);

            return addressLine;
        } else {
            return null;
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
}