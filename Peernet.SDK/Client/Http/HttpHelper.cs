using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

namespace Peernet.SDK.Client.Http
{
    public class HttpHelper
    {
        public static HttpRequestMessage PrepareMessage(string relativePath, HttpMethod method, Dictionary<string, string> queryParameters, HttpContent content)
        {
            var requestPath = relativePath;

            if (queryParameters != null)
            {
                requestPath += "?" + GetQueryString(queryParameters);
            }

            var httpRequestMessage = new HttpRequestMessage(method, requestPath);

            if (content != null)
            {
                httpRequestMessage.Content = content;
            }

            return httpRequestMessage;
        }

        private static string GetQueryString(Dictionary<string, string> queryParameters)
        {
            string queryString = null;
            foreach (var param in queryParameters)
            {
                if (queryString != null)
                {
                    queryString += "&";
                }

                queryString += $"{param.Key}={HttpUtility.UrlEncode(param.Value)}";
            }

            return queryString;
        }
    }
}