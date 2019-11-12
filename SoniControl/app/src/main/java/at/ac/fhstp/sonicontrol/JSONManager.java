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
import android.preference.PreferenceManager;
import android.util.Log;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Comparator;
import java.util.Date;

public class JSONManager {

    MainActivity main;
    private Scan detector;
    private Location locationFinder;

    private File fileDir;

    private static final String JSON_LIST_NAME = "items";
    private static final String JSON_ARRAY_SIGNALS = "signal";
    private static final String JSON_ARRAY_DISMISSED_SIGNALS = "signalDismissedThisTime";
    private static final String JSON_ARRAY_UNKNOWN_SIGNALS = "signalUnknownPosition";
    private static final String JSON_ARRAY_IMPORT_SIGNALS = "signalImportPosition";
    private static final String JSON_ARRAY_HISTORY_SIGNALS = "signalHistoryPosition";
    private static final String JSON_ARRAY_SIGNAL_LONGITUDE = "long";
    private static final String JSON_ARRAY_SIGNAL_LATITUDE = "lat";
    private static final String JSON_ARRAY_SIGNAL_TECHNOLOGY = "technology";
    private static final String JSON_ARRAY_SIGNAL_LAST_DETECTION = "last_detection";
    private static final String JSON_ARRAY_SIGNAL_SPOOFING_STATUS = "spoof";
    private static final String JSON_ARRAY_SIGNAL_ADDRESS = "address";
    private static final String JSON_ARRAY_SIGNAL_URL = "URL";
    private static final String JSON_ARRAY_SIGNAL_TECHNOLOGY_ID = "technologyId";
    private static final String JSON_ARRAY_SIGNAL_DETECTIONCOUNTER = "detectioncounter";
    private static final String JSON_ARRAY_SIGNAL_AMPLITUDE = "detectionamplitude";


    public JSONManager(MainActivity main){
        this.main = main;
        this.fileDir = main.getFilesDir();
    }

    public ArrayList<String[]> getImportJsonData(){
        ArrayList<String[]> data = new ArrayList<String[]>();

        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME);
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        JSONObject jObject = null;
        try {
            jObject = new JSONObject(
                    byteArrayOutputStream.toString());
        } catch (JSONException e) {
            e.printStackTrace();
        }

        JSONObject jObjectResult = null;
        try {
            jObjectResult = jObject.getJSONObject(JSON_LIST_NAME);
        } catch (JSONException e) {
            e.printStackTrace();
        }

        JSONArray array = jObjectResult.optJSONArray(JSON_ARRAY_IMPORT_SIGNALS);
        if (array == null) {
            JSONArray jImportArray = new JSONArray();
            try {
                jObjectResult.put(JSON_ARRAY_IMPORT_SIGNALS, jImportArray);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }

        data.addAll(retrieveSavedJsonData(JSON_ARRAY_IMPORT_SIGNALS));
        sortJsonDataByDatetime(data);
        return data;
    }

    public ArrayList<String[]> getHistoryJsonData(){
        ArrayList<String[]> data = new ArrayList<String[]>();
        data.addAll(retrieveSavedJsonData(JSON_ARRAY_HISTORY_SIGNALS));
        sortJsonDataByDatetime(data);
        return data;
    }

    public ArrayList<String[]> getAllJsonData(){
        ArrayList<String[]> data = new ArrayList<String[]>();
        data.addAll(retrieveSavedJsonData(JSON_ARRAY_SIGNALS));
        data.addAll(retrieveSavedJsonData(JSON_ARRAY_DISMISSED_SIGNALS));
        data.addAll(retrieveSavedJsonData(JSON_ARRAY_UNKNOWN_SIGNALS));
        sortJsonDataByDatetime(data);
        return data;
    }

    private ArrayList<String[]> sortJsonDataByDatetime(ArrayList<String[]> data){
        ArrayList<String[]> sortData = data;
        Collections.sort(sortData, new Comparator<String[]>() {
            @Override
            public int compare(String[] s1, String[] s2) {
                SimpleDateFormat dataFormatShort = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
                SimpleDateFormat dataFormatLong = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS'Z'");
                Date newDate1 = null;
                Date newDate2 = null;
                String toParse1 = s1[3];
                try {
                    if(toParse1.length()>20){
                        newDate1 = dataFormatLong.parse(toParse1);
                    }else{
                        newDate1 = dataFormatShort.parse(toParse1);
                    }
                } catch (ParseException e) {
                    e.printStackTrace();
                }
                String toParse2 = s2[3];
                try {
                    if(toParse2.length()>20){
                        newDate2 = dataFormatLong.parse(toParse2);
                    }else{
                        newDate2 = dataFormatShort.parse(toParse2);
                    }
                } catch (ParseException e) {
                    e.printStackTrace();
                }
                if (newDate1.getTime() < newDate2.getTime()) {
                    return 1;
                }
                else if (newDate1.getTime() >  newDate2.getTime()) {
                    return -1;
                }
                else {
                    return 0;
                }
                //return (int) (newDate2.getTime() - newDate1.getTime());
            }
        });
        return sortData;
    }

