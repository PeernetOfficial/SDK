using Peernet.Browser.Plugins.Template.ViewModels;
using System.Windows;

namespace Peernet.Browser.Plugins.Template
{
    /// <summary>
    /// Interaction logic for SampleWindow.xaml
    /// </summary>
    public partial class SampleWindow : Window
    {
        public SampleWindow(SampleViewModel sampleViewModel)
        {
            InitializeComponent();
            DataContext = sampleViewModel;
        }
    }
}