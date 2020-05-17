using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Get.the.solution.Image.Manipulation.Contract;
using Get.the.solution.Image.Manipulation.ViewModel;
using ResizeImage.Service;
using Unity;

namespace ResizeImage.Views
{
    public class MainWindow : Window
    {
        public MainWindow(IUnityContainer unityContainer)
        {
            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
            UnityContainer = unityContainer;
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            if (UserContent == null)
            {
                SetUserContentControl();
            }
            DataContextChanged += MainWindow_DataContextChanged;
        }

        public void SetUserContentControl()
        {
            UserContent = this.FindControl<ContentControl>("userContentControl");
        }

        private void MainWindow_DataContextChanged(object sender, System.EventArgs e)
        {
            if(DataContext is MainPageViewModel mv)
            {
                mv.NavigateToCommand.Execute(mv.SelectedMenuItem);
                DataContextChanged -= MainWindow_DataContextChanged;
            }
        }

        public ContentControl UserContent { get; set; }
        public IUnityContainer UnityContainer { get; }
    }
}
