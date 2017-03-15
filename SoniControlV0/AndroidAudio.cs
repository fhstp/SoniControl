using System;
using System.IO;
using System.Threading.Tasks;

using Android.Media;
using Android.Media.Audiofx;
using Java.Lang;
using SoniControlV0;
using Thread = System.Threading.Thread;

namespace Core
{
    public class AndroidAudio
    {
        private AudioRecord _aur = null;
        private AudioTrack _aut= null;

        private short[] _audioBuffer = null;

        private bool _isRecording = false;
        private bool _endRecording = false;

        public Action<bool> RecordingStateChanged;

        private static string _filepath = "/data/data/SoniControlV0.SoniControlV0/files/recording.mp4";

        private int _sampleRate = 44100;
        private Encoding _encoding = Android.Media.Encoding.Pcm16bit;
        private int _buffersize;
        private int runs;
        public Visualizer vis;

        public bool IsRecording
        {
            get { return _isRecording; }
        }

        public void StopAsyncRecording()
        {
            _endRecording = true;
            Thread.Sleep(500);
        }

        public async Task StartAsyncRecording()
        {
            await RecordingTask();
        }

        private void FireRecordingStateChanged()
        {
            if (RecordingStateChanged != null)
                RecordingStateChanged(_isRecording);
        }

        protected async Task RecordingTask()
        {
            _isRecording = true;
            _endRecording = false;
            FireRecordingStateChanged();

            _buffersize = AudioRecord.GetMinBufferSize(_sampleRate, ChannelIn.Mono, _encoding);
            _audioBuffer = new short[500000];

            _aur = new AudioRecord(
                AudioSource.Mic,
                _sampleRate, 
                ChannelIn.Mono, 
                _encoding, 
                _buffersize
            );
            
            _aur.StartRecording();
            await ReadAudioTask();
        }

        async Task ReadAudioTask()
        {
            runs = 0;
            StopAfterSeconds();

            do
            {
                int readBytes = await _aur.ReadAsync(_audioBuffer, runs * _buffersize, _buffersize);
                runs++;

            } while (_endRecording == false && runs * _buffersize < _audioBuffer.Length - _buffersize);

            _aur.Stop();
            _isRecording = false;
            _aur.Release();
            FireRecordingStateChanged();

            Console.Out.WriteLine("END");
            Console.Out.WriteLine(_buffersize);
            Console.Out.WriteLine(runs);
        }

        public async Task StopAfterSeconds()
        {
            await Task.Delay(2000);
            _endRecording = true;
        }

        public async Task StartPlayBackAsync()
        {
            await PlayBackTask();
        }

        public async Task StopPlayBackAsync()
        {
            if (_aut != null)
            {
                _aut.Stop();
                _aut.Release();
                _aut = null;
            }
        }

        public async Task PlayBackTask()
        {
            await PlayAudioTrackTask();
        }

        protected async Task PlayAudioTrackTask()
        {
            _aut = new AudioTrack(
                Android.Media.Stream.Music,
                _sampleRate,
                ChannelOut.Mono,
                _encoding,
                _buffersize,
                AudioTrackMode.Stream
            );

            
            _aut.Play();

            vis = new Visualizer(_aut.AudioSessionId);
            vis.SetCaptureSize(Visualizer.GetCaptureSizeRange()[0]);
            await _aut.WriteAsync(_audioBuffer, 0, runs*_buffersize);
            
            vis.SetEnabled(true);
            vis.SetDataCaptureListener(new IVisualizerFFT(), Visualizer.MaxCaptureRate, false, true);



        }
    }
}