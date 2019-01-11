using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EvEESITool.Enumerations
{
    public enum DataSource
    {
        [EnumMember(Value="tranquility")] /**/ Tranquility,
        [EnumMember(Value="singularity")] /**/ Singularity
    }
}
