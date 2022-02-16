using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Blockchain;
using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Client.Clients
{
    public interface IBlockchainClient
    {
        Task<ApiBlockchainHeader> GetHeader();

        Task<ApiBlockchainAddFiles> GetList();

        Task<ApiBlockchainBlockStatus> DeleteFile(ApiFile apiFile);

        Task<ApiBlockchainBlockStatus> AddFiles(ApiBlockchainAddFiles files);

        Task<ApiBlockchainBlock> ReadBlock(int block);

        Task<ApiBlockchainBlockStatus> UpdateFile(ApiFile apiFile);
    }
}