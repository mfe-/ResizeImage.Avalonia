using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Service
{
    public class ApplicationService : IApplicationService
    {
        public string ActivatedEventArgs => "";

        public string UriDefinitionOpen => "";

        public string UriDefinitionResize => "";

        public void AddToClipboard(string content)
        {
            throw new NotImplementedException();
        }

        public bool CtrlPressed(object param)
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public string GetAppVersion()
        {
            throw new NotImplementedException();
        }

        public string GetCulture()
        {
            throw new NotImplementedException();
        }

        public string GetDeviceFormFactorType()
        {
            throw new NotImplementedException();
        }

        public string GetLocalCacheFolder()
        {
            throw new NotImplementedException();
        }

        public Task LaunchFileAsync(ImageFile imageFile, bool openWith = false)
        {
            throw new NotImplementedException();
        }

        public Task LaunchFileAsync(string protocol, object param)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LaunchUriAsync(string protocol)
        {
            throw new NotImplementedException();
        }

        public void SetActivatedEventArgs(string args)
        {
            throw new NotImplementedException();
        }
    }
}
