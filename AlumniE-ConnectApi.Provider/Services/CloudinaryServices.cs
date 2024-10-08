using AlumniE_ConnectApi.Contract.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class CloudinaryServices
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryServices(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
       /* public async Task<string> UploadMediaAsync(IFormFile file)
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
        }*/

        public async Task<string> UploadMediaAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    throw new ArgumentException("File is empty.");

                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                var uploadResult = new RawUploadResult();

                using (var stream = file.OpenReadStream())
                {
                    if (IsImage(fileExtension))
                    {
                        // For images
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.FileName, stream)
                        };
                        uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    }
                    else if (IsVideo(fileExtension))
                    {
                        // For videos
                        var uploadParams = new VideoUploadParams
                        {
                            File = new FileDescription(file.FileName, stream)
                        };
                        uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    }
                    else
                    {
                        throw new NotSupportedException("Unsupported file type.");
                    }
                }

                return uploadResult?.SecureUrl.ToString();
            }
            catch (Exception ex)
            {
                // Handle the exception (you can log it here)
                throw new ApplicationException("An error occurred while uploading the media.", ex);
            }
        }
        #region helpers
        // Helper method to check if the file is an image
        private bool IsImage(string extension)
        {
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp";
        }

        // Helper method to check if the file is a video
        private bool IsVideo(string extension)
        {
            return extension == ".mp4" || extension == ".mov" || extension == ".avi" || extension == ".mkv" || extension == ".webm";
        }
        #endregion
    }
}
