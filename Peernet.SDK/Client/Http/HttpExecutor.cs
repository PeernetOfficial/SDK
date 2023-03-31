using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Peernet.SDK.Client.Http
{
    internal class HttpExecutor : IHttpExecutor
    {
        private readonly Lazy<HttpClient> httpClientLazy;
        private readonly object lockObject = new();
        private readonly Action<HttpResponseMessage, string> onError;

        public HttpExecutor(IHttpClientFactory httpClientFactory)
        {
            httpClientLazy = new Lazy<HttpClient>(httpClientFactory.CreateHttpClient);
        }

        public HttpExecutor(IHttpClientFactory httpClientFactory, Action<HttpResponseMessage, string> onError)
        {
            this.onError = onError;
            httpClientLazy = new Lazy<HttpClient>(httpClientFactory.CreateHttpClient);
        }

        public T GetResult<T>(HttpMethod method,
            string relativePath,
            Dictionary<string, string> queryParameters = null,
            HttpContent content = null,
            bool suppressErrorNotification = false)
        {
            var httpRequestMessage = HttpHelper.PrepareMessage(relativePath, method, queryParameters, content);
            var response = httpClientLazy.Value.Send(httpRequestMessage);

            return GetFromResponseMessage<T>(response, suppressErrorNotification);
        }

        public async Task<T> GetResultAsync<T>(
            HttpMethod method,
            string relativePath,
            Dictionary<string, string> queryParameters = null,
            HttpContent content = null,
            bool suppressErrorNotification = false,
            CancellationToken cancellationToken = default)
        {
            var httpRequestMessage = HttpHelper.PrepareMessage(relativePath, method, queryParameters, content);
            var response = await httpClientLazy.Value.SendAsync(httpRequestMessage, cancellationToken);

            return GetFromResponseMessage<T>(response, suppressErrorNotification);
        }

        public async Task<Stream> GetAsync(
            HttpMethod method,
            string relativePath,
            Dictionary<string, string> queryParameters = null,
            HttpContent content = null,
            bool suppressErrorNotification = false)
        {
            var httpRequestMessage = HttpHelper.PrepareMessage(relativePath, method, queryParameters, content);
            var response = await httpClientLazy.Value.SendAsync(httpRequestMessage);

            return GetFromResponseMessage(response, suppressErrorNotification);
        }

        private static T Deserialize<T>(Stream stream)
        {
            using var textReader = new StreamReader(stream);
            using var reader = new JsonTextReader(textReader);
            return new JsonSerializer().Deserialize<T>(reader);
        }

        private T GetFromResponseMessage<T>(HttpResponseMessage response, bool suppressErrorNotification)
        {
            using var stream = GetFromResponseMessage(response, suppressErrorNotification);
            return Deserialize<T>(stream);
        }

        private Stream GetFromResponseMessage(HttpResponseMessage response, bool suppressErrorNotification)
        {
            lock (lockObject)
            {
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent &&
                    response.StatusCode != HttpStatusCode.Created && !response.RequestMessage.RequestUri.ToString().EndsWith("status"))
                {
                    var content = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    var responseBody = string.IsNullOrEmpty(content) ? "(empty response)" : content;
                    var details =
                        $"{response.RequestMessage.Method} {response.RequestMessage.RequestUri} \n" +
                        $"{response.RequestMessage.Content} \n" +
                        $"Result: HTTP {response.StatusCode} \n" +
                        $"{responseBody}";

                    if (!suppressErrorNotification)
                    {
                        onError?.Invoke(response, details);
                    }

                    return default;
                }
            }

            return response.Content.ReadAsStreamAsync().Result;
        }
    }
}