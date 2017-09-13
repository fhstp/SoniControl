package sonicontrol.testroutine;


import android.content.SharedPreferences;
import android.media.AudioFormat;
import android.media.AudioManager;
import android.media.AudioRecord;
import android.media.AudioTrack;
import android.media.MediaRecorder;
import android.util.Log;
import android.widget.TextView;
import java.io.*;
import org.json.*;
import java.text.SimpleDateFormat;
import java.util.*;


public class Location {

    MainActivity main;
    private Scan detector;

    private double longitude;
    private double latitude;

    private Spoofer spoof;
    private MicCapture micCap;

    private static Location instanceLoc;
    private GPSTracker locationData;

    private double[] detectedSignalPosition = new double[2];
    private double[] positionLatest = new double[2];
    ArrayList<String[]> data = new ArrayList<String[]>();

    private String fileUrl;

    private String signalTech;

    byte[] noiseByteArray;

    int locationRadius;
    boolean micBlockPref;

    private Location(){
    }

    public static Location getInstanceLoc() { //getInstance method for Singleton pattern
        if(instanceLoc == null) { //if no instance of MicCapture is there create a new one, otherwise return the existing
            instanceLoc = new Location();
        }
        return instanceLoc;
    }

    public void init(MainActivity main){
        this.main = main;
    }

    public double[] getLocation(){
        locationData = new GPSTracker(main, main); //get a gpstracker for the location finding
        longitude = locationData.getLongitude(); //get the longitude
        Log.d("longitude", Double.toString(longitude));

        latitude = locationData.getLatitude(); //get the latitude
        Log.d("latitude", Double.toString(latitude));

        positionLatest[0] = longitude; //save the longitude in the positionLatest variable
        positionLatest[1] = latitude; //save the latitude in the positionLatest variable

        return positionLatest;
    }


    public void checkExistingLocatinoDB(double[] position, String signalType){
        signalTech = signalType;
        boolean isNewSignal = true;
        double[] positionDBEntry = new double[2];
        boolean shouldBeSpoofed = false;

        getJsonData(); //get the Json data saved in "data"
        for (String[] array : data){ //iterate through the list
            positionDBEntry[0] = Double.valueOf(array[0]); //save the longitude in the positionDBEntry array
            positionDBEntry[1] = Double.valueOf(array[1]); //save the latitude in the positionDBEntry array

            double distance = getDistanceInMetres(positionDBEntry, position); //calculate the distance between the latest Position and the position from the JSON-file

            SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
            locationRadius = Integer.valueOf(sharedPref.getString("etprefLocationRadius", "30")); //save the radius of the location in metres
            if(distance<locationRadius && array[2].equals(signalType)){ //if in the location and the technologie is the same
                isNewSignal = false; //no new signal
                Log.v("Longitude", array[0]);
                Log.v("Latitude", array[1]);
                Log.v("Technology", array[2]);
                Log.v("ShouldSpoof", array[3]);

                fileUrl = array[4]; //get file from json and save in fileUrl variable

                if(Integer.valueOf(array[3]) == 1){ //if the spoofed parameter from the json file is 1 then it should be spoofed and if its 0 it shouldnt be spoofed
                    shouldBeSpoofed = true;
                }else{
                    shouldBeSpoofed = false;
                }
            }
        }

        if(isNewSignal){ //if its a new signal
            Log.d("Location", "I am a new Signal");
            detectedSignalPosition = position; //save the new signal as the detected Position
            main.cancelScanningStatusNotification(); //cancel the scanning status notification
            main.activateOnHoldStatusNotification(); //activate the onHold status notification
            if(main.getBackgroundStatus()) { //if the app is in the background
                main.activateDetectionNotification(); //activate the detection notification
            }
            main.activateAlert(signalType); //open the alert with the found technology

        }else{
            Log.d("Location", "I am not a new Signal");
            detectedSignalPosition = positionDBEntry; //save the position from the json-file
            shouldDBEntrySpoofed(shouldBeSpoofed,positionDBEntry); //check the spoofed status from the json-file

        }
    }

    public double[] getDetectedDBEntry(){
        return detectedSignalPosition;
    }

    public void setPositionForContinuousSpoofing(double[] positionLatest){
        detectedSignalPosition = positionLatest; //set the latest position to the detected position if the continuous spoofing setting is active
    }

    private void shouldDBEntrySpoofed(boolean shouldBeSpoofed, double[]position){
        setLatestDate(position, signalTech); //update the date in the json-file at the detected position
        if(shouldBeSpoofed){ //if it should be spoofed
            Log.d("Location", "I should be spoofed");
            if (!main.getBackgroundStatus()) { //if the app is not in the background
                main.cancelDetectionNotification(); //cancel the detection notification
            }
            main.cancelScanningStatusNotification(); //cancel the scanning status notification
            main.activateSpoofingStatusNotification(); //activate the spoofing status notification
            tryGettingMicAccessForBlockingMethod(); //try get the microphone access for choosing the blocking method
        }else { //if it should not be spoofed
            Log.d("Location", "I shouldn't be spoofed");
            if (!main.getBackgroundStatus()) { //if the app is not in the background
                main.cancelDetectionNotification(); //cancel the detection notification
            }
            detector = Scan.getInstance(); //get an instance of the Scan
            detector.startScanning(); //start scanning again
        }
    }

    public double getDistanceInMetres(double[] positionOld, double[] positionNew){
        double distance = distance(positionOld[1],positionOld[0],positionNew[1],positionNew[0]); //calculate the distance between two distances
        TextView txtDistance = (TextView) main.findViewById(R.id.txtDistance); //can be deleted only for debugging
        txtDistance.setText(String.valueOf(distance*1000)); //can be deleted only for debugging
        return (distance*1000);
    }


