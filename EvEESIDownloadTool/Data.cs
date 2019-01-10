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

namespace EvEESIDownloadTool
{
	public class Data
	{
		//[JsonIgnore]
		//SDEData SDE;// = new SDEData();
		[JsonIgnore]
		public AppSettings Settings;
		public CharacterData Character;
		public CorporationData Corporation;
		public AllianceData Alliance;
		public MarketData Market;
		public Authenticator Authenticator;
		public EsiClient _client;
		public Data()
		{
			// load everything
			Settings = new AppSettings(ref _client);
			//SDE = new SDEData(ref Settings);
			Authenticator = new Authenticator(ref _client, ref Settings);
			_client = Authenticator.StartAuthenticating();
			Character = new CharacterData(ref _client, ref Settings);
			Corporation = new CorporationData(ref _client, ref Settings);
			Alliance = new AllianceData(ref _client, ref Settings);
			Market = new MarketData(ref _client, ref Settings);
		}
	}
}
