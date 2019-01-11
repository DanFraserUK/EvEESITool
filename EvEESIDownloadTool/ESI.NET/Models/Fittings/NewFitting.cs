using Newtonsoft.Json;

namespace EvEESITool.Models.Fittings
{
    public class NewFitting
    {
        [JsonProperty("fitting_id")]
        public int FittingId { get; set; }
    }
}
