using System.Collections.Generic;
using System.Threading.Tasks;
using Get.the.solution.Image.Contract;
using Get.the.solution.Image.Manipulation.Contract;
using Get.the.solution.Image.Manipulation.ServiceBase;

namespace ResizeImage.Service
{
    public class ImageFileService : ImageFileBaseService, IImageFileService
    {
        public ImageFileService(ILoggerService loggerService) : base(loggerService)
        {
        }

        public Task<ImageFile> FileToImageFileConverter(object storageFile)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ImageFile>> GetFilesFromFolderAsync(string folderPath)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImageFile> LoadImageFileAsync(string filepath)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<ImageFile>> PickMultipleFilesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ImageFile> PickSaveFileAsync(string preferredSaveLocation, string SuggestedFileName)
        {
            throw new System.NotImplementedException();
        }

        public Task WriteBytesAsync(ImageFile file, byte[] buffer)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImageFile> WriteBytesAsync(string folderPath, string suggestedFileName, ImageFile file, byte[] buffer)
        {
            throw new System.NotImplementedException();
        }
    }
}
