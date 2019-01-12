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
using EvEESITool.Models.Alliance;
using EvEESITool.Models.Mail;

namespace EvEESITool
{
	public class MailData : DataClassesBase
	{
		/// <summary>
		///  last_mail_id can be used to paginate backwards
		/// </summary>
		/// <returns></returns>
		public List<Header> Headers(long[] labels, int lastMailID)// { get; private set; } = new List<Header>();
		{
			return DownloadData<List<Header>>("Headers", Settings.EsiClient.Mail.Headers(labels, lastMailID));
		}
		public LabelCounts Labels { get; private set; } = new LabelCounts();
		public List<MailingList> MailingLists { get; private set; } = new List<MailingList>();
		public Message Retrieve(int mailID)// { get; private set; } = new Message();
		{
			return DownloadData<Message>("Mail", Settings.EsiClient.Mail.Retrieve(mailID));
		}

		/// <summary>
		/// Do not remove this constructor.  Even though it might say 0 references, it does get called by the deserialization in ReadInData()
		/// </summary>
		[JsonConstructor]
		internal MailData() : base()
		{
		}
		internal MailData(ref AppSettings settings) : base(ref settings)
		{
			GetData();
		}
		protected override void Download()
		{
			Labels = DownloadData<LabelCounts>("Labels", Settings.EsiClient.Mail.Labels());
			MailingLists = DownloadData<List<MailingList>>("Mailing lists", Settings.EsiClient.Mail.MailingLists());
		}
		protected override bool ReadInData()
		{
			throw new NotImplementedException();
		}
	}
}
