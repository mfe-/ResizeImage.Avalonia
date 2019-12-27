using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ResizeImage.Views
{
    public class ResizePage : UserControl
    {
        public ResizePage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
