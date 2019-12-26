using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Service
{
    public class ProgressBarDialogService : IProgressBarDialogService
    {
        public string CurrentItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ProcessedItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public IProgressBarDialogService ProgressBarDialogFactory()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(int amountItems)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
