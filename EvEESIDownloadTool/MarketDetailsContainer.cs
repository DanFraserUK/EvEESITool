using EvEESITool;
using EvEESITool.Enumerations;
using EvEESITool.Models.Assets;
using EvEESITool.Models.Character;
using EvEESITool.Models.Corporation;
using EvEESITool.Models.Industry;
using EvEESITool.Models.Location;
using EvEESITool.Models.Market;
using EvEESITool.Models.SSO;
using EvEESITool.Models.Wallet;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using EvEESITool.Models.Skills;

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
