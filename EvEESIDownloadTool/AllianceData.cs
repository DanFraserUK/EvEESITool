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
using System.Reflection;
using ESI.NET.Models.Alliance;

namespace EvEESITool
{
	public class AllianceData : DataClassesBase
	{
		public Alliance Information { get; private set; } = new Alliance();
		public Alliance GetAlliance(int allianceID)
		{
			return DownloadData<Alliance>("Alliance Information", Settings.EsiClient.Alliance.Information(allianceID));
		}
		public List<int> Corporations { get; private set; } = new List<int>();
		public List<int> GetCorporations(int allianceID)
		{
			return DownloadData<List<int>>("Alliance Corporations", Settings.EsiClient.Alliance.Corporations(AllianceID));
		}
		public Images Icons { get; private set; } = new Images();
		public Images GetIcons(int allianceID)
		{
			return DownloadData<Images>("Images", Settings.EsiClient.Alliance.Icons(AllianceID));
		}
		public List<int> GetAllianceIDs()
		{
			return DownloadData<List<int>>("Alliance IDs", Settings.EsiClient.Alliance.All()); // /alliances/:public

		}
		public int AllianceID { get; set; } = 0;
		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal AllianceData() : base()
		{
		}
		internal AllianceData(ref AppSettings settings) : base(ref settings)
		{
			AllianceID = Settings.AuthorisationData.CharacterID;
			GetData();
		}
		public override void Download()
		{
			Information = DownloadData<Alliance>("Information", Settings.EsiClient.Alliance.Information(AllianceID)); // /alliances/{alliance_id}/:public
			Corporations = DownloadData<List<int>>("Corporations", Settings.EsiClient.Alliance.Corporations(AllianceID)); // /alliances/{alliance_id}/corporations/:public
			Icons = DownloadData<Images>("Images", Settings.EsiClient.Alliance.Icons(AllianceID)); // /alliances/{alliance_id}/icons/:public

			Console.WriteLine();
			SaveToFile();
		}
		public override bool ReadInData()
		{
			using (StreamReader myReader = new StreamReader(SaveFile))
			{
				AllianceData temp = Settings.serializer.Deserialize<AllianceData>(new JsonTextReader(myReader));
				Console.Write($"Loading data from {Path.GetFileName(SaveFile)}");



				Console.Write(" - successful");
				Console.WriteLine();
				return true;
			}
		}
	}
}
