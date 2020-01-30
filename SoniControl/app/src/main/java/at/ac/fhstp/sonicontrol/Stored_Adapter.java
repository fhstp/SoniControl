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

import android.content.Context;
import androidx.annotation.Nullable;
import androidx.annotation.NonNull;
//import android.support.annotation.NonNull;
//import android.support.annotation.Nullable;
import android.graphics.Bitmap;
import android.graphics.PorterDuff;
import android.graphics.Typeface;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;


import java.util.ArrayList;
import java.util.List;

public class Stored_Adapter extends ArrayAdapter<String[]>{

    public Stored_Adapter(@NonNull Context context, ArrayList<String[]> resource) {
        super(context, R.layout.row_item, resource);
    }

    public interface OnItemClickListener {
        void onAllowedClick(String[] singleArrayItem, int spoofingStatus);
        void onBlockedClick(String[] singleArrayItem, int spoofingStatus);
        void onAskAgainClick(String[] singleArrayItem, int spoofingStatus);
    }

    private List<OnItemClickListener> onItemClickListener = new ArrayList<>();

    public void addOnItemClickListener(OnItemClickListener listener) {
        this.onItemClickListener.add(listener);
    }

    public void notifyAllowedClick(String[] singleArrayItem, int spoofingStatus){
        for(OnItemClickListener listener: onItemClickListener) {
            listener.onAllowedClick(singleArrayItem, spoofingStatus);
        }
    }

    public void notifyBlockedClick(String[] singleArrayItem, int spoofingStatus){
        for(OnItemClickListener listener: onItemClickListener) {
            listener.onBlockedClick(singleArrayItem, spoofingStatus);
        }
    }

    public void notifyAskAgainClick(String[] singleArrayItem, int spoofingStatus){
        for(OnItemClickListener listener: onItemClickListener) {
            listener.onAskAgainClick(singleArrayItem, spoofingStatus);
        }
    }

