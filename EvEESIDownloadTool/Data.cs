using System;
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
   public  class Data
    {
		AppSettings Settings;
		List<Profile> Profiles;

		public Data()
		{
			Profiles = new List<Profile>();
			Settings = new AppSettings();
		}

		public void CreateNewProfile()
		{
			Profiles.Add(new Profile());
		}

		public void DetectExistingProfiles()
		{

		}

		public void LoadExistingProfiles()
		{
			List<string> profileFolders = new List<string>();
			profileFolders.AddRange(Directory.GetDirectories(Settings.DataDirectory));
			foreach(string s in profileFolders)
			{
				Profiles.Add(new Profile(s));
			}
		}
    }
}
