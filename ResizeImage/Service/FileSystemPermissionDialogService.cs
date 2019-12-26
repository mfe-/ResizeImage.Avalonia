using Get.the.solution.Image.Manipulation.Contract;
using System.Threading.Tasks;

namespace ResizeImage.Service
{
    public class FileSystemPermissionDialogService : IFileSystemPermissionDialogService
    {
        public Task ShowFileSystemAccessDialogAsync()
        {
            //nothing to show
            return Task.FromResult(0);
        }
    }
}
