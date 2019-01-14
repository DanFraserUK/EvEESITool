using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
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
using AssetsItem = ESI.NET.Models.Assets.Item;
using ESI.NET.Models.Bookmarks;
using ESI.NET.Models.Calendar;
using ESI.NET.Models.FactionWarfare;
using ESI.NET.Models.Fleets;
using ESI.NET.Models.Killmails;
using ESI.NET.Models.Loyalty;
using ESI.NET.Models.Mail;
using ESI.NET.Models.PlanetaryInteraction;

namespace EvEESITool
{
    public class CharacterData : DataClassesBase
    {
        public ESI.NET.Models.Character.Information Information { get; private set; } = new ESI.NET.Models.Character.Information();
        public ESI.NET.Models.Character.Information GetInformation(int characterID)
        {
            return DownloadData("Information", Settings.EsiClient.Character.Information(characterID));
        }
        public SkillDetails Skills { get; private set; } = new SkillDetails();
        public Attributes Attributes { get; private set; } = new Attributes();
        public List<SkillQueueItem> SkillQueue { get; set; } = new List<SkillQueueItem>();
        public List<Stats> Stats { get; private set; } = new List<Stats>();
        public Location Location { get; private set; } = new Location();
        public Activity Activity { get; private set; } = new Activity();
        public Ship Ship { get; private set; } = new Ship();
        public List<AssetsItem> Assets { get; private set; } = new List<AssetsItem>();
        public List<ItemLocation> AssetsLocations(List<long> assetsItemID)
        {
            return DownloadData("Asset location", Settings.EsiClient.Assets.LocationsForCharacter(assetsItemID));
        }
        public List<ItemName> AssetsNames(List<long> assetsItemID)
        {
            return DownloadData("Asset name", Settings.EsiClient.Assets.NamesForCharacter(assetsItemID));
        }
        public List<JournalEntry> Journal { get; private set; } = new List<JournalEntry>();
        public List<Transaction> Transactions { get; private set; } = new List<Transaction>();
        public List<Notification> Notifications { get; private set; } = new List<Notification>();
        public List<Job> IndustryJobs { get; private set; } = new List<Job>();
        public Clones Clones { get; private set; } = new Clones();
        public List<int> Implants { get; private set; } = new List<int>();
        public List<Fitting> Fittings { get; private set; } = new List<Fitting>();
        public List<Bookmark> Bookmarks { get; private set; } = new List<Bookmark>();
        public List<Folder> BookmarkFolders { get; private set; } = new List<Folder>();
        public List<Event> CalendarEvents { get; private set; } = new List<Event>();
        public Event CalendarEvent(int eventID)
        {
            return DownloadData("", Settings.EsiClient.Calendar.Event(eventID));
        }
        public Images Portrait { get; private set; } = new Images();
        public Images GetPortrait(int characterID)
        {
            return DownloadData("Portrait", Settings.EsiClient.Character.Portrait(characterID));
        }
        public List<Corporation> CorporationHistory { get; private set; } = new List<Corporation>();
        public List<Corporation> GetCorporationHistory(int characterID)
        {
            return DownloadData("Corporation history", Settings.EsiClient.Character.CorporationHistory(characterID));
        }
        // disabled
        //public List<ChatChannel> ChatChannels { get; private set; } = new List<ChatChannel>();
        public List<Medal> Medals { get; private set; } = new List<Medal>();
        public List<Standing> Standings { get; private set; } = new List<Standing>();
        public List<Agent> ResearchAgents { get; private set; } = new List<Agent>();
        public List<Blueprint> Blueprints { get; private set; } = new List<Blueprint>();
        public Fatigue Fatigue { get; private set; } = new Fatigue();
        public List<ContactNotification> ContactNotifications { get; private set; } = new List<ContactNotification>();
        public Roles Roles { get; private set; } = new Roles();
        public List<Title> Titles { get; private set; } = new List<Title>();
        public List<ESI.NET.Models.Contacts.Contact> Contacts { get; private set; } = new List<ESI.NET.Models.Contacts.Contact>();
        public List<ESI.NET.Models.Contacts.Label> Labels { get; private set; } = new List<ESI.NET.Models.Contacts.Label>();
        public List<ESI.NET.Models.Contracts.Contract> Contracts { get; private set; } = new List<ESI.NET.Models.Contracts.Contract>();
        public List<ESI.NET.Models.Contracts.ContractItem> ContractItems(int contractID)
        {
            return DownloadData("Contract items", Settings.EsiClient.Contracts.CharacterContractItems(contractID, 1));
        }
        public List<ESI.NET.Models.Contracts.Bid> ContractBids(int contractID)
        {
            return DownloadData("Contract bids", Settings.EsiClient.Contracts.CharacterContractBids(contractID, 1));
        }
        public Stat FactionWarfareStats { get; private set; } = new Stat();
        public FleetInfo Fleet { get; private set; } = new FleetInfo();
        public List<Entry> MiningLedger { get; private set; } = new List<Entry>();
        public List<Killmail> Killmails { get; private set; } = new List<Killmail>();
        public List<Points> LoyaltyPoints { get; private set; } = new List<Points>();
        public List<Order> MarketOrders { get; private set; } = new List<Order>();
        public List<Planet> Planets { get; private set; } = new List<Planet>();
        public ColonyLayout ColonyLayout(int planetID)
        {
            return DownloadData("Colony layout", Settings.EsiClient.PlanetaryInteraction.ColonyLayout(planetID));
        }
        public Schematic SchematicInformation { get; private set; } = new Schematic();
        public Schematic GetSchematicInformation(int schematicID)
        {
            return DownloadData("Schematic information", Settings.EsiClient.PlanetaryInteraction.SchematicInformation(schematicID));
        }






