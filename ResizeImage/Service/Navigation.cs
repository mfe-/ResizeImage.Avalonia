using Avalonia.Controls;
using Get.the.solution.Image.Manipulation.Contract;
using ResizeImage.Views;
using System;
using System.Collections.Generic;
using Unity;

namespace ResizeImage.Service
{
    public class NavigationService : INavigation
    {
        protected readonly App _app;
        protected ContentControl _userControl;
        protected Dictionary<Type, Type> _pageDictionary;
        protected IUnityContainer _unityContainer;
        public NavigationService(IUnityContainer unityContainer, App app, Dictionary<Type, Type> pageDictionary)
        {
            _app = app;
            _pageDictionary = pageDictionary;
            _unityContainer = unityContainer;
        }
        public bool Navigate(Type pageToken, object parameter)
        {
            if (_userControl == null)
            {
                _userControl = (_app?.Window as MainWindow)?.UserContent;
            }
            var pageType = _pageDictionary[pageToken];
            var page = _unityContainer.Resolve(pageType) as UserControl;
            //get viewmodel
            object vm = _unityContainer.Resolve(pageToken);

            if (_userControl!=null)
            {
                (_app.Window as MainWindow).UserContent.Content = page;
                (_app.Window as MainWindow).UserContent.DataContext = vm;
            }

            return true;
        }
    }
}
