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

%normalize a given spectrum to sum==1

function bufferFFT_HiPass_Norm = normalizeSpectrum(bufferFFT_HiPass);
    % Normalize spectrum by its sum to obtain a spectral distribution function
    bufferFFT_HiPass_Norm = bufferFFT_HiPass;
    if sum(bufferFFT_HiPass(:))>0 %avoid division by 0
      bufferFFT_HiPass_Norm = bufferFFT_HiPass./(sum(bufferFFT_HiPass(:)));
    end
    