using Newtonsoft.Json;

namespace EvEESITool.Models.Assets
{
    public class ItemName
    {
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
