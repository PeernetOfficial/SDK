﻿using System.Collections.Generic;
using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Extensions;

namespace Peernet.SDK.Models.Domain.Search
{
    public class SearchResult
    {
        /// <summary>
        /// List of files found
        /// </summary>
        public List<ApiFile> Files { get; set; }

        /// <summary>
        /// Status: 0 = Success with results, 1 = No more results available, 2 = Search ID not found, 3 = No results yet available keep trying
        /// </summary>
        public SearchStatusEnum Status { get; set; }

        /// <summary>
        /// Statistics of all results (independent from applied filters), if requested. Only set if files are returned (= if statistics changed). See SearchStatisticData.
        /// </summary>
        public SearchStatisticData Statistic { get; set; }

        public bool IsTerminated => Status == SearchStatusEnum.NoMoreResults || Status == SearchStatusEnum.IdNotFound;

        public bool IsEmpty => Files.IsNullOrEmpty();
    }
}