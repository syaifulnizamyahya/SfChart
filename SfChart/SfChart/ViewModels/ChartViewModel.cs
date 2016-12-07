using SfChart.Models;
using System.Collections.ObjectModel;
using System;

namespace SfChart.ViewModels
{
	public class ChartViewModel
	{
		public ObservableCollection<GoldDemand> Demands { get; set; } = new ObservableCollection<GoldDemand>();

		public void InitDemands()
		{
			this.Demands = new ObservableCollection<GoldDemand>
			{
				new GoldDemand()
				{
					Demand = "Jewelry", Year2010 = 1998.0, Year2011 = 2361.2
				},
				new GoldDemand()
				{
					Demand = "Electronics", Year2010 = 1284.0, Year2011 = 1328.0
				},
				new GoldDemand()
				{
					Demand = "Research", Year2010 = 1090.5, Year2011 = 1032.0
				},
				new GoldDemand()
				{
					Demand = "Investment", Year2010 = 1643.0, Year2011 = 1898.0
				},
				new GoldDemand()
				{
					Demand = "Bank Purchases", Year2010 = 987.0, Year2011 = 887.0
				}
			};
		}

		public void InitSampleData()
		{
			InitDemands();
		}
	}
}