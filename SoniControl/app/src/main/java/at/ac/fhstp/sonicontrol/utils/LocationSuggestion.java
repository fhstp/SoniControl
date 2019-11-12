package at.ac.fhstp.sonicontrol.utils;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;

import java.util.Arrays;
import java.util.concurrent.atomic.AtomicLong;

import at.ac.fhstp.sonicontrol.GPSTracker;
import at.ac.fhstp.sonicontrol.Location;

public class LocationSuggestion extends AsyncTask<Void, Void, String[]> {

    private Runnable inputFinishChecker;
    long delay = 100;
    //TODO: AtomicLong
    AtomicLong lastTextEdit;
    AutoCompleteTextView actPosition;
    Context context;


    public LocationSuggestion(final AtomicLong lastTextEdit, AutoCompleteTextView actPosition, Context context){
        this.lastTextEdit = lastTextEdit;
        this.actPosition = actPosition;
        this.context = context;
        Log.d("LocationSuggestion", " " + lastTextEdit);
            /*this.inputFinishChecker = new Runnable() {
                public void run() {
                    if (System.currentTimeMillis() > (lastTextEdit.get())) {
                        Log.d("ImportedRulesFragment", "if currentTimeMil > lasttextedit");
                        //String[] countries = {"Vie,tnam","Eng, land","Can , ada", "Fra,nce","Australia"};
                        Location location = Location.getInstanceLoc();
                        Log.d("ImportedRulesFragment", "instLoc");
                        GPSTracker gpsTracker = location.getGPSTracker();
                        Log.d("ImportedRulesFragment", "getgps");
                        String[] addresses = gpsTracker.getAddressListOfName(actPosition.getText().toString(), getContext());
                        if(addresses!=null) {
                            Log.d("ImportedRulesFragment", "if addresses notNull " + addresses[0]);
                            System.out.println(Arrays.toString(addresses));
                            actPosition.setAdapter(null);
                            ArrayAdapter<String> adapter = new ArrayAdapter<String>(getContext(), android.R.layout.simple_dropdown_item_1line, addresses);
                            actPosition.setAdapter(adapter);
                            adapter.notifyDataSetChanged();

                        }
                    }
                }
            };*/
    }


    @Override
    protected String[] doInBackground(Void... params) {
        //textChangedHandler.postDelayed(inputFinishChecker, delay);
        if (System.currentTimeMillis() > (lastTextEdit.get()/* + delay*/)) {
            Log.d("ImportedRulesFragment", "if currentTimeMil > lasttextedit");
            //String[] countries = {"Vie,tnam","Eng, land","Can , ada", "Fra,nce","Australia"};
            Location location = Location.getInstanceLoc();
            Log.d("ImportedRulesFragment", "instLoc");
            GPSTracker gpsTracker = location.getGPSTracker();
            Log.d("ImportedRulesFragment", "getgps");
            String[] addresses = gpsTracker.getAddressListOfName(actPosition.getText().toString(), context);
            return addresses;
        }
        return null;
    }

    @Override
    protected void onPostExecute(String[] addresses) {
        if(addresses!=null) {
            Log.d("ImportedRulesFragment", "if addresses notNull " + addresses[0]);
            System.out.println(Arrays.toString(addresses));
            actPosition.setAdapter(null);
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(context, android.R.layout.simple_dropdown_item_1line, addresses);
            actPosition.setAdapter(adapter);
            adapter.notifyDataSetChanged();
            Log.d("ImportedRulesFragment", "onPostExecute");
        }
    }
}