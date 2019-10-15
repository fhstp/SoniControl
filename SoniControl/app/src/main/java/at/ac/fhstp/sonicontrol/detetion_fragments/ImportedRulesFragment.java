package at.ac.fhstp.sonicontrol.detetion_fragments;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
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

import at.ac.fhstp.sonicontrol.ConfigConstants;
import at.ac.fhstp.sonicontrol.GPSTracker;
import at.ac.fhstp.sonicontrol.JSONManager;
import at.ac.fhstp.sonicontrol.Location;
import at.ac.fhstp.sonicontrol.MainActivity;
import at.ac.fhstp.sonicontrol.R;
import at.ac.fhstp.sonicontrol.StoredLocations;
import at.ac.fhstp.sonicontrol.Stored_Adapter;
import at.ac.fhstp.sonicontrol.Technology;
import at.ac.fhstp.sonicontrol.rest.RESTController;
import at.ac.fhstp.sonicontrol.rest.SoniControlAPI;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ImportedRulesFragment extends Fragment {
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

    View rootView;
    AlertDialog filterDialog;
    View view;
    AlertDialog dateTimeDialog;
    View viewDateTime;

    AlertDialog filterImportDialog;

    Button btnTimestampFrom;
    Button btnTimestampTo;
    Button btnImport;
    Button btnCancel;

    Button btnDateTimeSet;
    Button btnDateTimeCancel;

    ImageButton btnResetTimestampFrom;
    ImageButton btnResetTimestampTo;

    EditText edtLocation;
    EditText edtRange;
    Spinner spnTechnology;

    TextView txtTimestampFrom;
    TextView txtTimestampTo;

    Long timeFrom;
    Long timeTo;
    DatePicker datePicker;
    TimePicker timePicker;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        rootView = inflater.inflate(R.layout.imported_rules_fragment, null);
        Log.d("MyRulesFragment", "onCreateView");
        //super.onCreateView(savedInstanceState);
        //setContentView(R.layout.stored_locations);

        //loadFragment(new DetectionHistoryFragment());

        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);

        data = jsonMan.getImportJsonData();

        txtNothingDiscovered = (TextView) rootView.findViewById(R.id.txtNoDetectionsYet);
        fabImportDetections = (FloatingActionButton) rootView.findViewById(R.id.fabImportDetections);
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

        lv = (ListView) rootView.findViewById(R.id.storedListView);
        lv.setAdapter(null);
        final Context listContext = getActivity();
        stored_adapter = new Stored_Adapter(getActivity(), data);


        final AlertDialog.Builder deleteJsonDialog = new AlertDialog.Builder(getActivity());
        deleteJsonDialog.setTitle(R.string.DeleteJsonAlertTitle)
                .setMessage(R.string.DeleteJsonAlertMessage)
                .setCancelable(false)
                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        String[] singleArrayItem = (String[]) parentLongClick.getItemAtPosition(positionLongClick);
                        double[] positionSignal = new double[2];
                        positionSignal[0] = Double.valueOf(singleArrayItem[0]);
                        positionSignal[1] = Double.valueOf(singleArrayItem[1]);
                        jsonMan.deleteImportEntry(positionSignal,singleArrayItem[2]);
                        jsonMan = new JSONManager(nextMain);
                        data = jsonMan.getImportJsonData();
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
                        jsonMan.setShouldBeSpoofedInImportedLoc(positionSignal,singleArrayItem[2], Integer.valueOf(singleArrayItem[4]));
                        jsonMan = new JSONManager(nextMain);
                        data = jsonMan.getImportJsonData();
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


        final AlertDialog.Builder openFilter = new AlertDialog.Builder(getActivity());
        openFilter.setCancelable(false);
        LayoutInflater inflaterImport = getLayoutInflater();
        final ViewGroup viewGroup = (ViewGroup) rootView.findViewById(android.R.id.content);
        view = inflaterImport.inflate(R.layout.detection_import_filter, viewGroup , false);
        openFilter.setView(view);
        filterDialog = openFilter.create();

        txtTimestampFrom = (TextView) view.findViewById(R.id.txtTimestampFrom);
        txtTimestampTo = (TextView) view.findViewById(R.id.txtTimestampTo);
        edtLocation = (EditText) view.findViewById(R.id.edtLocation);
        edtRange = (EditText) view.findViewById(R.id.edtRange);

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

        btnResetTimestampFrom = (ImageButton) view.findViewById(R.id.btnResetTimestampFrom);
        btnResetTimestampFrom.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                txtTimestampFrom.setText("");
                timeFrom = null;
            }
        });
        btnResetTimestampTo = (ImageButton) view.findViewById(R.id.btnResetTimestampTo);
        btnResetTimestampTo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                txtTimestampTo.setText("");
                timeTo = null;
            }
        });

        btnImport = (Button) view.findViewById(R.id.btnImport);
        btnImport.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                double[] position = new double[2];
                int range = 0;
                int technology;
                String timestampFrom = null;
                String timestampTo = null;
                Location location = Location.getInstanceLoc();
                GPSTracker gpsTracker = location.getGPSTracker();
                if(!edtLocation.getText().toString().matches("")){
                    position = gpsTracker.getLocationFromAddress(edtLocation.getText().toString(), getActivity());
                    Log.d("StoredDetections", (position[0]/1000000) + " " + (position[1]/1000000));
                }else{
                    position[0] = ConfigConstants.NO_VALUES_ENTERED;
                    position[1] = ConfigConstants.NO_VALUES_ENTERED;
                }
                if(!edtRange.getText().toString().matches("")){
                    range = Integer.valueOf(edtRange.getText().toString());
                }else{
                    range = ConfigConstants.NO_VALUES_ENTERED;
                }
                //technology = spnTechnology.getSelectedItemPosition();
                if(spnTechnology.getSelectedItem().toString().equals("All")){
                    technology = ConfigConstants.ALL_TECHNOLOGIES;
                }else{
                    technology = Technology.fromString(spnTechnology.getSelectedItem().toString()).getId();
                }

                if(jsonMan.returnDateStringFromAlert(timeFrom) != null){
                    Log.d("returnDataStringFrom", jsonMan.returnDateStringFromAlert(timeFrom));
                    timestampFrom = jsonMan.returnDateStringFromAlert(timeFrom);
                }
                if(jsonMan.returnDateStringFromAlert(timeTo) != null){
                    Log.d("returnDataStringTo", jsonMan.returnDateStringFromAlert(timeTo));
                    timestampTo = jsonMan.returnDateStringFromAlert(timeTo);
                }
                if(!edtLocation.getText().toString().matches("")) {
                    getNumberOfDetections((position[0] / 1000000), (position[1] / 1000000), range, technology, timestampFrom, timestampTo);
                }else{
                    getNumberOfDetections(position[0], position[1], range, technology, timestampFrom, timestampTo);
                }
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
                "All", Technology.UNKNOWN.toString(), Technology.GOOGLE_NEARBY.toString(), Technology.PRONTOLY.toString(), Technology.SONARAX.toString(), Technology.SIGNAL360.toString(),
                    Technology.SHOPKICK.toString(), Technology.SILVERPUSH.toString(), Technology.LISNR.toString(), Technology.SONITALK.toString()
                //"Unknown", "Google Nearby", "Prontoly", "Sonarax", "Signal 360", "Shopkick", "Silverpush", "Lisnr", "SoniTalk"
        };
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(),
                android.R.layout.simple_spinner_item, numberOfFrequencyElements);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spnTechnology.setAdapter(adapter);
        spnTechnology.setSelection(0);
        //just change the fragment_dashboard
        //with the fragment you want to inflate
        //like if the class is HomeFragment it should have R.layout.home_fragment
        //if it is DashboardFragment it should have R.layout.fragment_dashboard
        return rootView;
    }

    public void getDetections(final double longitude, final double latitude, final int range, final int technologyid, final String timestampfrom, final String timestampto) {
        main.threadPool.execute(new Runnable() {

            JSONArray jArray;

            @Override
            public void run() {
                final SoniControlAPI restService = RESTController.getRetrofitInstance().create(SoniControlAPI.class);

                restService.importDetections(longitude, latitude, range, technologyid, timestampfrom, timestampto).enqueue(new Callback<ResponseBody>() {
                    @Override
                    public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                        String detailsString = getStringFromRetrofitResponse(response.body());
                        Log.d("StoredDetections", detailsString);
                        //detailsString = detailsString.substring(1, detailsString.length()-1);
                        //Log.d("StoredDetections", detailsString);
                        try {
                            //JSONObject jsonObject = new JSONObject(detailsString);
                            //Log.d("StoredDetections", String.valueOf(jsonObject/*.getJSONObject("detection")*/));
                            jArray = new JSONArray(detailsString);
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                        double[] position = new double[2];
                        String technology = null;
                        int spoof = -1;
                        String address = null;
                        String timestamp = null;
                        int technologyid = -1;
                        Location location = Location.getInstanceLoc();
                        GPSTracker gpsTracker = location.getGPSTracker();

                        Log.d("StoreDetections", ""+data.size());
                        for (int i = 0; i < jArray.length(); i++) {
                            try {
                                position[0] = jArray.getJSONObject(i).getJSONObject("detection").getJSONObject("location").getJSONArray("coordinates").getDouble(0);
                                position[1] = jArray.getJSONObject(i).getJSONObject("detection").getJSONObject("location").getJSONArray("coordinates").getDouble(1);
                                technology = jArray.getJSONObject(i).getJSONObject("detection").getString("technology");
                                address = gpsTracker.getAddressFromPoint(position[1], position[0], getActivity());
                                spoof = jArray.getJSONObject(i).getJSONObject("detection").getInt("spoofDecision");
                                timestamp = jArray.getJSONObject(i).getJSONObject("detection").getString("timestamp");
                                technologyid = jArray.getJSONObject(i).getJSONObject("detection").getInt("technologyid");
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                            if(position[0]!=0 && position[1]!=0 && spoof!=-1 && address!=null && timestamp!=null){
                                Log.d("StoreDetections", "one detection importaed");
                                jsonMan.addImportedJsonObject(position, technology, spoof, address, timestamp, technologyid);
                            }
                        }
                        Log.d("StoreDetections", ""+data.size());
                        jArray = null;
                        data = jsonMan.getImportJsonData();
                        if(data.size()==0){
                            txtNothingDiscovered.setVisibility(View.VISIBLE);
                        }else {
                            txtNothingDiscovered.setVisibility(View.INVISIBLE);
                        }
                        lv.setAdapter(null);
                        stored_adapter = new Stored_Adapter(getActivity(), data);
                        lv.setAdapter(stored_adapter);

                    /*if(response.isSuccessful()) {
                        Log.i("StoredDetections", "post submitted to API." + response.body().toString());
                    }*/
                    }

                    @Override
                    public void onFailure(Call<ResponseBody> call, Throwable t) {
                        Log.e("StoredDetections", "Unable to submit post to API." + t);
                        Snackbar importSnackbar = Snackbar.make(rootView, R.string.import_filtered_detections_failure_snackbar,
                                Snackbar.LENGTH_INDEFINITE)
                                .setAction("OK", new View.OnClickListener() {
                                    @Override
                                    public void onClick(View view) {
                                    }
                                });
                        View importSnackbarView = importSnackbar.getView();
                        TextView importSnackbarTextView = (TextView) importSnackbarView.findViewById(android.support.design.R.id.snackbar_text);
                        importSnackbarTextView.setMaxLines(4);
                        importSnackbar.show();
                    }
                });
            }
        });
    }
    public void getNumberOfDetections(final double longitude, final double latitude, final int range, final int technologyid, final String timestampfrom, final String timestampto) {
        main.threadPool.execute(new Runnable() {
            JSONArray jArray;
            int numberOfFiles;

            @Override
            public void run() {
                final SoniControlAPI restService = RESTController.getRetrofitInstance().create(SoniControlAPI.class);

                restService.getNumberOfImportDetections(longitude, latitude, range, technologyid, timestampfrom, timestampto).enqueue(new Callback<ResponseBody>() {

                    @Override
                    public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                        String detailsString = getStringFromRetrofitResponse(response.body());

                        numberOfFiles = Integer.valueOf(detailsString);
                        openImportDialogWithCount(numberOfFiles, longitude, latitude, range, technologyid, timestampfrom, timestampto);
                        Log.d("StoredDetections", String.valueOf(numberOfFiles));
                    }

                    @Override
                    public void onFailure(Call<ResponseBody> call, Throwable t) {
                        Log.e("StoredDetections", "Unable to get numberOfDetections." + t);
                        Snackbar importSnackbar = Snackbar.make(rootView, R.string.import_filtered_detections_failure_snackbar,
                                Snackbar.LENGTH_INDEFINITE)
                                .setAction("OK", new View.OnClickListener() {
                                    @Override
                                    public void onClick(View view) {
                                    }
                                });
                        View importSnackbarView = importSnackbar.getView();
                        TextView importSnackbarTextView = (TextView) importSnackbarView.findViewById(android.support.design.R.id.snackbar_text);
                        importSnackbarTextView.setMaxLines(4);
                        importSnackbar.show();
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
        final AlertDialog.Builder openDateTime = new AlertDialog.Builder(getActivity());
        openDateTime.setCancelable(true);
        LayoutInflater inflaterD = getLayoutInflater();
        final ViewGroup viewGroupD = (ViewGroup) getView().findViewById(android.R.id.content);
        viewDateTime = inflaterD.inflate(R.layout.date_time_picker, viewGroupD , false);
        openDateTime.setView(viewDateTime);
        dateTimeDialog = openDateTime.create();

        btnDateTimeSet = (Button) viewDateTime.findViewById(R.id.btnDateTimeSet);
        btnDateTimeCancel = (Button) viewDateTime.findViewById(R.id.btnDateTimeCancel);
        datePicker = (DatePicker) viewDateTime.findViewById(R.id.date_picker);
        //timePicker = (TimePicker) viewDateTime.findViewById(R.id.time_picker);
        //timePicker.setIs24HourView(true);
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
                        datePicker.getDayOfMonth()
                        //timePicker.getCurrentHour(),
                        //timePicker.getCurrentMinute()
                        );

                timeFrom = calendar.getTimeInMillis();
                dateTimeDialog.dismiss();
                txtTimestampFrom.setText(jsonMan.returnDateStringFromAlert(timeFrom));
            }
        });

        btnDateTimeCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dateTimeDialog.cancel();
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
                        datePicker.getDayOfMonth()
                        //timePicker.getCurrentHour(),
                        //timePicker.getCurrentMinute()
                );

                timeTo = calendar.getTimeInMillis();
                dateTimeDialog.dismiss();
                txtTimestampTo.setText(jsonMan.returnDateStringFromAlert(timeTo));
            }
        });
        dateTimeDialog.setView(viewDateTime);
        dateTimeDialog.show();
    }

    private void openImportDialogWithCount(int count, final double longitude, final double latitude, final int range, final int technologyid, final String timestampfrom, final String timestampto){
        final AlertDialog.Builder filterImport = new AlertDialog.Builder(getActivity());
        filterImport.setTitle("Do you want to import?")
                .setMessage(String.format("The filter resulted in %s Detections.", String.valueOf(count)))
                .setCancelable(false)
                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        getDetections(longitude, latitude, range, technologyid, timestampfrom, timestampto);
                    }
                })
                .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        filterImportDialog.cancel();
                    }
                })
                .setIcon(android.R.drawable.ic_dialog_alert);
        filterImportDialog = filterImport.show();
    }
}
