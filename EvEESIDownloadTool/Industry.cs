using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvEESITool.Models.Industry;
using Newtonsoft.Json;

namespace EvEESITool
{
	public class IndustryData : DataClassesBase
	{
		public List<Facility> GetFacilities()
		{
			return DownloadData<List<Facility>>("Facilities", Settings.EsiClient.Industry.Facilities()); // /incursions/:public
		}
		public List<SolarSystem> GetSolarSystemCostIndices()
		{
			return DownloadData<List<SolarSystem>>("Solar system cost indices", Settings.EsiClient.Industry.SolarSystemCostIndices()); // /industry/systems/:public
		}

		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal IndustryData() : base()
		{
		}
		internal IndustryData(ref AppSettings settings) : base(ref settings)
		{
			GetData();
		}

		public override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
