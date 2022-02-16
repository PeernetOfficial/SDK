using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Peernet.SDK.Client.Clients;
using Peernet.SDK.Client.Http;

namespace Peernet.SDK.Client.Extensions
{
    public static class IoCProviderExtensions
    {
        public static void RegisterPeernetClients(this ServiceCollection provider, Func<string> apiUrlProvider, string apiKey, Action<HttpResponseMessage, string> onRequestFailure = null)
        {
            provider.AddSingleton<IHttpClientFactory, HttpClientFactory>((sp) => new HttpClientFactory(apiUrlProvider.Invoke(), apiKey));
            provider.AddSingleton<IHttpExecutor, HttpExecutor>((sp) => new HttpExecutor(sp.GetRequiredService<IHttpClientFactory>(), onRequestFailure));
            provider.AddTransient<IDownloadClient, DownloadClient>();
            provider.AddTransient<IFileClient, FileClient>();
            provider.AddTransient<IAccountClient, AccountClient>();
            provider.AddTransient<IBlockchainClient, BlockchainClient>();
            provider.AddTransient<IWarehouseClient, WarehouseClient>();
            provider.AddTransient<IExploreClient, ExploreClient>();
            provider.AddTransient<IProfileClient, ProfileClient>();
            provider.AddTransient<ISearchClient, SearchClient>();
            provider.AddTransient<IShutdownClient, ShutdownClient>();
            provider.AddTransient<IApiClient, ApiClient>();
            provider.AddTransient<ISocketClient, SocketClient>();
        }
    }
}