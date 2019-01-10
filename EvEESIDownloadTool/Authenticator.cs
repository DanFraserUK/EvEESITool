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

namespace EvEESITool
{
	/// <summary>
	/// This class should be used to interact with the ESI authorisation steps ONLY
	/// </summary>
	public class Authenticator
	{
		[JsonIgnore]
		private readonly string SaveFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\auth.txt";
		public AppSettings Settings { get; set; } = new AppSettings();
		public EsiClient _client;
		public SsoToken token;
		public string code = "";
		public IOptions<EsiConfig> config;
		public List<string> Scopes { get; private set; } = new List<string>();
		public string url;
		public bool AuthenticationSuccessful = false;
		public bool AuthenticationStepsComplete = false;

		public Authenticator()
		{

		}
		public Authenticator(ref EsiClient input, ref AppSettings settings)
		{
			
			_client = input;
			Settings = settings;
		}
		public EsiClient StartAuthenticating()
		{
			Setup();
			Console.WriteLine();
			if (Settings.LoadedFromFile)
			{
				Console.WriteLine("Authorization data file exists, loading data.");
				Console.WriteLine();
				Console.WriteLine("Obtaining refresh token.");
				//LoadAuthorisationFile();
				GetRefreshToken(Settings.AuthorisationData.RefreshToken);
				while (Settings.AuthorisationData.RefreshToken == null)
				{
					Task.Delay(50).Wait();
				}
			}
			else
			{
				CreateUrl();
				GetCode();
				InitialSSOTokenRequest();
			}

			url += " ";
			AuthenticationStepsComplete = true;
			return _client;
		}
		private void LoadData()
		{
			Console.CursorVisible = false;
			Console.WriteLine();
			//TryReadData();
		}


		//private void LoadAuthorisationFile()
		//{
		//	using (StreamReader myReader = new StreamReader(SaveFile))
		//	{
		//		JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
		//		JsonTextReader myJsonTextReader = new JsonTextReader(myReader);

		//		Settings.AuthorisationData = serializer.Deserialize<AuthorizedCharacterData>(myJsonTextReader);
		//	}
		//}
		public void Setup()
		{
			Console.WriteLine("Setting up authentication.");
			Console.WriteLine();
			token = new SsoToken();
			Console.WriteLine("SSO Token object created.");
			Console.WriteLine();
			config = Settings.Config.ConfigOutput();

			Console.WriteLine($"config created.");
			Console.WriteLine($"EsiUrl = {config.Value.EsiUrl}");
			Console.WriteLine($"DataSource = {config.Value.DataSource}");
			Console.WriteLine($"ClientId = {config.Value.ClientId}");
			Console.WriteLine($"SecretKey = {config.Value.SecretKey}");
			Console.WriteLine($"CallbackUrl = {config.Value.CallbackUrl}");
			Console.WriteLine($"UserAgent = {config.Value.UserAgent}");
			Console.WriteLine();

			Scopes = EvEESITool.Scopes.GetScopes();
			Console.WriteLine($"Scopes file loaded. {Scopes.Count} scopes added.");

			_client = new EsiClient(config);
			Console.WriteLine("Created EsiClient object.");
		}

		public void CreateUrl()
		{
			url = _client.SSO.CreateAuthenticationUrl(Scopes);
			Console.WriteLine("Url created.");
			Console.WriteLine();
		}

		public void GetCode()
		{
			Process.Start(url);
			Console.WriteLine("Paste the new url from the address textbox here.");
			string input = Console.ReadLine();
			code = input.Substring(input.IndexOf("?code=") + 6);
			Console.WriteLine();
			Console.WriteLine($"code = {code}");
			Console.WriteLine();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="refreshToken"></param>
		/// <returns>Successfully obtains a refresh token</returns>
		public async void GetRefreshToken(string refreshToken)
		{
			token = await _client.SSO.GetToken(GrantType.RefreshToken, refreshToken);
			//Extensions.AwaitMessage(ref token.RefreshToken, "Awaiting token...", "Token downloaded.");
			Settings.AuthorisationData = Verify().Result;
			//Extensions.AwaitMessage(ref Settings.AuthorisationData.CharacterName, "Awaiting verification...", "Token verified successfully.");
			_client.SetCharacterData(Settings.AuthorisationData);
			Console.WriteLine("Character data set.");
			Console.WriteLine();

			Settings.Save();
		}

		public async void InitialSSOTokenRequest()
		{
			token = await GetToken();
			Settings.AuthorisationData = Verify().Result;
			_client.SetCharacterData(Settings.AuthorisationData);
			Settings.Save();
		}

		public async Task<SsoToken> GetToken()
		{
			SsoToken result = await _client.SSO.GetToken(GrantType.AuthorizationCode, code);
			Console.WriteLine($"Token result obtained.");
			Console.WriteLine($"  {result.AccessToken}");
			Console.WriteLine($"  {result.ExpiresIn}");
			Console.WriteLine($"  {result.RefreshToken}");
			Console.WriteLine($"  {result.TokenType}");
			return result;
		}

		public async Task<AuthorizedCharacterData> Verify()
		{
			AuthorizedCharacterData result = await _client.SSO.Verify(token);
			return result;
		}
	}
}
