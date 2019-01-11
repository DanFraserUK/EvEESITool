using EvEESITool.Models.Status;
using System.Net.Http;
using System.Threading.Tasks;
using static EvEESITool.EsiRequest;

namespace EvEESITool.Logic
{
    public class StatusLogic
    {
        private readonly HttpClient _client;
        private readonly EsiConfig _config;

        public StatusLogic(HttpClient client, EsiConfig config) { _client = client; _config = config; }

        public async Task<EsiResponse<Status>> Retrieve()
            => await Execute<Status>(_client, _config, RequestSecurity.Public, RequestMethod.GET, "/status/");
    }
}