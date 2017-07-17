pkg load signal;
pkg load video;
## 'D:\Daten\Projekt - SoniControl\17 Dev\spec'
cd 'C:\Octave\Octave-4.2.1\share\octave\packages\video-1.2.3'
%% Parameters

%Spectrogram
win = 60; %ms
overlap = 40; %ms
frequencyRange = [17000:1:21100];

%Hipass Filter
Fstop = 17500;
Fpass = 18000;
Astop = 65;
Apass = 0.5;
fs = 44100;

[b,a] = butter(20,Fstop/(fs./2),'high');
hiPassFilt = [b,a];
##hiPassFilt = designfilt('highpassfir','StopbandFrequency',Fstop, ...
##  'PassbandFrequency',Fpass,'StopbandAttenuation',Astop, ...
##  'PassbandRipple',Apass,'SampleRate',fs,'DesignMethod','equiripple');
##fvtool(hiPassFilt)
##sos = zp2sos(A,B,C);
##fvtool(sos,'Analysis','freq')
[H,w] = freqz(b,a);
#figure() ; plot(abs(H))
figure;
freqs_plot((w.*(fs./2))./max(w),abs(H),'-k','Amplitude Response',...
         'Frequency (Hz)', 'Gain');

%Own Spectrogram parameters
winSize = 240; %ms
increment = 5; %ms
cutoffFrequency = 18000;
nPeaks = 10;

%Nearby Decoding Parameters
nBands=64;
bw=(20000-18500)./nBands*2;
centerFrequencies = linspace(18500,20000,nBands);
%generate filterbank
fb=[];
for i=1:numel(centerFrequencies)
%     fb(i).filter = designfilt('bandpassfir','FilterOrder',90, ...
%          'CutoffFrequency1',centerFrequencies(i)-bw/4,'CutoffFrequency2',centerFrequencies(i)+bw/4, 'SampleRate',fs);

  
    [fb(i).c,fb(i).d] = butter(4,[(centerFrequencies(i)-bw) (centerFrequencies(i)+bw)]/(fs./2));
    [c,d] = butter(4,[(centerFrequencies(i)-bw) (centerFrequencies(i)+bw)]/(fs./2));
    %[c,d] = butter(10,[Fstop Fpass]/(fs./2));
    #fb(i).filter  = designfilt('bandpassiir','FilterOrder',20, ...
    #fb(i).filter  = designfilt('bandpassiir','FilterOrder',20, ...
    #         'HalfPowerFrequency1',centerFrequencies(i)-bw,'HalfPowerFrequency2',centerFrequencies(i)+bw, ...
    #         'SampleRate',fs);     
    %fvtool(fb(i).filter)
    
    [H,w] = freqz(c,d);
%    figure() ; plot(abs(H))
#    figure;
#    freqs_plot((w.*(fs./2))./max(w),abs(H),'-k','Amplitude Response',...
#             'Frequency (Hz)', 'Gain');
             
end

%lpFilt = designfilt('lowpassiir','FilterOrder',8, 'PassbandFrequency',60,'PassbandRipple',0.2, 'SampleRate',fs);
%fvtool(lpFilt)



%% Files:

%folder = 'D:\Clouds\Dropbox (FH St. Pölten)\SoniControlShare\Audio\10cm\radon';
#folder = 'D:\Clouds\Dropbox (FH St. Pölten)\SoniControlShare\Audio\cleanrootcaptures\cleanrootcaptures';
folder = 'C:\Users\SoniControl#2\Desktop\audio';
d = dir([folder filesep '*.wav']);
nFiles = size(d,1);

