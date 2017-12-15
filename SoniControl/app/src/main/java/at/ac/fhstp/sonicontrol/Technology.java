package at.ac.fhstp.sonicontrol;


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

    public static Technology fromString(String text) throws IllegalArgumentException {
        for (Technology t : Technology.values()) {
            if (t.stringValue.equalsIgnoreCase(text)) {
                return t;
            }
        }
        throw new IllegalArgumentException("No Technology with text " + text + " found");
    }
}
