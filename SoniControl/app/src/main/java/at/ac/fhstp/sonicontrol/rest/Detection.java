package at.ac.fhstp.sonicontrol.rest;

import com.google.gson.annotations.SerializedName;

public class Detection {

    @SerializedName("longitude")
    private double longitude;
    @SerializedName("latitude")
    private double latitude;
    @SerializedName("spoofDecision")
    private int spoofDecision;
    @SerializedName("technologyid")
    private int technologyid;
    @SerializedName("technology")
    private String technology;
    @SerializedName("amplitude")
    private int amplitude;
    @SerializedName("timestamp")
    private String timestamp;
    @SerializedName("audiodata")
    private String audiodata;

    public Detection(double longitude, double latitude, int spoofDecision, int technologyid, String technology, int amplitude, String timestamp, String audiodata) {
        this.longitude = longitude;
        this.latitude = latitude;
        this.spoofDecision = spoofDecision;
        this.technologyid = technologyid;
        this.technology = technology;
        this.amplitude = amplitude;
        this.timestamp = timestamp;
        this.audiodata = audiodata;
    }

    public String getAudiodata() {
        return audiodata;
    }

    public void setAudiodata(String audiodata) {
        this.audiodata = audiodata;
    }

    public int getSpoofDecision() {
        return spoofDecision;
    }

    public void setSpoofDecision(int spoofDecision) {
        this.spoofDecision = spoofDecision;
    }

    public int getTechnologyid() {
        return technologyid;
    }

    public void setTechnologyid(int technologyid) {
        this.technologyid = technologyid;
    }

    public double getLongitude() {
        return longitude;
    }

    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    public double getLatitude() {
        return latitude;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    public String getTechnology() {
        return technology;
    }

    public void setTechnology(String technology) {
        this.technology = technology;
    }

    public int getAmplitude() {
        return amplitude;
    }

    public void setAmplitude(int amplitude) {
        this.amplitude = amplitude;
    }

    public String getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(String timestamp) {
        this.timestamp = timestamp;
    }
}

