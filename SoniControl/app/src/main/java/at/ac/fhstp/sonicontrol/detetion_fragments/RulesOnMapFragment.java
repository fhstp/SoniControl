package at.ac.fhstp.sonicontrol.detetion_fragments;

import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import org.osmdroid.api.IMapController;
import org.osmdroid.config.Configuration;
import org.osmdroid.events.MapEventsReceiver;
import org.osmdroid.tileprovider.tilesource.TileSourceFactory;
import org.osmdroid.util.GeoPoint;
import org.osmdroid.views.MapView;
import org.osmdroid.views.overlay.ItemizedIconOverlay;
import org.osmdroid.views.overlay.ItemizedOverlayWithFocus;
import org.osmdroid.views.overlay.MapEventsOverlay;
import org.osmdroid.views.overlay.Marker;
import org.osmdroid.views.overlay.OverlayItem;
import org.osmdroid.views.overlay.Polygon;
import org.osmdroid.views.overlay.infowindow.BasicInfoWindow;
import org.osmdroid.views.overlay.infowindow.InfoWindow;

import java.lang.reflect.Array;
import java.util.ArrayList;

import at.ac.fhstp.sonicontrol.JSONManager;
import at.ac.fhstp.sonicontrol.MainActivity;
import at.ac.fhstp.sonicontrol.R;

public class RulesOnMapFragment extends Fragment implements MapEventsReceiver {
    MapView map = null;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState){
        View rootView = inflater.inflate(R.layout.rules_on_map_fragment, container, false);

        Context ctx = getActivity();
        Configuration.getInstance().load(ctx, PreferenceManager.getDefaultSharedPreferences(ctx));

        map = (MapView) rootView.findViewById(R.id.map);
        map.setTileSource(TileSourceFactory.MAPNIK);
        map.setBuiltInZoomControls(true);
        map.setMultiTouchControls(true);

        IMapController mapController = map.getController();
        mapController.setZoom(10);
        GeoPoint startPoint = new GeoPoint(48.212602, 15.6352079);
        mapController.setCenter(startPoint);

        addMapMarkers();

        MapEventsOverlay mapEventsOverlay = new MapEventsOverlay(getActivity(), this);
        map.getOverlays().add(0, mapEventsOverlay);

        //just change the fragment_dashboard
        //with the fragment you want to inflate
        //like if the class is HomeFragment it should have R.layout.home_fragment
        //if it is DashboardFragment it should have R.layout.fragment_dashboard
        return rootView;
    }

    public void addMapMarkers(){
        MainActivity main = new MainActivity();
        MainActivity nextMain = main.getMainIsMain();
        JSONManager jsonMan = new JSONManager(nextMain);
        ArrayList<String[]> locationData = jsonMan.getJsonData();
        locationData.addAll(jsonMan.getImportJsonData());

        for(String[] sArray : locationData){
            Polygon circle = new Polygon(map);
            circle.setPoints(Polygon.pointsAsCircle(new GeoPoint(Double.valueOf(sArray[1]),Double.valueOf(sArray[0])), 20.0));
            circle.setFillColor(0x330000FF);
            circle.setStrokeColor(Color.BLUE);
            circle.setStrokeWidth(7);
            circle.setInfoWindow(new BasicInfoWindow(org.osmdroid.bonuspack.R.layout.bonuspack_bubble, map));
            circle.setTitle(sArray[2]);
            circle.setSubDescription("Last Detection: " +sArray[3]);
            map.getOverlays().add(circle);

            //TODO:
            /*switch(Integer.valueOf(sArray[2])){
                case 1:
            }*/
            Marker marker = new Marker(map);
            marker.setPosition(new GeoPoint(Double.valueOf(sArray[1]),Double.valueOf(sArray[0])));
            marker.setAnchor(Marker.ANCHOR_CENTER, Marker.ANCHOR_BOTTOM);
            marker.setIcon(getResources().getDrawable(R.drawable.baseline_place_black_48));
            marker.setTitle(sArray[2]);
            marker.setSubDescription("Last Detection: " +sArray[3]);
            map.getOverlays().add(marker);
        }




        /*ArrayList<OverlayItem> items = new ArrayList<OverlayItem>();
        for(String[] sArray : locationData){
                items.add(new OverlayItem(sArray[2] + "-" + sArray[3], sArray[5], new GeoPoint(Double.valueOf(sArray[1]),Double.valueOf(sArray[0])))); // Lat/Lon decimal degrees
        }


        //the overlay
        ItemizedOverlayWithFocus<OverlayItem> mOverlay = new ItemizedOverlayWithFocus<OverlayItem>(items,
                new ItemizedIconOverlay.OnItemGestureListener<OverlayItem>() {
                    @Override
                    public boolean onItemSingleTapUp(final int index, final OverlayItem item) {
                        Log.d("RulesOnMap", "onItemSignelTapUp");
                        return true;
                    }
                    @Override
                    public boolean onItemLongPress(final int index, final OverlayItem item) {
                        Log.d("RulesOnMap", "onItemLongPress");
                        return false;
                    }
                }, getContext());
        mOverlay.setFocusItemsOnTap(true);

        map.getOverlays().add(mOverlay);*/
    }

    public void onResume(){
        super.onResume();
        map.onResume(); //needed for compass, my location overlays, v6.0.0 and up
    }

    public void onPause(){
        super.onPause();
    }

    @Override
    public boolean singleTapConfirmedHelper(GeoPoint p) {
        InfoWindow.closeAllInfoWindowsOn(map);
        return true;
    }

    @Override
    public boolean longPressHelper(GeoPoint p) {
        return false;
    }
}
