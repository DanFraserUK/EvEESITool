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
	public class Data:IDisposable
	{
		[JsonIgnore]
		public AppSettings Settings;

		public CharacterData Character;
		public CorporationData Corporation;
		public AllianceData Alliance;
		public MarketData Market;
		public PublicData Public;

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
			Authenticator = new Authenticator(ref Settings);
			Settings.EsiClient = Authenticator.StartAuthenticating();
			Character = new CharacterData(ref Settings);
			Corporation = new CorporationData(ref Settings);
			Alliance = new AllianceData(ref Settings);
			Market = new MarketData(ref Settings);
			Public = new PublicData(ref Settings);
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
					Settings.Dispose();// or client.Close();
					Settings = null;
				}
				// Dispose remaining objects,
				if (Authenticator != null)
				{
					Authenticator.Dispose();// or client.Close();
					Authenticator = null;
				}
				// Dispose remaining objects,
				if (Alliance != null)
				{
					Alliance.Dispose();// or client.Close();
					Alliance = null;
				}
				// Dispose remaining objects,
				if (Character != null)
				{
					Character.Dispose();// or client.Close();
					Character = null;
				}
				// Dispose remaining objects,
				if (Corporation != null)
				{
					Corporation.Dispose();// or client.Close();
					Corporation = null;
				}
				// Dispose remaining objects,
				if (Market != null)
				{
					Market.Dispose();// or client.Close();
					Market = null;
				}
				// Dispose remaining objects,
				if (Public != null)
				{
					Public.Dispose();// or client.Close();
					Public = null;
				}
				// Dispose remaining objects,
			}
		}
	}
}
