using Peernet.Browser.Plugins.Template.ViewModels;
using Peernet.SDK.WPF;

namespace Peernet.Browser.Plugins.Template
{
    /// <summary>
    /// Interaction logic for SampleGenericWindow.xaml
    /// </summary>
    public partial class SampleGenericWindow : PeernetWindow
    {
        public SampleGenericWindow(SampleGenericViewModel sampleGenericViewModel)
        {
            InitializeComponent();
            DataContext = sampleGenericViewModel;
        }
    }
}