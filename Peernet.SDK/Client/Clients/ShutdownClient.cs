using System.Collections.Generic;
using System.Net.Http;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Shutdown;

namespace Peernet.SDK.Client.Clients
{
    internal class ShutdownClient : ClientBase, IShutdownClient
    {
        private readonly IHttpExecutor httpExecutor;

        public ShutdownClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => "shutdown";

        public ApiShutdownStatus GetAction(ShutdownAction action)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(action)] = ((int)action).ToString()
            };

            return httpExecutor.GetResult<ApiShutdownStatus>(HttpMethod.Get, GetRelativeRequestPath(string.Empty),
                parameters);
        }
    }
}