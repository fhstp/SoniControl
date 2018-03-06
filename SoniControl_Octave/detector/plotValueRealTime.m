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

% helper function to easier plot stuff with LTFAT

function vector = plotValueRealTime(value,vis_nRows,multiplier)
  

    value = round(value.*multiplier);
    vector = zeros(vis_nRows,1);
    %if value*multiplier is larger than the number of rows --> crop: (Otherwise vector will have more rows than vis_nRows):
    idx = min(value+1,vis_nRows);
    vector(idx) = 1;
    
    if value < 0
      disp('values smaller 0 cannot be ploted');
    end
    
   
    