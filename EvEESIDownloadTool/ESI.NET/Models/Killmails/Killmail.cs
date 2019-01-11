using Newtonsoft.Json;

namespace EvEESITool.Models.Killmails
{
    public class Killmail
    {
        [JsonProperty("killmail_hash")]
        public string Hash { get; set; }

        [JsonProperty("killmail_id")]
        public int Id { get; set; }
    }
}
