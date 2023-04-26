using System;
using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Download;

namespace Peernet.SDK.Client.Clients
{
    public interface IDownloadClient
    {
        Task<ApiResponseDownloadStatus> Start(string path, byte[] hash, byte[] node);

        Task<ApiResponseDownloadStatus> GetStatus(Guid id);

        Task<ApiResponseDownloadStatus> GetAction(Guid id, DownloadAction action);
    }
}