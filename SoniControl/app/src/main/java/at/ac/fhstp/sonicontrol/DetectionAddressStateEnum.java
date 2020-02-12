package at.ac.fhstp.sonicontrol;

public enum DetectionAddressStateEnum {

    UNKNOWN("Unknown", 0),
    NOT_AVAILABLE("Not_Available", 1),
    RESOLVED("Resolved", 2);

    private String stringValue;
    private int idValue;

    private DetectionAddressStateEnum(String toString, int id){
        stringValue = toString;
        idValue = id;
    }

    public int getId(){
        return idValue;
    }

    public String toString(){
        return stringValue;
    }

    public static DetectionAddressStateEnum fromString(String text) throws IllegalArgumentException {
        for (DetectionAddressStateEnum d : DetectionAddressStateEnum.values()) {
            if (d.stringValue.equalsIgnoreCase(text)) {
                return d;
            }
        }
        throw new IllegalArgumentException("No DetectionAddressStateEnum with text " + text + " found");
    }

    public static DetectionAddressStateEnum fromId(int id) throws IllegalArgumentException {
        for (DetectionAddressStateEnum d : DetectionAddressStateEnum.values()) {
            if (d.getId() == id) {
                return d;
            }
        }
        throw new IllegalArgumentException("No DetectionAddressStateEnum with text " + id + " found");
    }
}
