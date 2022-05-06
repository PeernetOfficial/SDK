using Peernet.SDK.Models.Domain.Common;
using System.Threading.Tasks;

namespace Peernet.SDK.Models.Plugins
{
    public interface IPlayButtonPlug
    {
        Task Execute(ApiFile file);

        bool IsSupported(ApiFile file);
    }
}