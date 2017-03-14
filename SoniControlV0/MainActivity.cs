using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using Core;

namespace SoniControlV0
{
    [Activity(Label = "SoniControl V0", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            TextView statusText = FindViewById<TextView>(Resource.Id.RecordStatus);

            Button startButton = FindViewById<Button>(Resource.Id.StartRecording);
            Button stopButton = FindViewById<Button>(Resource.Id.StopRecording);
            Button playButton = FindViewById<Button>(Resource.Id.PlayRecording);
            Button haltButton = FindViewById<Button>(Resource.Id.HaltRecording);
            AndroidAudio aa = new Core.AndroidAudio();


            startButton.Click += async delegate
            {
                startButton.Enabled = false;
                stopButton.Enabled = true;
                playButton.Enabled = false;
                haltButton.Enabled = false;
                statusText.Text = "Starting Recording";
                await aa.StartAsyncRecording();
                //aa.RecordingStateChanged()
                statusText.Text = "Recorded";
            };

            stopButton.Click += delegate
            {
                startButton.Enabled = true;
                stopButton.Enabled = false;
                playButton.Enabled = false;
                haltButton.Enabled = false;
                statusText.Text = "Stopped Recording";
                aa.StopAsyncRecording();
            };

            playButton.Click += async delegate
            {
                startButton.Enabled = false;
                stopButton.Enabled = false;
                playButton.Enabled = false;
                haltButton.Enabled = true;

                await aa.StartPlayBackAsync();

                startButton.Enabled = true;
                stopButton.Enabled = false;
                playButton.Enabled = true;
                haltButton.Enabled = false;
            };

            stopButton.Click += async delegate
            {
                startButton.Enabled = true;
                stopButton.Enabled = false;
                playButton.Enabled = true;
                haltButton.Enabled = false;

                await aa.StopPlayBackAsync();
            };


        }
    }
}

