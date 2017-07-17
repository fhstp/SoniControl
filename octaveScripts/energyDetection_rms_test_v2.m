close all
clear all
clc

%Matthias:
%cd 'D:\Clouds\Dropbox (FH St. Pölten)\SoniControlShare\matlab_code\detection'
%addpath('D:\Clouds\Dropbox (FH St. Pölten)\SoniControlShare\matlab_code');

if isOctave
    pkg load communications;
    pkg load signal;
    pkg load video;
    pkg load statistics;
end

%Florian: 
folder = 'C:\Users\SoniControl#2\Desktop\detectionNoise';
%Matthias: 
%folder = 'D:\Clouds\Dropbox (FH St. Pölten)\SoniControlShare\Audio\NoiseAudio'

d = dir([folder filesep '*.wav']);
nFiles = size(d,1);

%%
mainLoop(folder,d);





