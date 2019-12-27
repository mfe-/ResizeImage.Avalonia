using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ResizeImage.Views
{
    public class AboutPage : UserControl
    {
        public AboutPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
