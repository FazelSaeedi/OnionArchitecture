using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file , string path)
        {
             if (file == null) return "";

            var directoryPath = $"{ _webHostEnvironment.WebRootPath }//ProductPictures//{path}";
           
            if (!Directory.Exists(directoryPath))
               Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";

            var filePath = $"{directoryPath}/{fileName}";
            using var outPut = File.Create(filePath);
            file.CopyTo(outPut);

            return $"{path}/{fileName}";
        }
    }
}