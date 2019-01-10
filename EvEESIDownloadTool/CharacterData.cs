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

namespace EvEESITool
{
	public class CharacterData : DataClassesBase
	{
		public Information Information { get; private set; } = new Information();
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
		public int CharacterID { get; set; } = 0;
		public decimal Wallet { get; set; } = 0;
		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get referenced!
		/// </summary>
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