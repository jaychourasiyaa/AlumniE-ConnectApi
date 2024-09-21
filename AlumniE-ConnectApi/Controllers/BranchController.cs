using AlumniE_ConnectApi.Contract.Dtos.BranchDtos;
using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IBranchServices branchServices { get; set; }
        public BranchController(IBranchServices branchServices)
        {
            this.branchServices = branchServices;
        }
        [HttpPost("{collegeCourseId:guid}/{name}")]
        public async Task<ActionResult<ApiResponse<Guid>>> Add(Guid collegeCourseId, string name)
        {
            var response = new ApiResponse<Guid>();
            try
            {
                var branchId = await branchServices.AddBranch(name, collegeCourseId);
                response.Message = "Branch Added Successfully";
                response.Data = branchId;
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
        public async Task<ActionResult<ApiResponse<List<GetBranchDto>>>> Get()
        {
            var response = new ApiResponse<List<GetBranchDto>>();
            try
            {
                var branches = await branchServices.GetAllBranches();
                response.Data = branches;
                response.Message = "Fetched all branches";
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
