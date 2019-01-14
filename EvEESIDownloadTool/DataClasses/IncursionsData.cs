using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESI.NET.Models.Incursions;
using Newtonsoft.Json;

namespace EvEESITool
{
    public class IncursionsData : DataClassesBase
    {
        public List<Incursion> GetIncursions()
        {
            return DownloadData("Incursions", Settings.EsiClient.Incursions.All());
        }

        /// <summary>
        /// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
        /// </summary>
        [JsonConstructor]
        internal IncursionsData()
        {
        }
        internal IncursionsData(ref ProfileSettings settings) : base(ref settings)
        {
            GetData();
        }

        protected override bool ReadInData()
        {
            throw new NotImplementedException();
        }
    }
}
