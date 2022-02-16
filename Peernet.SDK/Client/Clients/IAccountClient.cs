using System.Threading.Tasks;

namespace Peernet.SDK.Client.Clients
{
    public interface IAccountClient
    {
        Task Delete(bool confirm);
    }
}