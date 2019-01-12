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
using EvEESITool.Models.Clones;
using EvEESITool.Models.Fittings;
using EvEESITool.Models;
using System.Web;
using System.Net;

namespace EvEESITool
{
	public class AppSettings
	{
		public AuthorizedCharacterData AuthorisationData { get; set; } = new AuthorizedCharacterData();
		public int MarketHistoryDays { get; private set; } = 10;
		public int DefaultRegionID { get; private set; } = 10000002;
		public ConfigClass Config { get; private set; } = new ConfigClass();
		[JsonIgnore]
		public bool LoadedFromFile { get; private set; } = false;
		[JsonIgnore]
		public EsiClient EsiClient { get; set; }
		[JsonIgnore]
		public JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
		[JsonIgnore]
		private readonly string SaveFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\settings.dat";
		[JsonIgnore]
		public readonly string DataDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\";
		[JsonIgnore]
		public readonly string SDEDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\";
		[JsonIgnore]
		public readonly string AppDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
		[JsonIgnore]
		public bool InternetAccessAvailable { get; private set; }
		public bool SkipAuthenticating { get; private set; } = false;
		public bool SaveDataWhenDownloaded { get; private set; } = true;

		public AppSettings()
		{

		}
		public AppSettings(bool fullStart)
		{
			if (fullStart)
			{
				CheckInternetAccess();
				if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\"))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\");
				}
				if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\"))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\");
				}

