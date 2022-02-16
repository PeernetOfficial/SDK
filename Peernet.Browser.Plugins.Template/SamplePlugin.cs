using Microsoft.Extensions.DependencyInjection;
using Peernet.Browser.Plugins.Template.Services;
using Peernet.SDK.Models.Plugins;

namespace Peernet.Browser.Plugins.Template
{
    public class SamplePlugin : IPlugin
    {
        public void Load(ServiceCollection services)
        {
            services.AddSingleton<IPlayButtonPlug, SampleService>();
        }
    }
}