﻿using Newtonsoft.Json;

namespace ESI.NET.Models.Contacts
{
    public class Contact
    {
        [JsonProperty("standing")]
        public decimal Standing { get; set; }

        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("contact_id")]
        public int ContactId { get; set; }

        [JsonProperty("is_watched")]
        public bool IsWatched { get; set; }

        [JsonProperty("is_blocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("label_id")]
        public long LabelId { get; set; }

    }
}