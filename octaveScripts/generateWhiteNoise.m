pkg load ltfat;
pkg load signal;
pkg load video;

Fstop = 18000;
Fpass = 22000;
fs = 44100;

[b,a] = butter(40,Fstop/(fs./2),'high');
hiPassFilt = [b,a];

inputNoise = noise(50000,'white');

perfectNoise = filter(b,a,inputNoise);

figure;specgram(inputNoise)
figure;specgram(perfectNoise);

audiowrite('C:\Users\SoniControl#2\Desktop\whitenoise_perfect40.wav',perfectNoise,fs);