using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagServices tagServices;
        public TagController(ITagServices tagServices)
        {
            this.tagServices = tagServices;
        }
        [HttpGet("GetAllTags")]
        public async Task<ActionResult<ApiResponse<List<IdAndNameDto>>>> Get()
        {
            var response = new ApiResponse<List<IdAndNameDto>>();
            try
            {
                var tags = await tagServices.GetAllTags();
                response.Message = "Tag Added";
                response.Data = tags;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("GetAllTags/{startsWith}")]
        public async Task<ActionResult<ApiResponse<List<Skill>>>> GetAll(string startsWith)
        {
            try
            {
                var skills = await tagServices.GetAllTagsStartsWith(startsWith);
                return Ok(new ApiResponse<List<IdAndNameDto>>(true, "Tags Fetched", skills));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        [HttpPost("AddNewTagInBlog/{blogId:guid}")]
        public async Task<ActionResult<ApiResponse<int>>> Add(List<string> tags, Guid blogId)
        {
            try
            {
                var tagId = await tagServices.AddTags(tags, blogId);
                if (tagId == -1)
                {
                    return NotFound(new ApiResponse<int>(true, "Blog Id is invalid", 0));
                }
                else if (tagId == -2)
                {
                    return Conflict(new ApiResponse<int>(true, "Tag Already Exists", 0));
                }
                else if (tagId == -3)
                {
                    return NotFound(new ApiResponse<int>(true, "User Role is Invalid", 0));
                }
                return Ok(new ApiResponse<int>(true, "Tag Added", 1));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        [HttpPost("AddExistingTagInBlog/{blogId:guid}")]
        public async Task<ActionResult<ApiResponse<int>>> AddBlogTags(List<Guid> tags, Guid blogId)
        {
            try
            {
                var result = await tagServices.AddTagsToBlog(tags, blogId);
                if (result == -1)
                {
                    return NotFound(new ApiResponse<int>(true, "User Id is Invalid", 0));
                }
                else if (result == -2)
                {
                    return NotFound(new ApiResponse<int>(true, "Tag Id is Invalid", 0));
                }
                else if (result == -3)
                {
                    return Conflict(new ApiResponse<int>(true, "Blog Tag Already Exists", 0));
                }
                else if (result == -4)
                {
                    return NotFound(new ApiResponse<int>(true, "Invalid Role", 0));
                }
                return Ok(new ApiResponse<int>(true, "Blog Tags Added", 1));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        [HttpDelete("DeleteTagFromBlog/{blogId}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteTag(Guid blogId, Guid tagId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await tagServices.DeleteTagFromBlog(blogId, tagId);
                if (result == -1)
                {
                    response.Message = "Blog not found";
                    return NotFound(response);
                }
                else if (result == -2)
                {
                    response.Message = "Blog is unaccessible for updation";
                    return NotFound(response);
                }
                else if (result == -3)
                {
                    response.Message = "Blog Tag not found";
                    return NotFound(response);
                }
                response.Message = "Tag Deleted From Blog";
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
