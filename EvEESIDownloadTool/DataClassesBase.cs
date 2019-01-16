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
using System.Timers;

namespace EvEESITool
{
	public class DataClassesBase : IDisposable
	{
		[JsonIgnore]
		protected ProfileSettings Settings;
		[JsonIgnore]
		protected readonly string SaveDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

		private Timer Timer { get; set; }
		private void TimerEvent(object source, ElapsedEventArgs e)
		{
			Console.WriteLine($"{this.GetType().Name} checking in!");
			Timer.Interval = Settings.MainSettings.TimerMinutes * Settings.MainSettings.TimerSeconds * Settings.MainSettings.TimerMilliseconds;
			Download();
		}
		protected DataClassesBase()
		{

		}
		protected DataClassesBase(ref ProfileSettings settings)
		{
			Settings = settings;
			SetupTimer();
		}
		private void SetupTimer()
		{
			Timer = new Timer((Settings.MainSettings.TimerMinutes + Settings.MainSettings.TimerEventCounters++)
							* Settings.MainSettings.TimerSeconds
							* Settings.MainSettings.TimerMilliseconds
							);
			Timer.Elapsed += TimerEvent;
			Timer.Enabled = true;
		}
		protected T DownloadData<T>(Task<EsiResponse<T>> myTask)
		{
			Task<EsiResponse<T>> workingObject = myTask;
			dynamic result = default(T);
			if (workingObject.Status == TaskStatus.WaitingForActivation)
			{
				while (workingObject.Status == TaskStatus.WaitingForActivation)
				{
					Task.Delay(100).Wait();
				}
			}
			if (workingObject.IsFaulted)
			{
				// throw an error maybe?
			}
			else
			{
				if (workingObject.Status == TaskStatus.RanToCompletion)
				{
					EsiResponse<T> data = workingObject.Result;
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
					}
				}
				
			}
			return result;
		}
		/// <summary>
		/// Verbose version with console logging
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objectName"></param>
		/// <param name="myTask"></param>
		/// <returns></returns>
		protected T DownloadData<T>(string objectName, Task<EsiResponse<T>> myTask)
		{
			var workingObject = myTask;
			dynamic result = default(T);
			if (workingObject.Status == TaskStatus.WaitingForActivation)
			{
				while (workingObject.Status == TaskStatus.WaitingForActivation)
				{
					Task.Delay(100).Wait();
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
		protected void SaveToFile()
		{
			if (Settings.MainSettings.SaveDataWhenDownloaded)
			{
				Console.WriteLine($"Saving {Path.GetFileNameWithoutExtension(SaveFile)} to {Path.GetFileName(SaveFile)}");
				Console.WriteLine();
				if (!Directory.Exists(Path.GetDirectoryName(SaveFile)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(SaveFile));
				}
				using (StreamWriter file = File.CreateText(SaveFile))
				{
					Settings.MainSettings.serializer.Serialize(file, this);
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
				return Settings.MainSettings.DataDirectory + "\\" + Settings.ProfileName + $"\\" + this.GetType().Name + ".json";
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
				if (!Settings.MainSettings.InternetAccessAvailable)
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
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources
				if (Settings != null)
				{
					Settings.Dispose();
					Settings = null;
				}
				// Dispose remaining objects,
			}
		}
	}
}
