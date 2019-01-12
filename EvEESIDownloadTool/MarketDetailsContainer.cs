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

namespace EvEESITool
{
	public class MarketDetailsContainer : MarketDetailsClass
	{
		public List<Statistic> History { get; set; }
		public MarketDetailsContainer() : base()
		{
			History = new List<Statistic>();
		}
		public override string ToString()
		{
			return base.ToString() + $", History Count : {History.Count}, Cheapest : {(Orders[0].Price * Orders[0].VolumeRemain).ToString("N2")}";
		}
	}
}
