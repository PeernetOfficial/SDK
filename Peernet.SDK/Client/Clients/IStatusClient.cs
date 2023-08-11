using System.Collections.Generic;
using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Domain.Status;

namespace Peernet.SDK.Client.Clients
{
    public interface IStatusClient
    {
        /// <summary>
        /// Provides current connectivity status to the network
        /// </summary>
        /// <returns>nameof()</returns>
        Task<ApiResponseStatus> Get();

        /// <summary>
        /// Provides currently connected Peers data
        /// </summary>
        /// <returns>List<PeerStatus></returns>
        Task<List<PeerStatus>> GetPeers();

        /// <summary>
        /// Provides current backend configuration
        /// </summary>
        /// <returns>List<PeerStatus></returns>
        Task<PeernetConfiguration> GetConfig();
    }
}