package sonicontrol.testroutine;

import android.content.Context;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.graphics.Color;


import org.w3c.dom.Text;

import java.util.ArrayList;


public class Stored_Adapter extends ArrayAdapter<String[]>{






    Stored_Adapter(@NonNull Context context, ArrayList<String[]> resource) {
        super(context, R.layout.row_item, resource);

    }



    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater storedInflater = LayoutInflater.from(getContext());

        View customView = storedInflater.inflate(R.layout.row_item,parent, false);

        String[] singleArrayItem = getItem(position);
        TextView txtLat = (TextView) customView.findViewById(R.id.latitude);
        TextView txtLon = (TextView) customView.findViewById(R.id.longitude);
        TextView txtTech = (TextView) customView.findViewById(R.id.technologyName);
        TextView txtLastDet = (TextView) customView.findViewById(R.id.lastdetection);
        TextView txtAddress = (TextView) customView.findViewById(R.id.txtAddress);
        TextView txtSpoofingStatus = (TextView) customView.findViewById(R.id.txtSpoofingStatus);

        txtLon.setText(singleArrayItem[0]);
        txtLat.setText(singleArrayItem[1]);
        txtTech.setText(singleArrayItem[2]);
        String formattedDate = singleArrayItem[3];
        //StringBuilder dateBuild = new StringBuilder(formattedDate);
        //dateBuild.setCharAt(11,);
        formattedDate = formattedDate.replace("T"," ");
        formattedDate = formattedDate.replace("Z","");

        txtLastDet.setText(formattedDate);
        txtAddress.setText(singleArrayItem[5]);

        String spoofingStatus;
        if(Integer.valueOf(singleArrayItem[4])==1){
            spoofingStatus = "Will be spoofed!";
            customView.setBackgroundColor(0xFFE39B26);
        }else {
            spoofingStatus = "Will not be spoofed!";
            customView.setBackgroundColor(0x00ffffff);
        }
        txtSpoofingStatus.setText(spoofingStatus);

        //TODO FILL LIST WITH JSON ITEMS
        //ArrayList<String[]> stored_data = jm.getJsonData();

        //ArrayList<String[]> test = jm.getJsonData();

        //System.out.println(stored_data);




        return customView;
    }
}
