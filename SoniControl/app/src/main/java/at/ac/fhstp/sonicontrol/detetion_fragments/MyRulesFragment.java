package at.ac.fhstp.sonicontrol.detetion_fragments;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import androidx.annotation.Nullable;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import androidx.fragment.app.Fragment;
//import android.support.annotation.Nullable;
//import android.support.design.widget.FloatingActionButton;
//import androidx.core.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;

import java.util.ArrayList;

import at.ac.fhstp.sonicontrol.JSONManager;
import at.ac.fhstp.sonicontrol.MainActivity;
import at.ac.fhstp.sonicontrol.R;
import at.ac.fhstp.sonicontrol.StoredLocations;
import at.ac.fhstp.sonicontrol.Stored_Adapter;

public class MyRulesFragment extends Fragment implements Stored_Adapter.OnItemClickListener{

    MainActivity main = new MainActivity();
    private static StoredLocations instanceStoredLoc;
    JSONManager jsonMan;
    ArrayList<String[]> data;
    Stored_Adapter stored_adapter;
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
    MyRulesFragment localContext;


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

        localContext = this;

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
        stored_adapter.addOnItemClickListener(localContext);


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
                        jsonMan = new JSONManager(nextMain);
                        //data = jsonMan.getJsonData();
                        if(data.size()==0){
                            txtNothingDiscovered.setVisibility(View.VISIBLE);
                        }else {
                            txtNothingDiscovered.setVisibility(View.INVISIBLE);
                        }
                        /*lv.setAdapter(null);
                        stored_adapter = new Stored_Adapter(listContext, data);
                        stored_adapter.addOnItemClickListener(localContext);
                        lv.setAdapter(stored_adapter);*/
                        //for(String[] listitem : data){
                        //    if(positionSignal[0] == Double.valueOf(listitem[0]) && positionSignal[1] == Double.valueOf(listitem[1]) && singleArrayItem[2].equals(listitem[2])){
                        data.remove(positionLongClick);
                        jsonMan.deleteEntryInStoredLoc(positionSignal,singleArrayItem[2]);
                        //    }
                        //}
                        stored_adapter.notifyDataSetChanged();
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

                        Log.d("MyRulesFragment", "onItemClick");
                        /*String[] singleArrayItem = (String[]) parent.getItemAtPosition(position);
                        double[] positionSignal = new double[2];
                        positionSignal[0] = Double.valueOf(singleArrayItem[0]);
                        positionSignal[1] = Double.valueOf(singleArrayItem[1]);
                        jsonMan.setShouldBeSpoofedInStoredLoc(positionSignal,singleArrayItem[2], Integer.valueOf(singleArrayItem[4]));
                        jsonMan = new JSONManager(nextMain);
                        data = jsonMan.getJsonData();
                        lv.setAdapter(null);
                        stored_adapter = new Stored_Adapter(listContext, data);
                        stored_adapter.addOnItemClickListener(localContext);
                        lv.setAdapter(stored_adapter);*/

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

    @Override
    public void onAllowedClick(String[] singleArrayItem, int spoofingStatus) {
        Log.d("MyRulesFragment", "onAllowedClick");
        changeRuleItem(singleArrayItem, spoofingStatus);
    }

    @Override
    public void onBlockedClick(String[] singleArrayItem, int spoofingStatus) {
        Log.d("MyRulesFragment", "onBlockedClick");
        changeRuleItem(singleArrayItem, spoofingStatus);
    }

    @Override
    public void onAskAgainClick(String[] singleArrayItem, int spoofingStatus) {
        Log.d("MyRulesFragment", "onAskAgainClick");
        changeRuleItem(singleArrayItem, spoofingStatus);
    }

    private void changeRuleItem(String[] singleArrayItem, int spoofingStatus){
        double[] positionSignal = new double[2];
        positionSignal[0] = Double.valueOf(singleArrayItem[0]);
        positionSignal[1] = Double.valueOf(singleArrayItem[1]);
        Log.d("MyRulesFragment", "changeRuleItem "+ spoofingStatus);
        jsonMan.setShouldBeSpoofedInStoredLoc(positionSignal,singleArrayItem[2], spoofingStatus);
        jsonMan = new JSONManager(nextMain);
        for(String[] listitem : data){
            if(positionSignal[0] == Double.valueOf(listitem[0]) && positionSignal[1] == Double.valueOf(listitem[1]) && singleArrayItem[2].equals(listitem[2])){
                Log.d("MyRulesFragment", "found listitem");
                listitem[4] = String.valueOf(spoofingStatus);
            }
        }
        stored_adapter.notifyDataSetChanged();
        //data = jsonMan.getJsonData();
        //lv.setAdapter(null);
        //stored_adapter = new Stored_Adapter(localContext.getContext(), data);
        //stored_adapter.addOnItemClickListener(localContext);
        //lv.setAdapter(stored_adapter);
    }
}
