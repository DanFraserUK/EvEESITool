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
	public class Data : IDisposable
	{
		[JsonIgnore]
		public AppSettings Settings;
		public SDEData SDE;
		public CharacterData Character;
		public CorporationData Corporation;
		public AllianceData Alliance;
		public MarketData Market;
		public PublicData Public;
		public UniverseData Universe;

		public Authenticator Authenticator;
		public Data()
		{
			Settings = new AppSettings(true);
			CreateData();
		}
		public Data(AppSettings settings)
		{
			Settings = settings;
			CreateData();
		}
		public void CreateData()
		{
			SDE = new SDEData(ref Settings);
			Authenticator = new Authenticator(ref Settings);
			Settings.EsiClient = Authenticator.StartAuthenticating();
			Character = new CharacterData(ref Settings);
			Corporation = new CorporationData(ref Settings);
			Alliance = new AllianceData(ref Settings);
			Market = new MarketData(ref Settings);
			Public = new PublicData(ref Settings);
			Universe = new UniverseData(ref Settings);
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources
				if (Settings != null)
				{
					Settings.Dispose();
					Settings = null;
				}
				// Dispose remaining objects,
				if (Authenticator != null)
				{
					Authenticator.Dispose();
					Authenticator = null;
				}
				// Dispose remaining objects,
				if (Alliance != null)
				{
					Alliance.Dispose();
					Alliance = null;
				}
				// Dispose remaining objects,
				if (Character != null)
				{
					Character.Dispose();
					Character = null;
				}
				// Dispose remaining objects,
				if (Corporation != null)
				{
					Corporation.Dispose();
					Corporation = null;
				}
				// Dispose remaining objects,
				if (Market != null)
				{
					Market.Dispose();
					Market = null;
				}
				// Dispose remaining objects,
				if (Public != null)
				{
					Public.Dispose();
					Public = null;
				}
				// Dispose remaining objects,
			}
		}
	}
}
