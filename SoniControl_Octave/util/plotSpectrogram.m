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

% plots a spectrogram for a power specgrogram p (a 2D double matrix), frequencies f and times t

function figure1=plotSpectrogram(p,f,t)
    maxF = max(f);
    minF = min(f);
    minT=min(t);
    maxT=max(t);
    
    figure1=figure;
    axes1 = axes('Parent',figure1,'YTickLabel',strread(num2str(linspace(minF,maxF,10),'%3.1f '),'%s'),'YTick',linspace(0,size(p,1),10),'XTickLabel',strread(num2str(linspace(minT,maxT,10),'%3.1f '),'%s'),'XTick',linspace(0,size(p,2),10));
    hold(axes1,'all');
    imagesc(p);
    set(gca,'YDir','normal');
    xlim([1,size(p,2)]);
    ylim([1,size(p,1)]);
    xlabel('Time (s)');
    ylabel('Frequency (kHz)');