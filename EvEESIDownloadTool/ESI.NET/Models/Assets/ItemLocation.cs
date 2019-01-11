using Newtonsoft.Json;

namespace EvEESITool.Models.Assets
{
    public class ItemLocation
    {
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("z")]
        public double Z { get; set; }
    }
}
