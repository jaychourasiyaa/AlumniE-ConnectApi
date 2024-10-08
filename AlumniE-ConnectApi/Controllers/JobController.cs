using AlumniE_ConnectApi.Contract.Dtos.JobDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobServices jobServices;
        public JobController(IJobServices jobServices)
        {
            this.jobServices = jobServices;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> Add(AddJobDto dto)
        {
            try
            {
                var jobId = await jobServices.AddJob(dto);
                return Ok(new ApiResponse<string>(true, "Job Posted", jobId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<GetJobDto>>>> Get()
        {
            try
            {
                var jobs = await jobServices.GetJob();
                return Ok(new ApiResponse<List<GetJobDto>>(true, "Fetched Job", jobs));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }
        
    }
}
