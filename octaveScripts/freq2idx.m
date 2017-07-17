function freqIdx = freq2idx(freq,fs,winLen)

freqIdx = round(freq/fs*winLen) + 1;   
