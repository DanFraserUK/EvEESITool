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
			return DownloadData<List<War>>("Faction warfare wars", Settings.EsiClient.FactionWarfare.List()); // /fw/wars/:public
		}
		public List<Stat> GetStats()
		{
			return DownloadData<List<Stat>>("Faction warfare stats", Settings.EsiClient.FactionWarfare.Stats()); // /fw/stats/:public
		}
		public List<FactionWarfareSystem> GetSystems()
		{
			return DownloadData<List<FactionWarfareSystem>>("Faction warfare systems", Settings.EsiClient.FactionWarfare.Systems()); // /fw/systems/:public
		}
		public Leaderboards<CharacterTotal> GetCharacterLeaderboards()
		{
			return DownloadData<Leaderboards<CharacterTotal>>("Faction warfare character leaderboards", Settings.EsiClient.FactionWarfare.LeaderboardsForCharacters()); // /fw/leaderboards/characters/:public
		}
		public Leaderboards<CorporationTotal> GetCorporationLeaderboards()
		{
			return DownloadData<Leaderboards<CorporationTotal>>("Faction warfare corporation leaderboards", Settings.EsiClient.FactionWarfare.LeaderboardsForCorporations()); // /fw/leaderboards/corporations/:public
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

		public override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
