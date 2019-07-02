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
import android.content.Context;
import android.content.DialogInterface;
import android.support.design.widget.FloatingActionButton;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;

import org.json.JSONArray;
import org.json.JSONException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;

import at.ac.fhstp.sonicontrol.rest.RESTController;
import at.ac.fhstp.sonicontrol.rest.SoniControlAPI;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class StoredLocations extends BaseActivity {
    private static final String JSON_ARRAY_SIGNAL_LONGITUDE = "long";
    private static final String JSON_ARRAY_SIGNAL_LATITUDE = "lat";
    private static final String JSON_ARRAY_SIGNAL_TECHNOLOGY = "technology";
    private static final String JSON_ARRAY_SIGNAL_LAST_DETECTION = "last_detection";
    private static final String JSON_ARRAY_SIGNAL_SPOOFING_STATUS = "spoof";
    private static final String JSON_ARRAY_SIGNAL_ADDRESS = "address";
    private static final String JSON_ARRAY_SIGNAL_URL = "URL";

    MainActivity main = new MainActivity();
    private static StoredLocations instanceStoredLoc;
    JSONManager jsonMan;
    ArrayList<String[]> data;
    ListAdapter stored_adapter;
    ListView lv;
    MainActivity nextMain;
    AlertDialog alertDelete = null;

    AdapterView<?> parentLongClick;
    int positionLongClick;

    TextView txtNothingDiscovered;
    FloatingActionButton fabImportDetections;

    AlertDialog filterDialog;
    View view;
    AlertDialog dateTimeDialog;
    View viewDateTime;

    Button btnTimestampFrom;
    Button btnTimestampTo;
    Button btnImport;
    Button btnCancel;

    Button btnDateTimeSet;

    EditText edtLocation;
    Spinner spnTechnology;

    TextView txtTimestampFrom;
    TextView txtTimestampTo;

    Long timeFrom;
    Long timeTo;
    DatePicker datePicker;
    TimePicker timePicker;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.stored_locations);

        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);

        data = jsonMan.getJsonData();

        txtNothingDiscovered = (TextView) findViewById(R.id.txtNoDetectionsYet);
        fabImportDetections = (FloatingActionButton) findViewById(R.id.fabImportDetections);
        fabImportDetections.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //TODO: show Alert with filter decisions
                Log.d("StoredDetections", "Click");
                filterDialog.show();
                //getDetections(14.810007, 48.1328671, 0, "2019-06-17T10:09:34Z", "2019-06-17T19:09:34Z");
            }
        });

        if(data.size()==0){
            txtNothingDiscovered.setVisibility(View.VISIBLE);
        }else {
            txtNothingDiscovered.setVisibility(View.INVISIBLE);
        }

        lv = (ListView) findViewById(R.id.storedListView);
        lv.setAdapter(null);
        final Context listContext = this;
        stored_adapter = new Stored_Adapter(this, data);


        final AlertDialog.Builder deleteJsonDialog = new AlertDialog.Builder(StoredLocations.this);
        deleteJsonDialog.setTitle(R.string.DeleteJsonAlertTitle)
                .setMessage(R.string.DeleteJsonAlertMessage)
                .setCancelable(false)
                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        String[] singleArrayItem = (String[]) parentLongClick.getItemAtPosition(positionLongClick);
                        double[] positionSignal = new double[2];
                        positionSignal[0] = Double.valueOf(singleArrayItem[0]);
                        positionSignal[1] = Double.valueOf(singleArrayItem[1]);
                        jsonMan.deleteEntryInStoredLoc(positionSignal,singleArrayItem[2]);
                        jsonMan = new JSONManager(nextMain);
                        data = jsonMan.getJsonData();
                        if(data.size()==0){
                            txtNothingDiscovered.setVisibility(View.VISIBLE);
                        }else {
                            txtNothingDiscovered.setVisibility(View.INVISIBLE);
                        }
                        lv.setAdapter(null);
                        stored_adapter = new Stored_Adapter(listContext, data);
                        lv.setAdapter(stored_adapter);
                    }
                })
                .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        alertDelete.cancel();
                    }
                })
                .setIcon(android.R.drawable.ic_dialog_alert);

        lv.setAdapter(stored_adapter);

        lv.setOnItemClickListener(
                new AdapterView.OnItemClickListener(){
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        String[] singleArrayItem = (String[]) parent.getItemAtPosition(position);
                        double[] positionSignal = new double[2];
                        positionSignal[0] = Double.valueOf(singleArrayItem[0]);
                        positionSignal[1] = Double.valueOf(singleArrayItem[1]);
                        jsonMan.setShouldBeSpoofedInStoredLoc(positionSignal,singleArrayItem[2], Integer.valueOf(singleArrayItem[4]));
                        jsonMan = new JSONManager(nextMain);
                        data = jsonMan.getJsonData();
                        lv.setAdapter(null);
                        stored_adapter = new Stored_Adapter(listContext, data);
                        lv.setAdapter(stored_adapter);

                    }
                }
        );

        lv.setOnItemLongClickListener(
                new AdapterView.OnItemLongClickListener(){
                    @Override
                    public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                        parentLongClick = parent;
                        positionLongClick = position;
                        alertDelete = deleteJsonDialog.show();
                        return true;
                    }
                }
        );


        final AlertDialog.Builder openFilter = new AlertDialog.Builder(StoredLocations.this);
        openFilter.setCancelable(false);
        LayoutInflater inflater = getLayoutInflater();
        final ViewGroup viewGroup = (ViewGroup) findViewById(android.R.id.content);
        view = inflater.inflate(R.layout.detection_import_filter, viewGroup , false);
        openFilter.setView(view);
        filterDialog = openFilter.create();

        txtTimestampFrom = (TextView) view.findViewById(R.id.txtTimestampFrom);
        txtTimestampTo = (TextView) view.findViewById(R.id.txtTimestampTo);
        edtLocation = (EditText) view.findViewById(R.id.edtLocation);

        btnTimestampFrom = (Button) view.findViewById(R.id.btnTimestampFrom);
        btnTimestampFrom.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openDateTimePickerFrom();
            }
        });

        btnTimestampTo = (Button) view.findViewById(R.id.btnTimestampTo);
        btnTimestampTo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openDateTimePickerTo();
            }
        });

        btnImport = (Button) view.findViewById(R.id.btnImport);
        btnImport.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Location location = Location.getInstanceLoc();
                GPSTracker gpsTracker = location.getGPSTracker();
                double[] position = gpsTracker.getLocationFromAddress(edtLocation.getText().toString(), StoredLocations.this);
                Log.d("StoredDetections", (position[0]/1000000) + " " + (position[1]/1000000));
                int technology = spnTechnology.getSelectedItemPosition();
                String timestampFrom = jsonMan.returnDateStringFromAlert(timeFrom);
                String timestampTo = jsonMan.returnDateStringFromAlert(timeTo);
                getDetections((position[0]/1000000), (position[1]/1000000), technology, timestampFrom, timestampTo);
                //getDetections(14.810007, 48.1328671, 0, "2019-06-17T10:09:34Z", "2019-06-17T19:09:34Z");
                filterDialog.cancel();
            }
        });

        btnCancel = (Button) view.findViewById(R.id.btnCancel);
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                filterDialog.cancel();
            }
        });

        spnTechnology = (Spinner) view.findViewById(R.id.spnTechnology);
        String[] numberOfFrequencyElements = new String[] {
                "Unknown", "Google Nearby", "Prontoly", "Sonarax", "Signal 360", "Shopkick", "Silverpush", "Lisnr"
        };
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
                android.R.layout.simple_spinner_item, numberOfFrequencyElements);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spnTechnology.setAdapter(adapter);
        spnTechnology.setSelection(0);
    }

    public void getDetections(final double longitude, final double latitude, final int technologyid, final String timestampfrom, final String timestampto) {
        main.threadPool.execute(new Runnable() {

            JSONArray jArray;

            @Override
            public void run() {
                final SoniControlAPI restService = RESTController.getRetrofitInstance().create(SoniControlAPI.class);

                restService.importDetections(longitude, latitude, technologyid, timestampfrom, timestampto).enqueue(new Callback<ResponseBody>() {
                    @Override
                    public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                        //Log.d("StoredDetections", String.valueOf(response.body().contentLength()));

                        String detailsString = getStringFromRetrofitResponse(response.body());

                        try {
                            jArray = new JSONArray(detailsString);
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                        double[] position = new double[2];
                        String technology = null;
                        int spoof = -1;
                        String address = null;
                        String timestamp = null;
                        Location location = Location.getInstanceLoc();
                        GPSTracker gpsTracker = location.getGPSTracker();


                        Log.d("StoreDetections", ""+data.size());
                        for (int i = 0; i < jArray.length(); i++) {
                            try {
                                position[0] = jArray.getJSONObject(i).getJSONObject("location").getJSONArray("coordinates").getDouble(0);
                                position[1] = jArray.getJSONObject(i).getJSONObject("location").getJSONArray("coordinates").getDouble(1);
                                technology = jArray.getJSONObject(i).getString("technology");
                                address = gpsTracker.getAddressFromPoint(position[1], position[0], StoredLocations.this);
                                spoof = jArray.getJSONObject(i).getInt("spoofDecision");
                                timestamp = jArray.getJSONObject(i).getString("timestamp");
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                            if(position[0]!=0 && position[1]!=0 && spoof!=-1 && address!=null && timestamp!=null){
                                Log.d("StoreDetections", "one detection importaed");
                                jsonMan.addImportedJsonObject(position, technology, spoof, address, timestamp);
                            }
                        }
                        Log.d("StoreDetections", ""+data.size());
                        jArray = null;
                        data = jsonMan.getJsonData();
                        if(data.size()==0){
                            txtNothingDiscovered.setVisibility(View.VISIBLE);
                        }else {
                            txtNothingDiscovered.setVisibility(View.INVISIBLE);
                        }
                        lv.setAdapter(null);
                        stored_adapter = new Stored_Adapter(StoredLocations.this, data);
                        lv.setAdapter(stored_adapter);

                        /*if(response.isSuccessful()) {
                            Log.i("StoredDetections", "post submitted to API." + response.body().toString());
                        }*/
                    }

                    @Override
                    public void onFailure(Call<ResponseBody> call, Throwable t) {
                        Log.e("StoredDetections", "Unable to submit post to API." + t);
                    }
                });
            }
        });
    }

    public static String getStringFromRetrofitResponse(ResponseBody response) {
        BufferedReader reader = null;
        StringBuilder sb = new StringBuilder();

        reader = new BufferedReader(new InputStreamReader(response.byteStream()));

        String line;

        try {
            while ((line = reader.readLine()) != null) {
                sb.append(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return sb.toString();

    }

    public void openDateTimePicker(){
        final AlertDialog.Builder openDateTime = new AlertDialog.Builder(StoredLocations.this);
        openDateTime.setCancelable(true);
        LayoutInflater inflaterD = getLayoutInflater();
        final ViewGroup viewGroupD = (ViewGroup) findViewById(android.R.id.content);
        viewDateTime = inflaterD.inflate(R.layout.date_time_picker, viewGroupD , false);
        openDateTime.setView(viewDateTime);
        dateTimeDialog = openDateTime.create();

        btnDateTimeSet = (Button) viewDateTime.findViewById(R.id.btnDateTimeSet);
        datePicker = (DatePicker) viewDateTime.findViewById(R.id.date_picker);
        timePicker = (TimePicker) viewDateTime.findViewById(R.id.time_picker);
        timePicker.setIs24HourView(true);
    }

    public void openDateTimePickerFrom() {
        openDateTimePicker();
        btnDateTimeSet.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                //DatePicker datePicker = (DatePicker) dateTimeDialog.findViewById(R.id.date_picker);
                //TimePicker timePicker = (TimePicker) dateTimeDialog.findViewById(R.id.time_picker);
                //timePicker.setIs24HourView(true);

                Calendar calendar = new GregorianCalendar(datePicker.getYear(),
                        datePicker.getMonth(),
                        datePicker.getDayOfMonth(),
                        timePicker.getCurrentHour(),
                        timePicker.getCurrentMinute());

                timeFrom = calendar.getTimeInMillis();
                dateTimeDialog.dismiss();
                txtTimestampFrom.setText(jsonMan.returnDateStringFromAlert(timeFrom));
            }
        });
        dateTimeDialog.setView(viewDateTime);
        dateTimeDialog.show();
    }

    public void openDateTimePickerTo() {
        openDateTimePicker();
        btnDateTimeSet.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                //DatePicker datePicker = (DatePicker) dateTimeDialog.findViewById(R.id.date_picker);
                //TimePicker timePicker = (TimePicker) dateTimeDialog.findViewById(R.id.time_picker);
                //timePicker.setIs24HourView(true);

                Calendar calendar = new GregorianCalendar(datePicker.getYear(),
                        datePicker.getMonth(),
                        datePicker.getDayOfMonth(),
                        timePicker.getCurrentHour(),
                        timePicker.getCurrentMinute());

                timeTo = calendar.getTimeInMillis();
                dateTimeDialog.dismiss();
                txtTimestampTo.setText(jsonMan.returnDateStringFromAlert(timeTo));
            }
        });
        dateTimeDialog.setView(viewDateTime);
        dateTimeDialog.show();
    }

}
