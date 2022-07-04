using Peernet.Browser.Plugins.Template.ViewModels;
using Peernet.SDK.WPF;

namespace Peernet.Browser.Plugins.Template
{
    /// <summary>
    /// Interaction logic for SampleWindow.xaml
    /// </summary>
    public partial class SampleWindow : PeernetWindow
    {
        public SampleWindow(SampleViewModel sampleViewModel)
        {
            InitializeComponent();
            DataContext = sampleViewModel;
        }
    }
}