using Peernet.Browser.Plugins.Template.ViewModels;
using System.Windows;

namespace Peernet.Browser.Plugins.Template
{
    /// <summary>
    /// Interaction logic for SampleGenericWindow.xaml
    /// </summary>
    public partial class SampleGenericWindow : Window
    {
        public SampleGenericWindow(SampleGenericViewModel sampleGenericViewModel)
        {
            InitializeComponent();
            DataContext = sampleGenericViewModel;
        }
    }
}