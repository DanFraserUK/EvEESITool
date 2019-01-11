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

namespace EvEESITool
{
	class Program
	{
		static void Main(string[] args)
		{
			Data esiData = new Data();

			// example
			ESI.NET.Models.Alliance.Alliance a = esiData.Alliance.GetAlliance(esiData.Corporation.AllianceHistory[1].AllianceId);

			Console.WriteLine("Press a key to end");

			Console.ReadKey();
		}
	}
}
