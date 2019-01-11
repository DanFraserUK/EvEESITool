﻿using Newtonsoft.Json;
using System;

namespace EvEESITool.Models.Corporation
{
    public class Medal
    {
        [JsonProperty("medal_id")]
        public int MedalId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
