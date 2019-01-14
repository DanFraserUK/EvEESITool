using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvEESITool;
using ESI.NET;
using ESI.NET.Models.Skills;

namespace EvEESIToolExample
{
	class Program
	{
		static void Main(string[] args)
		{
			Data esiData = new Data();
			//Profile esiData = new Profile();

			// I know this is incredibly basic!
			Console.WriteLine("Would you like to add a new profile? (Y/N) : ");
			if (Console.ReadKey().KeyChar.ToString().ToLower() == "y")
			{
				esiData.CreateNewProfile();
			}

			// examples
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
