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
	public class Data
	{
		[JsonIgnore]
		public AppSettings Settings;

		public CharacterData Character;
		public CorporationData Corporation;
		public AllianceData Alliance;
		public MarketData Market;
		public DogmaData Dogma;
		public FactionWarfareData FactionWarfare;
		public FleetData Fleets;

		public Authenticator Authenticator;
		public Data()
		{
			// load everything
			Settings = new AppSettings();
			Authenticator = new Authenticator(ref Settings);
			Settings.EsiClient = Authenticator.StartAuthenticating();
			Character = new CharacterData(ref Settings);
			Corporation = new CorporationData(ref Settings);
			Alliance = new AllianceData(ref Settings);
			Market = new MarketData(ref Settings);
			Dogma = new DogmaData(ref Settings);
			FactionWarfare = new FactionWarfareData(ref Settings);
			Fleets = new FleetData(ref Settings);
		}
	}
}
