﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EvEESITool.Models.Character;
using EvEESITool.Models.Insurance;
using EvEESITool.Models.Loyalty;
using EvEESITool.Models.Alliance;
using System.Diagnostics;
using System.IO;
using EvEESITool.Models.Skills;
using EvEESITool.Models.Clones;
using EvEESITool.Models.Fittings;
using EvEESITool.Models;
using System.Reflection;
using EvEESITool.Models.Corporation;

namespace EvEESITool
{
	public class PublicData : DataClassesBase
	{
		public DogmaData Dogma { get; private set; } = new DogmaData();
		public IndustryData Industry { get; private set; } = new IndustryData();
		public IncursionsData Incursions { get; private set; } = new IncursionsData();
		public FactionWarfareData FactionWarfare { get; private set; } = new FactionWarfareData();
		public MarketData Market { get; private set; } = new MarketData();
		public List<Character> GetCharacter(int[] characterIDs)
		{
			return DownloadData($"Character{(characterIDs.Length > 1 ? "s" : "")}", Settings.EsiClient.Character.Names(characterIDs));
		}
		public List<Character> GetCharacter(List<int> characterIDs)
		{
			return DownloadData($"Character{(characterIDs.Count > 1 ? "s" : "")}", Settings.EsiClient.Character.Names(characterIDs.ToArray()));
		}
		public List<Insurance> InsuranceLevels()
		{
			return DownloadData<List<Insurance>>("Insurance levels", Settings.EsiClient.Insurance.Levels());
		}
		public Models.Killmails.Information GetKillmail(string killmailHash, int killmailID)
		{
			return DownloadData<Models.Killmails.Information>("Killmail", Settings.EsiClient.Killmails.Information(killmailHash, killmailID));
		}
		public List<int> GetNPCCorps()
		{
			return DownloadData("NPC Corporations", Settings.EsiClient.Corporation.NpcCorps());
		}
		public List<Offer> GetLoyaltyOffers(int corporationID)
		{
			return DownloadData("Loyalty offers", Settings.EsiClient.Loyalty.Offers(corporationID)); 
		}
		public List<int> GetAllianceIDs()
		{
			return DownloadData("Alliance IDs", Settings.EsiClient.Alliance.All()); 

		}
		public List<EvEESITool.Models.Character.Corporation> GetCorporationHistory(int characterID)
		{
			return DownloadData("Corporation history", Settings.EsiClient.Character.CorporationHistory(characterID));
		}
		public List<AllianceHistory> GetAllianceHistory(int corporationID)
		{
			return DownloadData("Alliance history", Settings.EsiClient.Corporation.AllianceHistory(corporationID));
		}
		public Images GetIcons(int corporationID)
		{
			return DownloadData("Icons", Settings.EsiClient.Corporation.Icons(corporationID));
		}
		private void PublicMethods()
		{
			int ID = 0;
			var Information = DownloadData("Information", Settings.EsiClient.Alliance.Information(ID)); 
			var Corporations = DownloadData("Corporations", Settings.EsiClient.Alliance.Corporations(ID));
			var Icons = DownloadData("Images", Settings.EsiClient.Alliance.Icons(ID)); 
		}


		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal PublicData() : base()
		{
		}
		internal PublicData(ref AppSettings settings) : base(ref settings)
		{
			CreateData(ref settings);
		}
		public void CreateData(ref AppSettings settings)
		{
			Dogma = new DogmaData(ref settings);
			Industry = new IndustryData(ref settings);
			Incursions = new IncursionsData(ref settings);
			FactionWarfare = new FactionWarfareData(ref settings);
			Market = new MarketData(ref settings);
		}
		protected override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}