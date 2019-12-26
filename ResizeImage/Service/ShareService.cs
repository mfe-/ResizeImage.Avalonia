using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Service
{
    public class ShareService : IShareService
    {
        public bool SharingProcess { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task StartShareAsync(IList<ImageFile> imageFiles, Func<Action<ImageFile, string>, Task<bool>> viewModelReiszeImageFunc, Action shareCompleteAction = null)
        {
            throw new NotImplementedException();
        }
    }
}
