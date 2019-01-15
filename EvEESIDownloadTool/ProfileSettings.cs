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
using System.Web;
using System.Net;
using System.Timers;

namespace EvEESITool
{
	public class ProfileSettings
	{
		// Profile unique properties
		// remember, profile is the old appsettings
		// many of the old app settings can easily be ported to the new datasettings
		internal string ProfileName;

		public AuthorizedCharacterData AuthorisationData { get; set; } = new AuthorizedCharacterData();
		public ConfigClass Config { get; internal set; } = new ConfigClass();
		[JsonIgnore]
		public EsiClient EsiClient { get; set; }
		[JsonIgnore]
		public bool LoadedFromFile { get; private set; } = false;

		internal readonly MainSettings MainSettings;

		public ProfileSettings()
		{

		}

		public ProfileSettings(ref MainSettings mainSettings)
		{
			MainSettings = mainSettings;
			mainSettings.CheckInternetAccess();
			CheckForScopesFile();
			if (File.Exists(MainSettings.DataDirectory + ProfileName + $"\\{ProfileName}.json"))
			{
				Console.WriteLine();
				using (StreamReader myReader = new StreamReader(MainSettings.DataDirectory + ProfileName + $"\\{ProfileName}.json"))
				{
					ProfileSettings newFile = new ProfileSettings();
					MainSettings.jsonReader = new JsonTextReader(myReader);
					newFile = MainSettings.serializer.Deserialize<ProfileSettings>(MainSettings.jsonReader);
					AuthorisationData = newFile.AuthorisationData;
					Config = newFile.Config;
					LoadedFromFile = true;
				}
			}
			else
			{
				if (File.Exists(MainSettings.DataDirectory + "config.txt"))
				{
					using (StreamReader myReader = new StreamReader(MainSettings.DataDirectory + "config.txt"))
					{
						MainSettings.jsonReader = new JsonTextReader(myReader);
						Config = MainSettings.serializer.Deserialize<ConfigClass>(MainSettings.jsonReader);
						Console.WriteLine("Config settings imported.");
						Console.WriteLine();
					}
				}
				else
				{
					GetConfigDataFromUser();
				}
			}
			EsiClient = new EsiClient(Config.ConfigOutput());
		}
		private ProfileSettings(bool hidden)
		{

		}

		public ProfileSettings(ref MainSettings mainSettings, string profileFolder)
		{
			MainSettings = mainSettings;
			ProfileName = profileFolder;
			mainSettings.CheckInternetAccess();
			CheckForScopesFile();
			if (File.Exists(MainSettings.DataDirectory + ProfileName + $"\\{ProfileName}.json"))
			{
				Console.WriteLine();
				using (StreamReader myReader = new StreamReader(MainSettings.DataDirectory + ProfileName + $"\\{ProfileName}.json"))
				{
					ProfileSettings newFile = new ProfileSettings();
					MainSettings.jsonReader = new JsonTextReader(myReader);
					newFile = MainSettings.serializer.Deserialize<ProfileSettings>(MainSettings.jsonReader);
					AuthorisationData = newFile.AuthorisationData;
					Config = newFile.Config;
					LoadedFromFile = true;
				}
			}
			else
			{
				if (File.Exists(MainSettings.DataDirectory + "config.txt"))
				{
					using (StreamReader myReader = new StreamReader(MainSettings.DataDirectory + "config.txt"))
					{
						MainSettings.jsonReader = new JsonTextReader(myReader);
						Config = MainSettings.serializer.Deserialize<ConfigClass>(MainSettings.jsonReader);
						Console.WriteLine("Config settings imported.");
						Console.WriteLine();
					}
				}
				else
				{
					GetConfigDataFromUser();
				}
			}
		}

