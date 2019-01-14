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
        public Settings FleetSettings(int fleetID)
        {
            return DownloadData("Fleet settings", Settings.EsiClient.Fleets.Settings(fleetID));
        }
        public List<Member> Members(int fleetID)
        {
            return DownloadData("Members", Settings.EsiClient.Fleets.Members(fleetID));
        }
        public List<Wing> Wings(int fleetID)
        {
            return DownloadData("Wings", Settings.EsiClient.Fleets.Wings(fleetID));
        }

        /// <summary>
        /// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
        /// </summary>
        [JsonConstructor]
        internal FleetData()
        {
        }
        internal FleetData(ref ProfileSettings settings) : base(ref settings)
        {
            GetData();
        }

        protected override bool ReadInData()
        {
            throw new NotImplementedException();
        }
    }
}
