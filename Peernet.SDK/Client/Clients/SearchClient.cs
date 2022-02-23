﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Search;

namespace Peernet.SDK.Client.Clients
{
    internal class SearchClient : ClientBase, ISearchClient
    {
        private readonly IHttpExecutor httpExecutor;

        public SearchClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => "search";

        public async Task<SearchResult> GetSearchResult(SearchGetRequest searchGetRequest)
        {
            return await httpExecutor.GetResultAsync<SearchResult>(HttpMethod.Get, GetRelativeRequestPath("result"), GetParams(searchGetRequest));
        }

        public async Task<SearchStatistic> SearchResultStatistics(string id)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(id)] = id
            };
            return await httpExecutor.GetResultAsync<SearchStatistic>(HttpMethod.Get, GetRelativeRequestPath("statistic"), parameters);
        }

        public async Task<SearchRequestResponse> SubmitSearch(SearchRequest searchRequest)
        {
            return await httpExecutor.GetResultAsync<SearchRequestResponse>(HttpMethod.Post, GetRelativeRequestPath(string.Empty), content: JsonContent.Create(searchRequest));
        }

        public async Task<string> TerminateSearch(string id)
        {
            var parameters = new Dictionary<string, string>
            {
                [nameof(id)] = id,
            };

            return await httpExecutor.GetResultAsync<string>(HttpMethod.Get, GetRelativeRequestPath("terminate"), parameters, suppressErrorNotification: true);
        }

        private Dictionary<string, string> GetParams(object obj)
        {
            var res = new Dictionary<string, string>();
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                var val = pi.GetValue(obj, null);
                if (val != null)
                {
                    res.Add(pi.Name.ToLower(), Uri.EscapeDataString(val.ToString()));
                }
            }
            return res;
        }
    }
}