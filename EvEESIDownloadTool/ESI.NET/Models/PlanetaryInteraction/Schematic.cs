using Newtonsoft.Json;

namespace EvEESITool.Models.PlanetaryInteraction
{
    public class Schematic
    {
        [JsonProperty("cycle_time")]
        public int CycleTime { get; set; }

        [JsonProperty("schematic_name")]
        public string Name { get; set; }
    }
}