    public ArrayList<String[]> retrieveSavedJsonData(String jsonArrayName){
        ArrayList<String[]> data = new ArrayList<String[]>();
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        //Log.d("Text Data", byteArrayOutputStream.toString());

        JSONObject jObject = null; //new json-object with the outputstream
        JSONArray jArray =null;
        try {
            jObject = new JSONObject(byteArrayOutputStream.toString());
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            jArray = jObjectResult.getJSONArray(jsonArrayName); //get the jsonarray with the signals
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
            String technologyid = "";
            String detectioncounter = "";
            String amplitude = "";

            //boolean needsUpdate = false;
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                try {
                    lon = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LONGITUDE); //save longitude
                    lat = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LATITUDE); //save latitude
                    tech = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_TECHNOLOGY); //save technology
                    lastDet = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LAST_DETECTION); //save spoofingStatus
                    spoof = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_SPOOFING_STATUS); //save spoofingStatus
                    if(jArray.getJSONObject(i).optString(JSON_ARRAY_SIGNAL_ADDRESS).equals("")){
                        address = "Unknown";
                        //needsUpdate = true;
                    }else {
                        address = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_ADDRESS); //save spoofingStatus
                    }
                    url = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_URL); //save fileUrl
                    if(jArray.getJSONObject(i).optString(JSON_ARRAY_SIGNAL_TECHNOLOGY_ID).equals("")){
                        int techId = Technology.fromString(tech).getId();
                        technologyid = String.valueOf(techId);
                        //needsUpdate = true;
                        Log.d("JSONManager", technologyid);
                    }else{
                        technologyid = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_TECHNOLOGY_ID);
                    }
                    if(jArray.getJSONObject(i).optString(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER).equals("")){
                        detectioncounter = String.valueOf(1);
                    }else{
                        detectioncounter = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER);
                    }
                    if(jArray.getJSONObject(i).optString(JSON_ARRAY_SIGNAL_AMPLITUDE).equals("")){
                        amplitude = String.valueOf(0.5);
                    }else{
                        amplitude = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_AMPLITUDE);
                    }
                    //Log.d("Longitude", lon);
                    //Log.d("Latitude", lat);
                    //Log.d("Technology", tech);
                    data.add(new String[]{lon, lat, tech, lastDet, spoof, address, url, technologyid, detectioncounter, amplitude}); //add every data of one array-index in the data-list
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        }
        return data;
    }

    public ArrayList<String[]> getJsonData(){
        return retrieveSavedJsonData(JSON_ARRAY_SIGNALS);
    }

    public void updateSignalAndImportedDetectionCounter(double[] position, String technology){
        updateDetectionCounter(position, technology, JSON_ARRAY_SIGNALS);
        updateDetectionCounter(position, technology, JSON_ARRAY_IMPORT_SIGNALS);
    }

    public void updateDetectionCounter(double[] position, String technology, String jsonArrayName){
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray(jsonArrayName);
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                String lon = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LONGITUDE); //save longitude
                String lat = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_LATITUDE); //save latitude
                String tech = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_TECHNOLOGY); //save technology
                String detectionCounter = jArray.getJSONObject(i).optString(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER);
                if (detectionCounter.equals("")) {
                    detectionCounter = "1";
                }else{
                    detectionCounter = jArray.getJSONObject(i).getString(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER);
                }

                double[] positionDBEntry = new double[2];
                positionDBEntry[0] = Double.valueOf(lon);
                positionDBEntry[1] = Double.valueOf(lat);
                locationFinder = Location.getInstanceLoc();
                double distance = locationFinder.getDistanceInMetres(positionDBEntry, position);
                SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                locationFinder.locationRadius = Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_LOCATION_RADIUS, ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT)); //save the radius of the location in metres
                if (distance < locationFinder.locationRadius && tech.equals(technology)) {
                    Log.d("JSONManager", ""+position[0] +" "+ positionDBEntry[0] +" "+ position[1] +" "+ positionDBEntry[1]);
                    Log.d("JSONManager", "entryUpdated");
                    jArray.getJSONObject(i).put(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER, (Integer.valueOf(detectionCounter)+1));
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

    public void addJsonObject(double[] position, String technology, int spoof, String address, boolean justHistoryEntry, float amplitude){
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray;
            JSONArray jHistoryArray = jObjectResult.getJSONArray(JSON_ARRAY_HISTORY_SIGNALS);
            if(position[0]==0&&position[1]==0) {
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_UNKNOWN_SIGNALS);
                if(spoof==ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE){
                    spoof=ConfigConstants.DETECTION_TYPE_BLOCKED_THIS_TIME;
                }else if(spoof==ConfigConstants.DETECTION_TYPE_ALWAYS_DISMISSED_HERE){
                    spoof=ConfigConstants.DETECTION_TYPE_DISMISSED_THIS_TIME;
                }
            }else if(spoof==ConfigConstants.DETECTION_TYPE_BLOCKED_THIS_TIME || spoof==ConfigConstants.DETECTION_TYPE_DISMISSED_THIS_TIME){
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
            int technologyId = Technology.fromString(technology).getId();
            addArray.put(JSON_ARRAY_SIGNAL_TECHNOLOGY_ID, technologyId);
            addArray.put(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER, 1);
            addArray.put(JSON_ARRAY_SIGNAL_AMPLITUDE, amplitude);

            if(!justHistoryEntry){
                jArray.put(addArray); //add the created object to the json array
            }
            jHistoryArray.put(addArray);

            SharedPreferences sp =  PreferenceManager.getDefaultSharedPreferences(main);
            boolean shouldBeShared = sp.getBoolean(ConfigConstants.LAST_DECISION_ON_SHARING, ConfigConstants.SETTINGS_SHARING_DEFAULT_VALUE);
            if(shouldBeShared) {
                main.sendDetection(position[0], position[1], Technology.fromString(technology).getId(), technology, returnDateString(), spoof, amplitude);
            }

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

    public void addImportedJsonObject(double[] position, String technology, int spoof, String address, String timestamp, int technologyid, float amplitude){
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray;
            /*if(position[0]==0&&position[1]==0) {
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_UNKNOWN_SIGNALS);
                if(spoof==ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE){
                    spoof=ConfigConstants.DETECTION_TYPE_BLOCKED_THIS_TIME;
                }else if(spoof==ConfigConstants.DETECTION_TYPE_ALWAYS_DISMISSED_HERE){
                    spoof=ConfigConstants.DETECTION_TYPE_DISMISSED_THIS_TIME;
                }
            }else if(spoof==ConfigConstants.DETECTION_TYPE_BLOCKED_THIS_TIME || spoof==ConfigConstants.DETECTION_TYPE_DISMISSED_THIS_TIME){
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_DISMISSED_SIGNALS);
                //spoof=0;
            }else{
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_SIGNALS); //get the jsonarray with the signals
            }*/
            JSONArray array = jObjectResult.optJSONArray(JSON_ARRAY_IMPORT_SIGNALS);
            if (array == null) {
                //JSONObject jsonObject = jObjectResult.getJSONObject(JSON_LIST_NAME);
                JSONArray jImportArray = new JSONArray();
                jObjectResult.put(JSON_ARRAY_IMPORT_SIGNALS, jImportArray);
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_IMPORT_SIGNALS);
                // do stuff with the array
            }else{
                jArray = jObjectResult.getJSONArray(JSON_ARRAY_IMPORT_SIGNALS);
            }

            JSONObject addArray = new JSONObject(); //new json-object

            addArray.put(JSON_ARRAY_SIGNAL_LONGITUDE, position[0]); //add the longitude to the new object
            addArray.put(JSON_ARRAY_SIGNAL_LATITUDE, position[1]); //add the latitude to the new object
            addArray.put(JSON_ARRAY_SIGNAL_TECHNOLOGY, technology); //add the technology to the new object
            addArray.put(JSON_ARRAY_SIGNAL_LAST_DETECTION, timestamp); //add the last_detection to the new object
            addArray.put(JSON_ARRAY_SIGNAL_SPOOFING_STATUS, ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE); //add the spoofing status to the new object
            addArray.put(JSON_ARRAY_SIGNAL_ADDRESS, address); //add the addressline of the found signal
            detector = Scan.getInstance(); //get an instance of the scan
            String fileUrl = detector.getDetectedFileUrl(); //get the url from the scan
            addArray.put(JSON_ARRAY_SIGNAL_URL, ""); //add the url to the new object
            addArray.put(JSON_ARRAY_SIGNAL_TECHNOLOGY_ID, technologyid);
            addArray.put(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER, 1);
            addArray.put(JSON_ARRAY_SIGNAL_AMPLITUDE, amplitude);

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

    public void updateSpoofStatusOfRules(double[] position, String technology, int spoof) {
        updateSpoofStatusOfJsonObject(position, technology, spoof, JSON_ARRAY_SIGNALS);
        updateSpoofStatusOfJsonObject(position, technology, spoof, JSON_ARRAY_IMPORT_SIGNALS);
    }

    public void updateSpoofStatusOfJsonObject(double[] position, String technology, int spoof, String jsonArrayName){
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);
        //Log.d("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray(jsonArrayName); //get the jsonarray with the signals
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
                Log.d("JSONManager", ""+position[0] +" "+ positionDBEntry[0] +" "+ position[1] +" "+ positionDBEntry[1] + " " + spoof);
                locationFinder = Location.getInstanceLoc();
                double distance = locationFinder.getDistanceInMetres(positionDBEntry, position);
                SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                locationFinder.locationRadius = Integer.valueOf(sharedPref.getString(ConfigConstants.SETTING_LOCATION_RADIUS, ConfigConstants.SETTING_LOCATION_RADIUS_DEFAULT)); //save the radius of the location in metres
                if (distance < locationFinder.locationRadius && tech.equals(technology)) {
                //if (position[0] == positionDBEntry[0] && position[1] == positionDBEntry[1] && tech.equals(technology)) { //if in the location and the right technologytype
                    if(spoof == ConfigConstants.DETECTION_TYPE_BLOCKED_THIS_TIME || spoof == ConfigConstants.DETECTION_TYPE_DISMISSED_THIS_TIME){
                        jArray.getJSONObject(i).put(JSON_ARRAY_SIGNAL_SPOOFING_STATUS, ConfigConstants.DETECTION_TYPE_ASK_AGAIN); //change latest detection date
                    }else{
                        jArray.getJSONObject(i).put(JSON_ARRAY_SIGNAL_SPOOFING_STATUS, spoof); //change latest detection date
                    }
                    Log.d("JSONManager", "entryMatches");
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

    public void createJsonFile(){
        JSONObject jObject = new JSONObject(); //create a new json-object
        JSONObject jsObject = new JSONObject(); //create a second json-object
        JSONArray jArray = new JSONArray(); //create a json-array

        try {
            jObject.put(JSON_LIST_NAME, jsObject); //put the second json-object into the first with JSON_LIST_NAME
            jsObject.put(JSON_ARRAY_SIGNALS, jArray); //put the json-array into the second json-object with "signal"
            jsObject.put(JSON_ARRAY_UNKNOWN_SIGNALS, jArray); //put the json-array into the second json-object with "signal"
            jsObject.put(JSON_ARRAY_DISMISSED_SIGNALS, jArray); //put the json-array into the second json-object with "signal"
            jsObject.put(JSON_ARRAY_HISTORY_SIGNALS, jArray);
            jsObject.put(JSON_ARRAY_IMPORT_SIGNALS, jArray);
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

    public void updateJSONHistory(){
        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json file from external storage
        if(jsonFile.exists()){
            ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);
            try {
                JSONObject jObject = new JSONObject(
                        byteArrayOutputStream.toString()); //new json-object with the outputstream
                JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
                JSONArray array = jObjectResult.optJSONArray(JSON_ARRAY_HISTORY_SIGNALS);
                JSONArray jArray = null;
                if (array == null) {
                    JSONArray jImportArray = new JSONArray();
                    jObjectResult.put(JSON_ARRAY_HISTORY_SIGNALS, jImportArray);
                    jArray = jObjectResult.getJSONArray(JSON_ARRAY_HISTORY_SIGNALS);
                }

                ArrayList<String[]> data = getAllJsonData();

                for (String[] arrayData : data){
                    JSONObject addArray = new JSONObject(); //new json-object

                    addArray.put(JSON_ARRAY_SIGNAL_LONGITUDE, arrayData[0]); //add the longitude to the new object
                    addArray.put(JSON_ARRAY_SIGNAL_LATITUDE, arrayData[1]); //add the latitude to the new object
                    addArray.put(JSON_ARRAY_SIGNAL_TECHNOLOGY, arrayData[2]); //add the technology to the new object
                    addArray.put(JSON_ARRAY_SIGNAL_LAST_DETECTION, arrayData[3]); //add the last_detection to the new object
                    addArray.put(JSON_ARRAY_SIGNAL_SPOOFING_STATUS, arrayData[4]); //add the spoofing status to the new object
                    addArray.put(JSON_ARRAY_SIGNAL_ADDRESS, arrayData[5]); //add the addressline of the found signal
                    detector = Scan.getInstance(); //get an instance of the scan
                    String fileUrl = detector.getDetectedFileUrl(); //get the url from the scan
                    addArray.put(JSON_ARRAY_SIGNAL_URL, ""); //add the url to the new object
                    addArray.put(JSON_ARRAY_SIGNAL_TECHNOLOGY_ID, arrayData[7]);
                    addArray.put(JSON_ARRAY_SIGNAL_DETECTIONCOUNTER, 1);
                    addArray.put(JSON_ARRAY_SIGNAL_AMPLITUDE, 0.5);

                    jArray.put(addArray); //add the created object to the json array
                }

                try {
                    FileWriter file = new FileWriter(new File(this.fileDir, ConfigConstants.JSON_FILENAME));
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

    public String returnDateStringFromAlert(Long time){
        SimpleDateFormat rightFormat = new SimpleDateFormat("HH:mm:ss");
        SimpleDateFormat leftFormat = new SimpleDateFormat("yyyy-MM-dd");
        if(time!=null) {
            String dateLeft = String.valueOf(leftFormat.format(time));
            String dateRight = String.valueOf(rightFormat.format(time));
            String dateString = dateLeft + "T" + dateRight + "Z";
            return dateString;
        } else{
            return null;
        }
    }


    public void setLatestDate(double[] position, Technology signalType){
        Log.d("JSONManager", "setLatestDate");
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
                Log.d("JSONManager", ""+position[0] +" "+ positionDBEntry[0] +" "+ position[1] +" "+ positionDBEntry[1]);
                //if (position[0] == positionDBEntry[0] && position[1] == positionDBEntry[1] && tech.equals(signalType.toString())) {
                    Log.d("JSONManager", "entryMatches");
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

    public void setShouldBeSpoofed(double[] position, String signalType, int spoofStatus, String jsonArrayName){
        int shouldBeSpoofed = spoofStatus;
        if(shouldBeSpoofed == ConfigConstants.DETECTION_TYPE_ALWAYS_BLOCKED_HERE){ //if spoofStatus is 1 change it to 0
            shouldBeSpoofed = ConfigConstants.DETECTION_TYPE_ASK_AGAIN;
        }else if(shouldBeSpoofed == ConfigConstants.DETECTION_TYPE_ASK_AGAIN){ //if spoofStatus is 1 change it to 0
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
            JSONArray jArray = jObjectResult.getJSONArray(jsonArrayName); //get the jsonarray with the signals
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

    public void setShouldBeSpoofedInImportedLoc(double[] position, String signalType, int spoofStatus){
        setShouldBeSpoofed(position, signalType, spoofStatus, JSON_ARRAY_IMPORT_SIGNALS);
    }

    public void setShouldBeSpoofedInStoredLoc(double[] position, String signalType, int spoofStatus) {
        setShouldBeSpoofed(position, signalType, spoofStatus, JSON_ARRAY_SIGNALS);
    }

    public void deleteImportEntry(double[] position, String signalType){
        deleteJSONEntry(position, signalType, JSON_ARRAY_IMPORT_SIGNALS);
    }

    public void deleteJSONEntry(double[] position, String signalType, String jsonArrayName){

        File jsonFile = new File(this.fileDir, ConfigConstants.JSON_FILENAME); //get json-file from external storage
        ByteArrayOutputStream byteArrayOutputStream = getByteArrayOutputStreamWithJsonData(jsonFile);

        //Log.d("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject(JSON_LIST_NAME); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray(jsonArrayName); //get the json-array with the signals
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
                jObjectResult.remove(jsonArrayName); //remove the whole old json-array
                jObjectResult.put(jsonArrayName,jArrayWithoutDeletedEntry); //put in the new json-array
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

    public void deleteEntryInStoredLoc(double[] position, String signalType) {
        deleteJSONEntry(position, signalType, JSON_ARRAY_SIGNALS);
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
