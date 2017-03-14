using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Android.Media;

namespace Core
{
    public class AndroidAudio
    {
        private AudioRecord _aur = null;
        private AudioTrack _aut= null;

        private byte[] _audioBuffer = null;

        private bool _isRecording = false;
        private bool _endRecording = false;

        public Action<bool> RecordingStateChanged;

        private static string _filepath = "/data/data/SoniControlV0.SoniControlV0/files/recording.mp4";

        private int sampleRate = 44100;


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

            _audioBuffer = new byte[100000];
            _aur = new AudioRecord(
                AudioSource.Mic, 
                10000, 
                ChannelIn.Stereo, 
                Android.Media.Encoding.Pcm16bit, 
                _audioBuffer.Length
            );

            _aur.StartRecording();
            await ReadAudioTask();
            
        }

        async Task ReadAudioTask()
        {
            using (var filestream = new FileStream(_filepath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                StopAfterSeconds();
                while (true)
                {
                    if (_endRecording)
                    {
                        _endRecording = false;
                        break;
                    }

                    try
                    {
                        int readBytes = await _aur.ReadAsync(_audioBuffer, 0, _audioBuffer.Length);
                        Console.Out.WriteLine(""+readBytes);
                        await filestream.WriteAsync(_audioBuffer, 0, readBytes);
                    }
                    catch (Exception eo)
                    {
                        Console.Out.WriteLine(eo.Message);
                    }
                }

                filestream.Close();
            }

            _aur.Stop();
            _aur.Release();
            _isRecording = false;
            FireRecordingStateChanged();
            Console.Out.WriteLine("END");
        }

        public async void StopAfterSeconds()
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
            FileStream fileStream = new FileStream(_filepath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            long totalBytes = new System.IO.FileInfo(_filepath).Length;
            _audioBuffer = binaryReader.ReadBytes((Int32)totalBytes);
            fileStream.Close();
            fileStream.Dispose();
            binaryReader.Close();
            await PlayAudioTrackTask();
        }

        protected async Task PlayAudioTrackTask()
        {
            _aut = new AudioTrack(
                Android.Media.Stream.Music,
                10000,
                ChannelOut.Stereo,
                Android.Media.Encoding.Pcm16bit,
                _audioBuffer.Length,
                AudioTrackMode.Stream
            );

            _aut.Play();
            await _aut.WriteAsync(_audioBuffer, 0, _audioBuffer.Length);

        }


    }
}