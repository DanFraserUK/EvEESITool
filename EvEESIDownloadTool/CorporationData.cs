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

namespace EvEESIDownloadTool
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
		internal CorporationData()
		{

		}
		public CorporationData(ref EsiClient esiClient, ref SDEData sde, ref AppSettings settings) : base(ref esiClient, ref sde, ref settings)
		{
			CorporationID = Settings.AuthorisationData.CorporationID;
			MakeChoice();
		}
		public CorporationData(ref EsiClient esiClient, ref AppSettings settings) : base(ref esiClient, ref settings)
		{
			CorporationID = Settings.AuthorisationData.CorporationID;
			MakeChoice();
		}

		private CorporationData(ref EsiClient esiClient, ref AppSettings settings, bool isATempItem) : base(ref esiClient, ref settings)
		{
			if (isATempItem)
			{
				CorporationID = Settings.AuthorisationData.CorporationID;
			}
			else
			{
				CorporationID = Settings.AuthorisationData.CorporationID;
				MakeChoice();
			}
		}

		private void MakeChoice()
		{
			Console.Write("Download new corporation data? (Y/N) : ");
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
			return $"{Information.Name}, Ticker : {Information.Ticker}";
		}
		public void Download()
		{
			Information = DownloadData<Corporation>("Information", ImportedEsiClient.Corporation.Information(CorporationID));
			AllianceHistory = DownloadData<List<AllianceHistory>>("Alliance history", ImportedEsiClient.Corporation.AllianceHistory(CorporationID));
			Blueprints = DownloadData<List<Blueprint>>("Blueprints", ImportedEsiClient.Corporation.Blueprints());
			ContainerLogs = DownloadData<List<ContainerLog>>("Container logs", ImportedEsiClient.Corporation.ContainerLogs());
			Divisions = DownloadData<Divisions>("Divisions", ImportedEsiClient.Corporation.Divisions());
			Facilities = DownloadData<List<ESI.NET.Models.Corporation.Facility>>("Facilities", ImportedEsiClient.Corporation.Facilities());
			Icon = DownloadData<Images>("Images", ImportedEsiClient.Corporation.Icons(CorporationID));
			Medals = DownloadData<List<Medal>>("Medals", ImportedEsiClient.Corporation.Medals(1));
			IssuedMedals = DownloadData<List<IssuedMedal>>("Issued medals", ImportedEsiClient.Corporation.MedalsIssued(1));

			// todo figure this call out - there's an array not being deserialized properly
			//Members = DownloadData<List<Member>>("Members", ImportedEsiClient.Corporation.Members());

			MemberLimit = DownloadData<int>("Member Limit", ImportedEsiClient.Corporation.MemberLimit());
			MemberTitles = DownloadData<List<MemberTitles>>("Member titles", ImportedEsiClient.Corporation.MemberTitles());
			MemberTracking = DownloadData<List<MemberInfo>>("Member tracking", ImportedEsiClient.Corporation.MemberTracking());
			Roles = DownloadData<List<CharacterRoles>>("Roles", ImportedEsiClient.Corporation.Roles());
			RolesHistory = DownloadData<List<CharacterRolesHistory>>("Roles history", ImportedEsiClient.Corporation.RolesHistory());
			Shareholders = DownloadData<List<Shareholder>>("Shareholders", ImportedEsiClient.Corporation.Shareholders());
			// todo - yeah, this is one of those paginated items
			//Standings = DownloadData<List<Standing>>("Standings", ImportedEsiClient.Corporation.Standings(1));
			Starbases = DownloadData<List<Starbase>>("Starbases", ImportedEsiClient.Corporation.Starbases());
			// todo this is a kinda of paginated item
			foreach (Starbase s in Starbases)
			{
				StarbasesInfo.Add(ImportedEsiClient.Corporation.Starbase((int)s.StarbaseId, s.SystemId).Result.Data);
			}
			// todo paginated
			Structures = DownloadData<List<Structure>>("Structures", ImportedEsiClient.Corporation.Structures(1));
			Titles = DownloadData<List<Title>>("Titles", ImportedEsiClient.Corporation.Titles());
			NPCCorps = DownloadData<List<int>>("NPC Corporations", ImportedEsiClient.Corporation.NpcCorps());

			SaveToFile();
		}
		public bool LoadFromFile()
		{
			bool result = false;
			try
			{
				CorporationData temp = new CorporationData(ref ImportedEsiClient, ref Settings, true);
				using (StreamReader myReader = new StreamReader(SaveFile))
				{
					JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
					JsonTextReader reader = new JsonTextReader(myReader);
					temp = serializer.Deserialize<CorporationData>(new JsonTextReader(myReader));

					Information = temp.Information;

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
	}
}
