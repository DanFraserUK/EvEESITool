using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
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
using AssetsItem = ESI.NET.Models.Assets.Item;
using ESI.NET.Models.Bookmarks;
using ESI.NET.Models.Calendar;
using ESI.NET.Models.FactionWarfare;
using ESI.NET.Models.Fleets;
using ESI.NET.Models.Killmails;
using ESI.NET.Models.Loyalty;
using ESI.NET.Models.Mail;
using ESI.NET.Models.Opportunities;

namespace EvEESITool
{
	public class OpportunitiesData : DataClassesBase
	{
		public List<int> Groups { get; private set; } = new List<int>();
		public List<int> GetGroups()
		{
			return DownloadData("Groups", Settings.EsiClient.Opportunities.Groups()); // /opportunities/groups/:public
		}
		[JsonIgnore]
		public ESI.NET.Models.Opportunities.Group Group { get; private set; } = new ESI.NET.Models.Opportunities.Group();
		public ESI.NET.Models.Opportunities.Group GetGroup(int groupID)
		{
			return DownloadData("Group", Settings.EsiClient.Opportunities.Group(groupID)); // /opportunities/groups/{group_id}/:public
		}
		public List<int> Tasks { get; private set; } = new List<int>();
		public List<int> GetTasks()
		{
			return DownloadData("Tasks", Settings.EsiClient.Opportunities.Tasks()); // /opportunities/tasks/:public
		}
		[JsonIgnore]
		public ESI.NET.Models.Opportunities.Task Task { get; private set; } = new ESI.NET.Models.Opportunities.Task();
		public ESI.NET.Models.Opportunities.Task GetTask(int taskID)
		{
			return DownloadData("Task", Settings.EsiClient.Opportunities.Task(taskID)); // /opportunities/tasks/{task_id}/:public
		}
		public List<CompletedTask> CompletedTasks { get; private set; } = new List<CompletedTask>();




		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal OpportunitiesData() : base()
		{
		}
		internal OpportunitiesData(ref AppSettings settings) : base(ref settings)
		{
			GetData();
		}
		protected override void Download()
		{
			Groups = GetGroups();
			Tasks = GetTasks();
			CompletedTasks = DownloadData("Completed tasks", Settings.EsiClient.Opportunities.CompletedTasks());


			Console.WriteLine();
			SaveToFile();
		}
		protected override bool ReadInData()
		{
			using (StreamReader myReader = new StreamReader(SaveFile))
			{
				OpportunitiesData temp = Settings.serializer.Deserialize<OpportunitiesData>(new JsonTextReader(myReader));
				Console.Write($"Loading data from {Path.GetFileName(SaveFile)}");
				Groups = temp.Groups;
				Tasks = temp.Tasks;
				
				Console.Write(" - successful");
				Console.WriteLine();
				Console.WriteLine();

				return true;
			}
		}
	}
}
