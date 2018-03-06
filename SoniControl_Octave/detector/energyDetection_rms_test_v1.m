%
% Copyright (C) 2017 Matthias Zeppelzauer <matthias.zeppelzauer@fhstp.ac.at>.
%
% This file is part of the SoniControl Prototype.
%
% The SoniControl Prototype is free software: you can redistribute it and/or modify
% it under the terms of the GNU General Public License as published by
% the Free Software Foundation, either version 3 of the License, or
% (at your option) any later version.
%
% The SoniControl Prototype is distributed in the hope that it will be useful,
% but WITHOUT ANY WARRANTY; without even the implied warranty of
% MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
% GNU General Public License for more details.
%
% You should have received a copy of the GNU General Public License
% along with the SoniControl Prototype.  If not, see <http://www.gnu.org/licenses/>.
%

close all
clear all
clc

pkg load communications;
pkg load signal;
pkg load video;
pkg load statistics;

folder = 'C:\Users\SoniControl#2\Desktop\detectionNoise';
d = dir([folder filesep '*.wav']);

nFiles = size(d,1);

for idxFile = 1%:nFiles

  %[y,fs] = audioread('C:\Users\SoniControl#2\Desktop\detectionNoise\detectionNoiseSignal1.wav');
  %[y,fs] = audioread('C:\Users\SoniControl#2\Desktop\detector_testsignal.wav');
  [y,fs] = audioread('C:\Users\SoniControl#2\Desktop\radon_emp_nearbyClean-1.wav');
  %[y,fs] = audioread('C:\Users\SoniControl#2\Desktop\detectionSamples_full.wav');
  %[y,fs] = audioread([folder filesep d(idxFile).name]);
  y=mean(y,2); %tansform to mono
  n_smpl=numel(y); %Anzahl der Einzelwerte von y




  sizeBuffer=50; %ms Windowsize
  sizeBuffer_smpl = round(fs/1000*sizeBuffer); %Anzahl Windowsamples
  buffer = zeros(1,sizeBuffer_smpl);
  frequencyResolution = fs/2 / floor(sizeBuffer_smpl / 2);
  frequencies = 0:frequencyResolution:fs/2;
  

  rmsBufferSize = 500; %Anzahl der im Buffer gesammelten RMS, unit = number of buffers
  rmsBuffer = zeros(1,rmsBufferSize);

  medianBufferSize = 15;
  medianBuffer = zeros(1,medianBufferSize);

  bufferHistory = zeros(sizeBuffer_smpl,medianBufferSize);


  [b,a] = butter(20,18000/(fs./2),'high'); %Hochpassfilter


  %detNumber = 30; %Anzahl der Detections nacheinander um den Detektor auszul�sen
  windowStartIdx = 1:sizeBuffer_smpl:n_smpl-sizeBuffer_smpl;
  globalDetectionBuffer = zeros(1, numel(windowStartIdx))-1; %Erstellung einer Matrix nur mit 0er f�r die Anzahl der Durchl�ufe
  counter = 1;
  i = 0;
  j = 0;
  for idx=1:sizeBuffer_smpl:n_smpl-sizeBuffer_smpl
    
    buffer = y(idx:idx+sizeBuffer_smpl-1); %Aktueller frame/aktuelles Fenster ist die stelle von y vom aktuellen index bis zum aktuellen index plus die Fenstergr��e minus 1 = immer die Fenstergr��e
    bufferHiPass = filter(b,a,buffer); %Aktueller frame durch den Hochpassfilter gefiltert
    rms = sqrt(mean((bufferHiPass.^2))); %rms vom aktuellen frame
    
    if counter > rmsBufferSize %start detection when rmsBufferSize is full
      bufferHistory(:,mod(j,medianBufferSize)+1) = buffer;
      
      
      %env = abs(hilbert(y)); %extract envelop
      threshold = mean(rmsBuffer);
      %threshold = threshold-(std(bufferInput));
      detection = 0;
      if rms>threshold
        detection = 1;
        %detections(counter)=1; %Wenn an der aktuellen Counterstelle der rms gr��er als der Schwellwert ist wird detections auf 1 gestellt
      end
      
      medianBuffer(mod(j,medianBufferSize)+1) = detection;
      j = j+1;
      if counter > rmsBufferSize + medianBufferSize % medianBuffer if fully filled now
        %compute median:
        if sum(medianBuffer)>medianBufferSize/2 %median filter + criterion for detection
          globalDetectionBuffer(counter)=1;
          %if positive detection, compute fft for the last n buffers:
          fftSpectra = abs(fft(bufferHistory));
          fftSpectrum = mean(fftSpectra,2);
          fftSpectrum = log(fftSpectrum(1:floor(end/2)));
          plotSpectrum(fftSpectrum, frequencies, []);
          
        else
          globalDetectionBuffer(counter)=0;
        end
      end
      
      
    end
    
    counter = counter +1; %Counter um 1 hoch pro Schleifendurchgang
    rmsBuffer(mod(i,rmsBufferSize)+1) = rms;
    i = i+1;
  end


  %detectionsBig = resample(detections,n_smpl,numel(detections)); %polyphase algorithm (x, p, q) sample rate of x by a factor of p/q

  %figure; plot(y, 'c'); hold on; plot(detectionsBig,'m'); %Plot von y mit dem detectionsignal von 0 oder 1 dar�ber

  figure; plot(globalDetectionBuffer,"c");
end
