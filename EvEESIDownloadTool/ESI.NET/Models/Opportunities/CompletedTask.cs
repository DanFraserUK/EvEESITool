using Newtonsoft.Json;
using System;

namespace EvEESITool.Models.Opportunities
{
    public class CompletedTask
    {
        [JsonProperty("task_id")]
        public int TaskId { get; set; }

        [JsonProperty("completed_at")]
        public DateTime CompletedAt { get; set; }
    }
}
