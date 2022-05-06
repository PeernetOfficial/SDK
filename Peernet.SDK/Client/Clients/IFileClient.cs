using System.IO;
using System.Threading.Tasks;
using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Domain.File;

namespace Peernet.SDK.Client.Clients
{
    public interface IFileClient
    {
        Task<ApiResponseFileFormat> GetFormat(string path);

        Task<Stream> Read(ApiFile file);
    }
}