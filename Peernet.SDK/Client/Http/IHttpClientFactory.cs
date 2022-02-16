using System.Net.Http;

namespace Peernet.SDK.Client.Http
{
    internal interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}