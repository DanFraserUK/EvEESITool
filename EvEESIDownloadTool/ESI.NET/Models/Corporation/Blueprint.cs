﻿using Newtonsoft.Json;

namespace EvEESITool.Models.Corporation
{
    public class Blueprint
    {
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        [JsonProperty("location_flag")]
        public string LocationFlag { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("time_efficiency")]
        public int TimeEfficiency { get; set; }

        [JsonProperty("material_efficiency")]
        public int MaterialEfficiency { get; set; }

        [JsonProperty("runs")]
        public int Runs { get; set; }
    }
}
