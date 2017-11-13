package sonicontrol.testroutine;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.preference.Preference;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import android.content.Intent;

import java.util.ArrayList;
import java.util.List;

public class StoredLocations extends AppCompatActivity {

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


    /*private StoredLocations(){
    }*/

    /*public static StoredLocations getInstance() { //getInstance method for Singleton pattern
        if(instanceStoredLoc == null) { //if no instance of Scan is there create a new one, otherwise return the existing
            instanceStoredLoc = new StoredLocations();
        }
        return instanceStoredLoc;
    }*/

    /*public void init(MainActivity main){
        this.main = main;
    }*/

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.stored_locations);

        //Intent i = getIntent();
        //main = (MainActivity) i.getSerializableExtra("json");
        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);

        data = jsonMan.getJsonData();
        /*for (String[] array : data){
            Log.d("StoredLocTest",array[1] + " " + array[2] + " " + array[3]);
        }


            String[] testArray ={"test", "toast", "yummie"};
*/
        //jsonMan = new JSONManager(main);

        lv = (ListView) findViewById(R.id.storedListView);
        lv.setAdapter(null);
        //ArrayAdapter<String>adapter=new ArrayAdapter<>(this,android.R.layout.simple_list_item_1, testArray);
        final Context listContext = this;
        stored_adapter = new Stored_Adapter(this, data);


        final AlertDialog.Builder deleteJsonDialog = new AlertDialog.Builder(StoredLocations.this);
        deleteJsonDialog.setTitle("Delete Location-Entry")
                .setMessage("Are you sure you want to delete the Location-Entry?")
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


        //lv.setAdapter(adapter);

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



    }




}
