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

%for a cyclic buffer of length bufferLen, find the numItems before the current bufer Idx
%(currentIdx) and replace them by the numItems before these items.
%
% expects current index to run from 0..inf, i.e. index is in C/Java notation! Output is in MATLAB notation
function [toDelIdx, toReplaceWithIdx] = getIndicesCyclicBuffer(currentIdx, bufferLen, numItems)

%bufferLen = 11;
%numItems = 3;
%currentIdx = 0;



A=currentIdx-numItems;
B=currentIdx-1;
C=currentIdx-numItems*2;
D=currentIdx-numItems-1;

%[A B C D];
toDelIdx = A:B;
toReplaceWithIdx = C:D;

toDelIdx = mod(toDelIdx,bufferLen);
toReplaceWithIdx = mod(toReplaceWithIdx,bufferLen);

toDelIdx = toDelIdx+1; %add 1 to make compatible with MATLAB indexing (not necessary for Java/C)
toReplaceWithIdx = toReplaceWithIdx+1; %add 1 to make compatible with MATLAB indexing (not necessary for Java/C)
