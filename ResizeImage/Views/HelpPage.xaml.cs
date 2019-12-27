using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ResizeImage.Views
{
    public class HelpPage : UserControl
    {
        public HelpPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
