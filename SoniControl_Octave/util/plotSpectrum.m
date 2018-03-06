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

%plot spectrum. spec contains the spectrum as a vector, frequencies are the frequencies that should be labeled. Optionally, peacLocks contains a set of locations in the spectrum which refer to peaks

function plotSpectrum(spec, frequencies, peakLocs)

if nargin < 3
    peakLocs = [];
end
    
figure1=figure;
axes1 = axes('Parent',figure1,'XTickLabel',strread(num2str(linspace(min(frequencies)/1000,max(frequencies)/1000,10),'%3.1f '),'%s'), ...
    'XTick',linspace(0,numel(spec),10));
hold(axes1,'all');
plot(spec);
xlim([1,numel(spec)]);
ylim([min(spec),max(spec)]);
xlabel('Frequency (kHz)');
ylabel('DB/Amp');

hold on;

plot(peakLocs,spec(peakLocs),'r*');