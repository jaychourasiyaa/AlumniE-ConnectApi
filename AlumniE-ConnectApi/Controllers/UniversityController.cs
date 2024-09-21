using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityServices universityServices;
        public UniversityController(IUniversityServices universityServices)
        {
            this.universityServices = universityServices;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(string name)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var universityId = await universityServices.AddUniversity(name);
                response.Message = "Added University";
                response.Data = universityId;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(ex);
            }
        }
    }
}
