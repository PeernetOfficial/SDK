using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Warehouse;

namespace Peernet.SDK.Client.Clients
{
    public interface IWarehouseClient
    {
        Task<WarehouseResult> Create(Guid id, Stream stream, IProgress<UploadProgress> progress, CancellationToken cancellationToken = default);
        Task<ApiResponseUploadStatus> CreateTrackUploadId(Guid id, CancellationToken cancellationToken = default);
        Task<WarehouseResult> ReadPath(byte[] hash, string path);
    }
}