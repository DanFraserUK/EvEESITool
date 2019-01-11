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
			Settings = new AppSettings(true);
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
