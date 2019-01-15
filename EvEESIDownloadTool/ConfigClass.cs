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
using Newtonsoft.Json;
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
using System.Timers;

namespace EvEESITool
{
	public class ConfigClass
	{
		public string EsiUrl;
		public DataSource DataSource;
		public string ClientID;
		public string SecretKey;
		public string CallbackUrl;
		public string UserAgent;

		public IOptions<EsiConfig> ConfigOutput()
		{
			IOptions<EsiConfig> result = Options.Create(new EsiConfig()
			{
				EsiUrl = EsiUrl,
				DataSource = DataSource,
				ClientId = ClientID,
				SecretKey = SecretKey,
				CallbackUrl = CallbackUrl,
				UserAgent = UserAgent
			});
			return result;
		}
		public ConfigClass()
		{

		}

		public ConfigClass(string file)
		{
		}
	}
}
