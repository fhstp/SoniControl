# Add project specific ProGuard rules here.
# By default, the flags in this file are appended to flags specified
# in C:\Users\SoniControl#1\AppData\Local\Android\Sdk/tools/proguard/proguard-android.txt
# You can edit the include path and order by changing the proguardFiles
# directive in build.gradle.
#
# For more details, see
#   http://developer.android.com/guide/developing/tools/proguard.html

# Add any project specific keep options here:

# This method is only called from native code and would otherwise be removed by the code shrinker
-keep class at.ac.fhstp.sonicontrol.Scan {
    void detectedSignal(java.lang.String);
}

# To get the library org.apache.commons.math3.geometry.euclidean.threed.PolyhedronsSet$RotationTransform to work, we need these:
-dontwarn java.awt.**
# To get the library pl.edu.icm:JLargeArrays to work, we need these:
#-keep class sun.misc.** {*;}
#-libraryjars libs/pl.edu.icm:JLargeArrays:1.6

# If your project uses WebView with JS, uncomment the following
# and specify the fully qualified class name to the JavaScript interface
# class:
#-keepclassmembers class fqcn.of.javascript.interface.for.webview {
#   public *;
#}

# Uncomment this to preserve the line number information for
# debugging stack traces.
-keepattributes SourceFile,LineNumberTable

# If you keep the line number information, uncomment this to
# hide the original source file name.
-renamesourcefileattribute SourceFile