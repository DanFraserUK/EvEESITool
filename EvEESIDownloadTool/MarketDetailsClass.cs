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
	public class MarketDetailsClass
	{
	readonly	SortedDictionary<int, MarketDetailsContainer> MarketDetails = new SortedDictionary<int, MarketDetailsContainer>();
readonly		SortedDictionary<int, MarketDetailsContainer> TrimmedMarketDetails = new SortedDictionary<int, MarketDetailsContainer>();
		public int TypeID { get; set; }
		public List<Order> Orders { get; set; }

		[JsonIgnore]
		public string Name { get; set; }

		public void SetTypeID(int typeID)
		{
			TypeID = typeID;
		}

		public override string ToString()
		{
			return $"TypeID : {TypeID}, Name : {Name}, Number of orders : {Orders.Count}";
		}

		public MarketDetailsClass()
		{
			Orders = new List<Order>();
		}
	}
}
