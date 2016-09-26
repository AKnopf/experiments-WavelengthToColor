using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Silverlight_WavelengthToColor
{
	public partial class MainPage : UserControl
	{
		private const double point1Y = -200.00;
		private const double point2Y = +400.00;
		private const double point3Y = +100.00;

		public MainPage()
		{
			InitializeComponent();

			this.Loaded += new RoutedEventHandler(MainPage_Loaded);
		}

		void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			this.trackBar1.ValueChanged += new RoutedPropertyChangedEventHandler<double>(trackBar1_ValueChanged);
		}

		void trackBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			//minimum wavelnegth is 350nm which should display 2.2 waves.
			double slidefactor = (this.trackBar1.Value/3)/2;

			this.spline1.Points = new PointCollection(){	new Point(slidefactor * 1, point1Y), 
															new Point(slidefactor * 2, point2Y), 
												 			new Point(slidefactor * 3, point3Y),

															new Point(slidefactor * 4, point1Y), 
															new Point(slidefactor * 5, point2Y), 
												 			new Point(slidefactor * 6, point3Y),

															new Point(slidefactor * 7, point1Y), 
															new Point(slidefactor * 8, point2Y), 
												 			new Point(slidefactor * 9, point3Y)
			};

			this.panel1.Fill = new SolidColorBrush(this.getColorFromWaveLength((int)e.NewValue));
			this.labelCurrentWaveLength.Text = this.trackBar1.Value.ToString("000.00") + " nm";

			this.labelR.Text = "R: " + ((Color)getColorFromWaveLength((int)e.NewValue)).R.ToString();
			this.labelG.Text = "G: " + ((Color)getColorFromWaveLength((int)e.NewValue)).G.ToString();
			this.labelB.Text = "B: " + ((Color)getColorFromWaveLength((int)e.NewValue)).B.ToString();
		}

		private Color getColorFromWaveLength(int Wavelength)
		{
			double	Gamma = 1.00;
			int		IntensityMax = 255;

			double	Blue;
			double	Green;
			double	Red;
			double	Factor;

			if (Wavelength >= 350 && Wavelength <= 439)
			{
				Red = -(Wavelength - 440d) / (440d - 350d);
				Green = 0.0;
				Blue = 1.0;
			}
			else if (Wavelength >= 440 && Wavelength <= 489)
			{
				Red = 0.0;
				Green = (Wavelength - 440d) / (490d - 440d);
				Blue = 1.0;
			}
			else if (Wavelength >= 490 && Wavelength <= 509)
			{
				Red = 0.0;
				Green = 1.0;
				Blue = -(Wavelength - 510d) / (510d - 490d);
			}
			else if (Wavelength >= 510 && Wavelength <= 579)
			{
				Red = (Wavelength - 510d) / (580d - 510d);
				Green = 1.0;
				Blue = 0.0;
			}
			else if (Wavelength >= 580 && Wavelength <= 644)
			{
				Red = 1.0;
				Green = -(Wavelength - 645d) / (645d - 580d);
				Blue = 0.0;
			}
			else if (Wavelength >= 645 && Wavelength <= 780)
			{
				Red = 1.0;
				Green = 0.0;
				Blue = 0.0;
			}
			else
			{
				Red = 0.0;
				Green = 0.0;
				Blue = 0.0;
			}

			if (Wavelength >= 350 && Wavelength <= 419)
			{
				Factor = 0.3 + 0.7 * (Wavelength - 350d) / (420d - 350d);
			}
			else if (Wavelength >= 420 && Wavelength <= 700)
			{
				Factor = 1.0;
			}
			else if (Wavelength >= 701 && Wavelength <= 780)
			{
				Factor = 0.3 + 0.7 * (780d - Wavelength) / (780d - 700d);
			}
			else
			{
				Factor = 0.0;
			}

			byte A = 255;
			byte R = (byte)this.factorAdjust(Red, Factor, IntensityMax, Gamma);
			byte G = (byte)this.factorAdjust(Green, Factor, IntensityMax, Gamma);
			byte B = (byte)this.factorAdjust(Blue, Factor, IntensityMax, Gamma);

			return Color.FromArgb(A ,R, G, B);
		}

		private int factorAdjust(double Color, double Factor, int IntensityMax, double Gamma)
		{
			if (Color == 0.0)
			{
				return 0;
			}
			else
			{
				return (int)Math.Round(IntensityMax * Math.Pow(Color * Factor, Gamma));
			}
		}
	}
}
