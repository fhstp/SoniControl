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

%compute one-sided fourier spectrum

function bufferFFT = getFourierCoefficients(buffer)
    bufferFFT = abs(fft(buffer)); %compute magnitude spectrum
    bufferFFT = bufferFFT(1:round(numel(bufferFFT)/2)); %skip second half (which is redundant because FFT is symmetric)
    
  