using HospitalSystem.Application.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveImageAsync(IFormFile Img, string folderPath)
        {
            if (Img == null || Img.Length == 0)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(Img.FileName);
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath, fileName + extension);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await Img.CopyToAsync(fileStream);
            }

            return Path.Combine(folderPath, fileName + extension);
        }
    }
}
