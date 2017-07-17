function score = detectNearby(fftSpectrum, specsNearby, frequencies)

% This approach did not work: the nearby frequencies vary too much. It was
% not possible to locate them exactly
% energyIn  = sum(fftSpectrum(specsNearby.centerFreqIdx));
% energyOut = sum(fftSpectrum(specsNearby.offFreqIdx));

%much easer: compute auto correlation:
%the autocorrelation must have peaks at lags that correspond to the spacing
%of the nearby frequencies

%ac = autocorr(fftSpectrum(specsNearby.centerFreqIdx(1):specsNearby.centerFreqIdx(end)));
ac = xcorr(fftSpectrum(specsNearby.centerFreqIdx(1):specsNearby.centerFreqIdx(end)));

%figure; plot(ac);

%compute a score: get the AC of the lag that correspons to the nearby
%frequency spacing and get the AC of the lag inbetween (1.5*nearby lag).
%The difference will be high for nearby signals. For white noise it will be
%close to zero
score = max(ac(specsNearby.centerFreqIdxDiff-1:specsNearby.centerFreqIdxDiff+1)) - ...
        max(ac(round(specsNearby.centerFreqIdxDiff*1.5)-1:round(specsNearby.centerFreqIdxDiff*1.5)+1));

    
%plot (only for debug mode):
if false
    plotSpectrum(fftSpectrum, frequencies, []);
    hold on;
    plot(specs.nearby.centerFreqIdx, fftSpectrum(specs.nearby.centerFreqIdx),'r*');
    plot(specs.nearby.offFreqIdx, fftSpectrum(specs.nearby.offFreqIdx),'g*');
end
%globalDetectionHelper(counter) = entropy(fftSpectrum(specsNearby.centerFreqIdx(1):specsNearby.centerFreqIdx(end)));
%Compute görtzel: NOT SO USEFUL HERE: IT DOES THE SAME AS FFT BUT
%ONLY FOR SELECTED FREQUENCIES!
%           if isOctave
%             freqData = gga(x,fvec,fs)
%           else
%             freqData = abs(goertzel(bufferHistory(:,1),specsNearby.centerFreqIdx));
%
%             freqDataFFT = abs(fft(bufferHistory(:,1)));
%             freqDataFFT = freqDataFFT(1:floor(end/2));
%             freqDataFFT_Sel = freqDataFFT(specsNearby.centerFreqIdx);
%
%             figure; plot(freqData);
%             hold on; plot(freqDataFFT_Sel,'r--');
%           end