using Newtonsoft.Json;

namespace EvEESITool.Models.Wallet
{
    public class Wallet
    {
        [JsonProperty("division")]
        public int Division { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }
    }
}
