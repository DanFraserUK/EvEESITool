﻿using Newtonsoft.Json;
using System;

namespace EvEESITool.Models.Corporation
{
    public class AllianceHistory
    {
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("alliance_id")]
        public int AllianceId { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("record_id")]
        public int RecordId { get; set; }
    }
}
