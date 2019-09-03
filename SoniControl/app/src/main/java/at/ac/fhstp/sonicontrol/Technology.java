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


public enum Technology {
    /***
     * WARNING: Changing the String values would make the app incompatible with previous version.
     * (The Strings are used to persist values in SharedPreferences)
     */
    PRONTOLY("Prontoly", 2),
    GOOGLE_NEARBY("Google_Nearby", 1),
    LISNR("Lisnr", 7),
    SIGNAL360("Signal360", 4),
    SHOPKICK("Shopkick", 5),
    UNKNOWN("Unknown", 0),
    SILVERPUSH("Silverpush", 6),
    SONARAX("Sonarax", 3),
    SONITALK("SoniTalk", 8);

    private String stringValue;
    private int idValue;

    private Technology(String toString, int id){
        stringValue = toString;
        idValue = id;
    }

    public int getId(){
        return idValue;
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

    public static Technology fromId(int id) throws IllegalArgumentException {
        for (Technology t : Technology.values()) {
            if (t.getId() == id) {
                return t;
            }
        }
        throw new IllegalArgumentException("No Technology with text " + id + " found");
    }
}
