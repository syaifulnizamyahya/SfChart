using SfChart.Models;
using System.Collections.ObjectModel;
using System;

namespace SfChart.ViewModels
{
	public class ChartViewModel
	{
		public ObservableCollection<Curve> ChartSeries { get; set; } = new ObservableCollection<Curve>();

		public void InitCurve()
		{
			Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
			int min = 20;
			int max = 90;

			for(int j = 0; j<5; j++)
			{
				var curve = new Curve();

				for (int i = 0; i < 5; i++)
				{
					var point = new Point();
					point.x = random.Next(min, max);
					point.y = random.Next(min, max);

					curve.Points.Add(point);
				}

				ChartSeries.Add(curve);
			}
		}

		public void InitSampleData()
		{
			InitCurve();
		}
	}
}