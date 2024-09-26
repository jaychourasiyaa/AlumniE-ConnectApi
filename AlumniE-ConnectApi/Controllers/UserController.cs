
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Database;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;
        private readonly IEmailServices emailServices;

        public UserController(IUserServices userServices, IEmailServices emailServices)
        {
            this.userServices = userServices;
            this.emailServices = emailServices;
        }

        [HttpGet]
        public async Task<ActionResult<Admin>?> Get()
        {
            try
            {
                var admin = await userServices.GetUser();
                return admin;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPost("SendOtp/{gmail}/{name}")]
        public async Task<ActionResult<ApiResponse<bool>>> Send(string gmail, string name)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await emailServices.SendEmail(gmail, name);
                response.Message = "OTP Sent Successfully";
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPost("Verify/{gmail}/{otp}")]
        public async Task<ActionResult<ApiResponse<bool>>> Verify(string gmail, string otp)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await emailServices.VerifyOtp(gmail, otp);
                if (!result)
                {
                    response.Message = "OTP is Invalid";
                    return Conflict(response);
                }
                response.Message = "OTP Verified Successfully";
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPost("AddStudent")]
        public async Task<ActionResult<Guid>> AddStudent(AddStudentDto dto)
        {
            try
            {
                var studentId = await userServices.Add_Student(dto);
                return Ok(studentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddFaculty")]
        public async Task<ActionResult<Guid>> AddFaculty(AddFacultyDto dto)
        {
            try
            {
                var studentId = await userServices.Add_Faculty(dto);
                return Ok(studentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddAdmin")]
        public async Task<ActionResult<Guid>> AddAdmin(AddAdminDto dto)
        {
            try
            {
                var studentId = await userServices.Add_Admin(dto);
                return Ok(studentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
