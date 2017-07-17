%Java implementations: https://stackoverflow.com/questions/15226814/standard-fft-classes-library-for-android
%-->https://sites.google.com/site/piotrwendykier/software/jtransforms
%-->https://stackoverflow.com/questions/28243803/getting-back-original-signal-using-jtransform-method-realinverse

pkg load signal;
%specify fs and length of white noise signal
fs=44100;
winLen = 500; %millisecongs


%compute cutoff frequency for DCT:
%sig = rand(1,winLen*fs/1000);
freqRes = (fs/2) / (winLen/2*fs/1000);
frequencies = 0:freqRes:(fs/2); 
cutoffFreq = 18000; %Hz
[~,i]=min(abs(frequencies-cutoffFreq));

fixedRandomNumbers = load('C:\Users\Otakusarea\Desktop\whiteNoise_numberSet.txt');


%generate spectrum and apply highpass filter
%sigDCT = dct(sig);
sig = rand(1,winLen*fs/1000);
%sigFFT = fft(sig);
sigFFT = fft(fixedRandomNumbers);
%sigFFT = sigFFT(1:round(end/2));
sigFFT(1:i) = 0; 
sigFFT((winLen*fs/1000)-i+1:(winLen*fs/1000)) = 0; 
%inverse FFT
%sigRec = real(ifft(sigFFT));
sigRec = real(fft(-sigFFT));
helper=[];
helper(1:2:numel(sigFFT)*2) = real(sigFFT);
helper(2:2:numel(sigFFT)*2+1) = imag(sigFFT);
 

csvwrite('d:\fftCoeffs.txt',helper);

maxValue = max(abs(sigRec));
p=audioplayer(sigRec/maxValue,fs);
play(p);
whiteOutput = sigRec/maxValue;
audiowrite('d:\whitenoiseAfterinverse.wav',whiteOutput, 44100);
csvwrite('d:\whitenoiseAfterinverse.txt',sigRec/maxValue);

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
if ~isOctave
[s,f,t,p] = spectrogram(sigRec, round(fs/1000*win), round(fs/1000*overlap),frequencyRange,fs);
    plotSpectrogram(log(p),f,t);
    else
    [s,f,t] = specgram(sigRec, round(fs/1000*win),fs,round(fs/1000*overlap),frequencyRange);
    plotSpectrogram(log(abs(s)),f,t);
end