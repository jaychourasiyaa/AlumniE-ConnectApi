using AlumniE_ConnectApi.Contract.Dtos.ExperienceDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceServices experienceServices;
        public ExperienceController(IExperienceServices experienceServices)
        {
            this.experienceServices = experienceServices;
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<List<GetExperienceDto>>>> Get(Guid id)
        {
            try
            {
                var experiences = await experienceServices.GetExperience(id);
                return Ok(new ApiResponse<List<GetExperienceDto>>(true,"Fetched all experiences",experiences));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> Upsert(AddExperienceDto dto )
        {
            try
            {
                var experienceId = await experienceServices.UpsertExperience(dto);
                if(experienceId == -1)
                {
                    return Conflict(new ApiResponse<int>(true, "If ongoing is true end date must be null", experienceId));
                }
                else if (experienceId == -2)
                {
                    return Conflict(new ApiResponse<int>(true, "if ongoing is false end date cannot be null", experienceId));
                }
                else if (experienceId == -3)
                {
                    return NotFound(new ApiResponse<int>(true, "Blog not found", experienceId));
                }
                else if(experienceId == -4)
                {
                    return Conflict(new ApiResponse<int>(true,"Blog not accessible for updation",experienceId));
                }
                else if( experienceId == 0)
                {
                    return Ok(new ApiResponse<int>(true, "Blog Updated", experienceId));
                }
                return Ok(new ApiResponse<int>(true, "Blog Added", experienceId));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false,ex.Message,0));
            }
        }
    }
}
