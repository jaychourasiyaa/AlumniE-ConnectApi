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

        [HttpPost("Add/{name}")]
        public async Task<ActionResult<ApiResponse<int>>> Add(string name)
        {
            try
            {
                var tagId = await tagServices.AddTag(name);
                if(tagId == "-1")
                {
                    return Conflict(new ApiResponse<int>(true,"Tag Already Exists",0));
                }
                return Ok(new ApiResponse<int>(true, "Tag Added", 1));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        

    }
}
