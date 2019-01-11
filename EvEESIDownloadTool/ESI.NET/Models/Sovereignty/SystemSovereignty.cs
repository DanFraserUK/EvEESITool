﻿using Newtonsoft.Json;

namespace EvEESITool.Models.Sovereignty
{
    public class SystemSovereignty
    {
        [JsonProperty("faction_id")]
        public int FactionId { get; set; }

        [JsonProperty("system_id")]
        public int SystemId { get; set; }
    }
}
