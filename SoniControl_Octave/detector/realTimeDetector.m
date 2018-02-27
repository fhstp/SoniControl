function realTimeDetector2(source,specs,varargin) 

%Real time detector of ultrasonic transmission activity with real-time visualization
%   Usage: realTimeDetector('playrec',specs); %capture from microphone
%          realTimeDetector('mySound.wav',specs);
%   
%   This script builds upon the blockprocessing capabilities of the LTFAT library:
%   http://ltfat.github.io/
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


if demo_blockproc_header(mfilename,nargin)
   return;
end

%% INITIALIZE ALL FIGURES:

% Basic Control panel (Java object)
p = blockpanel({
               {'GdB','Gain',-20,20,0,21},...
               });


fobj_spec = blockfigure();        % Basic sepctrogram figure (Java object)
fobj_specNorm = blockfigure();    % Normalized spectrogram
fobj_bgModel = blockfigure();     % Background model 
fobj_backgroundDist = blockfigure();      % Figure for background model
fobj_det = blockfigure();                 % Detection Figure

% Setup blockstream
try
   fs=block(source,varargin{:},'loadind',p);
catch
    % Close the windows if initialization fails
    blockdone(p,fobj_spec);
    blockdone(p,fobj_specNorm);
    blockdone(p,fobj_bgModel);
    blockdone(p,fobj_backgroundDist);
    blockdone(p,fobj_det);

    
    err = lasterror;
    error(err.message);
end


%% INITIALIZE ALL BUFFERS AND VARIABLES OF THE DETECTOR:


%prepare input buffer
specs.detector.bufferSizeSmpl = round(specs.detector.bufferSizeInMS/1000*fs); %Number of samples in the buffer
frequencyResolution = fs/2 / floor(specs.detector.bufferSizeSmpl / 2); %expected frequency resolution of the fft spectrogam
frequencies = 0:frequencyResolution:fs/2; %frequencies of the individual FFT frequency bins

