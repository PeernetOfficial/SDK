using Peernet.SDK.Models.Domain.Shutdown;

namespace Peernet.SDK.Client.Clients
{
    public interface IShutdownClient
    {
        ApiShutdownStatus GetAction(ShutdownAction action);
    }
}