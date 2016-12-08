using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfChart.Models
{

	public class Series
	{
		public ObservableCollection<Curve> Curves { get; set; } = new ObservableCollection<Curve>();
	}

	public class Curve
	{
		public ObservableCollection<Point> Points { get; set; } = new ObservableCollection<Point>();
	}
	public class Point
	{
		public double x { get; set; } = default(double);
		public double y { get; set; } = default(double);
	}
}
