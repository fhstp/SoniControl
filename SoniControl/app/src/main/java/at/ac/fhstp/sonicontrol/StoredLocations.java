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

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class StoredLocations extends BaseActivity {

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

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.stored_locations);

        nextMain = main.getMainIsMain();
        jsonMan = new JSONManager(nextMain);

        data = jsonMan.getJsonData();

        txtNothingDiscovered = (TextView) findViewById(R.id.txtNoDetectionsYet);

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



    }
}
