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
using ESI.NET.Models.Clones;
using ESI.NET.Models.Fittings;
using ESI.NET.Models;
using System.Reflection;
using System.Timers;

namespace EvEESITool
{
	public class Enums
	{

	}
	public static class Extensions
	{
		public static InvTypes Search(this List<InvTypes> item, int searchValue)
		{
			// list.Find(i => i.Property == value);
			return item.Find(i => i.TypeID == searchValue);
		}
		public static InvItems Search(this List<InvItems> item, int searchValue)
		{
			// list.Find(i => i.Property == value);
			return item.Find(i => i.ItemID == searchValue);
		}
		public static StaStations Search(this List<StaStations> item, int searchValue)
		{
			// list.Find(i => i.Property == value);
			return item.Find(i => i.StationID == searchValue);
		}
		public static MapSolarSystems Search(this List<MapSolarSystems> item, int searchValue)
		{
			// list.Find(i => i.Property == value);
			return item.Find(i => i.SolarSystemID == searchValue);
		}
	}
}
