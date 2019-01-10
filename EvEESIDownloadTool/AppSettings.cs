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

namespace EvEESIDownloadTool
{
	public class AppSettings
	{
		public AuthorizedCharacterData AuthorisationData { get; set; } = new AuthorizedCharacterData();
		public int MarketHistoryDays { get; private set; } = 45;
		public int DefaultRegionID { get; private set; } = 10000043;
		public ConfigClass Config { get; private set; } = new ConfigClass();

		[JsonIgnore]
		public bool LoadedFromFile { get; private set; } = false;
		[JsonIgnore]
		EsiClient EsiClient { get; set; }
		[JsonIgnore]
		private readonly string SaveFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\settings.dat";
		[JsonIgnore]
		public readonly string DataDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\";
		[JsonIgnore]
		public readonly string SDEDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\";

		public AppSettings()
		{

		}
		public AppSettings(ref EsiClient esiClient)
		{
			if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\"))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\");
			}
			if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\"))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\");
			}

			EsiClient = esiClient;

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
				Config = new ConfigClass();
			}
			Save();
		}

		// todo HIDE THIS!
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
			// todo hide this!!!
			public string CCEsiUrl = "https://esi.evetech.net/";
			public DataSource CCDataSource = DataSource.Tranquility;
			public string CCClientId = "1fdbf25289cd4159b919109a72ff6324";
			public string CCSecretKey = "jDGeNj2ATou7bkubRjCnhW7JQGElSMORfhvxgjbm";
			public string CCCallbackUrl = "https://localhost/callback/";
			public string CCUserAgent = "danielfras@gmail.com";

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
	}
}
