using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.UploadImageService
{
    public interface IUploadImageService
    {
        Task<string> UploadImage(string folder,string subfolder, string name,IFormFile model);
    }
}