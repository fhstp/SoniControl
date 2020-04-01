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
    JSONManager jsonMan;
    ArrayList<String[]> data;
    Stored_Adapter stored_adapter;
    ListView lv;
    MainActivity nextMain;
    AlertDialog alertDelete = null;

    AdapterView<?> parentLongClick;
    int positionLongClick;

    TextView txtNothingDiscovered;
    MyRulesFragment localContext;


    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.my_rules_fragment, container, false);

        nextMain = main.getMainIsMain();
        jsonMan = JSONManager.getInstanceJSONManager();

        data = jsonMan.getJsonData();

        localContext = this;

        txtNothingDiscovered = (TextView) rootView.findViewById(R.id.txtNoDetectionsYet);

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
                        jsonMan = JSONManager.getInstanceJSONManager();
                        if(data.size()==0){
                            txtNothingDiscovered.setVisibility(View.VISIBLE);
                        }else {
                            txtNothingDiscovered.setVisibility(View.INVISIBLE);
                        }

                        data.remove(positionLongClick);
                        jsonMan.deleteEntryInStoredLoc(positionSignal,singleArrayItem[2]);

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
        changeRuleItem(singleArrayItem, spoofingStatus);
    }

    @Override
    public void onBlockedClick(String[] singleArrayItem, int spoofingStatus) {
        changeRuleItem(singleArrayItem, spoofingStatus);
    }

    @Override
    public void onAskAgainClick(String[] singleArrayItem, int spoofingStatus) {
        changeRuleItem(singleArrayItem, spoofingStatus);
    }

    private void changeRuleItem(String[] singleArrayItem, int spoofingStatus){
        double[] positionSignal = new double[2];
        positionSignal[0] = Double.valueOf(singleArrayItem[0]);
        positionSignal[1] = Double.valueOf(singleArrayItem[1]);
        jsonMan.setShouldBeSpoofedInStoredLoc(positionSignal,singleArrayItem[2], spoofingStatus);
        jsonMan = JSONManager.getInstanceJSONManager();//new JSONManager(nextMain);
        for(String[] listitem : data){
            if(positionSignal[0] == Double.valueOf(listitem[0]) && positionSignal[1] == Double.valueOf(listitem[1]) && singleArrayItem[2].equals(listitem[2])){
                listitem[4] = String.valueOf(spoofingStatus);
            }
        }
        stored_adapter.notifyDataSetChanged();
    }
}
