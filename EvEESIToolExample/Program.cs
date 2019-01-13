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

			// examples
			int characterID = esiData.Character.CharacterID;

			SkillDetails skills = esiData.Character.Skills;

			var i = esiData.Public.Industry.GetFacilities();

			ESI.NET.Models.Alliance.Alliance a = esiData.Alliance.GetAlliance(esiData.Corporation.AllianceHistory[1].AllianceId);

			if (esiData.Corporation.Facilities.Count > 0)
			{
				foreach (ESI.NET.Models.Corporation.Facility f in esiData.Corporation.Facilities)
				{
					Console.WriteLine(esiData.Universe.GetStructure(f.FacilityId).Name + ", "
						+ esiData.SDE.SolarSystems.Search(f.SystemId).SolarSystemName + ", "
						+ esiData.SDE.InvTypes.Search(f.TypeId).TypeName);
				}
			}
			else
			{
				Console.WriteLine($"{esiData.Corporation.Information.Name} has no facilities.");
			}
			// place a breakpoint below to hold the program to have a good look through the local items.

			Console.WriteLine("Press a key to end");

			Console.ReadKey();
		}
	}
}
