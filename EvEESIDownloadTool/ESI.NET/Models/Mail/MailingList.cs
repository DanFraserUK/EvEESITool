using Newtonsoft.Json;

namespace EvEESITool.Models.Mail
{
    public class MailingList
    {
        [JsonProperty("mailing_list_id")]
        public int MailingListId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
