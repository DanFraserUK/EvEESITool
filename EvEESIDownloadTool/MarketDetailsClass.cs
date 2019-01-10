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
