using System.Windows;
using System.Windows.Controls;

namespace Peernet.SDK.WPF
{
    public class PeernetWindow : Window
    {
        public static new readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",
                typeof(string),
                typeof(PeernetWindow));

        public new string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        protected void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public override void OnApplyTemplate()
        {
            Button closeButton = GetTemplateChild("closeButton") as Button;
            if (closeButton != null)
            {
                closeButton.Click += Close_OnClick;
            }

            base.OnApplyTemplate();
        }
    }
}
