using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Peernet.SDK.Client.Clients;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Common;

namespace Peernet.SDK.Client.Extensions
{
    public static class IoCProviderExtensions
    {
        public static void RegisterPeernetClients(this ServiceCollection provider, ISettingsManager settings, Action<HttpResponseMessage, string> onRequestFailure = null)
        {            
            provider.AddSingleton<IHttpClientFactory, HttpClientFactory>((sp) => new HttpClientFactory(settings));
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
            provider.AddTransient<IStatusClient, StatusClient>();
            provider.AddTransient<ISocketClient>((sp) => new SocketClient(settings.SocketUrl));
        }
    }
}