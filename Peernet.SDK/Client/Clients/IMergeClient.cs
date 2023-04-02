using Peernet.SDK.Models.Domain.Search;
using System.Threading.Tasks;

namespace Peernet.SDK.Client.Clients
{
    public interface IMergeClient
    {
        Task<SearchResult> GetDirectoryContent(byte[] hash);
    }
}