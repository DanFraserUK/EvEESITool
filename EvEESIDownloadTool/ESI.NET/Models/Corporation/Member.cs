using Newtonsoft.Json;

namespace EvEESITool.Models.Corporation
{
    public class Member
    {
        [JsonProperty("character_id")]
        public int CharacterId { get; set; }
    }
}
