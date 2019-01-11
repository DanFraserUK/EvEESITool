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
	public class MyOrder : Order
	{
		public MyOrder(Order newOrder)
		{
			this.AccountId = newOrder.AccountId;
			this.Duration = newOrder.AccountId;
			this.Escrow = newOrder.AccountId;
			this.IsBuyOrder = newOrder.IsBuyOrder;
			this.IsCorp = newOrder.IsCorp;
			this.IsCorporation = newOrder.IsCorporation;
			this.Issued = newOrder.Issued;
			this.LocationId = newOrder.LocationId;
			this.MinVolume = newOrder.MinVolume;
			this.OrderId = newOrder.OrderId;
			this.Price = newOrder.Price;
			this.Range = newOrder.Range;
			this.RegionId = newOrder.RegionId;
			this.State = newOrder.State;
			this.TypeId = newOrder.TypeId;
			this.VolumeRemain = newOrder.VolumeRemain;
			this.VolumeTotal = newOrder.VolumeTotal;
			this.WalletDivision = newOrder.WalletDivision;
		}
		[JsonIgnore]
		public string StationName { get; set; }
		[JsonIgnore]
		public string ItemName { get; set; }
		public override string ToString()
		{
			return $"{ItemName}, Price : {Price.ToString("N2")}, Station : {StationName}, Qty : {VolumeRemain}";
		}
	}
}
