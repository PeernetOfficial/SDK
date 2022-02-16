using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Presentation;
using System.Threading.Tasks;

namespace Peernet.Browser.Plugins.Template.ViewModels
{
    public class SampleGenericViewModel : GenericViewModelBase<ApiFile>
    {
        public ApiFile File { get; set; }

        public override Task Prepare(ApiFile parameter)
        {
            File = parameter;

            return Task.CompletedTask;
        }
    }
}