		private void CheckForScopesFile()
		{
			if (!File.Exists(MainSettings.DataDirectory + "\\" + ProfileName + "\\scopes.dat"))
			{
				// I'd prefer to find a source on a website that lists all the scopes in an easy to access format to download and build this file if it is missing.
				// But in the meantime we have this silly part here!
				string stupidlyLongString = "publicData esi-calendar.respond_calendar_events.v1 esi-calendar.read_calendar_events.v1 esi-location.read_location.v1 esi-location.read_ship_type.v1 esi-mail.organize_mail.v1 esi-mail.read_mail.v1 esi-mail.send_mail.v1 esi-skills.read_skills.v1 esi-skills.read_skillqueue.v1 esi-wallet.read_character_wallet.v1 esi-wallet.read_corporation_wallet.v1 esi-search.search_structures.v1 esi-clones.read_clones.v1 esi-characters.read_contacts.v1 esi-universe.read_structures.v1 esi-bookmarks.read_character_bookmarks.v1 esi-killmails.read_killmails.v1 esi-corporations.read_corporation_membership.v1 esi-assets.read_assets.v1 esi-planets.manage_planets.v1 esi-fleets.read_fleet.v1 esi-fleets.write_fleet.v1 esi-ui.open_window.v1 esi-ui.write_waypoint.v1 esi-characters.write_contacts.v1 esi-fittings.read_fittings.v1 esi-fittings.write_fittings.v1 esi-markets.structure_markets.v1 esi-corporations.read_structures.v1 esi-corporations.write_structures.v1 esi-characters.read_loyalty.v1 esi-characters.read_opportunities.v1 esi-characters.read_chat_channels.v1 esi-characters.read_medals.v1 esi-characters.read_standings.v1 esi-characters.read_agents_research.v1 esi-industry.read_character_jobs.v1 esi-markets.read_character_orders.v1 esi-characters.read_blueprints.v1 esi-characters.read_corporation_roles.v1 esi-location.read_online.v1 esi-contracts.read_character_contracts.v1 esi-clones.read_implants.v1 esi-characters.read_fatigue.v1 esi-killmails.read_corporation_killmails.v1 esi-corporations.track_members.v1 esi-wallet.read_corporation_wallets.v1 esi-characters.read_notifications.v1 esi-corporations.read_divisions.v1 esi-corporations.read_contacts.v1 esi-assets.read_corporation_assets.v1 esi-corporations.read_titles.v1 esi-corporations.read_blueprints.v1 esi-bookmarks.read_corporation_bookmarks.v1 esi-contracts.read_corporation_contracts.v1 esi-corporations.read_standings.v1 esi-corporations.read_starbases.v1 esi-industry.read_corporation_jobs.v1 esi-markets.read_corporation_orders.v1 esi-corporations.read_container_logs.v1 esi-industry.read_character_mining.v1 esi-industry.read_corporation_mining.v1 esi-planets.read_customs_offices.v1 esi-corporations.read_facilities.v1 esi-corporations.read_medals.v1 esi-characters.read_titles.v1 esi-alliances.read_contacts.v1 esi-characters.read_fw_stats.v1 esi-corporations.read_fw_stats.v1 esi-corporations.read_outposts.v1 esi-characterstats.read.v1";
				using (StreamWriter myWriter = new StreamWriter(MainSettings.DataDirectory + "\\" + ProfileName + "\\scopes.dat"))
				{
					myWriter.WriteLine(stupidlyLongString);
				}
			}
		}
		public void GetConfigDataFromUser()
		{
			ConfigDataConsoleEntry();
		}
		private void ConfigDataConsoleEntry()
		{
			Config = new ConfigClass();
			Console.WriteLine("Esi URL set to https://esi.evetech.net/");
			Config.EsiUrl = "https://esi.evetech.net/";
			Console.WriteLine("Data source set to Tranquility");
			Config.DataSource = DataSource.Tranquility;
			Console.WriteLine("Copy and paste the Client ID and press enter");
			Config.ClientID = Console.ReadLine();
			Console.WriteLine("Copy and paste the Secret Key and press enter");
			Config.SecretKey = Console.ReadLine();
			Console.WriteLine("Copy and paste the Callback Url and press enter");
			Config.CallbackUrl = Console.ReadLine();
			Console.WriteLine("Type an identifier for yourself such as an email address - quoting EvEESITool :");
			Console.WriteLine("For your protection (and mine), you are required to supply a user_agent value.");
			Console.WriteLine("This can be your character name and/or project name. CCP will be more likely to");
			Console.WriteLine("contact you than just cut off access to ESI if you provide something that can");
			Console.WriteLine("identify you within the New Eden galaxy. Without this property populated,");
			Console.WriteLine("the wrapper will not work.");
			Console.WriteLine("");
			Config.UserAgent = Console.ReadLine();
		}
		public void Save()
		{
			if (!Directory.Exists(MainSettings.DataDirectory + ProfileName))
			{
				Directory.CreateDirectory(MainSettings.DataDirectory + ProfileName);
			}
			using (StreamWriter file = File.CreateText(MainSettings.DataDirectory + ProfileName + $"\\{ProfileName}.json"))
			{
				MainSettings.serializer.Serialize(file, this);
			}
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			//if (disposing)
			//{
			//	// dispose managed resources
			//	if (EsiClient != null)
			//	{
			//		EsiClient.Dispose();
			//		EsiClient = null;
			//	}
			//	// Dispose remaining objects,
			//}
		}
	}
}
