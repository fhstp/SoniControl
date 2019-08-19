package at.ac.fhstp.sonicontrol.detetion_fragments;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.FloatingActionButton;
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

import at.ac.fhstp.sonicontrol.GPSTracker;
import at.ac.fhstp.sonicontrol.JSONManager;
import at.ac.fhstp.sonicontrol.Location;
import at.ac.fhstp.sonicontrol.MainActivity;
import at.ac.fhstp.sonicontrol.R;
import at.ac.fhstp.sonicontrol.StoredLocations;
import at.ac.fhstp.sonicontrol.Stored_Adapter;
import at.ac.fhstp.sonicontrol.rest.RESTController;
import at.ac.fhstp.sonicontrol.rest.SoniControlAPI;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MyRulesFragment extends Fragment {

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

    AlertDialog filterImportDialog;

    Button btnTimestampFrom;
    Button btnTimestampTo;
    Button btnImport;
    Button btnCancel;

    Button btnDateTimeSet;

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
        View rootView = inflater.inflate(R.layout.my_rules_fragment, container, false);
        Log.d("MyRulesFragment", "onCreateView");
        //super.onCreateView(savedInstanceState);
        //setContentView(R.layout.stored_locations);

        //loadFragment(new DetectionHistoryFragment());

        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);

        data = jsonMan.getJsonData();

        txtNothingDiscovered = (TextView) rootView.findViewById(R.id.txtNoDetectionsYet);
        /*fabImportDetections = (FloatingActionButton) rootView.findViewById(R.id.fabImportDetections);
        fabImportDetections.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //TODO: show Alert with filter decisions
                Log.d("StoredDetections", "Click");
                filterDialog.show();
                //getDetections(14.810007, 48.1328671, 0, "2019-06-17T10:09:34Z", "2019-06-17T19:09:34Z");
            }
        });*/

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


        //just change the fragment_dashboard
        //with the fragment you want to inflate
        //like if the class is HomeFragment it should have R.layout.home_fragment
        //if it is DashboardFragment it should have R.layout.fragment_dashboard
        return rootView;
    }

}
