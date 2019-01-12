using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
