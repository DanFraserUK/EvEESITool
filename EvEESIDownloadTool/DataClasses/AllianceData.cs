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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="allianceID">ID of the alliance to get information about</param>
		/// <returns>Information in an Alliance Class</returns>
		public Alliance GetAlliance(int allianceID)
		{
			return DownloadData("Alliance Information", Settings.EsiClient.Alliance.Information(allianceID));
		}
		public List<int> Corporations { get; private set; } = new List<int>();
		public List<int> GetCorporations(int allianceID)
		{
			return DownloadData("Alliance Corporations", Settings.EsiClient.Alliance.Corporations(AllianceID));
		}
		public Images Icons { get; private set; } = new Images();
		public Images GetIcons(int allianceID)
		{
			return DownloadData("Images", Settings.EsiClient.Alliance.Icons(AllianceID));
		}
		public List<ESI.NET.Models.Contacts.Contact> Contacts { get; private set; } = new List<ESI.NET.Models.Contacts.Contact>();



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
			AllianceID = Settings.AuthorisationData.AllianceID;
			if (AllianceID > 0)
			{
				GetData();
			}
		}
		protected override void Download()
		{
			Information = DownloadData("Information", Settings.EsiClient.Alliance.Information(AllianceID));
			Corporations = DownloadData("Corporations", Settings.EsiClient.Alliance.Corporations(AllianceID));
			Icons = DownloadData("Images", Settings.EsiClient.Alliance.Icons(AllianceID));
			Contacts = DownloadData("Contacts", Settings.EsiClient.Contacts.ListForAlliance(1));






			Console.WriteLine();
			SaveToFile();
		}
		protected override bool ReadInData()
		{
			using (StreamReader myReader = new StreamReader(SaveFile))
			{
				AllianceData temp = AppSettings.serializer.Deserialize<AllianceData>(new JsonTextReader(myReader));
				Console.Write($"Loading data from {Path.GetFileName(SaveFile)}");



				Console.Write(" - successful");
				Console.WriteLine();
				return true;
			}
		}
	}
}
