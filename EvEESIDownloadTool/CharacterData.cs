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
using AssetsItem = ESI.NET.Models.Assets.Item;
using ESI.NET.Models.Bookmarks;
using ESI.NET.Models.Calendar;
using ESI.NET.Models.FactionWarfare;
using ESI.NET.Models.Fleets;

namespace EvEESITool
{
	public class CharacterData : DataClassesBase
	{
		public Information Information { get; private set; } = new Information();
		public Information GetInformation(int characterID)
		{
			return DownloadData<Information>("Information", Settings.EsiClient.Character.Information(characterID));
		}
		public SkillDetails Skills { get; private set; } = new SkillDetails();
		public Attributes Attributes { get; private set; } = new Attributes();
		public List<SkillQueueItem> SkillQueue { get; set; } = new List<SkillQueueItem>();
		public List<Stats> Stats { get; private set; } = new List<Stats>();
		public Location Location { get; private set; } = new Location();
		public Activity Activity { get; private set; } = new Activity();
		public Ship Ship { get; private set; } = new Ship();
		public List<AssetsItem> Assets { get; private set; } = new List<AssetsItem>();
		public List<ItemLocation> AssetsLocations { get; private set; } = new List<ItemLocation>();
		public List<ItemName> AssetsNames { get; private set; } = new List<ItemName>();
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
		public Event CalendarEvent { get; private set; } = new Event();
		public List<Character> GetCharacter(int[] characterIDs)
		{
			return DownloadData<List<Character>>($"Character{(characterIDs.Length > 1 ? "s" : "")}", Settings.EsiClient.Character.Names(characterIDs));
		}
		public List<Character> GetCharacter(List<int> characterIDs)
		{
			return DownloadData<List<Character>>($"Character{(characterIDs.Count > 1 ? "s" : "")}", Settings.EsiClient.Character.Names(characterIDs.ToArray()));
		}
		public Images Portrait { get; private set; } = new Images();
		public Images GetPortrait(int characterID)
		{
			return DownloadData<Images>("Portrait", Settings.EsiClient.Character.Portrait(characterID));
		}
		public List<ESI.NET.Models.Character.Corporation> CorporationHistory { get; private set; } = new List<ESI.NET.Models.Character.Corporation>();
		public List<ESI.NET.Models.Character.Corporation> GetCorporationHistory(int characterID)
		{
			return DownloadData<List<ESI.NET.Models.Character.Corporation>>("Corporation history", Settings.EsiClient.Character.CorporationHistory(characterID)); // /characters/{character_id}/corporationhistory/:public
		}
		public List<ChatChannel> ChatChannels { get; private set; } = new List<ChatChannel>();
		public List<ESI.NET.Models.Character.Medal> Medals { get; private set; } = new List<ESI.NET.Models.Character.Medal>();
		public List<Standing> Standings { get; private set; } = new List<Standing>();
		public List<Agent> ResearchAgents { get; private set; } = new List<Agent>();
		public List<ESI.NET.Models.Character.Blueprint> Blueprints { get; private set; } = new List<ESI.NET.Models.Character.Blueprint>();
		public Fatigue Fatigue { get; private set; } = new Fatigue();
		public List<ContactNotification> ContactNotifications { get; private set; } = new List<ContactNotification>();
		public List<string> Roles { get; private set; } = new List<string>();
		public List<ESI.NET.Models.Character.Title> Titles { get; private set; } = new List<ESI.NET.Models.Character.Title>();
		public List<ESI.NET.Models.Contacts.Contact> Contacts { get; private set; } = new List<ESI.NET.Models.Contacts.Contact>();
		public List<ESI.NET.Models.Contacts.Label> Labels { get; private set; } = new List<ESI.NET.Models.Contacts.Label>();
		public List<ESI.NET.Models.Contracts.Contract> Contracts { get; private set; } = new List<ESI.NET.Models.Contracts.Contract>();
		public List<ESI.NET.Models.Contracts.ContractItem> ContractItems(int contractID)
		{
			return DownloadData<List<ESI.NET.Models.Contracts.ContractItem>>("Contract items", Settings.EsiClient.Contracts.CharacterContractItems(contractID, 1));
		}
		public List<ESI.NET.Models.Contracts.Bid> ContractBids(int contractID)
		{
			return DownloadData<List<ESI.NET.Models.Contracts.Bid>>("Contract bids", Settings.EsiClient.Contracts.CharacterContractBids(contractID, 1));
		}
		public Stat FactionWarfareStats { get; private set; } = new Stat();
		public FleetInfo Fleet { get; private set; } = new FleetInfo();



		public int CharacterID { get; set; } = 0;
		public decimal Wallet { get; set; } = 0;

