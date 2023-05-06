using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Search;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Peernet.SDK.Client.Clients
{
    internal class MergeClient : ClientBase, IMergeClient
    {
        private readonly IHttpExecutor httpExecutor;

        public MergeClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => "merge";

        public async Task<SearchResult> GetDirectoryContent(byte[] hash)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(hash)] = Convert.ToHexString(hash)
            };


            return await httpExecutor.GetResultAsync<SearchResult>(HttpMethod.Get, GetRelativeRequestPath("directory"), parameters);
        }
    }
}
