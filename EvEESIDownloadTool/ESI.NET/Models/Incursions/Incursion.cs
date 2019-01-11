﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace EvEESITool.Models.Incursions
{
    public class Incursion
    {
        [JsonProperty("constellation_id")]
        public int ConstellationId { get; set; }

        [JsonProperty("faction_id")]
        public int FactionId { get; set; }

        [JsonProperty("has_boss")]
        public bool HasBoss { get; set; }

        [JsonProperty("infested_solar_systems")]
        public long[] InfestedSystems { get; set; }

        [JsonProperty("influence")]
        public double Influence { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
