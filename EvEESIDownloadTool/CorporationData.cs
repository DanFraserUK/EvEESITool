using EvEESITool;
using EvEESITool.Enumerations;
using EvEESITool.Models.Assets;
//using EvEESITool.Models.Character;
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
using AssetsItem = EvEESITool.Models.Assets.Item;
using EvEESITool.Models.Bookmarks;
using EvEESITool.Models.Calendar;
using EvEESITool.Models.FactionWarfare;

namespace EvEESITool
{
	public class CorporationData : DataClassesBase
	{
		public Corporation Information { get; private set; } = new Corporation();
		public Corporation GetInformation(int corporationID)
		{
			return DownloadData("Information", Settings.EsiClient.Corporation.Information(corporationID));
		}
		public List<AllianceHistory> AllianceHistory { get; private set; } = new List<AllianceHistory>();
		public List<AllianceHistory> GetAllianceHistory(int corporationID)
		{
			return DownloadData("Alliance history", Settings.EsiClient.Corporation.AllianceHistory(corporationID)); // /corporations/{corporation_id}/alliancehistory/:public
		}
		public List<Blueprint> Blueprints { get; private set; } = new List<Blueprint>();
		public List<ContainerLog> ContainerLogs { get; private set; } = new List<ContainerLog>();
		public Divisions Divisions { get; private set; } = new Divisions();
		public List<Models.Corporation.Facility> Facilities { get; private set; } = new List<Models.Corporation.Facility>();
		public Images Icons { get; private set; } = new Images();
		public Images GetIcons(int corporationID)
		{
			return DownloadData("Icons", Settings.EsiClient.Corporation.Icons(corporationID)); // /corporations/{corporation_id}/icons/:public
		}
		public List<Medal> Medals { get; private set; } = new List<Medal>();
		public List<IssuedMedal> IssuedMedals { get; private set; } = new List<IssuedMedal>();
		public List<Member> Members { get; private set; } = new List<Member>();
		public int MemberLimit { get; private set; } = new int();
		public List<MemberTitles> MemberTitles { get; private set; } = new List<MemberTitles>();
		public List<MemberInfo> MemberTracking { get; private set; } = new List<MemberInfo>();
		public List<CharacterRoles> Roles { get; private set; } = new List<CharacterRoles>();
		public List<CharacterRolesHistory> RolesHistory { get; private set; } = new List<CharacterRolesHistory>();
		public List<Shareholder> Shareholders { get; private set; } = new List<Shareholder>();
		public Standing Standings { get; private set; } = new Standing();
		public List<Starbase> Starbases { get; private set; } = new List<Starbase>();
		public StarbaseInfo StarbaseInfo(int starbaseID, int systemID)// { get; private set; } = new List<StarbaseInfo>();
		{
			return DownloadData("Starbase information", Settings.EsiClient.Corporation.Starbase(starbaseID, systemID));
		}
		public List<Structure> Structures { get; private set; } = new List<Structure>();
		public List<Title> Titles { get; private set; } = new List<Title>();
		public List<int> NPCCorps { get; private set; } = new List<int>();
		public List<int> GetNPCCorps()
		{
			return DownloadData("NPC Corporations", Settings.EsiClient.Corporation.NpcCorps()); // /corporations/npccorps/:public
		}
		public List<Bookmark> Bookmarks { get; private set; } = new List<Bookmark>();
		public List<Folder> BookmarkFolders { get; private set; } = new List<Folder>();
		public List<Models.Contacts.Contact> Contacts { get; private set; } = new List<Models.Contacts.Contact>();
		public List<Models.Contacts.Label> Labels { get; private set; } = new List<Models.Contacts.Label>();
		public List<Models.Contracts.Contract> Contracts { get; private set; } = new List<Models.Contracts.Contract>();
		public List<Models.Contracts.ContractItem> ContractItems(int contractID)
		{
			return DownloadData("Contract items", Settings.EsiClient.Contracts.CorporationContractItems(contractID, 1));
		}
		public List<Models.Contracts.Bid> ContractBids(int contractID)
		{
			return DownloadData("Contract bids", Settings.EsiClient.Contracts.CorporationContractBids(contractID, 1));
		}
		public Stat FactionWarfareStats { get; private set; } = new Stat();






