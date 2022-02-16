﻿using System;
using System.Net.Http;

namespace Peernet.SDK.Client.Http
{
    internal class HttpClientFactory : IHttpClientFactory
    {
        private readonly string apiUrl;
        private readonly string apiKey;

        public HttpClientFactory(string apiUrl, string apiKey)
        {
            this.apiUrl = apiUrl;
            this.apiKey = apiKey;
        }

        public HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            return client;
        }
    }
}