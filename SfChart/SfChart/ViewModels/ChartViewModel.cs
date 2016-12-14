using SfChart.Models;
using System.Collections.ObjectModel;
using System;
using Syncfusion.UI.Xaml.Charts;
using System.Diagnostics;

namespace SfChart.ViewModels
{
	public class ChartViewModel
	{
		public ObservableCollection<Curve> RssiSeries { get; set; } = new ObservableCollection<Curve>();

		public ChartSeriesCollection RssiCollection { get; set; } = new ChartSeriesCollection();

		public void InitSampleData()
		{
			InitRssi();
			InitRssiCollection();
		}

		private void InitRssi()
		{
			Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
			int min = 20;
			int max = 90;

			for (int i = 0; i < 5; i++)
			{
				var rssiPoint = new Point();
				rssiPoint.x = random.Next(-2, 13);
				rssiPoint.y = random.Next(min, max);

				var aPoint = new Point();
				aPoint.x = rssiPoint.x - 2;
				aPoint.y = 0;

				var bPoint = new Point();
				bPoint.x = rssiPoint.x - 1;
				bPoint.y = rssiPoint.y - (rssiPoint.y / 5);

				var dPoint = new Point();
				dPoint.x = rssiPoint.x + 1;
				dPoint.y = rssiPoint.y - (rssiPoint.y / 5);

				var ePoint = new Point();
				ePoint.x = rssiPoint.x + 2;
				ePoint.y = 0;

				var curve = new Curve();
				curve.Points.Add(aPoint);
				curve.Points.Add(bPoint);
				curve.Points.Add(rssiPoint);
				curve.Points.Add(dPoint);
				curve.Points.Add(ePoint);

				RssiSeries.Add(curve);

				Debug.WriteLine(RssiSeries.Count + " A " + curve.Points[0].x + " " + curve.Points[0].y);
				Debug.WriteLine(RssiSeries.Count + " B " + curve.Points[1].x + " " + curve.Points[1].y);
				Debug.WriteLine(RssiSeries.Count + " R " + curve.Points[2].x + " " + curve.Points[2].y);
				Debug.WriteLine(RssiSeries.Count + " D " + curve.Points[3].x + " " + curve.Points[3].y);
				Debug.WriteLine(RssiSeries.Count + " E " + curve.Points[4].x + " " + curve.Points[4].y);
			}
		}
		private void InitRssiCollection()
		{
			Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

			for (int i = 0; i < RssiSeries.Count; i++)
			{
				var splineSeries = new SplineSeries();
				splineSeries.ItemsSource = RssiSeries[i].Points;
				splineSeries.XBindingPath = "x";
				splineSeries.YBindingPath = "y";
				splineSeries.Label = random.Next().ToString();
				RssiCollection.Add(splineSeries);
			}
		}
	}
}