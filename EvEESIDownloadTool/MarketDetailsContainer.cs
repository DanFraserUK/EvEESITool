using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
using ESI.NET.Models.Corporation;
using ESI.NET.Models.Industry;
using ESI.NET.Models.Location;
using ESI.NET.Models.Market;
using ESI.NET.Models.SSO;
using ESI.NET.Models.Wallet;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using ESI.NET.Models.Skills;

namespace EvEESIDownloadTool
{
	public class MarketDetailsContainer : MarketDetailsClass
	{
		public List<Statistic> History { get; set; }
		public MarketDetailsContainer() : base()
		{
			History = new List<Statistic>();
		}

		public MarketDetailsContainer(ref SDEData sde) : base(ref sde)
		{
			History = new List<Statistic>();
		}

		public void EvaluateMethod1()
		{
			int holder = 0;

			decimal margin = 20;
			decimal variationPercentage = 10;

			List<Statistic> tenDays = new List<Statistic>();
			int maxCount = Math.Min(10, History.Count);
			if (maxCount < 1)
			{
				return;
			}
			tenDays.AddRange(History.GetRange(0, maxCount));

			long averageVolumePerday = 0;
			decimal averagePricePerDay = 0;
			decimal variationLowest = (100 - variationPercentage) / 100;
			decimal variationHighest = (100 + variationPercentage) / 100;

			foreach (Statistic s in tenDays)
			{
				averageVolumePerday += s.OrderCount;
				averagePricePerDay += s.Average;
			}
			averageVolumePerday = averageVolumePerday / maxCount;
			averagePricePerDay = averagePricePerDay / maxCount;

			List<Order> subSetOfOrders = new List<Order>();
			decimal percentage = (100 - margin) / 100;
			foreach (Order o in Orders)
			{
				decimal percentagedAverage = averagePricePerDay * percentage;
				if (o.Price > percentagedAverage)
				{
					break;
				}
				else
				{
					if (o.Price < (o.Price * variationHighest) && o.Price > (o.Price * variationLowest))
					{
						subSetOfOrders.Add(o);
					}
				}
			}
			if (subSetOfOrders.Count > 5)
			{



				holder++;
			}


			holder++;
		}

		public void EvaluateMethod2()
		{
			long averageVolumePerday = 0;
			decimal averagePricePerDay = 0;
			List<Statistic> historyDays = new List<Statistic>();
			int maxCount = Math.Min(10, History.Count);
			if (maxCount < 1)
			{
				return;
			}
			historyDays.AddRange(History.GetRange(0, maxCount));
			foreach (Statistic s in historyDays)
			{
				averageVolumePerday += s.Volume;
				averagePricePerDay += (s.Highest + s.Lowest) / 2;
			}
			averageVolumePerday = averageVolumePerday / maxCount;
			averagePricePerDay = averagePricePerDay / maxCount;


			int holder = 0;
			if (History.Count > 0 && Orders[0].Price < History[0].Average)
			{
				int volumeCounter = 0;
				int orderCounter = 0;
				foreach (Order o in Orders)
				{
					if (volumeCounter + o.VolumeRemain > averageVolumePerday)
					{
						decimal costPerOrder = 0;
						int i = 0;
						for (i = 0; i < orderCounter; i++)
						{
							costPerOrder += Orders[i].Price * Orders[i].VolumeRemain;
						}
						decimal targetOrderValue = Orders[i + 1].Price * Orders[i].VolumeRemain;
						decimal targetPrice = Orders[i + 1].Price - 0.01M;
						decimal possibleProfit = volumeCounter * targetPrice;

						holder++;
					}
					else
					{
						volumeCounter += o.VolumeRemain;
						orderCounter++;
					}
				}



				holder++;
			}



			holder++;
		}

		public bool EvaluateMethod3()
		{
			List<Statistic> historyDays = new List<Statistic>();
			int maxCount = Math.Min(10, History.Count);
			if (maxCount < 1)
			{
				return false;
			}
			historyDays.AddRange(History.GetRange(0, maxCount));

			//decimal countingOrdersCost = 0;
			int countOrdersSoFar = 0;
			decimal countPriceSoFar = 0;
			for (int i = 0; i < maxCount - 1; i++)
			{
				countOrdersSoFar += Orders[i].VolumeRemain;
				countPriceSoFar += Orders[i].Price;


			}

			return false;
		}

		public override string ToString()
		{
			return base.ToString() + $", History Count : {History.Count}, Cheapest : {(Orders[0].Price * Orders[0].VolumeRemain).ToString("N2")}";
		}
	}
}