				CheckForScopesFile();
				CheckForScopesV2();
				if (File.Exists(SaveFile))
				{
					Console.WriteLine();
					using (StreamReader myReader = new StreamReader(SaveFile))
					{
						JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
						AppSettings newFile = new AppSettings();
						JsonReader jsonReader = new JsonTextReader(myReader);
						newFile = serializer.Deserialize<AppSettings>(jsonReader);
						AuthorisationData = newFile.AuthorisationData;
						MarketHistoryDays = newFile.MarketHistoryDays;
						DefaultRegionID = newFile.DefaultRegionID;
						Config = newFile.Config;
						DefaultRegionID = 10000002;
						LoadedFromFile = true;
					}
				}
				else
				{
					GetConfigDataFromUser();
				}
				EsiClient = new EsiClient(Config.ConfigOutput());
				Save();
			}
		}

		private void CheckForScopesFile()
		{
			if (!File.Exists(DataDirectory + "scopes.dat"))
			{
				// I'd prefer to find a source on a website that lists all the scopes in an easy to access format to download and build this file if it is missing.
				// But in the meantime we have this silly part here!
				string stupidlyLongString = "publicData esi-calendar.respond_calendar_events.v1 esi-calendar.read_calendar_events.v1 esi-location.read_location.v1 esi-location.read_ship_type.v1 esi-mail.organize_mail.v1 esi-mail.read_mail.v1 esi-mail.send_mail.v1 esi-skills.read_skills.v1 esi-skills.read_skillqueue.v1 esi-wallet.read_character_wallet.v1 esi-wallet.read_corporation_wallet.v1 esi-search.search_structures.v1 esi-clones.read_clones.v1 esi-characters.read_contacts.v1 esi-universe.read_structures.v1 esi-bookmarks.read_character_bookmarks.v1 esi-killmails.read_killmails.v1 esi-corporations.read_corporation_membership.v1 esi-assets.read_assets.v1 esi-planets.manage_planets.v1 esi-fleets.read_fleet.v1 esi-fleets.write_fleet.v1 esi-ui.open_window.v1 esi-ui.write_waypoint.v1 esi-characters.write_contacts.v1 esi-fittings.read_fittings.v1 esi-fittings.write_fittings.v1 esi-markets.structure_markets.v1 esi-corporations.read_structures.v1 esi-corporations.write_structures.v1 esi-characters.read_loyalty.v1 esi-characters.read_opportunities.v1 esi-characters.read_chat_channels.v1 esi-characters.read_medals.v1 esi-characters.read_standings.v1 esi-characters.read_agents_research.v1 esi-industry.read_character_jobs.v1 esi-markets.read_character_orders.v1 esi-characters.read_blueprints.v1 esi-characters.read_corporation_roles.v1 esi-location.read_online.v1 esi-contracts.read_character_contracts.v1 esi-clones.read_implants.v1 esi-characters.read_fatigue.v1 esi-killmails.read_corporation_killmails.v1 esi-corporations.track_members.v1 esi-wallet.read_corporation_wallets.v1 esi-characters.read_notifications.v1 esi-corporations.read_divisions.v1 esi-corporations.read_contacts.v1 esi-assets.read_corporation_assets.v1 esi-corporations.read_titles.v1 esi-corporations.read_blueprints.v1 esi-bookmarks.read_corporation_bookmarks.v1 esi-contracts.read_corporation_contracts.v1 esi-corporations.read_standings.v1 esi-corporations.read_starbases.v1 esi-industry.read_corporation_jobs.v1 esi-markets.read_corporation_orders.v1 esi-corporations.read_container_logs.v1 esi-industry.read_character_mining.v1 esi-industry.read_corporation_mining.v1 esi-planets.read_customs_offices.v1 esi-corporations.read_facilities.v1 esi-corporations.read_medals.v1 esi-characters.read_titles.v1 esi-alliances.read_contacts.v1 esi-characters.read_fw_stats.v1 esi-corporations.read_fw_stats.v1 esi-corporations.read_outposts.v1 esi-characterstats.read.v1";
				using (StreamWriter myWriter = new StreamWriter(AppDirectory + "\\scopes.dat"))
				{
					myWriter.WriteLine(stupidlyLongString);
				}
			}
		}

		private void CheckForScopesV2()
		{
			// https://esi.evetech.net/latest/swagger.json
			// slightly hacky, but using the official link for ESI stuff has the scopes riiiiight at the end!
			// and as someone else on the internet said - "This is why I love the .net libs ..." – Byron Whitlock Jul 12 '10 at 20:27
			string contents;
			using (var wc = new WebClient())
			{
				contents = wc.DownloadString("https://esi.evetech.net/latest/swagger.json");
			}
			string scopes = contents.Substring(contents.IndexOf("scopes"));
			scopes = scopes.Substring(scopes.IndexOf('{'));
			scopes = scopes.Substring(0, scopes.IndexOf('}') + 1);
			string[] parts = scopes.Split(',');
			List<string> newScopes = new List<string>();
			foreach (string s in parts)
			{
				newScopes.Add(s.Split(':')[0].Replace("\"", ""));
			}
			contents += "";
		}
		public void GetConfigDataFromUser()
		{
			ConfigDataConsoleEntry();
		}
		private void ConfigDataConsoleEntry()
		{
			Config = new ConfigClass();
			Console.WriteLine("Esi URL set to https://esi.evetech.net/");
			Config.CCEsiUrl = "https://esi.evetech.net/";
			Console.WriteLine("Data source set to Tranquility");
			Config.CCDataSource = DataSource.Tranquility;
			Console.WriteLine("Copy and paste the Client ID and press enter");
			Config.CCClientId = Console.ReadLine();
			Console.WriteLine("Copy and paste the Secret Key and press enter");
			Config.CCSecretKey = Console.ReadLine();
			Console.WriteLine("Copy and paste the Callback Url and press enter");
			Config.CCCallbackUrl = Console.ReadLine();
			Console.WriteLine("Type an identifier for yourself such as an email address - quoting EvEESITool :");
			Console.WriteLine("For your protection (and mine), you are required to supply a user_agent value.");
			Console.WriteLine("This can be your character name and/or project name. CCP will be more likely to");
			Console.WriteLine("contact you than just cut off access to ESI if you provide something that can");
			Console.WriteLine("identify you within the New Eden galaxy. Without this property populated,");
			Console.WriteLine("the wrapper will not work.");
			Console.WriteLine("");
			Config.CCUserAgent = Console.ReadLine();
		}
		public void Save()
		{
			using (StreamWriter file = File.CreateText(SaveFile))
			{
				JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
				//serialize object directly into file stream
				serializer.Serialize(file, this);
			}
		}
		public void Load()
		{
			using (StreamReader myReader = new StreamReader(SaveFile))
			{
				JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
				AppSettings newFile = new AppSettings();
				JsonReader jsonReader = new JsonTextReader(myReader);
				newFile = serializer.Deserialize<AppSettings>(jsonReader);
			}
		}
		public class ConfigClass
		{
			public string CCEsiUrl;
			public DataSource CCDataSource;
			public string CCClientId;
			public string CCSecretKey;
			public string CCCallbackUrl;
			public string CCUserAgent;

			public IOptions<EsiConfig> ConfigOutput()
			{
				IOptions<EsiConfig> result = Options.Create(new EsiConfig()
				{
					EsiUrl = CCEsiUrl,
					DataSource = CCDataSource,
					ClientId = CCClientId,
					SecretKey = CCSecretKey,
					CallbackUrl = CCCallbackUrl,
					UserAgent = CCUserAgent
				});
				return result;
			}

			public ConfigClass()
			{

			}
		}
		public void CheckInternetAccess()
		{
			try
			{
				using (var client = new WebClient() { Proxy = null })
				{
					using (client.OpenRead("http://clients3.google.com/generate_204"))
					{
						InternetAccessAvailable = true;
					}
				}
			}
			catch
			{
				InternetAccessAvailable = false;
			}
		}
	}
}
