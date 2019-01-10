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
		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get referenced!
		/// </summary>
		[JsonConstructor]
		internal MarketData() : base()
		{
		}
		public MarketData(ref AppSettings settings) : base(ref settings)
		{

		}
	}
}
