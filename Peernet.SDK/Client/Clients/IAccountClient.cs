using Peernet.SDK.Models.Domain.Account;
using System.Threading.Tasks;

namespace Peernet.SDK.Client.Clients
{
    public interface IAccountClient
    {
        Task Delete(bool confirm);
        Task<ApiResponsePeerSelf> Info();
    }
}