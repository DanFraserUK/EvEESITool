using Newtonsoft.Json;
using System.Runtime.Serialization;
using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
using ESI.NET.Models.Corporation;
using ESI.NET.Models.Industry;
using ESI.NET.Models.Location;
using ESI.NET.Models.Market;
using ESI.NET.Models.SSO;
using ESI.NET.Models.Wallet;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using ESI.NET.Models.Skills;
using ESI.NET.Models.Clones;
using ESI.NET.Models.Fittings;
using ESI.NET.Models;
using System.Web;
using System.Net;

namespace ESI.NET.Enumerations
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ContractType
    {
        [EnumMember(Value = "unknown")]  /**/ Unknown,
        [EnumMember(Value = "item_exchange")]  /**/ ItemExchange,
        [EnumMember(Value = "auction")] /**/ Auction,
        [EnumMember(Value = "courier")] /**/ Courier,
        [EnumMember(Value = "loan ")] /**/ Loan
    }
}
