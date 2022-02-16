using System.Net.Http;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Client.Clients
{
    internal class ApiClient : ClientBase, IApiClient
    {
        private readonly IHttpExecutor httpExecutor;

        public ApiClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => string.Empty;

        public async Task<ApiResponseStatus> GetStatus()
        {
            return await httpExecutor.GetResultAsync<ApiResponseStatus>(HttpMethod.Get, GetRelativeRequestPath("status"));
        }
    }
}