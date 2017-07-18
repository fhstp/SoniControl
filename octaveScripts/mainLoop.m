function mainLoop(folder,d, specs)


for idxFile = 1%:nFiles

  %[y,fs] = audioread('C:\Users\SoniControl#2\Desktop\detectionNoise\detectionNoiseSignal1.wav');
  %[y,fs] = audioread('C:\Users\SoniControl#2\Desktop\detector_testsignal.wav');
  %[y,fs] = audioread('C:\Users\SoniControl#2\Desktop\radon_emp_nearbyClean-1.wav');
  %[y,fs] = audioread('C:\Users\SoniControl#2\Desktop\detectionSamples_full.wav');
  
  [y,fs] = audioread([folder filesep d(idxFile).name]);
  %[y,fs] = audioread('I:\Datasets\SoniControl\audio_resources\internal-clean-root-captures\cardcase\cardcase_nearbyClean-1.wav');
  
  
  disp([folder filesep d(idxFile).name]);
  y=mean(y,2); %tansform to mono
  n_smpl=numel(y); %Number of single values of y

    %prepare buffer
    sizeBuffer_smpl = round(fs/1000*specs.detector.sizeBuffer); %Number of Windowsamples
    buffer = zeros(1,sizeBuffer_smpl);
    frequencyResolution = fs/2 / floor(sizeBuffer_smpl / 2);
    frequencies = 0:frequencyResolution:fs/2;
    
    %prepare rmsBuffer
    rmsBuffer = zeros(1,specs.detector.rmsBufferSize);

    %prepare medianBuffer
    medianBuffer = zeros(1,specs.detector.medianBufferSize);

    %prepare bufferHistory
    bufferHistory = zeros(sizeBuffer_smpl,specs.detector.medianBufferSize);

    %prepare highpass filter
    [b,a] = butter(20,specs.detector.cutoffFrequency/(fs./2),'high'); %Highpassfilter
    specs.detector.cutoffFrequencyIdx = freq2idx(specs.detector.cutoffFrequency,fs,sizeBuffer_smpl);

    %compute some additional parameters for nearby:
    specs.nearby.centerFreqIdx = freq2idx(specs.nearby.centerFreq,fs,sizeBuffer_smpl);
    specs.nearby.centerFreqIdxDiff = median(diff(specs.nearby.centerFreqIdx));
    %specs.nearby.centerFreqIdx = sort([specs.nearby.centerFreqIdx-2 specs.nearby.centerFreqIdx-1 specs.nearby.centerFreqIdx+1 specs.nearby.centerFreqIdx+2]);
    specs.nearby.offFreq = specs.nearby.centerFreq-(specs.nearby.bw/4); %intermediate frequencies (between two nearby frequencies)
    specs.nearby.offFreqIdx = freq2idx(specs.nearby.offFreq,fs,sizeBuffer_smpl);
    %specs.nearby.offFreqIdx = sort([specs.nearby.offFreqIdx-2 specs.nearby.offFreqIdx-1 specs.nearby.offFreqIdx+1 specs.nearby.offFreqIdx+2]);

  

  windowStartIdx = 1:sizeBuffer_smpl:n_smpl-sizeBuffer_smpl;
  
  %two helpers who store the detection results
  globalDetectionBuffer = zeros(1, numel(windowStartIdx))-1; %Creation of matrix with 0 only
  globalDetectionNearby = zeros(1, numel(windowStartIdx))-1; %Creation of matrix with 0 only
  
  counter = 1;
  i = 0; %running index for rmsBuffer
  j = 0; %running index for bufferHistory
  for idx=1:sizeBuffer_smpl:n_smpl-sizeBuffer_smpl
    
    buffer = y(idx:idx+sizeBuffer_smpl-1); %Current frame/current window is the point of y with the current index to the current index plus the windowsize minus 1 = always windowsize
    %version A: with time-domain highpass filter
    %bufferHiPass = filter(b,a,buffer); %Current frame filtered through the highpassfilter
    %rms = sqrt(mean((bufferHiPass.^2))); %RMS of the current frame
    %version B: with fourier transform (FFT)
    bufferHiPass = abs(fft(buffer));
    bufferHiPass = bufferHiPass(1:round(numel(bufferHiPass)/2));
    bufferHiPass(1:specs.detector.cutoffFrequencyIdx) = 0;
    rms = sqrt(mean(bufferHiPass.^2)); %RMS of the current frame
    %TODO: consider only those values which are above the average amplitude in bufferHiPass: mean(bufferHiPass(specs.detector.cutoffFrequencyIdx+1:end))
    if counter > rmsBufferSize %start detection when rmsBufferSize is full
      bufferHistory(:,mod(j,medianBufferSize)+1) = buffer;
      
      
      %env = abs(hilbert(y)); %extract envelop
      threshold = mean(rmsBuffer);
      %threshold = threshold-(std(bufferInput));
      detection = 0;
      if rms>threshold
        detection = 1;
      end
      
      medianBuffer(mod(j,medianBufferSize)+1) = detection;
      j = j+1;
      if counter > rmsBufferSize + medianBufferSize % medianBuffer if fully filled now
        %compute median:
        if sum(medianBuffer)>medianBufferSize/2  %median filter + criterion for detection
          
          globalDetectionBuffer(counter)=1;
          
          %if positive detection, compute fft for the last n buffers:
          fftSpectra = abs(fft(bufferHistory));
          halfIdx = floor(size(fftSpectra,1)/2);
          fftSpectra = fftSpectra(1:halfIdx,:);
          fftSpectrum = mean(fftSpectra,2);
          %plotSpectrum(fftSpectrum, frequencies, []);
          %figure; imagesc(log(fftSpectra));
          %detect google nearby:
          %get energy of center frequencies
          
          %detect google nearby:
          globalDetectionNearby(counter)=detectNearby(fftSpectrum, specs.nearby, frequencies);
          %TODO: specify a threshold (e.g. 0.4)
          
          %detect prontoly:
          
          
        else
          globalDetectionBuffer(counter)=0;
        end
      end
      
      
    end
    
    counter = counter +1; %Counter plus 1 at every loop
    rmsBuffer(mod(i,rmsBufferSize)+1) = rms;
    i = i+1;
  end


  %detectionsBig = resample(detections,n_smpl,numel(detections)); %polyphase algorithm (x, p, q) sample rate of x by a factor of p/q

  %figure; plot(y, 'c'); hold on; plot(detectionsBig,'m'); %Plot von y mit dem detectionsignal von 0 oder 1 darüber

  %Plot the spectrogram (to show result):
  win = 60; %ms
  overlap = 40; %ms
  frequencyRange = [16000:1:22050];

  if ~isOctave
    [s,f,t,p] = spectrogram(y, round(fs/1000*win), round(fs/1000*overlap),frequencyRange,fs);
    plotSpectrogram(log(p),f,t);
   else
    [s,f,t] = specgram(y, round(fs/1000*win),fs,round(fs/1000*overlap));
    mask = f>=frequencyRange(1) & f<=frequencyRange(end);
    f = f(mask);
    s = s(mask,:);
    plotSpectrogram(log(abs(s)),f,t);
  end
  
  figure; plot(globalDetectionBuffer,'c'); xlim([1 numel(globalDetectionBuffer)]);
  hold on;
  plot(globalDetectionNearby,'g'); xlim([1 numel(globalDetectionNearby)]);
end