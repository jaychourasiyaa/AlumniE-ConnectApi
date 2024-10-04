
using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        /*[Authorize]*/
        [HttpGet("GetLoginUserInfo")]
        public async Task<ActionResult<ApiResponse<UserDetailsDto>>> GetLoginUser()
        {
            try
            {
                var info = await userServices.GetLoginUserInfo();
                return Ok(new ApiResponse<UserDetailsDto>(true, "User Info fetched", info));
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiResponse<int>(false, ex.Message, 0));
            }
        }
        //[Authorize]
        [HttpGet("GetStudentDetails/{id:guid}")]
        public async Task<ActionResult<ApiResponse<GetStudentDto>>> GetStudent(Guid id)
        {
            var response = new ApiResponse<GetStudentDto>();
            try
            {
                var student = await userServices.GetStudentDetails(id);
                if (student == null)
                {
                    response.Message = "No student found check student id";
                    return NotFound(response);
                }
                response.Message = "Student Fetched";
                response.Data = student;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return Ok(response);
            }
        }

        //[Authorize]
        [HttpGet("GetFacultyDetails/{id:guid}")]
        public async Task<ActionResult<ApiResponse<GetFacultyDto>>> GetFaculty(Guid id)
        {
            var response = new ApiResponse<GetFacultyDto>();
            try
            {
                var faculty = await userServices.GetFacultyDetails(id);
                if (faculty == null)
                {
                    response.Message = "No Faculty found check faculty id";
                    return NotFound(response);
                }
                response.Message = "Faculty Fetched";
                response.Data = faculty;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
        [HttpGet("GetAllAdmin")]
        public async Task<ActionResult<ApiResponse<List<IdAndNameDto>>>> GetAdmin()
        {
            var response = new ApiResponse<List<IdAndNameDto>>();
            try
            {
                var admin = await userServices.GetAllAdmin();
                if (admin == null)
                {
                    response.Message = "No Admin Found";
                    return NotFound(response);
                }
                response.Message = "Admins Fetched";
                response.Data = admin;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
        [HttpPost("SendOtp/{gmail}/{name}")]
        public async Task<ActionResult<ApiResponse<bool>>> Send(string gmail, string name , bool forgetPassword)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await emailServices.SendEmail(gmail, name , forgetPassword);
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

        //[Authorize(Roles = "Admin")]
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

        //[Authorize(Roles = "SuperAdmin")]
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

        //[Authorize]
        [HttpPut("UpdateUserDetails")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateUser(UpdateUserDto dto)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await userServices.UpdateUser(dto);
                if(result == -1)
                {
                    response.Message = "No user found";
                    response.Data = false;
                    return NotFound(response);
                }
                /*else if( result == -2)
                {
                    response.Message = "User not accessible to update";
                    response.Data = false;
                    return Conflict(response);
                }*/
                else if( result == -3)
                {
                    response.Message = "No Changes to update";
                    response.Data = false;
                    return NotFound(response);
                }
                else if( result == -4)
                {
                    response.Message = "Invalid Role";
                    response.Data = false;
                    return NotFound(response);
                }
                response.Message = "Details Updated";
                response.Data = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
        //[Authorize]
        [HttpPut("ChangePassword")]
        public async Task<ActionResult<ApiResponse<bool>>> ChangePassword(ChangePasswordDto dto)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await userServices.ChangeUserPassword(dto);
                if (result == -1)
                {
                    response.Message = "user not found";
                    response.Data = false;
                    return NotFound(response);
                }
                /*else if (result == -2)
                {
                    response.Message = "not accessible to change password";
                    response.Data = false;
                    return Conflict(response);
                }*/
                else if (result == -3)
                {
                    response.Message = "Old Password is wrong";
                    response.Data = false;
                    return Conflict(response);
                }
                else if (result == -4)
                {
                    response.Message = "Old Password and new Password cannot be same";
                    response.Data = false;
                    return Conflict(response);
                }
                else if (result == -5)
                {
                    response.Message = "Invalid Role";
                    response.Data = false;
                    return NotFound(response);
                }
                response.Message = "Password Updated";
                response.Data = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
        //[Authorize]
        [HttpPut("ChangeProfilePicture")]
        public async Task<ActionResult<ApiResponse<bool>>> ChangeProfilePicture(ChangeProfilePictureDto dto)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await userServices.ChangeUserProfilePicture(dto);
                if (result == -1)
                {
                    response.Message = "user not found";
                    response.Data = false;
                    return NotFound(response);
                }
               /* else if (result == -2)
                {
                    response.Message = "Not accessible to change profile picture";
                    response.Data = false;
                    return Conflict(response);
                }*/
                else if (result == -3)
                {
                    response.Message = "Invalid Role";
                    response.Data = false;
                    return NotFound(response);
                }
                response.Message = "Profile Picture Updated";
                response.Data = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
        [HttpDelete("DeleteStudent/{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteStudent(Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await userServices.Delete_Student(id);
                if( result == -1)
                {
                    return NotFound(new ApiResponse<int>(true, "Student Id is invalid", 0));
                }
                else if( result == -2)
                {
                    return Conflict(new ApiResponse<int>(true, "Student is inaccessible to delete",0));

                }
                return Ok(new ApiResponse<int>(true, "Student Account Deactive / Deleted Successfully",1));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
        [HttpDelete("DeleteFaculty/{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteFaculty(Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await userServices.Delete_Faculty(id);
                if (result == -1)
                {
                    return NotFound(new ApiResponse<int>(true, "Faculty Id is invalid", 0));
                }
                else if (result == -2)
                {
                    return Conflict(new ApiResponse<int>(true, "Faculty is inaccessible to delete", 0));

                }
                return Ok(new ApiResponse<int>(true, "Faculty Account Deactive / Deleted Successfully", 1));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
    }

}
