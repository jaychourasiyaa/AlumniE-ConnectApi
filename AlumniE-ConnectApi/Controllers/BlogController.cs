using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
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
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<GetBlogDto>>>> Get()
        {
            var response = new ApiResponse<List<GetBlogDto>>();
            try
            {
                var blogs = await blogServices.GetAllBlogs();
                response.Data = blogs;
                response.Message = "Fetched Blogs";
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