    public void tryGettingMicAccessForBlockingMethod(){

        SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
        micBlockPref = sharedPref.getBoolean("cbprefMicBlock", true);
       //micBlockPref = Boolean.valueOf(sharedPref.getString("cbprefMicBlock", true)); //save the radius of the location in metres
        if(micBlockPref) {
            if (!validateMicAvailability()) { //if we don't have access to the microphone
                Log.d("MicAcc", "I don't have MicAccess");
                boolean playingGlobal = true; //the global play status is now true after the start
                boolean playingHandler = true; //helpboolean for switching the playstatus in the puslinghandler
                spoof = Spoofer.getInstance(); //get an instance of the spoofer
                spoof.init(main, playingGlobal, playingHandler); //initialize the spoofer
                spoof.startSpoofing(); //start spoofing

            } else {
                Log.d("MicAcc", "I have MicAccess");
                micCap = MicCapture.getInstance(); //get an instance of the microphone capture
                micCap.startCapturing(); //start capturing
            }
        }else{
            Log.d("MicAcc", "I don't have MicAccess");
            boolean playingGlobal = true; //the global play status is now true after the start
            boolean playingHandler = true; //helpboolean for switching the playstatus in the puslinghandler
            spoof = Spoofer.getInstance(); //get an instance of the spoofer
            spoof.init(main, playingGlobal, playingHandler); //initialize the spoofer
            spoof.startSpoofing(); //start spoofing
        }

    }


    private boolean validateMicAvailability(){
        Boolean available = true; //helpboolean for the availability of the microphone
        android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_URGENT_AUDIO);  //set the thread to urgent for audio

        AudioRecord recorder = //create a new recorder
                new AudioRecord(MediaRecorder.AudioSource.MIC, 44100,
                        AudioFormat.CHANNEL_IN_MONO,
                        AudioFormat.ENCODING_DEFAULT, 44100);
        try{
            if(recorder.getRecordingState() != AudioRecord.RECORDSTATE_STOPPED ){ //if recorder state is not stopped its not available
                available = false;

            }

            recorder.startRecording(); //start recording
            if(recorder.getRecordingState() != AudioRecord.RECORDSTATE_RECORDING){ //if the recorder is not recording its not available
                available = false;
            }
        } finally{
            recorder.stop(); //stop the recorder
            recorder.release(); //release the recorder resources
        }

        return available;
    }

    private double distance(double lat1, double lon1, double lat2, double lon2) { //distance calculation
        double theta = lon1 - lon2;
        double dist = Math.sin(deg2rad(lat1))
                * Math.sin(deg2rad(lat2))
                + Math.cos(deg2rad(lat1))
                * Math.cos(deg2rad(lat2))
                * Math.cos(deg2rad(theta));
        dist = Math.acos(dist);
        dist = rad2deg(dist);
        dist = dist * 60 * 1.1515;
        return (dist);
    }

    private double deg2rad(double deg) {
        return (deg * Math.PI / 180.0);
    }

    private double rad2deg(double rad) {
        return (rad * 180.0 / Math.PI);
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
            String spoof = ""; //spoofinStatus
            String url = ""; //fileUrl
            for (int i = 0; i < jArray.length(); i++) { //go through the array
                lon = jArray.getJSONObject(i).getString("long"); //save longitude
                lat = jArray.getJSONObject(i).getString("lat"); //save latitude
                tech = jArray.getJSONObject(i).getString("technology"); //save technology
                spoof = jArray.getJSONObject(i).getString("spoof"); //save spoofingStatus
                url = jArray.getJSONObject(i).getString("URL"); //save fileUrl
                Log.v("Longitude", lon);
                Log.v("Latitude", lat);
                Log.v("Technology", tech);
                data.add(new String[] { lon, lat, tech, spoof, url }); //add every data of one array-index in the data-list
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
                double distance = getDistanceInMetres(positionDBEntry, position);
                SharedPreferences sharedPref = main.getSettingsObject(); //get the settings
                locationRadius = Integer.valueOf(sharedPref.getString("etprefLocationRadius", "30")); //save the radius of the location in metres
                if (distance < locationRadius && tech.equals(signalType)) { //if in the location and the right technologytype
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

    public AudioTrack generatePlayer(){
        File file = new File("/storage/emulated/0/DCIM/lisnr_test4.wav"); //get the audio file //not working dynamically now because no dynamic links
        noiseByteArray = new byte[(int) file.length()]; //size & length of the file
        InputStream is = null;
        try{
            is  = new FileInputStream(file);
        }
        catch(IOException ex){

        }
        BufferedInputStream bis = new BufferedInputStream(is, 44100);
        DataInputStream dis = new DataInputStream(bis);

        int i = 0;
        try {
            while (dis.available() > 0) {
                noiseByteArray[i] = dis.readByte(); //read every entry of the data input stream into the new byte array
                i++;
            }

            dis.close();
        }
        catch (IOException ex){

        }
        AudioTrack sigPlayer = new AudioTrack(AudioManager.STREAM_MUSIC,14700, AudioFormat.CHANNEL_CONFIGURATION_MONO, AudioFormat.ENCODING_PCM_16BIT,noiseByteArray.length,AudioTrack.MODE_STATIC); //create a new player with the byte array
        sigPlayer.write(noiseByteArray, 0, noiseByteArray.length); //write the byte array into the player
        return sigPlayer;
    }
}
