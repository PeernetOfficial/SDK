﻿using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Models.Domain.Download
{
    public class ApiResponseDownloadStatus
    {
        public string Id { get; set; }

        public APIStatus APIStatus { get; set; }

        public DownloadStatus DownloadStatus { get; set; }

        public ApiFile File { get; set; }

        public Progress Progress { get; set; }

        public Swarm Swarm { get; set; }
    }
}