using AlumniE_ConnectApi.Contract.Dtos.RegionDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionServices regionServices;
        public RegionController(IRegionServices regionServices)
        {
            this.regionServices = regionServices;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<List<GetRegionDto>>>> Get(RegionIdDto dto)
        {
            var response = new ApiResponse<List<GetRegionDto>>();

            try
            {
                var regions = await regionServices.GetRegionsByParentId(dto.Id);
                if (regions.Count == 0)
                {
                    response.Message = "No Regions Found";
                    response.Data = regions;
                    return NotFound(response);
                }
                response.Message = "Fetched all regions under given parent id";
                response.Data = regions;
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
