using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media.Audiofx;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SoniControlV0
{
    class IVisualizerFFT : Java.Lang.Object, Visualizer.IOnDataCaptureListener
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IntPtr Handle { get; }
        public void OnFftDataCapture(Visualizer visualizer, byte[] fft, int samplingRate)
        {
            throw new NotImplementedException();
        }

        public void OnWaveFormDataCapture(Visualizer visualizer, byte[] waveform, int samplingRate)
        {
            throw new NotImplementedException();
        }
    }
}