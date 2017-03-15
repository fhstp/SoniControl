using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Core;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;

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
            Button alButton = FindViewById<Button>(Resource.Id.AnalyzeRecording);
            AndroidAudio aa = new Core.AndroidAudio();

            startButton.Enabled = true;
            stopButton.Enabled = false;
            playButton.Enabled = false;
            alButton.Enabled = true;
            startButton.Click += async delegate
            {
                startButton.Enabled = false;
                stopButton.Enabled = true;
                playButton.Enabled = false;
                alButton.Enabled = false;
                statusText.Text = "Starting Recording";
                await aa.StartAsyncRecording();
                //aa.RecordingStateChanged()
                statusText.Text = "Recorded";
                startButton.Enabled = true;
                stopButton.Enabled = false;
                playButton.Enabled = true;
                alButton.Enabled = false;
            };

            stopButton.Click += delegate
            {
                startButton.Enabled = true;
                stopButton.Enabled = false;
                playButton.Enabled = true;
                alButton.Enabled = false;
                statusText.Text = "Stopped Recording";
                aa.StopAsyncRecording();
            };

            playButton.Click += async delegate
            {
                startButton.Enabled = false;
                stopButton.Enabled = false;
                playButton.Enabled = false;
                alButton.Enabled = false;

                await aa.StartPlayBackAsync();

                startButton.Enabled = true;
                stopButton.Enabled = false;
                playButton.Enabled = true;
                alButton.Enabled = true;
            };

            PlotView view = FindViewById<PlotView>(Resource.Id.plotView1);


            alButton.Click += delegate
            {
                //byte[] raw = new byte[1000];
                //aa.vis.GetFft(raw);
                view.Model = CreatePlotModel();

                
            };


        }

        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel() {Title = "TestPlot"};
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom});
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0});

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;
        }

    }
}

