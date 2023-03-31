using System;
using System.IO;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Warehouse;

namespace Peernet.SDK.Client.Clients
{
    public interface IWarehouseClient
    {
        Task<WarehouseResult> Create(Stream stream, IProgress<UploadProgress> progress);

        Task<WarehouseResult> ReadPath(byte[] hash, string path);
    }
}