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


import android.content.Context;
import android.os.Environment;
import android.util.Log;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.ByteBuffer;
import java.nio.channels.FileChannel;

public class SignalConverter {

    public static void writeFloatArray(float[] floatArray, String filePath) {
        Log.d("writeFloatBuffer", filePath);
        RandomAccessFile randomAccessWriter = null;
        try {
            randomAccessWriter = new RandomAccessFile(filePath, "rw");
            Log.d("writeFloatBuffer", "File created");

            FileChannel outChannel = randomAccessWriter.getChannel();

            //one float 4 bytes
            ByteBuffer buf = ByteBuffer.allocate(4*floatArray.length);
            buf.clear();
            buf.asFloatBuffer().put(floatArray);

            outChannel.write(buf);

            outChannel.close();
            Log.d("writeFloatBuffer", "File written");

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (randomAccessWriter != null) {
                try {
                    randomAccessWriter.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public static float[] readFloatArray(String filePath, int arrayLength) {
        RandomAccessFile randomAccessReader = null;
        try {
            randomAccessReader = new RandomAccessFile(filePath, "r");

            float[] floatArray = new float[arrayLength];

            FileChannel inChannel = randomAccessReader.getChannel();
            ByteBuffer buf_in = ByteBuffer.allocate(arrayLength*4);
            buf_in.clear();

            inChannel.read(buf_in);

            buf_in.rewind();
            buf_in.asFloatBuffer().get(floatArray);

            inChannel.close();

            return floatArray;

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (randomAccessReader != null) {
                try {
                    randomAccessReader.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
        return null;
    }

    public static void writeToCSV(float[] dataArray, Context context){
        FileWriter writer = null;
        String root = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DCIM).toString();
        File myDir = new File(root+ "/detection.csv");
        try {
            writer = new FileWriter(myDir);
        } catch (IOException e) {
            e.printStackTrace();
        }

        for (int j = 0; j < dataArray.length; j++) {
            try {
                writer.append(String.valueOf(dataArray[j]));
            } catch (IOException e) {
                e.printStackTrace();
            }
            try {
                writer.append("\n");
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        try {
            writer.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void writeWAVHeaderToFile(/*byte[] rawdata, */float[] rawFloat, Context context, int maxValueIndex) {
        RandomAccessFile randomAccessWriter = null;
        try {
            randomAccessWriter = new RandomAccessFile(context.getFilesDir()+ "/detection.wav", "rw");
            Log.d("writeWAVHeaderToFile", context.getFilesDir()+ "/detection.wav");
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        short nChannels = 1;
        int sampleRate = 44100;
        short bSamples = 32;
        int payloadSize = rawFloat.length*4;
        try {
            randomAccessWriter.setLength(0); // Set file length to 0, to prevent unexpected behavior in case the file already existed
            randomAccessWriter.writeBytes("RIFF");
            randomAccessWriter.writeInt(Integer.reverseBytes(72+payloadSize));
            randomAccessWriter.writeBytes("WAVE");
            randomAccessWriter.writeBytes("fmt ");
            randomAccessWriter.writeInt(Integer.reverseBytes(16)); // Sub-chunk size, 16 for PCM
            randomAccessWriter.writeShort(Short.reverseBytes((short) 3)); // AudioFormat, 1 for PCM
            randomAccessWriter.writeShort(Short.reverseBytes(nChannels)); // Number of channels, 1 for mono, 2 for stereo
            randomAccessWriter.writeInt(Integer.reverseBytes(sampleRate)); // Sample rate
            randomAccessWriter.writeInt(Integer.reverseBytes(sampleRate*bSamples*nChannels/8)); // Byte rate, SampleRate*NumberOfChannels*BitsPerSample/8
            randomAccessWriter.writeShort(Short.reverseBytes((short)(nChannels * bSamples / 8))); // Block align, NumberOfChannels*BitsPerSample/8
            randomAccessWriter.writeShort(Short.reverseBytes(bSamples)); // Bits per sample
            randomAccessWriter.writeBytes("fact");
            randomAccessWriter.writeInt(Integer.reverseBytes(4));
            randomAccessWriter.writeInt(Integer.reverseBytes(payloadSize/(bSamples/8)));
            randomAccessWriter.writeBytes("PEAK");
            randomAccessWriter.writeInt(Integer.reverseBytes(16));
            randomAccessWriter.writeInt(Integer.reverseBytes(1));
            //Log.d("SignalConverter", String.valueOf((int) Math.floor((float)System.currentTimeMillis()/1000)));
            randomAccessWriter.writeInt(Integer.reverseBytes((int) Math.floor((float)System.currentTimeMillis()/1000))); //current timestamp in seconds
            //randomAccessWriter.writeInt(Integer.reverseBytes(1024434463));
            randomAccessWriter.writeInt(Integer.reverseBytes(Float.floatToIntBits(rawFloat[maxValueIndex])));
            randomAccessWriter.writeInt(Integer.reverseBytes(maxValueIndex));//index of max value of float array
            randomAccessWriter.writeBytes("data");
            randomAccessWriter.writeInt(Integer.reverseBytes(payloadSize));

            for(int i = 0; i< rawFloat.length;i++){
                randomAccessWriter.writeInt(Integer.reverseBytes(Float.floatToIntBits(rawFloat[i])));
            }
            //randomAccessWriter.write(rawdata, 0, payloadSize);
            Log.d("writeWAVHeaderToFile", "Done writing audio");
        } catch (Exception e) {
            if (e.getMessage() != null) {
                Log.e("SignalConverter", e.getMessage());
            } else {
                Log.e("SignalConverter", "Unknown error occured in prepare()");
            }
        } finally {
            try {
                randomAccessWriter.close(); // Remove prepared file
            } catch (IOException e) {
                Log.e("SignalConverter", "I/O exception occured while closing output file");
            }
        }
    }
}
