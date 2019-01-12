using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESI.NET.Models.Fleets;
using Newtonsoft.Json;

namespace EvEESITool
{
	public class FleetData : DataClassesBase
	{
		public Settings FleetSettings(int fleetID)// { get; private set; } = new Settings();
		{
			return DownloadData("Fleet settings", Settings.EsiClient.Fleets.Settings(fleetID));
		}
		public List<Member> Members(int fleetID)// { get; private set; } = new List<Member>();
		{
			return DownloadData("Members", Settings.EsiClient.Fleets.Members(fleetID)); // /fleets/{fleet_id}/members/:esi-fleets.read_fleet.v1
		}
		public List<Wing> Wings(int fleetID)// { get; private set; } = new List<Member>();
		{
			return DownloadData("Wings", Settings.EsiClient.Fleets.Wings(fleetID)); // /fleets/{fleet_id}/members/:esi-fleets.read_fleet.v1
		}

		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal FleetData() : base()
		{
		}
		internal FleetData(ref AppSettings settings) : base(ref settings)
		{
			GetData();
		}

		protected override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
