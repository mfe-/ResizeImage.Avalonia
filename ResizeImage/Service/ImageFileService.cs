using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
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

        public Task<ImageFile> FileToImageFileConverter(object path)
        {
            return FileToImageFile(path.ToString(), true);
        }

        public Task<IList<ImageFile>> GetFilesFromFolderAsync(string folderPath)
        {
            throw new System.NotImplementedException();
        }

        public Task<ImageFile> LoadImageFileAsync(string filepath)
        {
            return FileToImageFile(filepath, true);
        }

        public async Task<IReadOnlyList<ImageFile>> PickMultipleFilesAsync()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            foreach (string filetypeextension in FileTypeFilter)
                openFileDialog.Filters.Add(new FileDialogFilter()
                {
                    Name = filetypeextension,
                    Extensions = new List<string>() { filetypeextension.Replace(".", "") }
                });

            openFileDialog.AllowMultiple = true;

            var files = await openFileDialog.ShowAsync(((App)Application.Current).Window);
            List<ImageFile> imageFiles = new List<ImageFile>();
            foreach (string path in files)
            {
                try
                {
                    imageFiles.Add(await FileToImageFile(path, false));
                }
                catch (Exception e)
                {
                    _loggerService.LogException(nameof(PickMultipleFilesAsync), e);
                }
            }
            return imageFiles;
        }
        public static async Task<ImageFile> FileToImageFile(string path, bool readStream = true)
        {
            Stream ImageStream = null;
            if (readStream)
            {
                var ms = new MemoryStream();
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    await fs.CopyToAsync(ms);
                }
                ImageStream = ms;
            }
            int width = 0;
            int height = 0;
            using (var bitmap = new Bitmap(System.Drawing.Image.FromFile(path)))
            {
                width = bitmap.Width;
                height = bitmap.Height;
            }
            FileInfo fileInfo = new FileInfo(path);

            ImageFile imageFile = new ImageFile(fileInfo.FullName, ImageStream, width, height, fileInfo);
            imageFile.Tag = null;
            //imageFile.IsReadOnly = ;
            return imageFile;
        }

        public async Task<ImageFile> PickSaveFileAsync(string preferredSaveLocation, string SuggestedFileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            foreach (string filetypeextension in FileTypeFilter)
                saveFileDialog.Filters.Add(new FileDialogFilter()
                {
                    Name = filetypeextension,
                    Extensions = new List<string>() { filetypeextension.Replace(".", "") }
                });

            var File = await saveFileDialog.ShowAsync(((App)Application.Current).Window);

            if (File != null)
            {
                return await FileToImageFileConverter(File);
            }
            return null;
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
