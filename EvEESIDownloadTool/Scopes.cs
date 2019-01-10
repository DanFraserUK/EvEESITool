using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvEESIDownloadTool
{
	public static class Scopes
	{
		public static List<string> GetScopes()
		{
			List<string> lines = new List<string>();
			using (StreamReader myReader = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\scopes.dat"))
			{
				string line = "";
				while ((line = myReader.ReadLine()) != null)
				{
					lines.Add(line);
				}
			}
			if (lines.Count == 1)
			{
				lines.AddRange(lines[0].Split(' '));
				lines.RemoveAt(0);
			}
			return lines;
		}
	}
}
