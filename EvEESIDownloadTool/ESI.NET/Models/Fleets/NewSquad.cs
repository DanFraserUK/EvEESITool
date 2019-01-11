using Newtonsoft.Json;

namespace EvEESITool.Models.Fleets
{
    public class NewSquad
    {
        [JsonProperty("squad_id")]
        public long SquadId { get; set; }
    }
}