		[JsonConstructor]
		internal CharacterData() : base()
		{
		}
		internal CharacterData(ref AppSettings settings) : base(ref settings)
		{
			CharacterID = Settings.AuthorisationData.CharacterID;
			GetData();
		}
		public override string ToString()
		{
			return $"{Information.Name}, {Wallet.ToString("N2")} ISK";
		}
		public override void Download()
		{
			Wallet = DownloadData<decimal>("Wallet Balance", Settings.EsiClient.Wallet.CharacterWallet());
			Information = DownloadData<Information>("Information", Settings.EsiClient.Character.Information(CharacterID));
			Skills = DownloadData<SkillDetails>("Skills", Settings.EsiClient.Skills.List());
			Attributes = DownloadData<Attributes>("Attributes", Settings.EsiClient.Skills.Attributes());
			Stats = DownloadData<List<Stats>>("Stats", Settings.EsiClient.Character.Stats());
			SkillQueue = DownloadData<List<SkillQueueItem>>("Skill Queue", Settings.EsiClient.Skills.Queue());
			Location = DownloadData<Location>("Location", Settings.EsiClient.Location.Location());
			Activity = DownloadData<Activity>("Activity", Settings.EsiClient.Location.Online());
			Ship = DownloadData<Ship>("Ship", Settings.EsiClient.Location.Ship());
			Assets = DownloadData<List<AssetsItem>>("Assets", Settings.EsiClient.Assets.ForCharacter());
			Journal = DownloadData<List<JournalEntry>>("Journal", Settings.EsiClient.Wallet.CharacterJournal());
			Transactions = DownloadData<List<Transaction>>("Transactions", Settings.EsiClient.Wallet.CharacterTransactions());
			Notifications = DownloadData<List<Notification>>("Notifications", Settings.EsiClient.Character.Notifications());
			IndustryJobs = DownloadData<List<Job>>("Industry jobs", Settings.EsiClient.Industry.JobsForCharacter());
			Clones = DownloadData<Clones>("Clones", Settings.EsiClient.Clones.List());
			Implants.AddRange(DownloadData<int[]>("Implants", Settings.EsiClient.Clones.Implants()));
			GetAssetsLocations();
			GetAssetsNames();
			Fittings = DownloadData<List<Fitting>>("Fittings", Settings.EsiClient.Fittings.List());
			Bookmarks = DownloadData<List<Bookmark>>("Bookmarks", Settings.EsiClient.Bookmarks.ForCharacter());
			BookmarkFolders = DownloadData<List<Folder>>("Bookmark folders", Settings.EsiClient.Bookmarks.FoldersForCharacter());
			CalendarEvents = DownloadData<List<Event>>("Calendar events", Settings.EsiClient.Calendar.Events());
			//Event = DownloadData<Event>("Event", Settings.EsiClient.Calendar.Event());
			Portrait = DownloadData<Images>("Portrait", Settings.EsiClient.Character.Portrait(CharacterID));
			CorporationHistory = DownloadData<List<ESI.NET.Models.Character.Corporation>>("Corporation history", Settings.EsiClient.Character.CorporationHistory(CharacterID));
			ChatChannels = DownloadData<List<ChatChannel>>("Chat channels", Settings.EsiClient.Character.ChatChannels());
			Medals = DownloadData<List<ESI.NET.Models.Character.Medal>>("Medals", Settings.EsiClient.Character.Medals());
			Standings = DownloadData<List<Standing>>("Standings", Settings.EsiClient.Character.Standings());
			ResearchAgents = DownloadData<List<Agent>>("Research agents", Settings.EsiClient.Character.AgentsResearch());
			Blueprints = DownloadData<List<ESI.NET.Models.Character.Blueprint>>("Blueprints", Settings.EsiClient.Character.Blueprints(1));
			Fatigue = DownloadData<Fatigue>("Fatigue", Settings.EsiClient.Character.Fatigue());
			ContactNotifications = DownloadData<List<ContactNotification>>("Contact notifications", Settings.EsiClient.Character.ContactNotifications());
			Roles = DownloadData<List<string>>("Roles", Settings.EsiClient.Character.Roles());
			Titles = DownloadData<List<ESI.NET.Models.Character.Title>>("Titles", Settings.EsiClient.Character.Titles());
			Contacts = DownloadData<List<ESI.NET.Models.Contacts.Contact>>("Contacts", Settings.EsiClient.Contacts.ListForCharacter(1));
			Labels = DownloadData<List<ESI.NET.Models.Contacts.Label>>("Labels", Settings.EsiClient.Contacts.LabelsForCharacter());
			Contracts = DownloadData<List<ESI.NET.Models.Contracts.Contract>>("Contracts", Settings.EsiClient.Contracts.CharacterContracts(1)); // /characters/{character_id}/contracts/:esi-contracts.read_character_contracts.v1
			FactionWarfareStats = DownloadData<Stat>("Faction warfare statistics", Settings.EsiClient.FactionWarfare.StatsForCharacter());
			Fleet = DownloadData<FleetInfo>("Fleet", Settings.EsiClient.Fleets.FleetInfo());





			Console.WriteLine();
			SaveToFile();
		}
		public void GetAssetsLocations()
		{
			List<long> assetsItemIDs = new List<long>();
			foreach (AssetsItem i in Assets)
			{
				assetsItemIDs.Add(long.Parse(i.Id));
			}
			AssetsLocations = Settings.EsiClient.Assets.LocationsForCharacter(assetsItemIDs).Result.Data;
		}
		public void GetAssetsNames()
		{
			List<long> assetsItemIDs = new List<long>();
			foreach (AssetsItem i in Assets)
			{
				assetsItemIDs.Add(long.Parse(i.Id));
			}
			AssetsNames = Settings.EsiClient.Assets.NamesForCharacter(assetsItemIDs).Result.Data;
		}
		public override bool ReadInData()
		{
			using (StreamReader myReader = new StreamReader(SaveFile))
			{
				CharacterData temp = Settings.serializer.Deserialize<CharacterData>(new JsonTextReader(myReader));
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
				AssetsLocations = temp.AssetsLocations;
				AssetsNames = temp.AssetsNames;
				Journal = temp.Journal;
				Transactions = temp.Transactions;
				Notifications = temp.Notifications;
				IndustryJobs = temp.IndustryJobs;
				CharacterID = Settings.AuthorisationData.CharacterID;
				Wallet = temp.Wallet;
				Clones = temp.Clones;
				Implants = temp.Implants;
				Fittings = temp.Fittings;
				Console.Write(" - successful");
				Console.WriteLine();
				return true;
			}
		}
	}
}