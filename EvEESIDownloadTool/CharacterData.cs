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


		internal CharacterData()
		{

		}
		public CharacterData(ref EsiClient esiClient, ref SDEData sde, ref AppSettings settings) : base(ref esiClient, ref sde, ref settings)
		{
			CharacterID = Settings.AuthorisationData.CharacterID;
			MakeChoice();
		}

		internal CharacterData(ref EsiClient esiClient, ref AppSettings settings) : base(ref esiClient, ref settings)
		{
			CharacterID = Settings.AuthorisationData.CharacterID;
			MakeChoice();
		}

		private CharacterData(ref EsiClient esiClient, ref AppSettings settings, bool isATempItem) : base(ref esiClient, ref settings)
		{
			if (isATempItem)
			{
				CharacterID = Settings.AuthorisationData.CharacterID;
			}
			else
			{
				CharacterID = Settings.AuthorisationData.CharacterID;
				MakeChoice();
			}
		}

		public void MakeChoice()
		{
			// todo - this should become a timed check as well, once an hour max?
			Console.Write("Download new character data? (Y/N) : ");
			if (Console.ReadKey().KeyChar.ToString().ToLower() == "y")
			{
				Console.WriteLine();
				Console.WriteLine();
				Download();
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine();
				if (File.Exists(SaveFile))
				{
					if (LoadFromFile())
					{

					}
					else
					{
						Download();
					}
				}
				else
				{
					Console.WriteLine("Unable to load from file, downloading.");
					Download();
				}
			}
		}

		public override string ToString()
		{
			return $"{Information.Name}, {Wallet.ToString("N2")} ISK";
		}
		public void Download()
		{
			Wallet = DownloadData<decimal>("Wallet Balance", ImportedEsiClient.Wallet.CharacterWallet());
			Information = DownloadData<Information>("Information", ImportedEsiClient.Character.Information(CharacterID));
			// wallet is bloody awkward!
			//GetWalletData();
			Skills = DownloadData<SkillDetails>("Skills", ImportedEsiClient.Skills.List());
			Attributes = DownloadData<Attributes>("Attributes", ImportedEsiClient.Skills.Attributes());
			Stats = DownloadData<List<Stats>>("Stats", ImportedEsiClient.Character.Stats());
			SkillQueue = DownloadData<List<SkillQueueItem>>("Skill Queue", ImportedEsiClient.Skills.Queue());
			Location = DownloadData<Location>("Location", ImportedEsiClient.Location.Location());
			Activity = DownloadData<Activity>("Activity", ImportedEsiClient.Location.Online());
			Ship = DownloadData<Ship>("Ship", ImportedEsiClient.Location.Ship());
			Assets = DownloadData<List<AssetsItem>>("Assets", ImportedEsiClient.Assets.ForCharacter());
			Journal = DownloadData<List<JournalEntry>>("Journal", ImportedEsiClient.Wallet.CharacterJournal());
			Transactions = DownloadData<List<Transaction>>("Transactions", ImportedEsiClient.Wallet.CharacterTransactions());
			Notifications = DownloadData<List<Notification>>("Notifications", ImportedEsiClient.Character.Notifications());
			IndustryJobs = DownloadData<List<Job>>("Industry jobs", ImportedEsiClient.Industry.JobsForCharacter());
			Clones = DownloadData<Clones>("Clones", ImportedEsiClient.Clones.List());
			Implants.AddRange(DownloadData<int[]>("Implants", ImportedEsiClient.Clones.Implants()));
			GetAssetsLocations();
			GetAssetsNames();
			Fittings = DownloadData<List<Fitting>>("Fittings", ImportedEsiClient.Fittings.List());
			Console.WriteLine();
			SaveToFile();
		}

		//public void GetSkills()
		//{
		//	ESI.NET.Models.Skills.SkillDetails details = ImportedEsiClient.Skills.List().Result.Data;

		//	Skills = new SkillDetails(ref SDE);
		//	foreach (ESI.NET.Models.Skills.Skill s in details.Skills)
		//	{
		//		Skill newSkill = new Skill(ref SDE)
		//		{
		//			ActiveSkillLevel = s.ActiveSkillLevel,
		//			SkillId = s.SkillId,
		//			SkillpointsInSkill = s.SkillpointsInSkill,
		//			TrainedSkillLevel = s.TrainedSkillLevel
		//		};
		//		Skills.Skills.Add(newSkill);
		//	}
		//	Skills.TotalSp = details.TotalSp;
		//	Skills.UnallocatedSp = details.UnallocatedSp;
		//}
		public void GetAssetsLocations()
		{
			List<long> assetsItemIDs = new List<long>();
			foreach (AssetsItem i in Assets)
			{
				assetsItemIDs.Add(long.Parse(i.Id));
			}
			AssetsLocations = ImportedEsiClient.Assets.LocationsForCharacter(assetsItemIDs).Result.Data;
		}
		public void GetAssetsNames()
		{
			List<long> assetsItemIDs = new List<long>();
			foreach (AssetsItem i in Assets)
			{
				assetsItemIDs.Add(long.Parse(i.Id));
			}
			AssetsNames = ImportedEsiClient.Assets.NamesForCharacter(assetsItemIDs).Result.Data;
		}
		//public void SaveToFile()
		//{
		//	using (StreamWriter file = File.CreateText(SaveFile))
		//	{
		//		JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
		//		//serialize object directly into file stream
		//		serializer.Serialize(file, this);
		//	}
		//}
		public bool LoadFromFile()
		{
			bool result = false;
			try
			{
				CharacterData temp = new CharacterData(ref ImportedEsiClient, ref Settings, true);
				using (StreamReader myReader = new StreamReader(SaveFile))
				{
					JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
					JsonTextReader reader = new JsonTextReader(myReader);
					temp = serializer.Deserialize<CharacterData>(new JsonTextReader(myReader));

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
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Loading from file failed.");
				Console.WriteLine($"Error message : {ex.Message}");
				result = false;
			}
			return result;
		}
		//public class SkillDetails
		//{
		//	public SkillDetails()
		//	{
		//	}
		//	public SkillDetails(ref SDEData sde)
		//	{
		//		SDE = sde;
		//	}
		//	[JsonProperty("skills")]
		//	public List<Skill> Skills { get; set; } = new List<Skill>();

		//	[JsonProperty("total_sp")]
		//	public long TotalSp { get; set; }

		//	[JsonProperty("unallocated_sp")]
		//	public int UnallocatedSp { get; set; }
		//	public override string ToString()
		//	{
		//		return TotalSp.ToString("N0") + $" skill points{(UnallocatedSp > 0 ? $", {UnallocatedSp} unallocated" : "")}.";
		//	}
		//	[JsonIgnore]
		//	private SDEData SDE { get; set; }
		//}
		//public class Skill
		//{
		//	public Skill()
		//	{
		//	}
		//	public Skill(ref SDEData sde)
		//	{
		//		SDE = sde;
		//	}
		//	[JsonProperty("skill_id")]
		//	public int SkillId { get; set; }

		//	[JsonProperty("skillpoints_in_skill")]
		//	public long SkillpointsInSkill { get; set; }

		//	[JsonProperty("trained_skill_level")]
		//	public int TrainedSkillLevel { get; set; }

		//	[JsonProperty("active_skill_level")]
		//	public int ActiveSkillLevel { get; set; }
		//	[JsonIgnore]
		//	public string SkillName
		//	{
		//		get
		//		{
		//			return SDE.InvTypes[(long)SkillId].TypeName;
		//		}
		//	}
		//	public override string ToString()
		//	{
		//		return SkillName + " " + TrainedSkillLevel;
		//	}
		//	[JsonIgnore]
		//	private SDEData SDE { get; set; }
		//}
	}
}
