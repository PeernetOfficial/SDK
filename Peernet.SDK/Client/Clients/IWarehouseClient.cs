using System.IO;
using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Warehouse;

namespace Peernet.SDK.Client.Clients
{
    public interface IWarehouseClient
    {
        Task<WarehouseResult> Create(Stream stream);

        Task<WarehouseResult> ReadPath(byte[] hash, string path);
    }
}