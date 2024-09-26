using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageServices imageServices;
        public ImageController(ImageServices imageServices)
        {
            this.imageServices = imageServices;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> Add(IFormFile formFile)
        {
            var response = new ApiResponse<string>();
            try
            {
                var imageUrl = await imageServices.UploadImage(formFile);
                if(imageUrl == "")
                {
                    response.Message = "Unable to upload image";
                    response.Data = imageUrl;
                    return Conflict(response);
                }
                response.Message = "Image Uploaded Successfully";
                response.Data = imageUrl;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
