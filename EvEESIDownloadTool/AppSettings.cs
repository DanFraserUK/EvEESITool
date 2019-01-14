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
    public class AppSettings : IDisposable
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
        public static JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        [JsonIgnore]
        private string SaveFile;// = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\settings.dat";
       [JsonIgnore]
        public readonly string DataDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\";
        [JsonIgnore]
        public readonly string SDEDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SDE\\";
        [JsonIgnore]
        public readonly string AppDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        [JsonIgnore]
        public bool InternetAccessAvailable { get; private set; } = false;
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

                List<string> profileDirectories = new List<string>();
                profileDirectories.AddRange(Directory.GetDirectories(DataDirectory));

                if (profileDirectories.Count == 0)
                {
                    // blank load
                }
                else if (profileDirectories.Count == 1)
                {
                    // simple easy load!
                    SaveFile = profileDirectories[0] + $"\\settings.json";
                }
                else if (profileDirectories.Count > 1)
                {
                    // uh oh, this is the hard bit
                }

                if (File.Exists(SaveFile))
                {
                    Console.WriteLine();
                    using (StreamReader myReader = new StreamReader(SaveFile))
                    {
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
                    if (File.Exists(AppDirectory + "config.txt"))
                    {
                        using (StreamReader myReader = new StreamReader(AppDirectory + "config.txt"))
                        {
                            //ConfigClass temp = new ConfigClass();
                            JsonReader jsonReader = new JsonTextReader(myReader);
                            Config = serializer.Deserialize<ConfigClass>(jsonReader);
                            //Config.CallbackUrl = temp.CallbackUrl;
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
                // Save();
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
            if (!Directory.Exists(DataDirectory + $"\\{AuthorisationData.CharacterID}\\"))
            {
                Directory.CreateDirectory(DataDirectory + $"\\{AuthorisationData.CharacterID}\\");
            }
            SaveFile = DataDirectory + $"\\{AuthorisationData.CharacterID}\\settings.json";
            using (StreamWriter file = File.CreateText(SaveFile))
            {
                serializer.Serialize(file, this);
            }
        }
        public void Load()
        {
            using (StreamReader myReader = new StreamReader(SaveFile))
            {
                AppSettings newFile = new AppSettings();
                JsonReader jsonReader = new JsonTextReader(myReader);
                newFile = serializer.Deserialize<AppSettings>(jsonReader);
            }
        }
        public class ConfigClass
        {
            public string EsiUrl;
            public DataSource DataSource;
            public string ClientID;
            public string SecretKey;
            public string CallbackUrl;
            public string UserAgent;

            public IOptions<EsiConfig> ConfigOutput()
            {
                IOptions<EsiConfig> result = Options.Create(new EsiConfig()
                {
                    EsiUrl = EsiUrl,
                    DataSource = DataSource,
                    ClientId = ClientID,
                    SecretKey = SecretKey,
                    CallbackUrl = CallbackUrl,
                    UserAgent = UserAgent
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
