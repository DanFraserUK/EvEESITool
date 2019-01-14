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
using ESI.NET.Models.Alliance;
using ESI.NET.Models.Mail;

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
            return DownloadData("Headers", Settings.EsiClient.Mail.Headers(labels, lastMailID));
        }
        public LabelCounts Labels { get; private set; } = new LabelCounts();
        public List<MailingList> MailingLists { get; private set; } = new List<MailingList>();
        public Message Retrieve(int mailID)// { get; private set; } = new Message();
        {
            return DownloadData("Mail", Settings.EsiClient.Mail.Retrieve(mailID));
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
            Labels = DownloadData("Labels", Settings.EsiClient.Mail.Labels());
            MailingLists = DownloadData("Mailing lists", Settings.EsiClient.Mail.MailingLists());
        }
        protected override bool ReadInData()
        {
            throw new NotImplementedException();
        }
    }
}
