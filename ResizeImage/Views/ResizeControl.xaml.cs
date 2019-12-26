using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ResizeImage.Views
{
    public class ResizeControl : UserControl
    {
        public ResizeControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
