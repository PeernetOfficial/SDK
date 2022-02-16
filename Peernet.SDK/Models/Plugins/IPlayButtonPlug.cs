using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Models.Plugins
{
    public interface IPlayButtonPlug
    {
        void Execute(ApiFile file);
    }
}