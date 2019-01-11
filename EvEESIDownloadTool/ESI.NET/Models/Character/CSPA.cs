using Newtonsoft.Json;

namespace EvEESITool.Models.Character
{
    public class Cspa
    {
        [JsonProperty("cost")]
        public decimal Cost { get; set; }
    }
}
