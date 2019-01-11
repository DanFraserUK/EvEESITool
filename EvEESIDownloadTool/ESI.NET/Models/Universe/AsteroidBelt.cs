using Newtonsoft.Json;

namespace EvEESITool.Models.Universe
{
    class AsteroidBelt
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("system_id")]
        public int SystemId { get; set; }
    }
}
