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
	public class MarketData : DataClassesBase
	{
		public List<Price> Prices { get; private set; } = new List<Price>();
		public List<Price> GetPrices()
		{
			return DownloadData<List<Price>>("Prices", Settings.EsiClient.Market.Prices());
		}
		public List<Order> Orders { get; private set; } = new List<Order>();
		public List<Order> GetOrders(int regionID, MarketOrderType orderType, int page, int? typeID)
		{
			return DownloadData<List<Order>>("Region orders", Settings.EsiClient.Market.RegionOrders(regionID, orderType, page, typeID));
		}
		public List<Statistic> TypeHistory { get; private set; } = new List<Statistic>();
		public List<Statistic> GetTypeHistory(int regionID, int typeID)
		{
			return DownloadData<List<Statistic>>("Type history", Settings.EsiClient.Market.TypeHistoryInRegion(regionID, typeID));
		}
		public List<Order> GetStructureOrders(long structureID, int page)// { get; private set; } = new List<Order>();
		{
			return DownloadData<List<Order>>("Structure orders", Settings.EsiClient.Market.StructureOrders(structureID, page));
		}
		public List<int> Groups { get; private set; } = new List<int>();
		public List<int> GetGroups()
		{
			return DownloadData<List<int>>("Market groups", Settings.EsiClient.Market.Groups());
		}
		public Group Group { get; private set; } = new Group();
		public Group GetGroup(int marketGroupID)
		{
			return DownloadData<Group>("Market group", Settings.EsiClient.Market.Group(marketGroupID));
		}
		public List<int> GetRegionTypes(int regionID, int page)
		{
			return DownloadData<List<int>>("Region types", Settings.EsiClient.Market.Types(regionID, page)); // /markets/{region_id}/types/:public
		}





		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get referenced!
		/// </summary>
		[JsonConstructor]
		internal MarketData() : base()
		{
		}
		public MarketData(ref AppSettings settings) : base(ref settings)
		{
			GetData();
		}
		protected override void Download()
		{
			Prices = GetPrices();
			Orders = GetOrders(Settings.DefaultRegionID, MarketOrderType.Sell, 1, null);
			Groups = GetGroups();




			Console.WriteLine();
			SaveToFile();
		}
		protected override bool ReadInData()
		{
			using (StreamReader myReader = new StreamReader(SaveFile))
			{
				MarketData temp = Settings.serializer.Deserialize<MarketData>(new JsonTextReader(myReader));
				Console.Write($"Loading data from {Path.GetFileName(SaveFile)}");
				Prices = temp.Prices;
				

				Console.Write(" - successful");
				Console.WriteLine();
				Console.WriteLine();

				return true;
			}
		}
	}
}
