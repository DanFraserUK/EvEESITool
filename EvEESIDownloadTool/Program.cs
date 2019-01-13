using System;

using ESI.NET.Models.Skills;

namespace EvEESITool
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

			foreach (ESI.NET.Models.Corporation.Facility f in esiData.Corporation.Facilities)
			{
				Console.WriteLine(esiData.Universe.GetStructure(f.FacilityId).Name + ", " 
					+ esiData.SDE.SolarSystems.Search(f.SystemId).SolarSystemName + ", "
					+ esiData.SDE.InvTypes.Search(f.TypeId).TypeName);
			}
			// place a breakpoint below to hold the program to have a good look through the local items.

			Console.WriteLine("Press a key to end");

			Console.ReadKey();
		}
	}
}