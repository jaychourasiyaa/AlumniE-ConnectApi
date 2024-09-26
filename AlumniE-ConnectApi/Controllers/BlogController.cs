using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogServices blogServices;
        public BlogController(IBlogServices blogServices)
        {
            this.blogServices = blogServices;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(AddBlogDto dto)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var blogId = await blogServices.AddBlog(dto);
                response.Data = blogId;
                response.Message = "Posted Blog";
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
