using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OxyPlotSample.WindowsPhone.Resources;

namespace OxyPlotSample.WindowsPhone
{
	using OxyPlot.WP8;

	public partial class MainPage : PhoneApplicationPage
	{
		/// <summary>
		/// The plot view.
		/// </summary>
		private PlotView plotView;

		/// <summary>
		/// The object that contains the plot model.
		/// </summary>
		private readonly MyClass myClass = new MyClass();

		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// Create the plot view and set the model
			this.plotView = new PlotView();
			this.plotView.Model = myClass.MyModel;

			// Set the frame and add the plot view to the view
			plotView.VerticalAlignment = VerticalAlignment.Stretch;
			plotView.HorizontalAlignment = HorizontalAlignment.Stretch;
			ContentPanel.Children.Add(plotView);
		}
	}
}