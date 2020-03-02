/*
 * Copyright (c) 2018, 2019, 2020. Peter Kopciak, Kevin Pirner, Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
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
