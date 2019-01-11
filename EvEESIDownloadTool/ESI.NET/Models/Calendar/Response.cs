using EvEESITool.Enumerations;
using Newtonsoft.Json;

namespace EvEESITool.Models.Calendar
{
    public class Response
    {
        [JsonProperty("character_id")]
        public int CharacterId { get; set; }

        [JsonProperty("event_response")]
        public EventResponse EventResponse { get; set; }
    }
}
