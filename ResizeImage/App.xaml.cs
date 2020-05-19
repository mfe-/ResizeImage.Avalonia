using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Get.the.solution.Image.Contract;
using Get.the.solution.Image.Manipulation.Contract;
using Get.the.solution.Image.Manipulation.ResizeService;
using Get.the.solution.Image.Manipulation.ServiceBase;
using Get.the.solution.Image.Manipulation.ViewModel;
using ResizeImage.Service;
using ResizeImage.Views;
using System;
using System.Collections.Generic;
using Unity;

namespace ResizeImage
{
    public class App : Application
    {
        private ApplicationService _applicationService;
        private ILoggerService _loggerService;
        private UnityContainer _unityContainer;
        public Window Window { get; set; }
        public IUnityContainer Container => _unityContainer;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
        public override void RegisterServices()
        {
            base.RegisterServices();

            try
            {
                _unityContainer = new UnityContainer();
                _applicationService = new ApplicationService();
                _loggerService = new LoggerService();

                Dictionary<Type, Type> pageDictionary = new Dictionary<Type, Type>()
                {
                     { typeof(AboutPageViewModel),typeof(AboutPage) }
                    ,{ typeof(HelpPageViewModel),typeof(HelpPage) }
                    ,{ typeof(MainPageViewModel),typeof(ResizePage) }
                    ,{ typeof(ResizePageViewModel),typeof(ResizePage) }
                    ,{ typeof(ImageViewPageViewModel),typeof(ResizePage) }
                    ,{ typeof(SettingsPageViewModel),typeof(SettingsPage) }
                };

                _unityContainer.RegisterInstance(_loggerService);
                _unityContainer.RegisterInstance<IApplicationService>(_applicationService);

                NavigationService navigationService = new NavigationService(Container, this, pageDictionary);
                _unityContainer.RegisterInstance<INavigation>(navigationService);

                _unityContainer.RegisterSingleton<IResourceService, ResourceService>();
                _unityContainer.RegisterSingleton<IImageFileService, ImageFileService>();
                _unityContainer.RegisterSingleton<ILocalSettings, LocalSettingsService>();
                _unityContainer.RegisterSingleton<IResizeService, ResizeSerivceSix>();
                _unityContainer.RegisterSingleton<IDragDropService, DragDropService>();
                _unityContainer.RegisterSingleton<IShareService, ShareService>();
                _unityContainer.RegisterSingleton<IPageDialogService, PageDialogService>();
                _unityContainer.RegisterSingleton<IProgressBarDialogService, ProgressBarDialogWindow>();
                _unityContainer.RegisterSingleton<IFileSystemPermissionDialogService, FileSystemPermissionDialogService>();
                TimeSpan timeSpan = TimeSpan.MinValue;
                _unityContainer.RegisterInstance<TimeSpan>(timeSpan);

            }
            catch (Exception e)
            {
                _loggerService?.LogException(nameof(RegisterServices), e);
            }
        }
    }
}
