﻿using ESI.NET;
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
	public class Profile : IDisposable
	{
		[JsonIgnore]
		public ProfileSettings Settings;

		public CharacterData Character;

		public CorporationData Corporation;
		public AllianceData Alliance;
		
		//public MarketData Market;
		// public PublicData Public;
		// public UniverseData Universe;

		internal Authenticator Authenticator;

		/// <summary>
		/// Creates a new profile and commits to a new authorisation procedure
		/// </summary>
		public Profile(ref MainSettings mainSettings)
		{
			Settings = new ProfileSettings(ref mainSettings);
			Authenticate();
			if (!Settings.MainSettings.NoDownloading)
			{
				CreateData();
			}
		}

		public Profile(ref MainSettings mainSettings, ConfigClass config)
		{
			Settings = new ProfileSettings(ref mainSettings)
			{
				Config = config
			};
			Authenticate();
			if (!Settings.MainSettings.NoDownloading)
			{
				CreateData();
			}
		}

		/// <summary>
		/// Loads an existing profile from the folder supplied
		/// </summary>
		/// <param name="profileName"></param>
		public Profile(ref MainSettings mainSettings, string profileName)
		{
			Settings = new ProfileSettings(ref mainSettings, profileName);
			Authenticate();
			if (!Settings.MainSettings.NoDownloading)
			{
				CreateData();
			}
		}

		public void Authenticate()
		{
			Authenticator = new Authenticator(ref Settings);
			Settings.EsiClient = Authenticator.StartAuthenticating();
		}


		public void CreateData()
		{
			Character = new CharacterData(ref Settings);
			Corporation = new CorporationData(ref Settings);
			Alliance = new AllianceData(ref Settings);
			//Market = new MarketData(ref Settings);
			//Public = new PublicData(ref Settings);
			//Universe = new UniverseData(ref Settings);
		}

		public override string ToString()
		{
			return Character.Information.Name + ", " + Character.Wallet.Balance.ToString("N2") + " ISK, " + Corporation.Information.Name + ", " + Corporation.Information.Ticker;
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
				if (Character != null)
				{
					Character.Dispose();
					Character = null;
				}
			}
		}
	}
}
