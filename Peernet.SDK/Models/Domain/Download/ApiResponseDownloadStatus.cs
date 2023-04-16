using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Presentation;
using System;

namespace Peernet.SDK.Models.Domain.Download
{
    public class ApiResponseDownloadStatus
    {
        public Guid Id { get; set; }

        public APIStatus APIStatus { get; set; }

        public DataTransferStatus DownloadStatus { get; set; }

        public ApiFile File { get; set; }

        public Progress Progress { get; set; }

        public Swarm Swarm { get; set; }
    }
}