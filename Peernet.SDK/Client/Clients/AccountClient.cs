using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Account;
using Peernet.SDK.Models.Domain.Blockchain;

namespace Peernet.SDK.Client.Clients
{
    internal class AccountClient : ClientBase, IAccountClient
    {
        private readonly IHttpExecutor httpExecutor;

        public AccountClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => "account";

        public async Task<ApiResponsePeerSelf> Info()
        {
            return await httpExecutor.GetResultAsync<ApiResponsePeerSelf>(HttpMethod.Get, GetRelativeRequestPath("info"));
        }

        public async Task Delete(bool confirm)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(confirm)] = confirm ? "1" : "0"
            };

            await httpExecutor.GetResultAsync<ApiBlockchainBlockStatus>(HttpMethod.Get, GetRelativeRequestPath("delete"), parameters);
        }
    }
}