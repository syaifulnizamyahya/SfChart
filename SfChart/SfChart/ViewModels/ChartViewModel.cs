using SfChart.Models;
using System.Collections.ObjectModel;
using System;
using Syncfusion.UI.Xaml.Charts;
using System.Diagnostics;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;

namespace SfChart.ViewModels
{

	public class ChartViewModel
	{

		int _ChartStripLineStartExcellent = default(int);
		int _ChartStripLineStartGood = default(int);
		int _ChartStripLineStartPoor = default(int);
		int _ChartStripLineWidthExcellent = default(int);
		int _ChartStripLineWidthGood = default(int);
		int _ChartStripLineWidthPoor = default(int);
		int _MaxChannel1 = default(int);
		int _MaxChannel2 = default(int);
		double _MaxRssi = default(double);
		int _MinChannel1 = default(int);
		int _MinChannel2 = default(int);
		double _MinRssi = default(double);
		public int ChartStripLineStartExcellent { get { return _ChartStripLineStartExcellent; } set { _ChartStripLineStartExcellent = value; } }
		public int ChartStripLineStartGood { get { return _ChartStripLineStartGood; } set { _ChartStripLineStartGood = value; } }
		public int ChartStripLineStartPoor { get { return _ChartStripLineStartPoor; } set { _ChartStripLineStartPoor = value; } }
		public int ChartStripLineWidthExcellent { get { return _ChartStripLineWidthExcellent; } set { _ChartStripLineWidthExcellent = value; } }
		public int ChartStripLineWidthGood { get { return _ChartStripLineWidthGood; } set { _ChartStripLineWidthGood = value; } }
		public int ChartStripLineWidthPoor { get { return _ChartStripLineWidthPoor; } set { _ChartStripLineWidthPoor = value; } }
		public ChartSeriesCollection Collection { get; set; } = new ChartSeriesCollection();
		public int MaxChannel1 { get { return _MaxChannel1; } set { _MaxChannel1 = value; } }
		public int MaxChannel2 { get { return _MaxChannel2; } set { _MaxChannel2 = value; } }
		public double MaxRssi { get { return _MaxRssi; } set { _MaxRssi = value; } }
		public int MinChannel1 { get { return _MinChannel1; } set { _MinChannel1 = value; } }
		public int MinChannel2 { get { return _MinChannel2; } set { _MinChannel2 = value; } }
		public double MinRssi { get { return _MinRssi; } set { _MinRssi = value; } }
		public ObservableCollection<Curve> Series { get; set; } = new ObservableCollection<Curve>();

		public void InitSampleData()
		{
			InitAux();
			InitSeries();
			InitCollection();
		}

		private void InitAux()
		{
			//range for first group of series
			_MinChannel1 = 36;
			_MaxChannel1 = 64;

			//range for second group of series
			_MinChannel2 = 149;
			_MaxChannel2 = 165;

			_MinRssi = -90;
			_MaxRssi = -20;

			ChartStripLineStartExcellent = -55;
			ChartStripLineWidthExcellent = Math.Abs(ChartStripLineStartExcellent - (int)_MaxRssi);
			ChartStripLineStartGood = -68;
			ChartStripLineWidthGood = Math.Abs(ChartStripLineStartGood - ChartStripLineStartExcellent);
			ChartStripLineStartPoor = (int)_MinRssi;
			ChartStripLineWidthPoor = Math.Abs((int)_MinRssi - ChartStripLineStartGood);
		}

		private void InitCollection()
		{
			Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

			for (int i = 0; i < Series.Count; i++)
			{
				var splineSeries = new SplineSeries();
				splineSeries.ItemsSource = Series[i].Points;
				splineSeries.XBindingPath = "x";
				splineSeries.YBindingPath = "y";
				splineSeries.Label = "Ap " + random.Next().ToString();

				ChartAdornmentInfo adornments = new ChartAdornmentInfo();
				//adornments.AdornmentsPosition = AdornmentsPosition.TopAndBottom;
				//adornments.ShowLabel = true;
				adornments.HighlightOnSelection = true;

				splineSeries.AdornmentsInfo = adornments;
				splineSeries.SeriesSelectionBrush = Application.Current.Resources["SystemControlHighlightAccentBrush"] as SolidColorBrush;

				Collection.Add(splineSeries);
			}
		}

		// create dummy data
		private void InitSeries()
		{
			Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

			// data for the first half. x range 36-64
			for (int i = 0; i < 5; i++)
			{
				var rssiPoint = new Point();
				rssiPoint.x = random.Next(_MinChannel1, _MaxChannel1);
				rssiPoint.y = random.Next((int)_MinRssi, (int)_MaxRssi);

				var aPoint = new Point();
				aPoint.x = rssiPoint.x - 2;
				aPoint.y = _MinRssi;

				var bPoint = new Point();
				bPoint.x = rssiPoint.x - 1;
				bPoint.y = rssiPoint.y - Math.Abs(rssiPoint.y - _MinRssi) / 5;

				var dPoint = new Point();
				dPoint.x = rssiPoint.x + 1;
				dPoint.y = rssiPoint.y - Math.Abs(rssiPoint.y - _MinRssi) / 5;

				var ePoint = new Point();
				ePoint.x = rssiPoint.x + 2;
				ePoint.y = _MinRssi;

				var curve = new Curve();

				curve.Points.Add(aPoint);
				curve.Points.Add(bPoint);
				curve.Points.Add(rssiPoint);
				curve.Points.Add(dPoint);
				curve.Points.Add(ePoint);

				Series.Add(curve);

				for (int k = 0; k < curve.Points.Count; k++)
				{
					Debug.WriteLine("Series1 " + Series.Count + " Points " + k + " x " + curve.Points[k].x + " y " + curve.Points[k].y);

				}
			}

			for (int i = 0; i < 5; i++)
			{
				var rssiPoint = new Point();
				rssiPoint.x = random.Next(_MinChannel2, _MaxChannel2);
				rssiPoint.y = random.Next((int)_MinRssi, (int)_MaxRssi);

				var aPoint = new Point();
				aPoint.x = rssiPoint.x - 2;
				aPoint.y = _MinRssi;

				var bPoint = new Point();
				bPoint.x = rssiPoint.x - 1;
				bPoint.y = rssiPoint.y - Math.Abs(rssiPoint.y - _MinRssi) / 5;

				var dPoint = new Point();
				dPoint.x = rssiPoint.x + 1;
				dPoint.y = rssiPoint.y - Math.Abs(rssiPoint.y - _MinRssi) / 5;

				var ePoint = new Point();
				ePoint.x = rssiPoint.x + 2;
				ePoint.y = _MinRssi;

				var curve = new Curve();

				curve.Points.Add(aPoint);
				curve.Points.Add(bPoint);
				curve.Points.Add(rssiPoint);
				curve.Points.Add(dPoint);
				curve.Points.Add(ePoint);

				Series.Add(curve);

				for (int k = 0; k < curve.Points.Count; k++)
				{
					Debug.WriteLine("Series2 " + Series.Count + " Points " + k + " x " + curve.Points[k].x + " y " + curve.Points[k].y);

				}
			}
		}

	}
}