    @NonNull
    @Override
    public View getView(final int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater storedInflater = LayoutInflater.from(getContext());

        View customView = storedInflater.inflate(R.layout.row_item,parent, false);

        final String[] singleArrayItem = getItem(position);

        //TextView txtLat = (TextView) customView.findViewById(R.id.latitude);
        //TextView txtLon = (TextView) customView.findViewById(R.id.longitude);
        TextView txtTech = (TextView) customView.findViewById(R.id.technologyName);
        TextView txtLastDet = (TextView) customView.findViewById(R.id.lastdetection);
        TextView txtAddress = (TextView) customView.findViewById(R.id.txtAddress);
        //TextView txtSpoofingStatus = (TextView) customView.findViewById(R.id.txtSpoofingStatus);
        TextView txtDetectionCounter = (TextView) customView.findViewById(R.id.txtDetectionCounter);
        Button btnAllowed = (Button) customView.findViewById(R.id.btnAllowed);
        Button btnBlocked = (Button) customView.findViewById(R.id.btnBlocked);
        Button btnAskAgain = (Button) customView.findViewById(R.id.btnAskAgain);

        if(Integer.valueOf(singleArrayItem[4])==1){
            btnAllowed.setTextColor(0xFF535353);
            btnAllowed.setTypeface(btnAllowed.getTypeface(),Typeface.NORMAL);
            btnAllowed.getCompoundDrawables()[0].setColorFilter(0xFF535353, PorterDuff.Mode.SRC_IN);
            btnBlocked.setTextColor(0xFFff0015);
            btnBlocked.setTypeface(btnBlocked.getTypeface(),Typeface.BOLD);
            btnBlocked.getCompoundDrawables()[0].setColorFilter(0xFFff0015, PorterDuff.Mode.SRC_IN);
            btnAskAgain.setTextColor(0xFF535353);
            btnAskAgain.setTypeface(btnAskAgain.getTypeface(),Typeface.NORMAL);
            btnAskAgain.getCompoundDrawables()[0].setColorFilter(0xFF535353, PorterDuff.Mode.SRC_IN);
        }else if(Integer.valueOf(singleArrayItem[4])==0){
            btnAllowed.setTextColor(0xFF00c200);
            btnAllowed.setTypeface(btnAllowed.getTypeface(),Typeface.BOLD);
            btnAllowed.getCompoundDrawables()[0].setColorFilter(0xFF00c200, PorterDuff.Mode.SRC_IN);
            btnBlocked.setTextColor(0xFF535353);
            btnBlocked.setTypeface(btnBlocked.getTypeface(),Typeface.NORMAL);
            btnBlocked.getCompoundDrawables()[0].setColorFilter(0xFF535353, PorterDuff.Mode.SRC_IN);
            btnAskAgain.setTextColor(0xFF535353);
            btnAskAgain.setTypeface(btnAskAgain.getTypeface(),Typeface.NORMAL);
            btnAskAgain.getCompoundDrawables()[0].setColorFilter(0xFF535353, PorterDuff.Mode.SRC_IN);
        }else if(Integer.valueOf(singleArrayItem[4])==4){
            btnAllowed.setTextColor(0xFF535353);
            btnAllowed.setTypeface(btnAllowed.getTypeface(),Typeface.NORMAL);
            btnAllowed.getCompoundDrawables()[0].setColorFilter(0xFF535353, PorterDuff.Mode.SRC_IN);
            btnBlocked.setTextColor(0xFF535353);
            btnBlocked.setTypeface(btnBlocked.getTypeface(),Typeface.NORMAL);
            btnBlocked.getCompoundDrawables()[0].setColorFilter(0xFF535353, PorterDuff.Mode.SRC_IN);
            btnAskAgain.setTextColor(0xFFe39b26);
            btnAskAgain.setTypeface(btnAskAgain.getTypeface(),Typeface.BOLD);
            btnAskAgain.getCompoundDrawables()[0].setColorFilter(0xFFe39b26, PorterDuff.Mode.SRC_IN);
        }

        btnAllowed.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d("Stored_Adapter", "btnAllowed");
                notifyAllowedClick(singleArrayItem, ConfigConstants.DETECTION_TYPE_ALWAYS_DISMISSED_HERE);
            }
        });
        btnBlocked.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d("Stored_Adapter", "btnBlocked");
                notifyBlockedClick(singleArrayItem, ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE);
            }
        });
        btnAskAgain.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d("Stored_Adapter", "btnAskAgain");
                notifyAskAgainClick(singleArrayItem, ConfigConstants.DETECTION_TYPE_ASK_AGAIN);
            }
        });

        //txtLon.setText("Lon " + singleArrayItem[0].substring(0, 7));
        //txtLat.setText("Lat " + singleArrayItem[1].substring(0, 7));
        txtTech.setText(singleArrayItem[2]);
        String formattedDate = singleArrayItem[3];
        formattedDate = formattedDate.replace("T"," ");
        formattedDate = formattedDate.replace("Z","");
        formattedDate = formattedDate.substring(0, 19);

        txtLastDet.setText(formattedDate);
        if(singleArrayItem[5].equals("Unknown")){
            String unknownAddress = getContext().getString(R.string.stored_adapter_unknown_address);
            txtAddress.setText(unknownAddress + " (Lat "+singleArrayItem[1].substring(0, 7)+", Lon "+ singleArrayItem[0].substring(0, 7)+")");
            //txtLat.setVisibility(View.GONE);
            //txtLon.setVisibility(View.GONE);
        }else{
            txtAddress.setText(singleArrayItem[5]);
        }
        txtDetectionCounter.setText(getContext().getString(R.string.stored_adapter_detection_counter_title)+singleArrayItem[8]);

        /*String spoofingStatus = null;
        if(Integer.valueOf(singleArrayItem[4])==1){
            spoofingStatus = getContext().getString(R.string.stored_detections_will_be_blocked);
            customView.setBackgroundColor(0xFFFF0015);
            //customView.setBackgroundColor(0xFFE39B26);
        }else if(Integer.valueOf(singleArrayItem[4])==0){
            spoofingStatus = getContext().getString(R.string.stored_detections_will_be_ignored);
            customView.setBackgroundColor(0xFF00C200);
            //customView.setBackgroundColor(0x00ffffff);
        }else if(Integer.valueOf(singleArrayItem[4])==4){
            spoofingStatus = getContext().getString(R.string.stored_detections_ask_again);
            customView.setBackgroundColor(0xFFE39B26);
        }*/
        //txtSpoofingStatus.setText(spoofingStatus);
        customView.setBackgroundColor(0x00ffffff);

        return customView;
    }
}
