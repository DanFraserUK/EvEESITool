using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ESI.NET.Models.Sovereignty;

namespace EvEESITool
{
	public class SovereigntyData : DataClassesBase
	{
		public List<Structure> Structures { get; private set; } = new List<Structure>();
		public List<Structure> GetStructures()
		{
			return DownloadData<List<Structure>>("Structures", Settings.EsiClient.Sovereignty.Structures());
		}
		public List<Campaign> Campaigns { get; private set; } = new List<Campaign>();
		public List<Campaign> GetCampaigns()
		{
			return DownloadData<List<Campaign>>("Campaigns", Settings.EsiClient.Sovereignty.Campaigns());
		}
		public List<SystemSovereignty> Systems { get; private set; } = new List<SystemSovereignty>();
		public List<SystemSovereignty> GetSystems()
		{
			return DownloadData<List<SystemSovereignty>>("Systems", Settings.EsiClient.Sovereignty.Systems());
		}



		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal SovereigntyData() : base()
		{
		}
		internal SovereigntyData(ref AppSettings settings) : base(ref settings)
		{
		}
		protected override void Download()
		{
			Structures = DownloadData("Structures", Settings.EsiClient.Sovereignty.Structures());
			Campaigns = DownloadData("Campaigns", Settings.EsiClient.Sovereignty.Campaigns());
			Systems = DownloadData("Systems", Settings.EsiClient.Sovereignty.Systems());

			Console.WriteLine();
			SaveToFile();
		}
		protected override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
