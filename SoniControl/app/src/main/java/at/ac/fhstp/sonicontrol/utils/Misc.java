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

package at.ac.fhstp.sonicontrol.utils;

import android.app.Activity;
import android.preference.PreferenceManager;

import java.util.HashMap;

/**
 * This class is inspired from an app written by Guillaume Adam
 *  (see https://bitbucket.org/galmiza/spectrogram-android)
 *
 */
public class Misc {

    private static HashMap<String,Object> map = new HashMap<String,Object>();
    public static Object getAttribute(String s)	{ return map.get(s); }
    public static void setAttribute(String s, Object o)	{ map.put(s, o); }

    public static void setPreference(Activity a, String key, boolean value) {	PreferenceManager.getDefaultSharedPreferences(a).edit().putBoolean(key, value).commit();	}
    public static void setPreference(Activity a, String key, float value) {		PreferenceManager.getDefaultSharedPreferences(a).edit().putFloat(key, value).commit();	}
    public static void setPreference(Activity a, String key, int value) {		PreferenceManager.getDefaultSharedPreferences(a).edit().putInt(key, value).commit();	}
    public static void setPreference(Activity a, String key, long value) {		PreferenceManager.getDefaultSharedPreferences(a).edit().putLong(key, value).commit();	}
    public static void setPreference(Activity a, String key, String value) {	PreferenceManager.getDefaultSharedPreferences(a).edit().putString(key, value).commit();	}

    public static boolean getPreference(Activity a, String key, boolean def) {	return PreferenceManager.getDefaultSharedPreferences(a).getBoolean(key, def);	}
    public static float getPreference(Activity a, String key, float def) {		return PreferenceManager.getDefaultSharedPreferences(a).getFloat(key, def);	}
    public static int getPreference(Activity a, String key, int def) {			return PreferenceManager.getDefaultSharedPreferences(a).getInt(key, def);	}
    public static long getPreference(Activity a, String key, long def) {		return PreferenceManager.getDefaultSharedPreferences(a).getLong(key, def);	}
    public static String getPreference(Activity a, String key, String def) {	return PreferenceManager.getDefaultSharedPreferences(a).getString(key, def);	}
    public static String getPreference(String key, String def) {	return getPreference(getActivity(), key, def);	}
    public static Activity getActivity() {
        return (Activity) getAttribute("activity");
    }
}

