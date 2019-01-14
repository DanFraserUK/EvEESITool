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
    public class MarketData : DataClassesBase
    {
        public List<Price> Prices { get; private set; } = new List<Price>();
        public List<Price> GetPrices()
        {
            return DownloadData("Prices", Settings.EsiClient.Market.Prices());
        }
        public List<Order> Orders { get; private set; } = new List<Order>();
        public List<Order> GetOrders(int regionID, MarketOrderType orderType, int page, int? typeID)
        {
            return DownloadData("Region orders", Settings.EsiClient.Market.RegionOrders(regionID, orderType, page, typeID));
        }
        public List<Statistic> TypeHistory { get; private set; } = new List<Statistic>();
        public List<Statistic> GetTypeHistory(int regionID, int typeID)
        {
            return DownloadData("Type history", Settings.EsiClient.Market.TypeHistoryInRegion(regionID, typeID));
        }
        public List<Order> GetStructureOrders(long structureID, int page)
        {
            return DownloadData("Structure orders", Settings.EsiClient.Market.StructureOrders(structureID, page));
        }
        public List<int> Groups { get; private set; } = new List<int>();
        public List<int> GetGroups()
        {
            return DownloadData("Market groups", Settings.EsiClient.Market.Groups());
        }
        public Group Group { get; private set; } = new Group();
        public Group GetGroup(int marketGroupID)
        {
            return DownloadData("Market group", Settings.EsiClient.Market.Group(marketGroupID));
        }
        public List<int> GetRegionTypes(int regionID, int page)
        {
            return DownloadData("Region types", Settings.EsiClient.Market.Types(regionID, page)); // /markets/{region_id}/types/:public
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
                MarketData temp = AppSettings.serializer.Deserialize<MarketData>(new JsonTextReader(myReader));
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
