using AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentController : ControllerBase
    {
        private readonly IBlogCommentServices blogCommentServices;
        public BlogCommentController(IBlogCommentServices blogCommentServices)
        {
            this.blogCommentServices = blogCommentServices;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(AddBlogCommmentDto dto)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var blogId = await blogCommentServices.AddComments(dto);
                response.Message = "Added Comment in Blog";
                response.Data = blogId;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
    }
}
