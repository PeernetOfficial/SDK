using System.Collections;
using Microsoft.Extensions.DependencyInjection;

namespace Peernet.SDK.Models.Plugins
{
    public interface IPlugin
    {
        void Load(ServiceCollection services);
    }
}
