/*
 * Copyright (c) 2018, 2019, 2020. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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
    }


    @Override
    protected String[] doInBackground(Void... params) {
        if (System.currentTimeMillis() > (lastTextEdit.get())) {
            Location location = Location.getInstanceLoc();
            GPSTracker gpsTracker = location.getGPSTracker();
            String[] addresses = gpsTracker.getAddressListOfName(actPosition.getText().toString(), context);
            return addresses;
        }
        return null;
    }

    @Override
    protected void onPostExecute(String[] addresses) {
        if(addresses!=null) {
            actPosition.setAdapter(null);
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(context, android.R.layout.simple_dropdown_item_1line, addresses);
            actPosition.setAdapter(adapter);
            adapter.notifyDataSetChanged();
        }
    }
}