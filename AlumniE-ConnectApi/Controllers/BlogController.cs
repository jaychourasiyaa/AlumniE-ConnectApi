using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogServices blogServices;
        public BlogController(IBlogServices blogServices)
        {
            this.blogServices = blogServices;
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
        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<ApiResponse<GetBlogDto>>> GetById(Guid Id)
        {
            var response = new ApiResponse<GetBlogDto>();
            try
            {
                var blog = await blogServices.GetBlogById(Id);
                if (blog == null)
                {
                    response.Message = "Blog not found";
                    return NotFound(response);
                }
                response.Data = blog;
                response.Message = "Blog Fetched";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> Add([FromForm] AddBlogDto dto)
        {
            try
            {
                var blogId = await blogServices.AddBlog(dto);
                if( blogId == "-1")
                {
                    return Conflict(new ApiResponse<int>(true,"Not Every field can be null",0));
                }
                else if(blogId == "-2")
                {
                    return NotFound(new ApiResponse<int>(true, "Tag Id is invalid",0));
                }
                return Ok(new ApiResponse<string>(true, "BlogPosted", blogId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        /*[Produces("application/json")]
        [Consumes("multipart/form-data")]
        [HttpPost("addBlog")]
        public async Task<ActionResult<ApiResponse<string>>> AddBlog([FromForm] AddBlogDto dto)

        {
            try
            {
                
                var blogId = await blogServices.AddBlog(dto);
                if (blogId == "-1")
                {
                    return Conflict(new ApiResponse<int>(true, "Not Every field can be null", 0));
                }
                else if (blogId == "-2")
                {
                    return NotFound(new ApiResponse<int>(true, "Tag Id is invalid", 0));
                }
                return Ok(new ApiResponse<string>(true, "BlogPosted", blogId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }*/
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(UpdateBlogDto dto, Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await blogServices.UpdateBlog(dto, id);
                if (result == -1)
                {
                    response.Message = "Blog Not Found";
                    return NotFound(response);
                }
                else if (result == -2)
                {
                    response.Message = "Blog is unaccessible for updation";
                    return Conflict(response);
                }
                else if (result == -3)
                {
                    return NotFound(new ApiResponse<int>(true, "RemoveTags Id is invalid", 0));
                }
                else if (result == -4)
                {
                    return NotFound(new ApiResponse<int>(true, "AddTags Id is invalid", 0));
                }
                else if (result == -5)
                {
                    return NotFound(new ApiResponse<int>(true, "Nothing to updated", 0));
                }
                response.Message = "Updated Blog Successfully";
                response.Data = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                {
                    response.Success = false;
                    response.Message = ex.Message;
                    return BadRequest(response);
                }
            }
        }

        [HttpDelete("{Id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid Id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await blogServices.DeleteBlog(Id);
                if (result == -1)
                {
                    response.Message = "Blog Not found";
                    return NotFound(response);
                }
                else if (result == -2)
                {
                    response.Message = "Blog is not accessible for deletion";
                    return NotFound(response);
                }
                response.Message = "Blog Deleted";
                response.Data = true;
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
