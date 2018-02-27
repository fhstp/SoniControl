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

% Configuration for Real-Time Detector:
clear all
close all
clc

if isOctave
    pkg load communications;
    pkg load signal;
    pkg load video;
    pkg load statistics;
    pkg load image;
end

specs=[];
%% Set Parameters for the detector
specs.detector.bufferSizeInMS=46.440; %ms (Note: this produces a buffersize of 2048 samples) Windowsize (200 necessary for nearby)!
specs.detector.backgroundBufferSize = 10; %s 
specs.detector.medianBufferSize = 1.5;%s 
specs.detector.cutoffFrequency = 16800; %lower limit for prontoly! All other technologies send above 18kHz
specs.detector.decisionThreshold = 0.5; %the actual decision threshold. As KL Divergence is between 0 and 1, take a value in the middle. 0 means identical distributions, 1 means competely different distributions; 
specs.detector.decisionThresholdNearby = 3.5; %the decision threshold for nearby signals. If the RMS Energy in the Nearby band is N-times higher than in the neighboring bands above and beneath, then declare a nearby detection. 
specs.detector.decisionThresholdNearbyAC = 0.05; %the recognition threshold for nearby based on autocorrelation



realTimeDetector('playrec',specs);

