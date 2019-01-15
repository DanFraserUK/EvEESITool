using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
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
using AssetsItem = ESI.NET.Models.Assets.Item;
using ESI.NET.Models.Bookmarks;
using ESI.NET.Models.Calendar;
using ESI.NET.Models.FactionWarfare;
using ESI.NET.Models.Fleets;
using ESI.NET.Models.Killmails;
using ESI.NET.Models.Loyalty;
using ESI.NET.Models.Mail;
using ESI.NET.Models.PlanetaryInteraction;

namespace EvEESITool
{
	public class CorporationWalletData : DataClassesBase
	{
		public List<Wallet> Balance { get; set; } = new List<Wallet>();
		public List<List<JournalEntry>> Journal { get; private set; } = new List<List<JournalEntry>>();
		public List<List<Transaction>> Transactions { get; private set; } = new List<List<Transaction>>();
		public List<Order> MarketOrders { get; private set; } = new List<Order>();
		public List<Order> MarketOrderHistory { get; private set; } = new List<Order>();

		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal CorporationWalletData()
		{
		}
		internal CorporationWalletData(ref ProfileSettings settings) : base(ref settings)
		{
			GetData();
		}

		protected override void Download()
		{
			Balance = DownloadData("Wallet Balance", Settings.EsiClient.Wallet.CorporationWallets());
			for(int i =1;i<=7;i++)
			{
				Journal.Add(DownloadData("Journal", Settings.EsiClient.Wallet.CorporationJournal(i)));
				Transactions.Add(DownloadData("Journal", Settings.EsiClient.Wallet.CorporationTransactions(i)));
			}
			MarketOrders = DownloadData("Market orders", Settings.EsiClient.Market.CorporationOrders());
			MarketOrderHistory = DownloadData("Market order history",Settings.EsiClient.Market.CorporationOrderHistory());
		}
		protected override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
