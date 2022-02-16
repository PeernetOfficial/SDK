using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Search;

namespace Peernet.SDK.Client.Clients
{
    public interface IExploreClient
    {
        Task<SearchResult> GetFiles(int limit, int? type = null);
    }
}