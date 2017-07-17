%specify fs and length of white noise signal
fs=44100;
winLen = 500; %milliseconds

%compute cutoff frequency for DCT:
%sig = rand(1,winLen*fs/1000);
freqRes = (fs/2) / (winLen*fs/1000);
frequencies = 0:freqRes:(fs/2);
cutoffFreq = 18000; %Hz
[~,i]=min(abs(frequencies-cutoffFreq));

cutoffFreqIdx = round(cutoffFreq/(fs/2)*(winLen*(fs/1000))+1)

%generate spectrum and apply highpass filter
%sigDCT = dct(sig);
sigDCT = rand(1,winLen*fs/1000);
%sigDCT = ones(1,winLen*fs/1000) / (winLen*fs/1000);
sigDCT(1:i-1) = 0; 

%inverse DCT
sigRec = idct(sigDCT.*100);
%fade



p=audioplayer(sigRec,fs);
%p.play();
play(p);

%plot time-domain signal
%figure; plot(log(sigDCT-min(sigDCT)));

%plot spectrum
figure; plot(sigRec);
sigFFT = log(abs(fft(sigRec)));
sigFFT=sigFFT(1:floor(end/2));
fResFFT=(fs/2) / numel(sigFFT);
freqFFT=0:fResFFT:fs/2;
plotSpectrum(sigFFT, freqFFT(1:end-1))

%plot spectrogram
win=20;
overlap=10;
frequencyRange=[0:1:22050];
%[s,f,t,p] = specgram(sigRec, round(fs/1000*win), round(fs/1000*overlap),frequencyRange,fs);
[s,f,t] = specgram(sigRec, round(fs/1000*win),fs,round(fs/1000*overlap),frequencyRange);
    plotSpectrogram(log(abs(s)),f,t);
    