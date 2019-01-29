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
					Scopes = null;
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

			string stupidlyLongString = "esi-calendar.respond_calendar_events.v1 esi-calendar.read_calendar_events.v1 esi-location.read_location.v1 esi-location.read_ship_type.v1 esi-mail.organize_mail.v1 esi-mail.read_mail.v1 esi-mail.send_mail.v1 esi-skills.read_skills.v1 esi-skills.read_skillqueue.v1 esi-wallet.read_character_wallet.v1 esi-wallet.read_corporation_wallet.v1 esi-search.search_structures.v1 esi-clones.read_clones.v1 esi-characters.read_contacts.v1 esi-universe.read_structures.v1 esi-bookmarks.read_character_bookmarks.v1 esi-killmails.read_killmails.v1 esi-corporations.read_corporation_membership.v1 esi-assets.read_assets.v1 esi-planets.manage_planets.v1 esi-fleets.read_fleet.v1 esi-fleets.write_fleet.v1 esi-ui.open_window.v1 esi-ui.write_waypoint.v1 esi-characters.write_contacts.v1 esi-fittings.read_fittings.v1 esi-fittings.write_fittings.v1 esi-markets.structure_markets.v1 esi-corporations.read_structures.v1 esi-corporations.write_structures.v1 esi-characters.read_loyalty.v1 esi-characters.read_opportunities.v1 esi-characters.read_chat_channels.v1 esi-characters.read_medals.v1 esi-characters.read_standings.v1 esi-characters.read_agents_research.v1 esi-industry.read_character_jobs.v1 esi-markets.read_character_orders.v1 esi-characters.read_blueprints.v1 esi-characters.read_corporation_roles.v1 esi-location.read_online.v1 esi-contracts.read_character_contracts.v1 esi-clones.read_implants.v1 esi-characters.read_fatigue.v1 esi-killmails.read_corporation_killmails.v1 esi-corporations.track_members.v1 esi-wallet.read_corporation_wallets.v1 esi-characters.read_notifications.v1 esi-corporations.read_divisions.v1 esi-corporations.read_contacts.v1 esi-assets.read_corporation_assets.v1 esi-corporations.read_titles.v1 esi-corporations.read_blueprints.v1 esi-bookmarks.read_corporation_bookmarks.v1 esi-contracts.read_corporation_contracts.v1 esi-corporations.read_standings.v1 esi-corporations.read_starbases.v1 esi-industry.read_corporation_jobs.v1 esi-markets.read_corporation_orders.v1 esi-corporations.read_container_logs.v1 esi-industry.read_character_mining.v1 esi-industry.read_corporation_mining.v1 esi-planets.read_customs_offices.v1 esi-corporations.read_facilities.v1 esi-corporations.read_medals.v1 esi-characters.read_titles.v1 esi-alliances.read_contacts.v1 esi-characters.read_fw_stats.v1 esi-corporations.read_fw_stats.v1 esi-characterstats.read.v1";
			Scopes.AddRange(stupidlyLongString.Split(' '));
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
