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
	internal class Authenticator : IDisposable
	{
		public ProfileSettings Settings;
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
		public Authenticator(ref ProfileSettings settings)
		{
			Settings = settings;
		}
		public EsiClient StartAuthenticating()
		{
			Setup();
			Console.WriteLine();
			if (!Settings.MainSettings.SkipAuthenticating)
			{
				if (Settings.LoadedFromFile)
				{
					Console.WriteLine("Authorization data file exists, loading data.");
					Console.WriteLine();
					Console.WriteLine("Obtaining refresh token.");
					if (Settings.MainSettings.InternetAccessAvailable)
					{
						GetRefreshToken(Settings.AuthorisationData.RefreshToken);
						while (Settings.AuthorisationData.RefreshToken == null)
						{
							Task.Delay(50).Wait();
						}
					}
					else
					{
						Console.WriteLine("No internet access available.  Attempting to load from any files present.");
					}
				}
				else
				{
					CreateUrl();
					GetCode();
					InitialSSOTokenRequest();
				}
			}
			AuthenticationStepsComplete = true;
			return _client;
		}
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


			List<string> scopesCheck = new List<string>();
			if (Settings.AuthorisationData.Scopes != null)
			{
				scopesCheck.AddRange(Settings.AuthorisationData.Scopes.Split(' '));
			}
			if (scopesCheck.Count > 0)
			{
				// only load the scopes found in the profile
				Scopes = scopesCheck;
			}
			else
			{
				// load all the scopes if nothing found
				Scopes = EvEESITool.Scopes.GetScopes();
			}
			Console.WriteLine($"Scopes file loaded. {Scopes.Count} scopes added.");

			_client = new EsiClient(config);
			Console.WriteLine("Created EsiClient object.");
			Console.WriteLine();
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
			Settings.ProfileName = Settings.AuthorisationData.CharacterName.Replace(" ", "");
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
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{

				if (Settings != null)
				{
					Settings.Dispose();
					Settings = null;
				}
			}
		}
	}
}
