cd 'D:\Daten\Projekt - SoniControl\17 Dev\spec'

%% File 1:
[data, fs] = audioread('D:\Clouds\Dropbox (FH St. Pölten)\SoniControlShare\Audio\10cm\radon\20170301_radon_sen_10cm-2.wav');
inputSeg = data(1:300000);
%inputSeg = data(300000:600000);


%% File 2:

%inputSeg = data(340000:540000);
%% Compute Spectrogram

%inputSeg = data;
win = 60; %ms
overlap = win-20; %ms
[s,f,t,p] = spectrogram(inputSeg, round(fs/1000*win), round(fs/1000*overlap),[17000:1:20100],fs);
p=log(p);

s = abs(s);
plotSpectrogram(p,f,t);

%figure; imagesc(p); set(gca,'YDir','normal')

%% Apply Highpass Filter
Fstop = 17500;
Fpass = 18000;
Astop = 65;
Apass = 0.5;


d = designfilt('highpassfir','StopbandFrequency',Fstop, ...
  'PassbandFrequency',Fpass,'StopbandAttenuation',Astop, ...
  'PassbandRipple',Apass,'SampleRate',fs,'DesignMethod','equiripple');

fvtool(d)

inputSeg = filter(d,inputSeg);

%spectrogram(dataOut);
figure; plot(inputSeg);
%a=audioplayer(dataOut,fs/3);
%a.play();


%% Bandpass Filter

dataOut=[];
frequencies = [17000:10:20100];
%frequencies = [19344];
bw=50;
for i=1:numel(frequencies)
d = designfilt('bandpassfir','FilterOrder',60, ...
         'CutoffFrequency1',frequencies(i)-bw,'CutoffFrequency2',frequencies(i)+bw, ...
         'SampleRate',fs);

%     d = designfilt('bandpassiir','FilterOrder',20, ...
%              'HalfPowerFrequency1',frequencies(i)-bw,'HalfPowerFrequency2',frequencies(i)+bw, ...
%              'SampleRate',fs);     
    %fvtool(d)

    dataOut(i,:) = filter(d,inputSeg);
end

%figure; plot(dataOut);
%figure; imagesc(dataOut);

figure1=plotSpectrogram(dataOut,frequencies,1:numel(inputSeg));

%% Comb-Filter Bank:

dataOut=[];
frequencies = [16000:20:20100];

for i=1:numel(frequencies)
    
    sig=generateCosineFunction(frequencies(i), 0.001, fs);
    dataOut(i,:) = conv(inputSeg,sig,'same');
end

figure1=plotSpectrogram(dataOut,frequencies,1:numel(inputSeg));

%% SpectradataOut=[];
dataOut=[];
dataOutFull=[];
winSize = 30; %ms
winSizeSamples = round(fs/1000*winSize);
step = round(winSizeSamples/100);
cutoffFrequency = 18000;
frequencies = linspace(0,round(fs/2),winSizeSamples/2+1);
[v,cutoffIdx]=min(abs(frequencies - cutoffFrequency)); %get frequency index of cutoff frequency
frequencies = frequencies(cutoffIdx:end);
nPeaks = 5;
windowPos = 1:step:numel(inputSeg)-winSizeSamples;
nWindowPos = numel(windowPos);
signalDuration = numel(inputSeg)/fs; %unit: seconds
times = linspace(0,signalDuration,nWindowPos);
for i=windowPos
    spec = (abs(fft(inputSeg(i:i+winSizeSamples))));
    hHalf = round(numel(spec)/2);
    spec=spec(1:hHalf);
    
    spec = spec(cutoffIdx:end); %remove all content below cutoff frequency:
    
    dataOutFull(:,end+1)=spec; %store entire spectrum in global array
    
    helper = sort(spec,'descend'); %set all to 0 except strongest n peaks
    spec(spec<helper(nPeaks)) = 0;

    dataOut(:,end+1)=spec; %store filtered spectrum in global array
end

%plot spectrogram
plotSpectrogram(dataOut, frequencies, times);

%plot histogram over filtered spectra
freqHist = sum(dataOut,2);
[peaks, locs] = findpeaks(freqHist,'Threshold',30);
plotSpectrum(freqHist, frequencies,locs);
locFrequencies = frequencies(locs)



%plot histogram over unfiltered spectra
freqHistFull = sum(dataOutFull,2);
[peaks, locs] = findpeaks(freqHistFull,'Threshold',30);
plotSpectrum(freqHistFull, frequencies,locs);
locFrequencies = frequencies(locs)
