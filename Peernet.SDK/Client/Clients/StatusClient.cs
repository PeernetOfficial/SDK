using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Domain.Status;

namespace Peernet.SDK.Client.Clients
{
    internal class StatusClient : ClientBase, IStatusClient
    {
        private readonly IHttpExecutor httpExecutor;

        public StatusClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => string.Empty;

        public async Task<ApiResponseStatus> Get()
        {
            return await httpExecutor.GetResultAsync<ApiResponseStatus>(HttpMethod.Get, GetRelativeRequestPath("status"));
        }

        public async Task<List<PeerStatus>> GetPeers()
        {
            return await httpExecutor.GetResultAsync<List<PeerStatus>>(HttpMethod.Get, GetRelativeRequestPath("status/peers"));
        }
    }
}