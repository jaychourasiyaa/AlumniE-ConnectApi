using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices courseServices;
        public CourseController(ICourseServices courseServices)
        {
            this.courseServices = courseServices;
        }
        [HttpPost("{collegeId:guid}")]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(Guid collegeId, AddCourseDto dto)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var courseId = await courseServices.AddCourse(dto, collegeId);
                response.Message = "Added Course Successfully";
                response.Data = courseId;
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
        public async Task<ActionResult<ApiResponse<List<GetCourseDto>>>> Get()
        {
            var response = new ApiResponse<List<GetCourseDto>>();
            try
            {
                var courses = await courseServices.GetAllCourses();
                response.Data = courses;
                response.Message = "Fetched all courses";
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
