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

import android.content.SharedPreferences;
import android.util.Log;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class JSONManager {

    MainActivity main;
    private Scan detector;
    private Location locationFinder;
    ArrayList<String[]> data = new ArrayList<String[]>();

    private File fileDir;

    private static final String JSON_LIST_NAME = "items";
    private static final String JSON_ARRAY_SIGNALS = "signal";
    private static final String JSON_ARRAY_DISMISSED_SIGNALS = "signalDismissedThisTime";
    private static final String JSON_ARRAY_UNKNOWN_SIGNALS = "signalUnknownPosition";
    private static final String JSON_ARRAY_SIGNAL_LONGITUDE = "long";
    private static final String JSON_ARRAY_SIGNAL_LATITUDE = "lat";
    private static final String JSON_ARRAY_SIGNAL_TECHNOLOGY = "technology";
    private static final String JSON_ARRAY_SIGNAL_LAST_DETECTION = "last_detection";
    private static final String JSON_ARRAY_SIGNAL_SPOOFING_STATUS = "spoof";
    private static final String JSON_ARRAY_SIGNAL_ADDRESS = "address";
    private static final String JSON_ARRAY_SIGNAL_URL = "URL";


    public JSONManager(MainActivity main){
        this.main = main;
        this.fileDir = main.getFilesDir();
    }

    public ArrayList<String[]> getJsonData(){
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        //Log.d("Text Data", byteArrayOutputStream.toString());

        JSONObject jObject = null; //new json-object with the outputstream
        JSONArray jArray =null;
        try {
            jObject = new JSONObject(byteArrayOutputStream.toString());
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            jArray = jObjectResult.getJSONArray(JSON_ARRAY_SIGNALS); //get the jsonarray with the signals
        } catch (JSONException e) {
            e.printStackTrace();
        }
        if (jArray != null) {
            String lon = ""; //longitude
            String lat = ""; //latidude
            String tech = ""; //technology
            String lastDet = ""; //last Detection
            String spoof = ""; //spoofinStatus
            String address = ""; //addressLine
            String url = ""; //fileUrl
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                try {
                    lon = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LONGITUDE); //save longitude
                    lat = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LATITUDE); //save latitude
                    tech = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_TECHNOLOGY); //save technology
                    lastDet = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LAST_DETECTION); //save spoofingStatus
                    spoof = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_SPOOFING_STATUS); //save spoofingStatus
                    address = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_ADDRESS); //save spoofingStatus
                    url = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_URL); //save fileUrl
                    //Log.d("Longitude", lon);
                    //Log.d("Latitude", lat);
                    //Log.d("Technology", tech);
                    data.add(new String[]{lon, lat, tech, lastDet, spoof, address, url}); //add every data of one array-index in the data-list
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        }
        return data;
    }

    public void addJsonObject(double[] position, String technology, int spoof, String address){
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray;
            if(position[0]==0&&position[1]==0) {
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_UNKNOWN_SIGNALS);
                //if(spoof==2){
                spoof=ConfigConstants.DETECTION_TYPE_THIS_TIME;
                //}
            }else if(spoof==ConfigConstants.DETECTION_TYPE_THIS_TIME){
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_DISMISSED_SIGNALS);
                //spoof=0;
            }else{
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_SIGNALS); //get the jsonarray with the signals
            }

            JSONObject addArray = new JSONObject(); //new json-object

            addArray.put(JSON_ARRAY_SIGNAL_LONGITUDE, position[0]); //add the longitude to the new object
            addArray.put(JSON_ARRAY_SIGNAL_LATITUDE, position[1]); //add the latitude to the new object
            addArray.put(JSON_ARRAY_SIGNAL_TECHNOLOGY, technology); //add the technology to the new object
            addArray.put(JSON_ARRAY_SIGNAL_LAST_DETECTION, returnDateString()); //add the last_detection to the new object
            addArray.put(JSON_ARRAY_SIGNAL_SPOOFING_STATUS, spoof); //add the spoofing status to the new object
            addArray.put(JSON_ARRAY_SIGNAL_ADDRESS, address); //add the addressline of the found signal
            detector = Scan.getInstance(); //get an instance of the scan
            String fileUrl = detector.getDetectedFileUrl(); //get the url from the scan
            addArray.put(JSON_ARRAY_SIGNAL_URL, ""); //add the url to the new object

            jArray.put(addArray); //add the created object to the json array

            try {
                FileWriter file = new FileWriter(new File(this.fileDir, ConfigConstants.JSON_FILENAME)); //get the json file
                //Log.d("TryJsonSave", "I am saved");
                file.write( jObject.toString() ); //write the new entry into the file
                file.flush();
                file.close();

            } catch (IOException e) {
                e.printStackTrace();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void createJsonFile(){
        JSONObject jObject = new JSONObject(); //create a new json-object
        JSONObject jsObject = new JSONObject(); //create a second json-object
        JSONArray jArray = new JSONArray(); //create a json-array

        try {
            jObject.put(JSON_LIST_NAME, jsObject); //put the second json-object into the first with JSON_LIST_NAME
            jsObject.put(JSON_ARRAY_SIGNALS, jArray); //put the json-array into the second json-object with "signal"
            jsObject.put(JSON_ARRAY_UNKNOWN_SIGNALS, jArray); //put the json-array into the second json-object with "signal"
            jsObject.put(JSON_ARRAY_DISMISSED_SIGNALS, jArray); //put the json-array into the second json-object with "signal"

        }catch (JSONException ext) {
            ext.printStackTrace();
        }
        try {
            FileWriter file = new FileWriter(new File(this.fileDir, ConfigConstants.JSON_FILENAME)); //write the newly created json-object into the new json file
            file.write( jObject.toString() );
            file.flush();
            file.close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void deleteJsonFile(){
        File file = new File(this.fileDir, ConfigConstants.JSON_FILENAME);
        file.delete();
        deleteWaveFilesInDirectory();
    }

    public void deleteWaveFilesInDirectory(){
        File fileOrDirectory = new File(this.fileDir +ConfigConstants.DIR_NAME_SAVED_RECORDINGS);
        if (fileOrDirectory.isDirectory())
            for (File child : fileOrDirectory.listFiles())
                deleteWaveFilesInDirectory(child);

        fileOrDirectory.delete();
    }

    public void deleteWaveFilesInDirectory(File fileOrDirectory){
        if (fileOrDirectory.isDirectory())
            for (File child : fileOrDirectory.listFiles())
                deleteWaveFilesInDirectory(child);

        fileOrDirectory.delete();
    }

    public boolean checkIfJsonFileIsAvailable(){
        File file = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //"make" a new file where the file normally should be
        if(file.exists()){ //if it exists
            //Log.d("Filecheck","The file is here");
            return true;
        }else{
           // Log.d("Filecheck","here is no file");
            return false;
        }
    }

    public boolean checkIfSavefolderIsAvailable(){
        File file = new File(this.fileDir + ConfigConstants.DIR_NAME_SAVED_RECORDINGS); //get the folder for the audio files
        if(file.isDirectory()){ //if directory is available
            return true;
        }else{
            return false;
        }
    }

    public void createSaveFolder() {
        File file = new File(this.fileDir +ConfigConstants.DIR_NAME_SAVED_RECORDINGS); //create a new folder for the audio files
        file.mkdir(); //save the folder
    }

    public String returnDateString(){
        Long currentTime = Calendar.getInstance().getTimeInMillis(); //get the current time in milliseconds
        //SimpleDateFormat rightFormat = new SimpleDateFormat("HH:mm:ss.SSS"); //get the time formatted old with milliseconds
        SimpleDateFormat rightFormat = new SimpleDateFormat("HH:mm:ss"); //get the time formatted
        SimpleDateFormat leftFormat = new SimpleDateFormat("yyyy-MM-dd"); //get the date formatted
        String dateLeft = String.valueOf(leftFormat.format(currentTime));
        String dateRight = String.valueOf(rightFormat.format(currentTime));
        String dateString = dateLeft + "T" + dateRight + "Z";
        return dateString;
    }


    public void setLatestDate(double[] position, Technology signalType){
        locationFinder = Location.getInstanceLoc();
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);
        //Log.d("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray(JSON_ARRAY_SIGNALS); //get the jsonarray with the signals
            String lon = ""; //longitude
            String lat = ""; //latitude
            String tech = ""; //technology
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LONGITUDE); //save longitude
                lat = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LATITUDE); //save latitude
                tech = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_TECHNOLOGY); //save technology

                double[] positionDBEntry = new double[2];
                positionDBEntry[0] = Double.valueOf(lon);
                positionDBEntry[1] = Double.valueOf(lat);
                double distance = locationFinder.getDistanceInMetres(positionDBEntry, position);
                SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                locationFinder.locationRadius = Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_LOCATION_RADIUS, ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT)); //save the radius of the location in metres
                if (distance < locationFinder.locationRadius && tech.equals(signalType.toString())) { //if in the location and the right technologytype
                    jArray.getJSONObject(i).put(JSON_ARRAY_SIGNAL_LAST_DETECTION, returnDateString()); //change latest detection date
                }
            }
            try {
                FileWriter file = new FileWriter(new File(this.fileDir, ConfigConstants.JSON_FILENAME)); //write the newly created json-object into the new json file
                //Log.d("TryJsonSave", "I am saved");
                file.write( jObject.toString() );
                file.flush();
                file.close();

            } catch (IOException e) {
                e.printStackTrace();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void setShouldBeSpoofedInStoredLoc(double[] position, String signalType, int spoofStatus) {
        int shouldBeSpoofed = spoofStatus;
        if(shouldBeSpoofed == ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE){ //if spoofStatus is 1 change it to 0
            shouldBeSpoofed = ConfigConstants.DETECTION_TYPE_ALWAYS_DISMISSED_HERE;
        }else if(shouldBeSpoofed == ConfigConstants.DETECTION_TYPE_ALWAYS_DISMISSED_HERE){ //if spoofStatus is 0 change it to 1
            shouldBeSpoofed = ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE;
        }
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json-file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        //Log.d("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray(JSON_ARRAY_SIGNALS); //get the jsonarray with the signals
            String lon = ""; //longitude
            String lat = ""; //latitude
            String tech = ""; //technology
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LONGITUDE); //save longitude
                lat = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LATITUDE); //save latitude
                tech = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_TECHNOLOGY); //save technology

                double[] positionDBEntry = new double[2];
                positionDBEntry[0] = Double.valueOf(lon);
                positionDBEntry[1] = Double.valueOf(lat);

                if(positionDBEntry[0]==position[0]&&positionDBEntry[1]==position[1]&&tech.equals(signalType)){ //check if its the same position in the json-file and the list, also check the technology
                    jArray.getJSONObject(i).put(JSON_ARRAY_SIGNAL_SPOOFING_STATUS, shouldBeSpoofed); //change the spoofing status
                }
            }
            try {
                FileWriter file = new FileWriter(new File(this.fileDir, ConfigConstants.JSON_FILENAME)); //write the json-object into the new json file
                //Log.d("TryJsonSave", "I am saved");
                file.write( jObject.toString() );
                file.flush();
                file.close();

            } catch (IOException e) {
                e.printStackTrace();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void deleteEntryInStoredLoc(double[] position, String signalType) {

        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json-file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        //Log.d("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray(JSON_ARRAY_SIGNALS); //get the json-array with the signals
            JSONArray jArrayWithoutDeletedEntry = new JSONArray(); //new json-array for the entries without the one to delete
            String lon = ""; //longitude
            String lat = ""; //latitude
            String tech = ""; //technology
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LONGITUDE); //save longitude
                lat = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LATITUDE); //save latitude
                tech = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_TECHNOLOGY); //save technology

                double[] positionDBEntry = new double[2];
                positionDBEntry[0] = Double.valueOf(lon);
                positionDBEntry[1] = Double.valueOf(lat);

                if(positionDBEntry[0]==position[0]&&positionDBEntry[1]==position[1]&&tech.equals(signalType)){ //check if its the same position in the json-file and the list, also check the technology

                }else{
                    jArrayWithoutDeletedEntry.put(jArray.getJSONObject(i)); //put all the other entries in the new json-array
                }
            }
            try {
                jObjectResult.remove(JSON_ARRAY_SIGNALS); //remove the whole old json-array
                jObjectResult.put(JSON_ARRAY_SIGNALS,jArrayWithoutDeletedEntry); //put in the new json-array
                FileWriter file = new FileWriter(new File(this.fileDir, ConfigConstants.JSON_FILENAME)); //write the json-object into the new json file
                //Log.d("TryJsonSave", "I am deleted");
                file.write( jObject.toString() );
                file.flush();
                file.close();

            } catch (IOException e) {
                e.printStackTrace();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private ByteArrayOutputStream getByteArrayOutputStreamWithJsonData(File jsonFile) {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        FileInputStream inputStream = null;
        int ctr;
        try{
            inputStream = new FileInputStream(jsonFile);
            ctr = inputStream.read(); //read the inputstream of the file
            while (ctr != -1) {
                byteArrayOutputStream.write(ctr);
                ctr = inputStream.read();
            }
        }
        catch(IOException ioex){
            ioex.printStackTrace();
        }
        finally {
            if (inputStream != null) {
                try {
                    inputStream.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

        return byteArrayOutputStream;
    }
}
