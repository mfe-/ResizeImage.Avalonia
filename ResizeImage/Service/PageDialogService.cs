using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Service
{
    public class PageDialogService : IPageDialogService
    {
        public Task ShowAsync(string content)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ShowConfirmationAsync(string content, string yesButton, string noButton)
        {
            throw new NotImplementedException();
        }
    }
}
