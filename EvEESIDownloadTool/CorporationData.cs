using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
//using ESI.NET.Models.Character;
using ESI.NET.Models.Corporation;
using ESI.NET.Models.Industry;
using ESI.NET.Models.Location;
using ESI.NET.Models.Market;
using ESI.NET.Models;
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

namespace EvEESITool
{
	public class CorporationData : DataClassesBase
	{
		public Corporation Information { get; private set; } = new Corporation();
		public List<AllianceHistory> AllianceHistory { get; private set; } = new List<AllianceHistory>();
		public List<Blueprint> Blueprints { get; private set; } = new List<Blueprint>();
		public List<ContainerLog> ContainerLogs { get; private set; } = new List<ContainerLog>();
		public Divisions Divisions { get; private set; } = new Divisions();
		public List<ESI.NET.Models.Corporation.Facility> Facilities { get; private set; } = new List<ESI.NET.Models.Corporation.Facility>();
		public Images Icon { get; private set; } = new Images();
		public List<Medal> Medals { get; private set; } = new List<Medal>();
		public List<IssuedMedal> IssuedMedals { get; private set; } = new List<IssuedMedal>();
		public List<Member> Members { get; private set; } = new List<Member>();
		public int MemberLimit { get; private set; } = new int();
		public List<MemberTitles> MemberTitles { get; private set; } = new List<MemberTitles>();
		public List<MemberInfo> MemberTracking { get; private set; } = new List<MemberInfo>();
		public List<CharacterRoles> Roles { get; private set; } = new List<CharacterRoles>();
		public List<CharacterRolesHistory> RolesHistory { get; private set; } = new List<CharacterRolesHistory>();
		public List<Shareholder> Shareholders { get; private set; } = new List<Shareholder>();
		public List<Standing> Standings { get; private set; } = new List<Standing>();
		public List<Starbase> Starbases { get; private set; } = new List<Starbase>();
		public List<StarbaseInfo> StarbasesInfo { get; private set; } = new List<StarbaseInfo>();
		public List<Structure> Structures { get; private set; } = new List<Structure>();
		public List<Title> Titles { get; private set; } = new List<Title>();
		public List<int> NPCCorps { get; private set; } = new List<int>();
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
			if (isATempItem)
			{
				CorporationID = Settings.AuthorisationData.CorporationID;
			}
			else
			{
				CorporationID = Settings.AuthorisationData.CorporationID;
				GetData();
			}
		}
		public override string ToString()
		{
			return $"{Information.Name}, Ticker : {Information.Ticker}";
		}
		public override void Download()
		{
			Information = DownloadData<Corporation>("Information", Settings.EsiClient.Corporation.Information(CorporationID));
			AllianceHistory = DownloadData<List<AllianceHistory>>("Alliance history", Settings.EsiClient.Corporation.AllianceHistory(CorporationID));
			Blueprints = DownloadData<List<Blueprint>>("Blueprints", Settings.EsiClient.Corporation.Blueprints());
			ContainerLogs = DownloadData<List<ContainerLog>>("Container logs", Settings.EsiClient.Corporation.ContainerLogs());
			Divisions = DownloadData<Divisions>("Divisions", Settings.EsiClient.Corporation.Divisions());
			Facilities = DownloadData<List<ESI.NET.Models.Corporation.Facility>>("Facilities", Settings.EsiClient.Corporation.Facilities());
			Icon = DownloadData<Images>("Images", Settings.EsiClient.Corporation.Icons(CorporationID));
			Medals = DownloadData<List<Medal>>("Medals", Settings.EsiClient.Corporation.Medals(1));
			IssuedMedals = DownloadData<List<IssuedMedal>>("Issued medals", Settings.EsiClient.Corporation.MedalsIssued(1));

			// todo figure this call out - there's an array not being deserialized properly
			//Members = DownloadData<List<Member>>("Members", Settings.EsiClient.Corporation.Members());

			MemberLimit = DownloadData<int>("Member Limit", Settings.EsiClient.Corporation.MemberLimit());
			MemberTitles = DownloadData<List<MemberTitles>>("Member titles", Settings.EsiClient.Corporation.MemberTitles());
			MemberTracking = DownloadData<List<MemberInfo>>("Member tracking", Settings.EsiClient.Corporation.MemberTracking());
			Roles = DownloadData<List<CharacterRoles>>("Roles", Settings.EsiClient.Corporation.Roles());
			RolesHistory = DownloadData<List<CharacterRolesHistory>>("Roles history", Settings.EsiClient.Corporation.RolesHistory());
			Shareholders = DownloadData<List<Shareholder>>("Shareholders", Settings.EsiClient.Corporation.Shareholders());
			// todo - yeah, this is one of those paginated items
			//Standings = DownloadData<List<Standing>>("Standings", Settings.EsiClient.Corporation.Standings(1));
			Starbases = DownloadData<List<Starbase>>("Starbases", Settings.EsiClient.Corporation.Starbases());
			// todo this is a kinda of paginated item
			foreach (Starbase s in Starbases)
			{
				StarbasesInfo.Add(Settings.EsiClient.Corporation.Starbase((int)s.StarbaseId, s.SystemId).Result.Data);
			}
			// todo paginated
			Structures = DownloadData<List<Structure>>("Structures", Settings.EsiClient.Corporation.Structures(1));
			Titles = DownloadData<List<Title>>("Titles", Settings.EsiClient.Corporation.Titles());
			NPCCorps = DownloadData<List<int>>("NPC Corporations", Settings.EsiClient.Corporation.NpcCorps());

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
				Icon = temp.Icon;
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
				StarbasesInfo = temp.StarbasesInfo;
				Structures = temp.Structures;
				Titles = temp.Titles;
				NPCCorps = temp.NPCCorps;
				CorporationID = temp.CorporationID;
				Console.Write(" - successful");
				Console.WriteLine();
				Console.Write(".");

				return true;
			}
		}
	}
}
