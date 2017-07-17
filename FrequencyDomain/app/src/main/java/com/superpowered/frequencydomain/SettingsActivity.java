package com.superpowered.frequencydomain;


import android.os.Build;
import android.support.v7.app.AppCompatActivity;

import android.os.Bundle;

import android.widget.Button;
import android.widget.EditText;

import android.view.View.OnClickListener;
import android.view.View;
import android.widget.RadioButton;

public class SettingsActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.settings);

        Button cutFButton = (Button) findViewById(R.id.SetCutF);
        final EditText inputFreq = (EditText) findViewById(R.id.inputCutF);
        cutFButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                SetNewCutFrequency(Integer.parseInt(inputFreq.getText().toString()));
            }
        });

        Button detectionButton = (Button) findViewById(R.id.SetDetectionWindow);
        final EditText inputDetection = (EditText) findViewById(R.id.inputSetDetectionWindow);
        detectionButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                SetNewDetectionTime(Integer.parseInt(inputDetection.getText().toString()));
            }
        });

        Button rmsButton = (Button) findViewById(R.id.SetRMSWindow);
        final EditText inputrms = (EditText) findViewById(R.id.inputSetRMSWindow);
        rmsButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                SetNewRmsBuffer(Integer.parseInt(inputrms.getText().toString()));
            }
        });

        Button extremecutButton = (Button) findViewById(R.id.SetExtremeCut);
        final EditText inputExtremeCut = (EditText) findViewById(R.id.inputSetExtremeCut);
        extremecutButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                SetNewExtremeCut(Float.parseFloat(inputExtremeCut.getText().toString()));
            }
        });

        Button extremeMinButton = (Button) findViewById(R.id.SetExtremeMinimum);
        final EditText inputExtremeMin = (EditText) findViewById(R.id.inputSetExtremeMinimum);
        extremeMinButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                SetNewExtremeMinimum(Float.parseFloat(inputExtremeMin.getText().toString()));
            }
        });

        Button extremeBaseButton = (Button) findViewById(R.id.SetNewExtremeBase);
        final EditText inputExtremeBase = (EditText) findViewById(R.id.inputSetNewExtremeBase);
        extremeBaseButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                SetNewExtremeBase(Float.parseFloat(inputExtremeBase.getText().toString()));
            }
        });

        Button avgButton = (Button) findViewById(R.id.SetNewAVGType);
        final EditText inputTimes = (EditText) findViewById(R.id.inputMeanNtimes);
        final RadioButton avg0 = (RadioButton) findViewById(R.id.radioButtonMean);
        avg0.setChecked(true);
        final RadioButton avg1 = (RadioButton) findViewById(R.id.radioButtonVariance);
        final RadioButton avg2 = (RadioButton) findViewById(R.id.radioButtonTimes);
        final RadioButton avg3 = (RadioButton) findViewById(R.id.radioButtonX);
        avgButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                if(avg0.isChecked())
                {
                    SetNewAverageRmsType(0);
                }
                else if(avg1.isChecked())
                {
                    SetNewAverageRmsType(1);
                }
                else if(avg2.isChecked())
                {
                    SetNewRmsCustomVar(Integer.parseInt(inputTimes.getText().toString()));
                    SetNewAverageRmsType(2);
                }
                else if(avg3.isChecked())
                {
                    SetNewRmsCustomVar(Integer.parseInt(inputTimes.getText().toString()));
                    SetNewAverageRmsType(3);
                }
            }
        });
    }



    private native void SetNewCutFrequency(int f);
    private native void SetNewBufferSize(int buffer);
    private native void SetNewExtremeBase(float base);
    private native void SetNewAverageRmsType(int type);
    private native void SetNewRmsCustomVar(int var);
    private native void SetNewRmsBuffer(int lastSeconds);
    private native void SetNewDetectionTime(int lastMilliseconds);
    private native void SetNewExtremeCut(float percentage);
    private native void SetNewExtremeMinimum(float minimum);
}
