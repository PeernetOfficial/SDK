using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Domain.Download;
using Peernet.SDK.Models.Presentation;

namespace Peernet.SDK.Models.Domain.Warehouse
{
    public class ApiResponseUploadStatus
    {
        public string Id { get; set; }

        public APIStatus APIStatus { get; set; }

        public DataTransferStatus UploadStatus { get; set; }

        public Progress Progress { get; set; }

    }
}