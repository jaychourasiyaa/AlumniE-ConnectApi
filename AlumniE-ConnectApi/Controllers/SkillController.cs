using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Digests;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillServices skillServices;
        public SkillController(ISkillServices skillServices)
        {
            this.skillServices = skillServices;
        }
        //[Authorize]
        [HttpGet("GetAllSkillsInSystem")]
        public async Task<ActionResult<ApiResponse<List<IdAndNameDto>>>> GetAll()
        {
            try
            {
                var skills = await skillServices.GetAllSkills();
                return Ok(new ApiResponse<List<IdAndNameDto>>(true, "Skills Fetched", skills));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }
        //[Authorize]
        [HttpGet("GetAllSkills/{startsWith}")]
        public async Task<ActionResult<ApiResponse<List<Skill>>>> GetAll(string startsWith)
        {
            try
            {
                var skills = await skillServices.GetAllSkillsStartsWith(startsWith);
                return Ok(new ApiResponse<List<IdAndNameDto>>(true, "Skills Fetched", skills));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        //[Authorize]
        [HttpGet("GetAllSkillsOfUser/{id:guid}")]
        public async Task<ActionResult<ApiResponse<List<IdAndNameDto>>>> GetUserSkills(Guid id)
        {
            try
            {
                var skills = await skillServices.GetSkillsOfUser(id);
                return Ok(new ApiResponse<List<IdAndNameDto>>(true, "Skills Fetched", skills));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        //[Authorize]
        [HttpPost("AddExistingSkillsToUser")]
        public async Task<ActionResult<ApiResponse<int>>> AddUserSkills(List<Guid> skills)
        {
            try
            {
                var result = await skillServices.AddSkillsOfUser(skills);
                if (result == -1)
                {
                    return NotFound(new ApiResponse<int>(true, "User Id is Invalid", 0));
                }
                else if (result == -2)
                {
                    return NotFound(new ApiResponse<int>(true, "Skill Id is Invalid", 0));
                }
                else if (result == -3)
                {
                    return Conflict(new ApiResponse<int>(true, "User Skill Already Exists", 0));
                }
                else if (result == -4)
                {
                    return NotFound(new ApiResponse<int>(true, "Invalid Role", 0));
                }
                return Ok(new ApiResponse<int>(true, "User Skills Added", 1));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }

        //[Authorize]
        [HttpPost("AddNewSkillsToUser")]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(List<string> names)
        {
            try
            {
                var skillId = await skillServices.AddSkills(names);
                if(skillId == -1)
                {
                    return NotFound(new ApiResponse<int>(true, "User Id is invalid", 0));
                }
                else if(skillId == -2)
                {
                    return Conflict(new ApiResponse<int>(true, "Skill Already Exists", 0));
                }
                else if (skillId == -3)
                {
                    return NotFound(new ApiResponse<int>(true, "User Role is Invalid", 0));
                }
                return Ok(new ApiResponse<int>(true, "Skill Added", 1));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false,ex.Message, 0));
            }
        }

        //[Authorize]
        [HttpPost("DeleteSkillsofUser")]
        public async Task<ActionResult<int>> Delete(List<Guid> userSkills)
        {
            try
            {

                var result = await skillServices.DeleteSkillsOfUser(userSkills);
                if(result == -1)
                {
                    return NotFound(new ApiResponse<int>(true, "User Skill Not found", 0));
                }
                return Ok(new ApiResponse<int>(true, "User Skill Deleted", 1));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 1));
            }
        }
    }
}
