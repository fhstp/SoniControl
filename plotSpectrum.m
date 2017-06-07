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