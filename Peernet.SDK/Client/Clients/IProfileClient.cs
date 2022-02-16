using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Blockchain;
using Peernet.SDK.Models.Domain.Profile;

namespace Peernet.SDK.Client.Clients
{
    public interface IProfileClient
    {
        Task<ApiBlockchainBlockStatus> UpdateUser(string userName, byte[] image);

        Task<ApiBlockchainBlockStatus> DeleteUserImage();

        Task<ApiProfileData> GetProfileData();
    }
}