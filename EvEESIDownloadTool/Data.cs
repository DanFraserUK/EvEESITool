﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvEESITool
{
	/// <summary>
	/// This is a current work in progress as a concept!
	/// </summary>
	public class Data
	{
		MainSettings Settings = new MainSettings();

		public List<Profile> Profiles;
		public SDEData SDE;

		public MarketData Market;
		public PublicData Public;
		public UniverseData Universe;

		public Data()
		{
			Startup();

			DoProfileWork();
		}
		internal void Startup()
		{
			Profiles = new List<Profile>();
			Settings = new MainSettings();
			SDE = new SDEData(ref Settings);
		}

		internal void DoProfileWork()
		{
			List<string> existingFolders = FindExistingProfiles();
			foreach (string s in existingFolders)
			{
				Profiles.Add(new Profile(ref Settings, new DirectoryInfo(s).Name));
			}
			if (Profiles.Count > 0)
			{
				CreatePublicAccess(ref Profiles[0].Settings);
			}
		}

		internal List<string> FindExistingProfiles()
		{
			List<string> profileFolders = new List<string>();
			profileFolders.AddRange(Directory.GetDirectories(Settings.DataDirectory, "*", SearchOption.TopDirectoryOnly));

			return profileFolders;
		}

		public void CreateNewProfile()
		{
			Profiles.Add(new Profile(ref Settings));
			if (Profiles.Count > 0)
			{
				CreatePublicAccess(ref Profiles[0].Settings);
			}
		}

		public void CreatePublicAccess(ref ProfileSettings settings)
		{
			Market = new MarketData(ref settings);
			Public = new PublicData(ref settings);
			Universe = new UniverseData(ref settings);
		}
	}
}
