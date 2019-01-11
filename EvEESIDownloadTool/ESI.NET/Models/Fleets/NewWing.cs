using Newtonsoft.Json;

namespace EvEESITool.Models.Fleets
{
    public class NewWing
    {
        [JsonProperty("wing_id")]
        public long WingId { get; set; }
    }
}
