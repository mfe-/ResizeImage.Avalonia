using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResizeImage.Service
{
    public class ResourceService : IResourceService
    {
        public string GetString(string resource)
        {
            return resource;
        }
    }
}
