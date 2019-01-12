using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EvEESITool.Models.Character;
using EvEESITool.Models.Insurance;
using EvEESITool.Models.Loyalty;

namespace EvEESITool
{
	public class PublicData : DataClassesBase
	{
		public List<int> GetNPCCorps()
		{
			return DownloadData("NPC Corporations", Settings.EsiClient.Corporation.NpcCorps()); // /corporations/npccorps/:public
		}
		public DogmaData Dogma { get; private set; } = new DogmaData();
		public IndustryData Industry { get; private set; } = new IndustryData();
		public IncursionsData Incursions { get; private set; } = new IncursionsData();
		public FactionWarfareData FactionWarfare { get; private set; } = new FactionWarfareData();
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
			return DownloadData<List<Insurance>>("Insurance levels", Settings.EsiClient.Insurance.Levels()); // /insurance/prices/:public
		}
		public Models.Killmails.Information GetKillmail(string killmailHash, int killmailID)
		{
			return DownloadData<Models.Killmails.Information>("Killmail", Settings.EsiClient.Killmails.Information(killmailHash, killmailID)); // /killmails/{killmail_id}/{killmail_hash}/:public
		}
		public List<Offer> GetProperty(int corporationID)
		{
			return DownloadData("Loyalty offers", Settings.EsiClient.Loyalty.Offers(corporationID)); // /loyalty/stores/{corporation_id}/offers/:public
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
		}
		protected override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
