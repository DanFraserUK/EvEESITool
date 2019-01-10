using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
using ESI.NET.Models.Corporation;
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
using System.Reflection;

namespace EvEESITool
{
	public class DataClassesBase
	{
		[JsonIgnore]
		internal AppSettings Settings = new AppSettings();
		[JsonIgnore]
		internal readonly string SaveDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		[JsonIgnore]
		internal EsiClient ImportedEsiClient;
		[JsonIgnore]
		internal SDEData SDE;

		internal DataClassesBase()
		{

		}
		public DataClassesBase(ref EsiClient input, ref AppSettings settings)
		{
			ImportedEsiClient = input;
			Settings = settings;
		}
		public DataClassesBase(ref EsiClient input, ref SDEData sde, ref AppSettings settings)
		{
			SDE = sde;
			ImportedEsiClient = input;
			Settings = settings;
		}
		internal T DownloadData<T>(string objectName, Task<ESI.NET.EsiResponse<T>> func)
		{
			var workingObject = func;
			dynamic result = default(T);
			if (workingObject.Status == TaskStatus.WaitingForActivation)
			{
				while (workingObject.Status == TaskStatus.WaitingForActivation)
				{
					Task.Delay(50).Wait();
				}
			}
			if (workingObject.IsFaulted)
			{
				// throw an error maybe?
				Console.WriteLine($"Downloading {objectName} failed. {workingObject.Exception.InnerException.Message}");
			}
			else
			{
				if (workingObject.Status == TaskStatus.RanToCompletion)
				{
					var data = workingObject.Result;
					if (data.Data.GetType() == typeof(int))
					{
						result = int.Parse(data.Message);
					}
					else if (data.Data.GetType() == typeof(decimal))
					{
						result = decimal.Parse(data.Message);
					}
					else
					{
						result = data.Data;
					}
					Console.WriteLine($"Downloaded {objectName}");
				}
				else
				{

				}
			}
			return result;
		}
		/// <summary>
		/// EXPERIMENTAL
		/// 
		/// Looking to figure out how to add parameters or arguments to 'func' to allow
		/// downloading of all pages of paginated results.
		/// </summary>
		/// <param name="objectName"></param>
		/// <param name="func"></param>
		internal T DownloadDataWithPages<T>(string objectName, Task<ESI.NET.EsiResponse<T>> func)
		{
			var workingObject = func;
			dynamic result;
			if (workingObject.Status == TaskStatus.WaitingForActivation)
			{
				while (workingObject.Status == TaskStatus.WaitingForActivation)
				{
					Task.Delay(50).Wait();
				}
			}
			if (workingObject.IsFaulted)
			{
				// throw an error maybe?
				Console.WriteLine($"Downloading {objectName} failed. {workingObject.Exception.InnerException.Message}");
			}
			else
			{
				if (workingObject.Status == TaskStatus.RanToCompletion)
				{
					result = workingObject.Result.Data;
					int? pages = workingObject.Result.Pages;
					if (pages != null)
					{
						result.Add(result[0]);
						Console.Write($"Downloaded {objectName} page 1     ");
						for (int page = 2; page <= pages; page++)
						{
							Console.SetCursorPosition(0, Console.CursorTop);
							//var tempObject = func(page);
							//var tempObject = func;
							//result.AddRange(tempObject(page).Result.Data);
							int test = 0;
							test += 2;
							Console.Write($"Downloaded {objectName} page {page}");
						}
						Console.WriteLine($"Downloaded {objectName}                ");
						return result;
					}
					else
					{
						Console.WriteLine($"Downloaded {objectName}");
						return result;
					}
				}
				else
				{
					return default(T);
				}
			}
			return default(T);
		}
		/// <summary>
		/// Saves the data to a file of type .json
		/// </summary>
		/// <param name="fileName">Name of the file without extension</param>
		internal void SaveToFile()
		{
			using (StreamWriter file = File.CreateText(SaveFile))
			{
				JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
				//serialize object directly into file stream
				serializer.Serialize(file, this);
			}
		}
		internal string SaveFile
		{
			get
			{
				string test = SaveDirectory + "\\Data\\" + this.GetType().Name + ".json";
				return test;
			}
			private set
			{
				throw new NotImplementedException("How did you get in here!?");
			}
		}
	}
}
