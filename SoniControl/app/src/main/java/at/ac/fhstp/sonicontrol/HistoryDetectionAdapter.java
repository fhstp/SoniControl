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
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
//import android.support.annotation.NonNull;
//import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

public class HistoryDetectionAdapter extends ArrayAdapter<String[]> {

    public HistoryDetectionAdapter(@NonNull Context context, ArrayList<String[]> resource) {
        super(context, R.layout.row_history_item, resource);
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater storedInflater = LayoutInflater.from(getContext());

        View customView = storedInflater.inflate(R.layout.row_history_item,parent, false);

        String[] singleArrayItem = getItem(position);

        TextView txtTech = (TextView) customView.findViewById(R.id.technologyName);
        TextView txtLastDet = (TextView) customView.findViewById(R.id.lastdetection);
        TextView txtAddress = (TextView) customView.findViewById(R.id.txtAddress);
        txtTech.setText(customView.getContext().getString(R.string.gui_technology) + " " + singleArrayItem[2]);
        String formattedDate = singleArrayItem[3];
        formattedDate = formattedDate.replace("T"," ");
        formattedDate = formattedDate.replace("Z","");

        txtLastDet.setText(formattedDate);
        if(DetectionAddressStateEnum.fromId(Integer.valueOf(singleArrayItem[10])).equals(DetectionAddressStateEnum.NOT_AVAILABLE)){
            txtAddress.setText(getContext().getString(R.string.rules_location_not_available));
        }else if(DetectionAddressStateEnum.fromId(Integer.valueOf(singleArrayItem[10])).equals(DetectionAddressStateEnum.UNKNOWN)){
            String unknownAddress = getContext().getString(R.string.stored_adapter_unknown_address);
            int latLength;
            int lonLength;
            if(singleArrayItem[1].length()<9){
                latLength = singleArrayItem[1].length();
            }else{
                latLength = 9;
            }
            if(singleArrayItem[0].length()<9){
                lonLength = singleArrayItem[0].length();
            }else{
                lonLength = 9;
            }
            if(latLength>=9||lonLength>=9) {
                txtAddress.setText(unknownAddress + " (Lat " + singleArrayItem[1].substring(0, 9) + ", Lon " + singleArrayItem[0].substring(0, 9) + ")");
            }else if(latLength<=lonLength){
                txtAddress.setText(unknownAddress + " (Lat " + singleArrayItem[1].substring(0, latLength) + ", Lon " + singleArrayItem[0].substring(0, latLength) + ")");
            }else{
                txtAddress.setText(unknownAddress + " (Lat " + singleArrayItem[1].substring(0, lonLength) + ", Lon " + singleArrayItem[0].substring(0, lonLength) + ")");
            }
        }else{
            txtAddress.setText(singleArrayItem[5]);
        }

        return customView;
    }
}
