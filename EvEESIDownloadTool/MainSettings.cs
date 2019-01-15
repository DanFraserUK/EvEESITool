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
	public class MainSettings
	{
		[JsonIgnore]
		internal readonly string DataDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\";
		[JsonIgnore]
		internal readonly string SDEDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\";
		[JsonIgnore]
		internal readonly string AppDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";

		[JsonIgnore]
		internal JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
		[JsonIgnore]
		internal JsonReader jsonReader;

		public int MarketHistoryDays { get; private set; } = 10;
		public int DefaultRegionID { get; private set; } = 10000002;
		[JsonIgnore]
		public bool InternetAccessAvailable { get; internal  set; } = false;
		public bool SkipAuthenticating { get; private set; } = false;
		public bool SaveDataWhenDownloaded { get; private set; } = true;
		[JsonIgnore]
		public int DefaultTimerTimeSpan { get; private set; } = 60 * 1000;//60 * 60 * 1000;
		[JsonIgnore]
		public int TimerEventCounters { get; set; } = 0;
		public int TimerMinutes { get; private set; } = 60;
		[JsonIgnore]
		public int TimerSeconds { get; private set; } = 60;
		[JsonIgnore]
		public int TimerMilliseconds { get; private set; } = 1000;


		public MainSettings()
		{
			CheckFolders();
		}

		public void CheckFolders()
		{
			if (!Directory.Exists(DataDirectory))
			{
				Directory.CreateDirectory(DataDirectory);
			}
			if (!Directory.Exists(SDEDirectory))
			{
				Directory.CreateDirectory(SDEDirectory);
			}
		}

		public void Save()
		{
			if (!Directory.Exists(DataDirectory))
			{
				Directory.CreateDirectory(DataDirectory);
			}
			using (StreamWriter file = File.CreateText(DataDirectory + "settings.json"))
			{
				serializer.Serialize(file, this);
			}
		}
		public void Load()
		{
			using (StreamReader myReader = new StreamReader(DataDirectory + "settings.json"))
			{
				MainSettings newFile = new MainSettings();
				 jsonReader = new JsonTextReader(myReader);
				newFile = serializer.Deserialize<MainSettings>(jsonReader);
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
		public void Dispose()
		{
			Save();
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
