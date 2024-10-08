using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthorizationServices authorizationService;
        public AuthorizationController(IAuthorizationServices authorizationServices)
        {
            this.authorizationService = authorizationServices;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login( UserLoginDto dto)
        {
            try
            {
                var loginResponse = await authorizationService.LoginUser(dto);
                return Ok(new ApiResponse<LoginResponseDto>(true,"Logged in Successfully",loginResponse));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
