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