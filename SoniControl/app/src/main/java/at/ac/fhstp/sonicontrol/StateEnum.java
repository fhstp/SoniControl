package at.ac.fhstp.sonicontrol;

/**
 * Created by aringot on 10.01.2018.
 */

public enum StateEnum {
    /***
     * WARNING: Changing the String values would make the app incompatible with previous version.
     * (The Strings are used to persist values in SharedPreferences)
     */
    ON_HOLD("On hold"),
    SCANNING("Scanning"),
    JAMMING("Jamming");

    private String stringValue;

    private StateEnum(String toString){
        stringValue = toString;
    }

    public String toString(){
        return stringValue;
    }

    public static StateEnum fromString(String text) throws IllegalArgumentException {
        for (StateEnum s : StateEnum.values()) {
            if (s.stringValue.equalsIgnoreCase(text)) {
                return s;
            }
        }
        throw new IllegalArgumentException("No StateEnum with text " + text + " found");
    }
}
