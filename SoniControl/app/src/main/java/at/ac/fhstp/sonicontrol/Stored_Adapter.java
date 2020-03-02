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

package at.ac.fhstp.sonicontrol;

import android.content.Context;
import androidx.annotation.Nullable;
import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;
//import android.support.annotation.NonNull;
//import android.support.annotation.Nullable;
import android.graphics.Bitmap;
import android.graphics.Color;
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

        TextView txtTech = (TextView) customView.findViewById(R.id.technologyName);
        TextView txtLastDet = (TextView) customView.findViewById(R.id.lastdetection);
        TextView txtAddress = (TextView) customView.findViewById(R.id.txtAddress);
        TextView txtDetectionCounter = (TextView) customView.findViewById(R.id.txtDetectionCounter);
        Button btnAllowed = (Button) customView.findViewById(R.id.btnAllowed);
        Button btnBlocked = (Button) customView.findViewById(R.id.btnBlocked);
        Button btnAskAgain = (Button) customView.findViewById(R.id.btnAskAgain);

        if(Integer.valueOf(singleArrayItem[4])==1){
            changeUIonButtonBlockedClick(btnAllowed, btnBlocked, btnAskAgain, customView);
        }else if(Integer.valueOf(singleArrayItem[4])==0){
            changeUIonButtonAllowedClick(btnAllowed, btnBlocked, btnAskAgain, customView);
        }else if(Integer.valueOf(singleArrayItem[4])==4){
            changeUIonButtonAskAgainClick(btnAllowed, btnBlocked, btnAskAgain, customView);
        }

        btnAllowed.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                notifyAllowedClick(singleArrayItem, ConfigConstants.DETECTION_TYPE_ALWAYS_DISMISSED_HERE);
            }
        });
        btnBlocked.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                notifyBlockedClick(singleArrayItem, ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE);
            }
        });
        btnAskAgain.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                notifyAskAgainClick(singleArrayItem, ConfigConstants.DETECTION_TYPE_ASK_AGAIN);
            }
        });

        txtTech.setText(customView.getContext().getString(R.string.gui_technology) + " " + singleArrayItem[2]);
        String formattedDate = singleArrayItem[3];
        formattedDate = formattedDate.replace("T"," ");
        formattedDate = formattedDate.replace("Z","");
        formattedDate = formattedDate.substring(0, 19);

        txtLastDet.setText(formattedDate);
        if(DetectionAddressStateEnum.fromId(Integer.valueOf(singleArrayItem[10])).equals(DetectionAddressStateEnum.UNKNOWN)){
            String unknownAddress = getContext().getString(R.string.stored_adapter_unknown_address);
            txtAddress.setText(unknownAddress + " (Lat "+singleArrayItem[1].substring(0, 9)+", Lon "+ singleArrayItem[0].substring(0, 9)+")");
        }else{
            txtAddress.setText(singleArrayItem[5]);
        }
        txtDetectionCounter.setText(getContext().getString(R.string.stored_adapter_detection_counter_title) + " " + singleArrayItem[8]);

        return customView;
    }

    private void changeUIonButtonAllowedClick(Button btnAllowed, Button btnBlocked, Button btnAskAgain, View customView){
        int grey = ContextCompat.getColor(customView.getContext(), R.color.colorRuleItemGrey);
        int colorAllowed = ContextCompat.getColor(customView.getContext(), R.color.colorRuleItemAllowed);
        btnAllowed.setTextColor(colorAllowed);
        btnAllowed.setTypeface(btnAllowed.getTypeface(),Typeface.BOLD);
        btnAllowed.getCompoundDrawables()[0].setColorFilter(colorAllowed, PorterDuff.Mode.SRC_IN);
        btnBlocked.setTextColor(grey);
        btnBlocked.setTypeface(btnBlocked.getTypeface(),Typeface.NORMAL);
        btnBlocked.getCompoundDrawables()[0].setColorFilter(grey, PorterDuff.Mode.SRC_IN);
        btnAskAgain.setTextColor(grey);
        btnAskAgain.setTypeface(btnAskAgain.getTypeface(),Typeface.NORMAL);
        btnAskAgain.getCompoundDrawables()[0].setColorFilter(grey, PorterDuff.Mode.SRC_IN);
    }

    private void changeUIonButtonBlockedClick(Button btnAllowed, Button btnBlocked, Button btnAskAgain, View customView){
        int grey = ContextCompat.getColor(customView.getContext(), R.color.colorRuleItemGrey);
        int colorBlocked = ContextCompat.getColor(customView.getContext(), R.color.colorRuleItemBlocked);
        btnAllowed.setTextColor(grey);
        btnAllowed.setTypeface(btnAllowed.getTypeface(),Typeface.NORMAL);
        btnAllowed.getCompoundDrawables()[0].setColorFilter(grey, PorterDuff.Mode.SRC_IN);
        btnBlocked.setTextColor(colorBlocked);
        btnBlocked.setTypeface(btnBlocked.getTypeface(),Typeface.BOLD);
        btnBlocked.getCompoundDrawables()[0].setColorFilter(colorBlocked, PorterDuff.Mode.SRC_IN);
        btnAskAgain.setTextColor(grey);
        btnAskAgain.setTypeface(btnAskAgain.getTypeface(),Typeface.NORMAL);
        btnAskAgain.getCompoundDrawables()[0].setColorFilter(grey, PorterDuff.Mode.SRC_IN);
    }

    private void changeUIonButtonAskAgainClick(Button btnAllowed, Button btnBlocked, Button btnAskAgain, View customView){
        int grey = ContextCompat.getColor(customView.getContext(), R.color.colorRuleItemGrey);
        int colorAskAgain = ContextCompat.getColor(customView.getContext(), R.color.colorRuleItemAskAgain);
        btnAllowed.setTextColor(grey);
        btnAllowed.setTypeface(btnAllowed.getTypeface(),Typeface.NORMAL);
        btnAllowed.getCompoundDrawables()[0].setColorFilter(grey, PorterDuff.Mode.SRC_IN);
        btnBlocked.setTextColor(grey);
        btnBlocked.setTypeface(btnBlocked.getTypeface(),Typeface.NORMAL);
        btnBlocked.getCompoundDrawables()[0].setColorFilter(grey, PorterDuff.Mode.SRC_IN);
        btnAskAgain.setTextColor(colorAskAgain);
        btnAskAgain.setTypeface(btnAskAgain.getTypeface(),Typeface.BOLD);
        btnAskAgain.getCompoundDrawables()[0].setColorFilter(colorAskAgain, PorterDuff.Mode.SRC_IN);
    }
}
