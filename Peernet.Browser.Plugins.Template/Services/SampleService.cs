using Peernet.Browser.Plugins.Template.ViewModels;
using Peernet.SDK.Common;
using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Plugins;
using System.Threading.Tasks;

namespace Peernet.Browser.Plugins.Template.Services
{
    public class SampleService : IPlayButtonPlug
    {
        private readonly ISettingsManager settingsManager;

        public SampleService(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;
        }

        // Open Window on Execute
        public async Task Execute(ApiFile file)
        {
            var sampleGenericViewModel = new SampleGenericViewModel();
            await sampleGenericViewModel.Prepare(file);
            new SampleGenericWindow(sampleGenericViewModel).Show();

            var sampleViewModel = new SampleViewModel();
            new SampleWindow(sampleViewModel).Show();
        }

        public bool IsSupported(ApiFile file)
        {
            if (file != null)
            {
                return true;
            }

            return false;
        }
    }
}