		public int CorporationID { get; set; } = 0;

		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get referenced!
		/// </summary>
		[JsonConstructor]
		internal CorporationData() : base()
		{
			Settings = new AppSettings();
		}
		public CorporationData(ref AppSettings settings) : base(ref settings)
		{
			CorporationID = Settings.AuthorisationData.CorporationID;
			GetData();
		}
		private CorporationData(ref AppSettings settings, bool isATempItem) : base(ref settings)
		{
			CorporationID = Settings.AuthorisationData.CorporationID;
			if (!isATempItem)
			{
				GetData();
			}
		}
		public override string ToString()
		{
			return $"{Information.Name}, Ticker : {Information.Ticker}";
		}
		public override void Download()
		{
			Information = DownloadData("Information", Settings.EsiClient.Corporation.Information(CorporationID));
			AllianceHistory = DownloadData("Alliance history", Settings.EsiClient.Corporation.AllianceHistory(CorporationID));
			Blueprints = DownloadData("Blueprints", Settings.EsiClient.Corporation.Blueprints(1));
			ContainerLogs = DownloadData("Container logs", Settings.EsiClient.Corporation.ContainerLogs(1));
			Divisions = DownloadData("Divisions", Settings.EsiClient.Corporation.Divisions());
			Facilities = DownloadData("Facilities", Settings.EsiClient.Corporation.Facilities());
			Icons = DownloadData("Images", Settings.EsiClient.Corporation.Icons(CorporationID));
			Medals = DownloadData("Medals", Settings.EsiClient.Corporation.Medals(1));
			IssuedMedals = DownloadData("Issued medals", Settings.EsiClient.Corporation.MedalsIssued(1));

			// todo figure this call out - there's an array not being deserialized properly
			//Members = DownloadData<List<Member>>("Members", Settings.EsiClient.Corporation.Members());

			MemberLimit = DownloadData("Member Limit", Settings.EsiClient.Corporation.MemberLimit());
			MemberTitles = DownloadData("Member titles", Settings.EsiClient.Corporation.MemberTitles());
			MemberTracking = DownloadData("Member tracking", Settings.EsiClient.Corporation.MemberTracking());
			Roles = DownloadData("Roles", Settings.EsiClient.Corporation.Roles());
			RolesHistory = DownloadData("Roles history", Settings.EsiClient.Corporation.RolesHistory());
			Shareholders = DownloadData("Shareholders", Settings.EsiClient.Corporation.Shareholders(1));
			// todo - yeah, this is one of those paginated items
			//Standings = DownloadData<List<Standing>>("Standings", Settings.EsiClient.Corporation.Standings(1));
			Starbases = DownloadData("Starbases", Settings.EsiClient.Corporation.Starbases());
			// todo paginated
			Structures = DownloadData("Structures", Settings.EsiClient.Corporation.Structures(1));
			Titles = DownloadData("Titles", Settings.EsiClient.Corporation.Titles());
			NPCCorps = DownloadData("NPC Corporations", Settings.EsiClient.Corporation.NpcCorps());
			Bookmarks = DownloadData("Bookmarks", Settings.EsiClient.Bookmarks.ForCorporation()); // /characters/{character_id}/bookmarks/:esi-bookmarks.read_character_bookmarks.v1
			BookmarkFolders = DownloadData("Bookmark folders", Settings.EsiClient.Bookmarks.FoldersForCorporation());
			Contacts = DownloadData("Contacts", Settings.EsiClient.Contacts.ListForCorporation(1));
			Labels = DownloadData("Labels", Settings.EsiClient.Contacts.LabelsForCorporation());
			Contracts = DownloadData("Contracts", Settings.EsiClient.Contracts.CorporationContracts(1)); // /characters/{character_id}/contracts/:esi-contracts.read_character_contracts.v1
			Standings = DownloadData("Standings", Settings.EsiClient.Corporation.Standings(1));
			FactionWarfareStats = DownloadData("Faction warfare statistics", Settings.EsiClient.FactionWarfare.StatsForCorporation());




			SaveToFile();
		}
		public override bool ReadInData()
		{
			using (StreamReader myReader = new StreamReader(SaveFile))
			{
				CorporationData temp = Settings.serializer.Deserialize<CorporationData>(new JsonTextReader(myReader));
				Console.Write($"Loading data from {Path.GetFileName(SaveFile)}");
				Information = temp.Information;
				AllianceHistory = temp.AllianceHistory;
				Blueprints = temp.Blueprints;
				ContainerLogs = temp.ContainerLogs;
				Divisions = temp.Divisions;
				Facilities = temp.Facilities;
				Icons = temp.Icons;
				Medals = temp.Medals;
				IssuedMedals = temp.IssuedMedals;
				Members = temp.Members;
				MemberLimit = temp.MemberLimit;
				MemberTitles = temp.MemberTitles;
				MemberTracking = temp.MemberTracking;
				Roles = temp.Roles;
				RolesHistory = temp.RolesHistory;
				Shareholders = temp.Shareholders;
				Standings = temp.Standings;
				Starbases = temp.Starbases;
				Structures = temp.Structures;
				Titles = temp.Titles;
				NPCCorps = temp.NPCCorps;
				CorporationID = temp.CorporationID;
				Bookmarks = temp.Bookmarks;
				BookmarkFolders = temp.BookmarkFolders;
				Contacts = temp.Contacts;
				Labels = temp.Labels;
				Contracts = temp.Contracts;
				Standings = temp.Standings;
				FactionWarfareStats = temp.FactionWarfareStats;




				Console.Write(" - successful");
				Console.WriteLine();
				Console.WriteLine();

				return true;
			}
		}
	}
}
