﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Peernet.SDK.Client.Http
{
    internal interface IHttpExecutor
    {
        Task<T> GetResultAsync<T>(
            HttpMethod method,
            string relativePath,
            Dictionary<string, string> queryParameters = null,
            HttpContent content = null,
            bool suppressErrorNotification = false);

        T GetResult<T>(
            HttpMethod method,
            string relativePath,
            Dictionary<string, string> queryParameters = null,
            HttpContent content = null,
            bool suppressErrorNotification = false);
    }
}