        public int CharacterID { get; set; } = 0;
        public decimal Wallet { get; set; } = 0;

        [JsonConstructor]
        internal CharacterData()
        {
        }
        internal CharacterData(ref ProfileSettings settings) : base(ref settings)
        {
            CharacterID = Settings.AuthorisationData.CharacterID;
            GetData();
        }
        public override string ToString()
        {
            return $"{Information.Name}, {Wallet.ToString("N2")} ISK";
        }
        protected override void Download()
        {
            Wallet = DownloadData("Wallet Balance", Settings.EsiClient.Wallet.CharacterWallet());
            Information = DownloadData("Information", Settings.EsiClient.Character.Information(CharacterID));
            Skills = DownloadData("Skills", Settings.EsiClient.Skills.List());
            Attributes = DownloadData("Attributes", Settings.EsiClient.Skills.Attributes());
            Stats = DownloadData("Stats", Settings.EsiClient.Character.Stats());
            SkillQueue = DownloadData("Skill Queue", Settings.EsiClient.Skills.Queue());
            Location = DownloadData("Location", Settings.EsiClient.Location.Location());
            Activity = DownloadData("Activity", Settings.EsiClient.Location.Online());
            Ship = DownloadData("Ship", Settings.EsiClient.Location.Ship());
            Assets = DownloadData("Assets", Settings.EsiClient.Assets.ForCharacter());
            Journal = DownloadData("Journal", Settings.EsiClient.Wallet.CharacterJournal());
            Transactions = DownloadData("Transactions", Settings.EsiClient.Wallet.CharacterTransactions());
            Notifications = DownloadData("Notifications", Settings.EsiClient.Character.Notifications());
            IndustryJobs = DownloadData("Industry jobs", Settings.EsiClient.Industry.JobsForCharacter());
            Clones = DownloadData("Clones", Settings.EsiClient.Clones.List());
            Implants.AddRange(DownloadData("Implants", Settings.EsiClient.Clones.Implants()));
            Fittings = DownloadData("Fittings", Settings.EsiClient.Fittings.List());
            Bookmarks = DownloadData("Bookmarks", Settings.EsiClient.Bookmarks.ForCharacter());
            BookmarkFolders = DownloadData("Bookmark folders", Settings.EsiClient.Bookmarks.FoldersForCharacter());
            CalendarEvents = DownloadData("Calendar events", Settings.EsiClient.Calendar.Events());
            Portrait = DownloadData("Portrait", Settings.EsiClient.Character.Portrait(CharacterID));
            CorporationHistory = DownloadData("Corporation history", Settings.EsiClient.Character.CorporationHistory(CharacterID));
            // disabled because of chat servers being borked i guess
            //ChatChannels = DownloadData("Chat channels", Settings.EsiClient.Character.ChatChannels());
            Medals = DownloadData("Medals", Settings.EsiClient.Character.Medals());
            Standings = DownloadData("Standings", Settings.EsiClient.Character.Standings());
            ResearchAgents = DownloadData("Research agents", Settings.EsiClient.Character.AgentsResearch());
            Blueprints = DownloadData("Blueprints", Settings.EsiClient.Character.Blueprints(1));
            Fatigue = DownloadData("Fatigue", Settings.EsiClient.Character.Fatigue());
            ContactNotifications = DownloadData("Contact notifications", Settings.EsiClient.Character.ContactNotifications());
            Roles = DownloadData("Roles", Settings.EsiClient.Character.Roles());
            Titles = DownloadData("Titles", Settings.EsiClient.Character.Titles());
            Contacts = DownloadData("Contacts", Settings.EsiClient.Contacts.ListForCharacter(1));
            Labels = DownloadData("Labels", Settings.EsiClient.Contacts.LabelsForCharacter());
            Contracts = DownloadData("Contracts", Settings.EsiClient.Contracts.CharacterContracts(1));
            FactionWarfareStats = DownloadData("Faction warfare statistics", Settings.EsiClient.FactionWarfare.StatsForCharacter());
            MiningLedger = DownloadData("Mining ledger", Settings.EsiClient.Industry.MiningLedger(1));
            Killmails = DownloadData("Killmails", Settings.EsiClient.Killmails.ForCharacter());
            LoyaltyPoints = DownloadData("Loyalty points", Settings.EsiClient.Loyalty.Points());
            //Mail = new MailData(ref Settings);
            //Mails = GetMails();
            MarketOrders = DownloadData("Market orders", Settings.EsiClient.Market.CharacterOrders());
            Fleet = DownloadData("Fleet", Settings.EsiClient.Fleets.FleetInfo());
            Planets = DownloadData("Planets", Settings.EsiClient.PlanetaryInteraction.Colonies());





            Console.WriteLine();
            SaveToFile();
        }
        protected override bool ReadInData()
        {
            using (StreamReader myReader = new StreamReader(SaveFile))
            {
                CharacterData temp = Settings.MainSettings.serializer.Deserialize<CharacterData>(new JsonTextReader(myReader));
                Console.Write($"Loading data from {Path.GetFileName(SaveFile)}");
                Information = temp.Information;
                Skills = temp.Skills;
                Attributes = temp.Attributes;
                SkillQueue = temp.SkillQueue;
                Stats = temp.Stats;
                Location = temp.Location;
                Activity = temp.Activity;
                Ship = temp.Ship;
                Assets = temp.Assets;
                Journal = temp.Journal;
                Transactions = temp.Transactions;
                Notifications = temp.Notifications;
                IndustryJobs = temp.IndustryJobs;
                CharacterID = Settings.AuthorisationData.CharacterID;
                Wallet = temp.Wallet;
                Clones = temp.Clones;
                Implants = temp.Implants;
                Fittings = temp.Fittings;
                Bookmarks = temp.Bookmarks;
                BookmarkFolders = temp.BookmarkFolders;
                CalendarEvents = temp.CalendarEvents;
                Portrait = temp.Portrait;
                CorporationHistory = temp.CorporationHistory;
                Medals = temp.Medals;
                Standings = temp.Standings;
                ResearchAgents = temp.ResearchAgents;
                Blueprints = temp.Blueprints;
                Fatigue = temp.Fatigue;
                ContactNotifications = temp.ContactNotifications;
                Roles = temp.Roles;
                Titles = temp.Titles;
                Contacts = temp.Contacts;
                Labels = temp.Labels;
                Contracts = temp.Contracts;
                FactionWarfareStats = temp.FactionWarfareStats;
                Fleet = temp.Fleet;



                Console.Write(" - successful");
                Console.WriteLine();
                Console.WriteLine();

                return true;
            }
        }
    }
}