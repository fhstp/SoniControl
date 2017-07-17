% frequency in Hz,
% duration in seconds
% Fs in Hz
function sig=generateCosineFunction(frequency, duration, Fs)

sig=sin(2*pi*frequency*duration*(0:(1/(duration*Fs)):1));