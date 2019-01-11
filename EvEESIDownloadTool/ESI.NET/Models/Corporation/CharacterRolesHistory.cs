﻿using Newtonsoft.Json;
using System;

namespace EvEESITool.Models.Corporation
{
    public class CharacterRolesHistory
    {
        [JsonProperty("character_id")]
        public int CharacterId { get; set; }

        [JsonProperty("changed_at")]
        public DateTime ChangedAt { get; set; }

        [JsonProperty("issuer_id")]
        public int IssuerId { get; set; }

        [JsonProperty("role_type")]
        public string RoleType { get; set; }

        [JsonProperty("old_roles")]
        public string[] OldRoles { get; set; }

        [JsonProperty("new_roles")]
        public string[] NewRoles { get; set; }
    }
}
