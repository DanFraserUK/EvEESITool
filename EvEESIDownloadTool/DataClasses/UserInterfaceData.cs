using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ESI.NET.Models.Universe;

namespace EvEESITool
{
	public class UserInterfaceData : DataClassesBase
	{
		public void OpenMarketDetails(int typeID)
		{
			// who cares about this warning?
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
			Settings.EsiClient.UserInterface.MarketDetails(typeID);
		}

		public void SetWaypoint(int destinationID)
		{
			Settings.EsiClient.UserInterface.Waypoint(destinationID, false, true);
		}
		public void AddWaypoint(int destinationID)
		{
			Settings.EsiClient.UserInterface.Waypoint(destinationID, false, false);
		}

		internal UserInterfaceData(ref ProfileSettings settings) : base(ref settings)
		{

		}
	}
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
}
