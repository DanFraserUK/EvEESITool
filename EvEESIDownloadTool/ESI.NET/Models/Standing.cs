using Newtonsoft.Json;

namespace EvEESITool.Models
{
    public class Standing
    {
        [JsonProperty("from_id")]
        public int FromId { get; set; }

        [JsonProperty("from_type")]
        public string FromType { get; set; }

        [JsonProperty("standing")]
        public decimal Value { get; set; }
    }
}
