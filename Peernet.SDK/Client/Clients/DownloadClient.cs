using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Download;

namespace Peernet.SDK.Client.Clients
{
    internal class DownloadClient : ClientBase, IDownloadClient
    {
        private const string ActionSegment = "action";
        private const string StartSegment = "start";
        private const string StatusSegment = "status";

        private readonly IHttpExecutor httpExecutor;

        public DownloadClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => "download";

        public async Task<ApiResponseDownloadStatus> GetAction(Guid id, DownloadAction action)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(id)] = id.ToString(),
                [nameof(action)] = ((int)action).ToString()
            };

            return await httpExecutor.GetResultAsync<ApiResponseDownloadStatus>(HttpMethod.Get, GetRelativeRequestPath(ActionSegment), parameters);
        }

        public async Task<ApiResponseDownloadStatus> GetStatus(Guid id)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(id)] = id.ToString()
            };

            return await httpExecutor.GetResultAsync<ApiResponseDownloadStatus>(HttpMethod.Get, GetRelativeRequestPath(StatusSegment), parameters);
        }

        public async Task<ApiResponseDownloadStatus> Start(string path, byte[] hash, byte[] node)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(path)] = path,
                [nameof(hash)] = Convert.ToHexString(hash),
                [nameof(node)] = Convert.ToHexString(node)
            };

            return await httpExecutor.GetResultAsync<ApiResponseDownloadStatus>(HttpMethod.Get, GetRelativeRequestPath(StartSegment), parameters);
        }
    }
}