%compute the frequency index of the cutoff frequency of the highpass filter (this index can be used in the fourier domain directly
specs.detector.cutoffFrequencyIdx = freq2idx(specs.detector.cutoffFrequency,fs,specs.detector.bufferSizeSmpl);

%prepare background model
specs.detector.backgroundBufferSizeItems = round(specs.detector.backgroundBufferSize*1000/specs.detector.bufferSizeInMS); %Number of samples in the buffer
nComponents = numel(specs.detector.cutoffFrequencyIdx:round(specs.detector.bufferSizeSmpl/2)); %number of frequency bins in the background model
backgroundModelBuffer = zeros(nComponents,specs.detector.backgroundBufferSizeItems); %initialize
currentBackgroundModel=zeros(nComponents,1); % this variable holds in each iteration of the detection process the background model (the median over all background frames in "backgroundModelBuffer"

%prepare medianBuffer
specs.detector.medianBufferSizeItems = round(specs.detector.medianBufferSize*1000/specs.detector.bufferSizeInMS); %Number of samples in the buffer
medianBuffer = zeros(1,specs.detector.medianBufferSizeItems);
cyclicMedianBufferIdx = 1;

%prepare highpass filter (not used currently, filtering is applied via the fft)
%[b,a] = butter(10,specs.detector.cutoffFrequency/(fs./2),'high'); %Highpassfilter

%prepare bufferHistory
bufferHistory = zeros(specs.detector.bufferSizeSmpl,specs.detector.medianBufferSizeItems);



%detector control variables
detection=0;                %becomes one, if the current frame is above the decision threshold
detectionAfterMedian = 0;   %becomes one only if more than the half of the past frames were above the decision threshold
%isUpdating=0;               %helper, not used any more
backgroundDist=0;           %holds the distance (Kullback Leibler Divergence) between the current frame and the background model 

%initialize some counters for our buffers (all buffers are cyclic buffers)
counter = 1;                %increments in every loop (without exception), helps to find out when backgroundBuffer is full and detection can be started
i = 0;                      %running index for background model; goes modulo specs.detector.backgroundBufferSizeItems 
j = 0;                      %running index for bufferHistory and medianBuffer; goes modulo specs.detector.medianBufferSizeItems
%detectionDuration = 0;      %stores the number of analysis frames (buffers) of a current detection. With this we can evaluate how long we are already detection a signal to decide if we start with the signal recognition (recognition of the respective technology). By increasing the median buffer a similar effect (less accurate) can be reached. For the sake of simplicity, we do not use this additional variable


%% ACTUAL DETECTION
doDetection = 1;
%Loop until end of the stream (doDetection) and until panel is opened
while doDetection && p.flag
    % Obtain the global gain value
    gain = blockpanelget(p,'GdB');
    gain = 10^(gain/20);

    % Read the next block of samples and connect to the gain (to enable change of loudness interactively)
    [buffer,doDetection] = blockread(specs.detector.bufferSizeSmpl);
    %size(buffer)
    %pause
    
    buffer=buffer*gain;

    
    % Convert to mono if stereo input
    buffer = mean(buffer,2);
    
    % Compute FFT and extract high-frequency coefficients
    bufferFFT = getFourierCoefficients(buffer);
    
    % Get highpass portion of signal (above cutoff frequency)
    bufferFFT_HiPass = bufferFFT(specs.detector.cutoffFrequencyIdx:end);
    
    % Normalize spectrum
    bufferFFT_HiPass_Norm = normalizeSpectrum(bufferFFT_HiPass);
    
    %if the background model is full, start with detection, i.e. start with filling the median buffer
    if counter > specs.detector.backgroundBufferSizeItems  
      
      %store current buffer for later processing (e.g. recogniton of signals)
      cyclicMedianBufferIdx = mod(j,specs.detector.medianBufferSizeItems)+1;
      bufferHistory(:,cyclicMedianBufferIdx) = buffer; 
      
      %store current spectum (entire frequency range) for later processing and for AC computation (nearby detection)
      %spectumHistory(:,cyclicMedianBufferIdx) = bufferFFT; 
      
      %compute distance to background model:
      currentBackgroundModel = median(backgroundModelBuffer,2);
      backgroundDist = getKullbackLeibler(currentBackgroundModel./sum(currentBackgroundModel),bufferFFT_HiPass_Norm);
       
      
      
          
      % Detection condition: 
      % is the current buffer different from the background model (backgroundDist>threshold) 
      if backgroundDist > specs.detector.decisionThreshold 
        detection = 1;
      else
        detection = 0;           
      end

      % store decision in median buffer      
      medianBuffer(cyclicMedianBufferIdx) = detection;
      j = j+1; % increase counter for median buffer
      
      % if backgroundBuffer and medianBuffer is full, start with the actual detection:
      if counter > specs.detector.backgroundBufferSizeItems + specs.detector.medianBufferSizeItems 
        
        %Are there more detections than non-detection in the buffer, then declare a detection (=median over the past specs.detector.medianBufferSizeItems buffer-based detections)
        if sum(medianBuffer) > specs.detector.medianBufferSizeItems/2  
          detectionAfterMedian=1;

          
        else
          detectionAfterMedian=0;

        end
      end %end bg-model-buffer and median buffer full
    end % end bg-model-buffer full


    %in every iteration:
    counter = counter +1; %increase loop counter plus 1
    
    %% UPDATE BACKGROUND BUFFER:
    
    %increase buffer for background model buffer
    cyclicBackgroundBufferIndex = mod(i,specs.detector.backgroundBufferSizeItems); %this is 0..bufSiz-1, note: a C-style buffer starting with 0
    
    % if currently a detection (after temporal median filter) is active, do not further update the background model
    % This avoids that the model learns wrong information and keeps the background threshold robust and stable
    % When a detection (after median) is issued then, however, the background model already contains some information (frames) from the detected sound
    % The reason is that the temporal median delays the detection a bit.
    % To correct this error, we remove the last specs.detector.medianBufferSizeItems samples 
    % and replace them with the samples that came before (they are at position: currentPos-2*specs.detector.medianBufferSizeItems:currentPos-specs.detector.medianBufferSizeItems)
    %if detectionAfterMedian==1 
    if detectionAfterMedian==1 
      %replace the last medianBufferSizeItems values with the medianBufferSizeItems that were captured before!
      [delIndices replaceIndices]=getIndicesCyclicBuffer(cyclicBackgroundBufferIndex,specs.detector.backgroundBufferSizeItems,specs.detector.medianBufferSizeItems); 
      backgroundModelBuffer(:,delIndices) = backgroundModelBuffer(:,replaceIndices);
    
    %if no detection: standard update (kick the oldest value (=cyclicBackgroundBufferIndex+1) out of the buffer and replace by most currentone
    else 
      
      %append current normalized spectral distribution to background model
      backgroundModelBuffer(:,cyclicBackgroundBufferIndex+1) = bufferFFT_HiPass_Norm;
      %acBuffer(:,cyclicBackgroundBufferIndex+1) = bufferAC;
    end
    
    i = i+1; %increase loop counter for background  buffer
    
    
    
    
    
    
    %% VISUALIZE
    blockplot(fobj_spec,bufferFFT_HiPass(:));             % Show  Spectrogram
    blockplot(fobj_specNorm,bufferFFT_HiPass_Norm(:)*10);    % Show Normalized Spectrogram
    blockplot(fobj_bgModel,currentBackgroundModel*10);       % Show Background Model
    
    %plot distance (KL) function + threshold
    vis_nRows = 100;
    multiplier = 50;
    vis_helper_dist = plotValueRealTime(backgroundDist,vis_nRows,multiplier);
    if counter > specs.detector.backgroundBufferSizeItems %if backgroundBuffer is full:
      vis_helper_distThres = plotValueRealTime(specs.detector.decisionThreshold,vis_nRows,multiplier);
      vis_helper_dist=vis_helper_dist+vis_helper_distThres;
    end
    blockplot(fobj_backgroundDist,vis_helper_dist(:));
    
    %plot detection function
    vis_nRows = 100;
    vis_helper_det = plotValueRealTime(detectionAfterMedian,vis_nRows,vis_nRows/2);
    blockplot(fobj_det,vis_helper_det(:));
    

    
end %end main loop

%clean up
blockdone(p,fobj_spec);
blockdone(p,fobj_specNorm);
blockdone(p,fobj_bgModel);
blockdone(p,fobj_det);
blockdone(p,fobj_backgroundDist);

