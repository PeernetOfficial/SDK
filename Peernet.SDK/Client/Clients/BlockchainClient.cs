using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Blockchain;
using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Client.Clients
{
    internal class BlockchainClient : ClientBase, IBlockchainClient
    {
        private readonly IHttpExecutor httpExecutor;

        public BlockchainClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => "blockchain";

        public async Task<ApiBlockchainBlockStatus> AddFiles(ApiBlockchainAddFiles files)
        {
            var content = JsonContent.Create(files);
            return await httpExecutor.GetResultAsync<ApiBlockchainBlockStatus>(HttpMethod.Post, GetRelativeRequestPath("file/add"), content: content);
        }

        public async Task<ApiBlockchainBlockStatus> DeleteFile(ApiFile apiFile)
        {
            var content = JsonContent.Create(new ApiBlockchainAddFiles { Files = new List<ApiFile> { apiFile } });
            return await httpExecutor.GetResultAsync<ApiBlockchainBlockStatus>(HttpMethod.Post,
                GetRelativeRequestPath("file/delete"), content: content);
        }

        public async Task<ApiBlockchainBlockStatus> UpdateFile(ApiFile apiFile)
        {
            var content = JsonContent.Create(new ApiBlockchainAddFiles { Files = new List<ApiFile> { apiFile } });
            var result = await httpExecutor.GetResultAsync<ApiBlockchainBlockStatus>(HttpMethod.Post, GetRelativeRequestPath("file/update"), content: content);
            return result;
        }

        public async Task<ApiBlockchainHeader> GetHeader()
        {
            return await httpExecutor.GetResultAsync<ApiBlockchainHeader>(HttpMethod.Get, GetRelativeRequestPath("header"));
        }

        public async Task<ApiBlockchainAddFiles> GetList()
        {
            return await httpExecutor.GetResultAsync<ApiBlockchainAddFiles>(HttpMethod.Get, GetRelativeRequestPath("file/list"));
        }

        public async Task<ApiBlockchainBlock> ReadBlock(int block)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(block)] = block.ToString()
            };

            return await httpExecutor.GetResultAsync<ApiBlockchainBlock>(HttpMethod.Get,
                GetRelativeRequestPath("read"),
                parameters);
        }
    }
}