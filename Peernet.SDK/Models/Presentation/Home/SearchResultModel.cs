﻿using Peernet.SDK.Models.Presentation.Footer;
using System.Collections.Generic;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class SearchResultModel
    {
        public string Id { get; set; }
        public string StatusText { get; set; }
        public List<DownloadModel> Rows { get; set; } = new();

        public SearchFilterResultModel Filters { get; set; }

        public IDictionary<FilterType, int> Stats { get; set; }

        public static FilterType[] GetDefaultStats()
        {
            return new[]
            {
                FilterType.All,
                FilterType.Audio,
                FilterType.Video,
                FilterType.Ebooks,
                FilterType.Documents,
                FilterType.Pictures,
                FilterType.Text,
                FilterType.Binary
            };
        }
    }
}