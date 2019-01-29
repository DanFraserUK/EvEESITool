using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvEESITool;
using ESI.NET;
using ESI.NET.Models.Skills;
using ESI.NET.Enumerations;
using System.Windows.Forms;

namespace EvEESIToolExample
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			// starts the tool and loads any existing profiles
			Data esiData = new Data();

			esiData.Settings.NoDownloading = false;
			// use this to start loading existing profiles/downloading data etc
			esiData.LoadData();

			// examples

			//I know this is incredibly basic!
			//existing profiles or not, this adds a new one
			Console.WriteLine("Would you like to add a new profile? (Y/N) : ");
			if (Console.ReadKey().KeyChar.ToString().ToLower() == "y")
			{
				esiData.CreateNewProfile();
				Console.WriteLine();
			}

			// or 
			// this will obviously not run as it is
			//ConfigClass newConfig = new ConfigClass()
			//{
			//	EsiUrl = "https://esi.evetech.net/",
			//	DataSource = DataSource.Tranquility,
			//	ClientID = "<YOUR CLIENT ID>",
			//	SecretKey = "<YOUR SECRET KEY>",
			//	CallbackUrl = "https://localhost/callback/",
			//	UserAgent = "<YOUR EMAIL>"
			//};
			//esiData.CreateNewProfile(newConfig);

			var test = esiData.Market.GetRegionTypes(10000032,1);

			int characterID = esiData.Profiles[0].Character.CharacterID;

			SkillDetails skills = esiData.Profiles[0].Character.Skills;

			Profile p = esiData.Profiles[0];

			var i = esiData.Public.Industry.GetFacilities();

			ESI.NET.Models.Alliance.Alliance a = esiData.Profiles[0].Alliance.GetAlliance(esiData.Profiles[0].Corporation.AllianceHistory[1].AllianceId);

			if (esiData.Profiles[0].Corporation.Structures.Count > 0)
			{
				foreach (ESI.NET.Models.Corporation.Structure f in esiData.Profiles[0].Corporation.Structures)
				{
					Console.WriteLine(esiData.Universe.GetStructure(f.StructureId).Name + ", "
						+ esiData.SDE.SolarSystems.Search(f.SystemId).SolarSystemName + ", "
						+ esiData.SDE.InvTypes.Search(f.TypeId).TypeName);
				}
			}
			else
			{
				Console.WriteLine($"{esiData.Profiles[0].Corporation.Information.Name} has no facilities.");
			}

			// place a breakpoint below to hold the program to have a good look through the local items.

			Console.WriteLine("Press a key to end");

			Console.ReadKey();
		}
	}
}