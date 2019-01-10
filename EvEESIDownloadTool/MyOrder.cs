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
		public MyOrder(Order newOrder, ref SDEData sde)
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
			//SDE = sde;

			//StationName = SDE.StaStations.ContainsKey(LocationId) ? SDE.StaStations[LocationId].StationName : "Unknown Type";
			//ItemName = SDE.InvTypes.ContainsKey(TypeId) ? SDE.InvTypes[TypeId].TypeName : "Unknown Type";
		}

		[JsonIgnore]
		public string StationName { get; set; }
		[JsonIgnore]
		public string ItemName { get; set; }
		public override string ToString()
		{
			return $"{ItemName}, Price : {Price.ToString("N2")}, Station : {StationName}, Qty : {VolumeRemain}";
		}
		//[JsonIgnore]
		//private SDEData SDE { get; set; }
	}
}
