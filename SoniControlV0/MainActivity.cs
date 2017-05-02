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
        private LineSeries spectro = new LineSeries
        {
            MarkerType = MarkerType.Circle,
            MarkerSize = 1,
            MarkerStroke = OxyColors.White
        };

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

                //aa.NewFFTDataAvailable += new NewFFTData(AddFFTDataToSeries);
                await aa.StartAsyncRecording();
                //aa.NewFFTDataAvailable -= new NewFFTData(AddFFTDataToSeries);

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

            PlotView view = GetPlotView();
            var plotModel = new PlotModel() { Title = "AudioData" };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 100000.0, Minimum = -1.0 });
            plotModel.Series.Add(spectro);
            view.Model = plotModel;

            alButton.Click += async delegate
            {
                Console.Out.WriteLine("start");

                double[] data = await aa.AnalyzeAudio();
                Console.Out.WriteLine("stop");


                spectro = new LineSeries
                {
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 1,
                    MarkerStroke = OxyColors.White
                };

                for (int i = 0; i < data.Length; i++)
                {
                    spectro.Points.Add(new DataPoint(i, data[i]));
                }

                GetPlotView().InvalidatePlot();
            };


        }

        private PlotView GetPlotView()
        {
            return FindViewById<PlotView>(Resource.Id.plotView1);
        }

        private void AddFFTDataToSeries(object sender, double[] data)
        {
            int start = spectro.Points.Count;

            for (int i = 0; i < data.Length; i++)
            {
                spectro.Points.Add(new DataPoint(start + i, data[i]));
            }
            //GetPlotView().InvalidatePlot();
            Console.Out.WriteLine(data.Length);
        }


    }
}

