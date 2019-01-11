using Newtonsoft.Json;

namespace EvEESITool.Models.Loyalty
{
    public class Points
    {
        [JsonProperty("corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty("loyalty_points")]
        public int LoyaltyPoints { get; set; }
    }
}
