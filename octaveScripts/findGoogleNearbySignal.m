pkg load signal;
pkg load video;
## 'D:\Daten\Projekt - SoniControl\17 Dev\spec'
cd 'C:\Octave\Octave-4.2.1\share\octave\packages\video-1.2.3'

folder = 'C:\Users\SoniControl#2\Desktop\audio';
d = dir([folder filesep '*.wav']);
nFiles = size(d,1);
win = 60; %ms
overlap = 40; %ms

for idxFile = 1%:nFiles
    %% read data
    [data, fs] = audioread([folder filesep d(idxFile).name]);
    data = data(:,1); %take first channel
    data = data(1:round(end/2));
    inputSeg = data;
    
    [s,f,t] = specgram(inputSeg, round(fs/1000*win), fs, round(fs/1000*win), round(fs/1000*overlap));
    plotSpectrogram(log(abs(s)),f,t);
end
