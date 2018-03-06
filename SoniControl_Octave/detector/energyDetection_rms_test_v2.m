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

%% Initialization

%Matthias:
%cd 'D:\Clouds\Dropbox (FH St. P�lten)\SoniControlShare\matlab_code\detection'
%addpath('D:\Clouds\Dropbox (FH St. P�lten)\SoniControlShare\matlab_code');

if isOctave
    pkg load communications;
    pkg load signal;
    pkg load video;
    pkg load statistics;
end

%Florian: 
%folder = 'C:\Users\SoniControl#2\Desktop\detectionNoise';
%Matthias: 
%folder = 'D:\Clouds\Dropbox (FH St. P�lten)\SoniControlShare\Audio\NoiseAudio'
%Alexis:
folder = 'C:\Development\Audio_Data\nearby\fhstp\noisy'

d = dir([folder filesep '*.wav']);
nFiles = size(d,1);

fs=44100; %Set this here globally! We work only with this sampling rate

%% Set Parameters for the detector
specs.detector.sizeBuffer=200; %ms Windowsize (200 necessary for nearby)!
specs.detector.rmsBufferSize = 20; %Number of collected RMS values in the buffer, unit = number of buffers
specs.detector.medianBufferSize = 15; %Number of collected individual decisions (detections), unit = number of buffers
specs.detector.cutoffFrequency = 18000;

%% Set Parameters for the recognizer: Specification of different transmission technologies:
%Google Nearby:
specs.nearby.nBands=64;
specs.nearby.bw=(20000-18500)./specs.nearby.nBands*2;
specs.nearby.centerFreq = linspace(18500,20000,specs.nearby.nBands);

%Prontoly
specs.prontoly.frequencies = [18430 18520 18690 18780 18955 19040 19380 19466 19726]; %Hz
specs.prontoly.bandwidth = 40; %unit: Hz
specs.prontoly.duration = 250; %ms %or longer (up to 500ms)
specs.prontoly.spacing = 4000; %ms %spacing between two words


%% Run Processing
mainLoop(folder,d,specs);





