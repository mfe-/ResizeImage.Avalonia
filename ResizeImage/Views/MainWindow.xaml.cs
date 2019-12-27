using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ResizeImage.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContextChanged += MainWindow_DataContextChanged;
        }

        private void MainWindow_DataContextChanged(object sender, System.EventArgs e)
        {
            if (UserContent == null)
            {
                UserContent = this.FindControl<ContentControl>("userContentControl");
                UserContent.Content = new ResizePage();
            }

        }
        public ContentControl UserContent { get; set; }
    }
}
