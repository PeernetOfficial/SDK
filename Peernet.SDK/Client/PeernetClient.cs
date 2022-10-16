using System;
using System.Net.Http;
using Peernet.SDK.Client.Clients;
using Peernet.SDK.Client.Http;

namespace Peernet.SDK.Client
{
    public class PeernetClient
    {
        public PeernetClient(string apiUrl, string apiKey, Action<HttpResponseMessage, string> onRequestFailure = null)
        {
            var httpClientFactory = new HttpClientFactory(apiUrl, apiKey);
            var httpExecutor = new HttpExecutor(httpClientFactory, onRequestFailure);

            Core = new StatusClient(httpExecutor);
            Account = new AccountClient(httpExecutor);
            Blockchain = new BlockchainClient(httpExecutor);
            Download = new DownloadClient(httpExecutor);
            Explore = new ExploreClient(httpExecutor);
            File = new FileClient(httpExecutor);
            Profile = new ProfileClient(httpExecutor);
            Search = new SearchClient(httpExecutor);
            Shutdown = new ShutdownClient(httpExecutor);
            Warehouse = new WarehouseClient(httpExecutor);
        }

        public IAccountClient Account { get; set; }

        public IBlockchainClient Blockchain { get; set; }

        public IStatusClient Core { get; set; }

        public IDownloadClient Download { get; set; }

        public IExploreClient Explore { get; set; }

        public IFileClient File { get; set; }

        public IProfileClient Profile { get; set; }

        public ISearchClient Search { get; set; }

        public IShutdownClient Shutdown { get; set; }

        public IWarehouseClient Warehouse { get; set; }
    }
}