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

			int minChannel = -1;
			int maxChannel = 15;

			//var dummyCurve = new Curve();
			//for (int j = minChannel; j < maxChannel; j++)
			//{
			//	//add dummy curve
			//	var dummyPoint = new Point();
			//	dummyPoint.x = j;
			//	//dummyPoint.y = 0;

			//	dummyCurve.Points.Add(dummyPoint);
			//}

			//RssiSeries.Add(dummyCurve);

			for (int i = 0; i < 5; i++)
			{
				var rssiPoint = new Point();
				rssiPoint.x = random.Next(1, 13);
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

				//// fill missing points in front
				//for (int k = minChannel; k < aPoint.x; k++)
				//{
				//	var dummyPoint = new Point();
				//	dummyPoint.x = k;
				//	dummyPoint.y = -10;
				//	curve.Points.Add(dummyPoint);
				//}

				curve.Points.Add(aPoint);
				curve.Points.Add(bPoint);
				curve.Points.Add(rssiPoint);
				curve.Points.Add(dPoint);
				curve.Points.Add(ePoint);

				////fill missing points at the end
				//for (int k = (int)(ePoint.x + 1.0f); k <= maxChannel; k++)
				//{
				//	var dummyPoint = new Point();
				//	dummyPoint.x = k;
				//	dummyPoint.y = -10;
				//	curve.Points.Add(dummyPoint);
				//}
				
				RssiSeries.Add(curve);

				for (int k = 0; k < curve.Points.Count; k++)
				{
					Debug.WriteLine("Series " + RssiSeries.Count + " Points " + k + " x " + curve.Points[k].x + " y " + curve.Points[k].y);

				}
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
				//splineSeries.EmptyPointValue = EmptyPointValue.Zero;
				RssiCollection.Add(splineSeries);
			}
		}
	}
}