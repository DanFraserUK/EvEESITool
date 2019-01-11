using Newtonsoft.Json;

namespace EvEESITool.Models.Corporation
{
    public class Facility
    {
        [JsonProperty("facility_id")]
        public long FacilityId { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        [JsonProperty("system_id")]
        public int SystemId { get; set; }
    }
}
