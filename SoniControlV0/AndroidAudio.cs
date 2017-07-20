using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.Media;
using Android.Media.Audiofx;
using Java.Lang;
using SoniControlV0;
using SoundAnalysis;
using Thread = System.Threading.Thread;

namespace Core
{
    public delegate void NewFFTData(object sender, double[] data);


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

        public event NewFFTData NewFFTDataAvailable;

        protected virtual void OnNewFFTDataAvailable(double[] data)
        {
            NewFFTDataAvailable?.Invoke(this, data);
        }

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

                //short[] pre = BufferCopy(_audioBuffer, _buffersize, runs * _buffersize);
                //double[] data = Array.ConvertAll(pre, x => (double)x);
                //double[] spectr = FftAlgorithm.Calculate(data);
                double[] spectr = FftAlgorithm.Calculate(
                                    Array.ConvertAll(
                                        BufferCopy(_audioBuffer, _buffersize, runs * _buffersize), 
                                        x => (double)x
                                    )
                                );
                OnNewFFTDataAvailable(spectr);
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

            await _aut.WriteAsync(_audioBuffer, 0, runs*_buffersize);

        }

        public async Task ShowAudio()
        {
            
        }

        public short[] BufferCopy(short[] from, int count, int index)
        {
            const int SHORT_SIZE = 2;
            short[] to = new short[count];

            Buffer.BlockCopy(from, index * SHORT_SIZE, to, 0, count* SHORT_SIZE);

            return to;
        }

        public async Task<double[]> AnalyzeAudio()
        {
            double[] spectr = FftAlgorithm.Calculate(
                                    Array.ConvertAll(
                                        BufferCopy(_audioBuffer, runs * _buffersize, 0),
                                        x => (double)x
                                    )
                                );

            return spectr;
            /*
            int usefullMinSpectr = System.Math.Max(0,
                (int)(14000 * spectr.Length / _sampleRate));
            int usefullMaxSpectr = System.Math.Min(spectr.Length,
                (int)(21000 * spectr.Length / _sampleRate) + 1);

            // find peaks in the FFT frequency bins 
            const int PeaksCount = 50;
            int[] peakIndices;
            peakIndices = FftAlgorithm.FindPeaks(spectr, usefullMinSpectr, usefullMaxSpectr - usefullMinSpectr,
                PeaksCount);

            if (Array.IndexOf(peakIndices, usefullMinSpectr) >= 0)
            {
                // lowest usefull frequency bin shows active
                // looks like is no detectable sound, return 0
                Console.Out.WriteLine("Nothing");
                return new int[0];
            }
            Console.Out.WriteLine("Something");

            return peakIndices;
            //return spectr.Take(spectr.Length/2+1).ToArray();*/
        }
    }
}