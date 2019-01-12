using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESI.NET.Models.FactionWarfare;
using Newtonsoft.Json;

namespace EvEESITool
{
	public class FactionWarfareData : DataClassesBase
	{
		public List<War> GetWars()
		{
			return DownloadData("Faction warfare wars", Settings.EsiClient.FactionWarfare.List());
		}
		public List<Stat> GetStats()
		{
			return DownloadData("Faction warfare stats", Settings.EsiClient.FactionWarfare.Stats());
		}
		public List<FactionWarfareSystem> GetSystems()
		{
			return DownloadData("Faction warfare systems", Settings.EsiClient.FactionWarfare.Systems());
		}
		public Leaderboards<CharacterTotal> GetCharacterLeaderboards()
		{
			return DownloadData("Faction warfare character leaderboards", Settings.EsiClient.FactionWarfare.LeaderboardsForCharacters());
		}
		public Leaderboards<CorporationTotal> GetCorporationLeaderboards()
		{
			return DownloadData("Faction warfare corporation leaderboards", Settings.EsiClient.FactionWarfare.LeaderboardsForCorporations());
		}



		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal FactionWarfareData() : base()
		{
		}
		internal FactionWarfareData(ref AppSettings settings) : base(ref settings)
		{
			GetData();
		}

		protected override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
