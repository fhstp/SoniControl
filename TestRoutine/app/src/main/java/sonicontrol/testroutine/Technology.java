package sonicontrol.testroutine;


public enum Technology {
    PRONTOLY("Prontoly"),
    GOOGLE_NEARBY("Google_Nearby"),
    LISNR("Lisnr"),
    SIGNAL360("Signal360"),
    SHOPKICK("Shopkick"),
    UNKNOWN("Unknown"),
    SILVERPUSH("Silverpush");

    private String stringValue;

    private Technology(String toString){
        stringValue = toString;
    }

    public String toString(){
        return stringValue;
    }
}
