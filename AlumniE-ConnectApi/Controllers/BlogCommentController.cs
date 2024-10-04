using AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<List<GetBlogCommentsDto>>>> Get(Guid id)
        {
            try
            {
                var blogComments = await blogCommentServices.GetBlogComment(id);
                return Ok(new ApiResponse<List<GetBlogCommentsDto>>(true,"Fetched all comments",blogComments));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false,ex.Message,1));
            }
        }
        [HttpPost("blogId/{id:guid}")]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(AddBlogCommmentDto dto , Guid id)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var blogId = await blogCommentServices.AddComment(dto,id);
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
        [HttpPut("blogId/{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Update(UpdateBlogCommentDto dto ,Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await blogCommentServices.UpdateComment(dto,id);
                if( result == -1)
                {
                    response.Message = "Blog not found";
                    return NotFound(response);
                }
                else if (result == -2)
                {
                    response.Message = "Blog Comment is unaccessible to update";
                    return Conflict(response);
                }
                else if ( result == -3)
                {
                    response.Message = "Nothing to update in comment";
                    return NotFound(response);
                }
                response.Message = "Blog comment updated";
                response.Data = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await blogCommentServices.Delete(id);
                if (result == -1)
                {
                    response.Message = "Blog not found";
                    return NotFound(response);
                }
                else if (result == -2)
                {
                    response.Message = "Blog Comment is unaccessible to delete";
                    return Conflict(response);
                }
                response.Message = "Blog comment deleted";
                response.Data = true;
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