for idxFile = 1%:nFiles
    %% read data
    [data, fs] = audioread([folder filesep d(idxFile).name]);
    data = data(:,1); %take first channel
    data = data(1:round(end/2));
    inputSeg = data;
    %inputSeg = data(1:300000);
    %inputSeg = data(300000:600000);
    
    %% compute spectrogram
    #[s,f,t,p] = spectrogram(inputSeg, round(fs/1000*win), round(fs/1000*overlap),frequencyRange,fs);
    [s,f,t] = specgram(inputSeg, round(fs/1000*win), fs, round(fs/1000*win), round(fs/1000*overlap));
    %p=abs(s)
    #plotSpectrogram(log(p),f,t);
    plotSpectrogram(log(abs(s)),f,t);
    
    %% Apply Highpass Filter
    #inputSeg = filter(hiPassFilt,inputSeg);
    inputSeg = filter(b,a,inputSeg);
    
    %% Compute my own spectrogam (much denser)
    mySpecPeaks=[];
    mySpecFull=[];

    winSizeSamples = round(fs/1000*winSize); %win Size in samples
    incSizeSamples = round(fs/1000*increment); %increment in samples
    frequencies = linspace(0,round(fs/2),winSizeSamples/2+1); %compute frequency of each entry in the spectrum
    [v,cutoffIdx]=min(abs(frequencies - cutoffFrequency)); %get frequency index of cutoff frequency
    frequencies = frequencies(cutoffIdx:end); %remove frequencies below cutoff frequencies
    windowPos = 1:incSizeSamples:numel(inputSeg)-winSizeSamples; % get indices where analysis windows start
    nWindowPos = numel(windowPos); %get number of analysis windows
    signalDuration = numel(inputSeg)/fs; %signal duration in unit: seconds
    times = linspace(0,signalDuration,nWindowPos); %compute time [seconds] for each analysis window 
    for i=windowPos % for all windows compute spectrum, assemble in a spectrogram
        spec = (abs(fft(inputSeg(i:i+winSizeSamples)))); %compute spectrum
        hHalf = round(numel(spec)/2); %remove one half (fft is symmetric)
        spec=spec(1:hHalf);
        spec = spec(cutoffIdx:end); %remove all content below cutoff frequency:

        mySpecFull(:,end+1)=spec; %store entire spectrum in global array

        helper = sort(spec,'descend'); %set all frequencies to 0 except strongest n peaks
        spec(spec<helper(nPeaks)) = 0;

        mySpecPeaks(:,end+1)=spec; %store filtered spectrum in global array
    end
    
    %plot spectrogram
    plotSpectrogram(mySpecPeaks, frequencies, times);
    plotSpectrogram(mySpecFull, frequencies, times);
    
    %plot histogram over filtered spectra
    freqHist = sum(mySpecPeaks,2);
    #[peaks, locs] = findpeaks(freqHist,'Threshold',30);
    [peaks, locs] = findpeaks(freqHist,'MinPeakHeight',30);
    plotSpectrum(freqHist, frequencies,locs);
    locFrequencies = frequencies(locs);
    
    %plot histogram over unfiltered spectra
    freqHistFull = sum(mySpecFull,2);
    #[peaks, locs] = findpeaks(freqHistFull,'Threshold',30);
    [peaks, locs] = findpeaks(freqHistFull,'MinPeakHeight',30);
    plotSpectrum(freqHistFull, frequencies,locs);
    locFrequencies = frequencies(locs);

    %% Decode Nearby Message
    win = 240;
   
    %g = fspecial('gaussian',[1, 500],100); figure; plot(g);
    overlap = 30;
    #[s,f,t,p] = spectrogram(inputSeg, round(fs/1000*win), round(fs/1000*overlap),centerFrequencies,fs);
    #plotSpectrogram(p,f,t);
    [s,f,t] = specgram(inputSeg, round(fs/1000*win), fs, round(fs/1000*win), round(fs/1000*overlap));
    plotSpectrogram(abs(s),f,t);
    
    response = zeros(nBands,numel(inputSeg));
    for i=1:numel(centerFrequencies)
        #currentBand = filter(fb(i).filter,inputSeg); %get current frequency band
        currentBand = filter(fb(i).c,fb(i).d,inputSeg); %get current frequency band
        env = abs(hilbert(currentBand)); %extract envelop
        response(i,:) = env;
        
        %figure; plot(abs(currentBand)); hold on;
        %plot(response(i,:),'r-'); hold on;
        
        %response(i,:) = filter(lpFilt,response(i,:));
        %response(i,:) = conv(response(i,:), g, 'same');
    end
        
    #plotSpectrogram(response(:, 1:220000),centerFrequencies,linspace(0,numel(inputSeg)/fs,numel(inputSeg)));
    %every pattern (in each freq. band) is sent 4 times (in a sequence)
    
    figure; plot(response(10,:)); title('signal envelope');
    
    %Period: 60 times in 3 seconds --> 20x per second --> 20 Hz Cutoff!
    
    %% Nearby Detection 
    slidingWin = 200; %ms
    slidingWinSamples = slidingWin*fs/1000;
    result = [];
    for i = 1:100:numel(inputSeg)-slidingWinSamples
        %result(end+1) = sum(autocorr(response(1,i:i+slidingWinSamples)));
        result(:,end+1)=sum(response(:,i:i+slidingWinSamples),2);
    end
    indicator = mean(result,1) > mean(result(:));
    figure; plot(indicator);
    
    %% Pause

    #pause

end

