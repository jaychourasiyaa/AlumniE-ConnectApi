using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.CollegeCourseDtos;
using AlumniE_ConnectApi.Contract.Dtos.CollegeDto;
using AlumniE_ConnectApi.Contract.Dtos.CollegeDtos;
using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeServices collegeServices;
        public CollegeController(ICollegeServices collegeServices)
        {
            this.collegeServices = collegeServices;
        }
        [HttpGet("GetAllCollegeByAdminId/{adminId:guid}")]
        public async Task<ActionResult<ApiResponse<List<GetCollegeDto>>>> Get(Guid adminId)
        {
            var response = new ApiResponse<List<GetCollegeDto>>();
            try
            {
                var colleges = await collegeServices.GetCollegeByAdminId(adminId);
                response.Data = colleges;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("GetCollegeCourse/{collegeId:guid}")]
        public async Task<ActionResult<ApiResponse<List<GetCollegeCourseDto>>>> GetCourses(Guid collegeId)
        {
            var response = new ApiResponse<List<GetCollegeCourseDto>>();
            try
            {
                var courses = await collegeServices.GetCoursesByCollege(collegeId);
                response.Message = "Fetched all courses";
                response.Data = courses;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("GetCollegeByDomain/{domain}")]
        public async Task<ActionResult<ApiResponse<IdAndNameDto>>> GetCollegeByDomain(string domain)
        {
            var response = new ApiResponse<IdAndNameDto>();
            try
            {
                var college = await collegeServices.GetCollegeNameAndIdByDomain(domain);
                if (college == null)
                {
                    response.Message = "No college found with given college domain";
                    return NotFound(response);
                }
                response.Message = "College Info Fetcehd with given domain";
                response.Data = college;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("GetBranchesUnderCollegeCourse/{collegeCourseId:Guid}")]
        public async Task<ActionResult<ApiResponse<List<IdAndNameDto>>>> GetCollegeCourseBranches(Guid collegeCourseId)
        {
            var response = new ApiResponse<List<IdAndNameDto>>();
            try
            {
                var branches = await collegeServices.GetBranchesUnderCollegeCourse(collegeCourseId);
                if (branches == null)
                {
                    response.Message = "No branches found with given collegeCourseId";
                    return NotFound(response);
                }
                response.Message = "All Branches Info Fetcehd with given collegeCourseId";
                response.Data = branches;
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
        public async Task<ActionResult<ApiResponse<Guid>>> Add(AddCollegeDto dto)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var collegeId = await collegeServices.AddCollege(dto);
                response.Data = collegeId;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        
        [HttpPost("AddCourse/{courseId:guid}/{collegeId:guid}")]
        public async Task<ActionResult<ApiResponse<Guid>>> AddCourse(Guid courseId, Guid collegeId)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var result = await collegeServices.AddProvidedCourse(courseId, collegeId);
                response.Data = result;
                response.Message = "Course Added Successfully in College";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost("AddBranch/{collegeCourseId:guid}/{branchId:guid}")]
        public async Task<ActionResult<ApiResponse<Guid>>> AddBranch(Guid collegeCourseId, Guid branchId)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var result = await collegeServices.AddProvidedBranch(collegeCourseId, branchId);
                response.Data = result;
                response.Message = "Branch Added Successfully in Course Under College";
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
