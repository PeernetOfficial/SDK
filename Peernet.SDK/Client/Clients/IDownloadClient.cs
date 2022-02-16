using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Download;

namespace Peernet.SDK.Client.Clients
{
    public interface IDownloadClient
    {
        Task<ApiResponseDownloadStatus> Start(string path, byte[] hash, byte[] node);

        Task<ApiResponseDownloadStatus> GetStatus(string id);

        Task<ApiResponseDownloadStatus> GetAction(string id, DownloadAction action);
    }
}