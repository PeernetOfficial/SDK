using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Client.Clients
{
    public interface IApiClient
    {
        /// <summary>
        /// Provides current connectivity status to the network
        /// </summary>
        /// <returns></returns>
        Task<ApiResponseStatus> GetStatus();
    }
}