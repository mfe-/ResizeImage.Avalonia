using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Service
{
    public class DragDropService : IDragDropService
    {
        public bool IsDragAndDropEnabled => throw new NotImplementedException();

        public void OnDragOverCommand(object param)
        {
            throw new NotImplementedException();
        }

        public Task OnDropCommandAsync(object param, ObservableCollection<ImageFile> ImageFiles)
        {
            throw new NotImplementedException();
        }
    }
}
