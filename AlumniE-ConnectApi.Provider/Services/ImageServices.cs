using AlumniE_ConnectApi.Contract.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class ImageServices
    {
        private readonly Cloudinary _cloudinary;
        public ImageServices(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            try
            {
                var uploadResult = new ImageUploadResult();

                if (file.Length > 0)
                {
                    using var stream = file.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, stream)
                    };

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }

                return uploadResult.Url.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
