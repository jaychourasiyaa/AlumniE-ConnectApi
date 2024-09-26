using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Interfaces;
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
        [HttpPost("{name}")]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(string name)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var tagId = await tagServices.AddTag(name);
                response.Message = "Tag Added";
                response.Data = tagId;
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

    }
}
