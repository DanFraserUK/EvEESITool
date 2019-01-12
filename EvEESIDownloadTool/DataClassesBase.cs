using EvEESITool;
using EvEESITool.Enumerations;
using EvEESITool.Models.Assets;
using EvEESITool.Models.Character;
using EvEESITool.Models.Corporation;
using EvEESITool.Models.Industry;
using EvEESITool.Models.Location;
using EvEESITool.Models.Market;
using EvEESITool.Models.SSO;
using EvEESITool.Models.Wallet;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using EvEESITool.Models.Skills;
using EvEESITool.Models.Clones;
using EvEESITool.Models.Fittings;
using EvEESITool.Models;
using System.Reflection;
using System.Timers;

namespace EvEESITool
{
	public class DataClassesBase
	{
		[JsonIgnore]
		protected AppSettings Settings = new AppSettings();
		[JsonIgnore]
		protected readonly string SaveDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

		private Timer Timer { get; set; }
		private void TimerEvent(object source, ElapsedEventArgs e)
		{
			Console.WriteLine($"{this.GetType().Name} checking in!");
			Timer.Interval = Settings.TimerMinutes * Settings.TimerSeconds * Settings.TimerMilliseconds;
			Download();
		}
		protected DataClassesBase()
		{
			Settings = new AppSettings();
		}
		protected DataClassesBase(ref AppSettings settings)
		{
			Settings = settings;
			SetupTimer();
		}
		private void SetupTimer()
		{
			Timer = new Timer((Settings.TimerMinutes + Settings.TimerEventCounters++) * Settings.TimerSeconds * Settings.TimerMilliseconds); // minutes * seconds * milliseconds
			Timer.Elapsed += TimerEvent;
			Timer.Enabled = true;
		}
		protected T DownloadData<T>(string objectName, Task<EsiResponse<T>> func)
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
					if (data.StatusCode != System.Net.HttpStatusCode.NotFound)
					{
						if (data.Data != null && data.Data.GetType() == typeof(int))
						{
							result = int.Parse(data.Message);
						}
						else if (data.Data != null && data.Data.GetType() == typeof(decimal))
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
						Console.WriteLine($"No data found for {objectName}");
					}
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
		protected T DownloadDataWithPages<T>(string objectName, Task<EsiResponse<T>> func)
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
		protected void SaveToFile()
		{
			if (Settings.SaveDataWhenDownloaded)
			{
				Console.WriteLine($"Saving {Path.GetFileNameWithoutExtension(SaveFile)} to {Path.GetFileName(SaveFile)} .");
				Console.WriteLine();
				using (StreamWriter file = File.CreateText(SaveFile))
				{
					JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
					//serialize object directly into file stream
					serializer.Serialize(file, this);
				}
			}
			else
			{
				Console.WriteLine($"Automatic saving of downloaded data to {Path.GetFileName(SaveFile)} disabled.");
				Console.WriteLine();
			}
		}
		protected string SaveFile
		{
			get
			{
				return Settings.DataDirectory + this.GetType().Name + ".json";
			}
			private set
			{
				throw new NotImplementedException("How did you get in here!?");
			}
		}
		protected void GetData()
		{
			if (File.Exists(SaveFile))
			{
				if (FileAge(SaveFile) < 60)
				{
					if (LoadFromFile())
					{
						// loading from file successful
					}
					else
					{
						// some kind of failure loading from file, so 
						Download();
					}
				}
				else
				{
					// current data is more than 1 hour old
					Download();
				}
			}
			else
			{
				// download data
				Download();
			}
		}
		protected virtual void Download()
		{
			//	throw new NotImplementedException();
		}
		protected virtual bool LoadFromFile()
		{
			bool result = false;
			try
			{
				result = ReadInData();
			}
			catch (Exception ex)
			{
				Console.SetCursorPosition(0, Console.CursorTop);
				Console.WriteLine(("Loading from file failed.").PadRight(SaveFile.Length + 13));
				Console.WriteLine($"Error message : {ex.Message}");
				if (!Settings.InternetAccessAvailable)
				{
					Console.WriteLine();
					Console.WriteLine("Well this is a problem isn't it?");
					Console.WriteLine();
				}
				result = false;
			}
			return result;
		}
		private int FileAge(string filePath)
		{
			// Got this working correctly now.
			int result = DateTime.Now.Subtract(new FileInfo(filePath).LastWriteTime).Minutes;
			result += DateTime.Now.Subtract(new FileInfo(filePath).LastWriteTime).Hours * 60;
			return result;
		}
		protected virtual bool ReadInData()
		{
			return false;
		}
	}
}
