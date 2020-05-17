using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using Get.the.solution.Image.Manipulation.Contract;
using Get.the.solution.Image.Manipulation.ViewModel;
using ResizeImage.Views;
using Unity;

namespace ResizeImage
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
        private static void AppMain(Application app, string[] args)
        {
            App app1 = (App)app;
            var vm = app1.Container.Resolve<MainPageViewModel>();
            app1.Window = new MainWindow(app1.Container);
            app1.Window.DataContext = vm;
            app1.Run(app1.Window);

        }
    }
}
