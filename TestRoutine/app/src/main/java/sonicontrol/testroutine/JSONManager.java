package sonicontrol.testroutine;

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

    public JSONManager(MainActivity main){
        this.main = main;
    }

    public ArrayList<String[]> getJsonData(){
        File jsonFile = new File(main.getExternalFilesDir(null), "soni.json"); //get json file from external storage
        FileInputStream inputStream = null;
        try{
            inputStream = new FileInputStream(jsonFile);
        }
        catch(IOException ioex){
        }
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

        int ctr;
        try {
            ctr = inputStream.read(); //read the inputstream of the file
            while (ctr != -1) {
                byteArrayOutputStream.write(ctr);
                ctr = inputStream.read();
            }
            inputStream.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        Log.v("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject("items"); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray("signal"); //get the jsonarray with the signals
            String lon = ""; //longitude
            String lat = ""; //latidude
            String tech = ""; //technology
            String lastDet = ""; //last Detection
            String spoof = ""; //spoofinStatus
            String url = ""; //fileUrl
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString("long"); //save longitude
                lat = jArray.getJSONObject(i).getString("lat"); //save latitude
                tech = jArray.getJSONObject(i).getString("technology"); //save technology
                lastDet = jArray.getJSONObject(i).getString("last_detection"); //save spoofingStatus
                spoof = jArray.getJSONObject(i).getString("spoof"); //save spoofingStatus
                url = jArray.getJSONObject(i).getString("URL"); //save fileUrl
                Log.v("Longitude", lon);
                Log.v("Latitude", lat);
                Log.v("Technology", tech);
                data.add(new String[] { lon, lat, tech, spoof, lastDet, url }); //add every data of one array-index in the data-list
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return data;
    }

    public void addJsonObject(double[] position, String technology, int spoof){
        File jsonFile = new File(main.getExternalFilesDir(null), "soni.json"); //get json file from external storage
        FileInputStream inputStream = null;
        try{
            inputStream = new FileInputStream(jsonFile);
        }
        catch(IOException ioex){
        }
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

        int ctr;
        try {
            ctr = inputStream.read(); //read the inputstream of the file
            while (ctr != -1) {
                byteArrayOutputStream.write(ctr);
                ctr = inputStream.read();
            }
            inputStream.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject("items"); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray("signal"); //get the jsonarray with the signals

            JSONObject addArray = new JSONObject(); //new json-object

            addArray.put("long", position[0]); //add the longitude to the new object
            addArray.put("lat", position[1]); //add the latitude to the new object
            addArray.put("technology", technology); //add the technology to the new object
            addArray.put("last_detection", returnDateString()); //add the last_detection to the new object
            addArray.put("spoof", spoof); //add the spoofing status to the new object
            detector = Scan.getInstance(); //get an instance of the scan
            String fileUrl = detector.getDetectedFileUrl(); //get the url from the scan
            addArray.put("URL", fileUrl); //add the url to the new object

            jArray.put(addArray); //add the created object to the json array

            try {
                FileWriter file = new FileWriter(new File(main.getExternalFilesDir(null), "soni.json")); //get the json file
                Log.d("TryJsonSave", "I am saved");
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
            jObject.put("items", jsObject); //put the second json-object into the first with "items"
            jsObject.put("signal", jArray); //put the json-array into the second json-object with "signal"

        }catch (JSONException ext) {

        }
        try {
            FileWriter file = new FileWriter(new File(main.getExternalFilesDir(null), "soni.json")); //write the newly created json-object into the new json file
            file.write( jObject.toString() );
            file.flush();
            file.close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public boolean checkIfSavefolderIsAvailable(){
        File file = new File(main.getExternalFilesDir(null) +"/detected-files"); //get the folder for the audio files
        if(file.isDirectory()){ //if directory is available
            Log.d("Dircheck","The directory is here");
            return true;
        }else{
            Log.d("Dircheck","here is no directory");
            return false;
        }
    }

    public void createSaveFolder() {
        File file = new File(main.getExternalFilesDir(null) +"/detected-files"); //create a new folder for the audio files
        file.mkdir(); //save the folder
    }

    public String returnDateString(){
        Long currentTime = Calendar.getInstance().getTimeInMillis(); //get the current time in milliseconds
        SimpleDateFormat rightFormat = new SimpleDateFormat("HH:mm:ss.SSS"); //get the time formatted
        SimpleDateFormat leftFormat = new SimpleDateFormat("yyyy-MM-dd"); //get the date formatted
        String dateLeft = String.valueOf(leftFormat.format(currentTime));
        String dateRight = String.valueOf(rightFormat.format(currentTime));
        String dateString = dateLeft + "T" + dateRight + "Z";
        return dateString;
    }


    public void setLatestDate(double[] position, String signalType){
        locationFinder = Location.getInstanceLoc();
        File jsonFile = new File(main.getExternalFilesDir(null), "soni.json"); //get json file from external storage
        FileInputStream inputStream = null;
        try{
            inputStream = new FileInputStream(jsonFile);
        }
        catch(IOException ioex){
        }
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

        int ctr;
        try {
            ctr = inputStream.read(); //read the inputstream of the file
            while (ctr != -1) {
                byteArrayOutputStream.write(ctr);
                ctr = inputStream.read();
            }
            inputStream.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        Log.v("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject("items"); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray("signal"); //get the jsonarray with the signals
            String lon = ""; //longitude
            String lat = ""; //latitude
            String tech = ""; //technology
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString("long"); //save longitude
                lat = jArray.getJSONObject(i).getString("lat"); //save latitude
                tech = jArray.getJSONObject(i).getString("technology"); //save technology

                double[] positionDBEntry = new double[2];
                positionDBEntry[0] = Double.valueOf(lon);
                positionDBEntry[1] = Double.valueOf(lat);
                double distance = locationFinder.getDistanceInMetres(positionDBEntry, position);
                SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                locationFinder.locationRadius = Integer.valueOf(sharedPref.getString("etprefLocationRadius", "30")); //save the radius of the location in metres
                if (distance < locationFinder.locationRadius && tech.equals(signalType)) { //if in the location and the right technologytype
                    jArray.getJSONObject(i).put("last_detection", returnDateString()); //change latest detection date
                }
            }
            try {
                FileWriter file = new FileWriter(new File(main.getExternalFilesDir(null), "soni.json")); //write the newly created json-object into the new json file
                Log.d("TryJsonSave", "I am saved");
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
        if(shouldBeSpoofed == 1){ //if spoofStatus is 1 change it to 0
            shouldBeSpoofed = 0;
        }else if(shouldBeSpoofed == 0){ //if spoofStatus is 0 change it to 1
            shouldBeSpoofed = 1;
        }
        File jsonFile = new File(main.getExternalFilesDir(null), "soni.json"); //get json-file from external storage
        FileInputStream inputStream = null;
        try{
            inputStream = new FileInputStream(jsonFile);
        }
        catch(IOException ioex){
        }
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

        int ctr;
        try {
            ctr = inputStream.read(); //read the inputstream of the file
            while (ctr != -1) {
                byteArrayOutputStream.write(ctr);
                ctr = inputStream.read();
            }
            inputStream.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        Log.v("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject("items"); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray("signal"); //get the jsonarray with the signals
            String lon = ""; //longitude
            String lat = ""; //latitude
            String tech = ""; //technology
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString("long"); //save longitude
                lat = jArray.getJSONObject(i).getString("lat"); //save latitude
                tech = jArray.getJSONObject(i).getString("technology"); //save technology

                double[] positionDBEntry = new double[2];
                positionDBEntry[0] = Double.valueOf(lon);
                positionDBEntry[1] = Double.valueOf(lat);

                if(positionDBEntry[0]==position[0]&&positionDBEntry[1]==position[1]&&tech.equals(signalType)){ //check if its the same position in the json-file and the list, also check the technology
                    jArray.getJSONObject(i).put("spoof", shouldBeSpoofed); //change the spoofing status
                }
            }
            try {
                FileWriter file = new FileWriter(new File(main.getExternalFilesDir(null), "soni.json")); //write the json-object into the new json file
                Log.d("TryJsonSave", "I am saved");
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
        File jsonFile = new File(main.getExternalFilesDir(null), "soni.json"); //get json-file from external storage
        FileInputStream inputStream = null;
        try{
            inputStream = new FileInputStream(jsonFile);
        }
        catch(IOException ioex){
        }
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

        int ctr;
        try {
            ctr = inputStream.read(); //read the inputstream of the file
            while (ctr != -1) {
                byteArrayOutputStream.write(ctr);
                ctr = inputStream.read();
            }
            inputStream.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        Log.v("Text Data", byteArrayOutputStream.toString());
        try {
            JSONObject jObject = new JSONObject(
                    byteArrayOutputStream.toString()); //new json-object with the outputstream
            JSONObject jObjectResult = jObject.getJSONObject("items"); //get the jsonobject "items"
            JSONArray jArray = jObjectResult.getJSONArray("signal"); //get the json-array with the signals
            JSONArray jArrayWithoutDeletedEntry = new JSONArray(); //new json-array for the entries without the one to delete
            String lon = ""; //longitude
            String lat = ""; //latitude
            String tech = ""; //technology
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString("long"); //save longitude
                lat = jArray.getJSONObject(i).getString("lat"); //save latitude
                tech = jArray.getJSONObject(i).getString("technology"); //save technology

                double[] positionDBEntry = new double[2];
                positionDBEntry[0] = Double.valueOf(lon);
                positionDBEntry[1] = Double.valueOf(lat);

                if(positionDBEntry[0]==position[0]&&positionDBEntry[1]==position[1]&&tech.equals(signalType)){ //check if its the same position in the json-file and the list, also check the technology

                }else{
                    jArrayWithoutDeletedEntry.put(jArray.getJSONObject(i)); //put all the other entries in the new json-array
                }
            }
            try {
                jObjectResult.remove("signal"); //remove the whole old json-array
                jObjectResult.put("signal",jArrayWithoutDeletedEntry); //put in the new json-array
                FileWriter file = new FileWriter(new File(main.getExternalFilesDir(null), "soni.json")); //write the json-object into the new json file
                Log.d("TryJsonSave", "I am saved");
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
