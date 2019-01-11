using Newtonsoft.Json;

namespace EvEESITool.Models.Character
{
	public class CharacterRoles
	{
		[JsonProperty("roles")]
		public string[] Roles { get; set; }
		[JsonProperty("roles_at_base")]
		public string[] RolesAtBase { get; set; }
		[JsonProperty("roles_at_hq")]
		public string[] RolesAtHq { get; set; }
		[JsonProperty("roles_at_other")]
		public string[] RolesAtOther { get; set; }
	}
}
