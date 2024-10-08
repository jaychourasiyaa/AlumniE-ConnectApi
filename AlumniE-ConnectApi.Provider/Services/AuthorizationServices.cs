using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using AlumniE_ConnectApi.Provider.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class AuthorizationServices : IAuthorizationServices
    {
        private readonly dbContext _dbContext;
        private readonly IConfiguration configuration;
        public AuthorizationServices(dbContext _dbContext, IConfiguration configuration)
        {
            this._dbContext = _dbContext;
            this.configuration = configuration;
        }
        public string GenerateToken(Guid id, string name, string role, string gmail)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {

                 new Claim("Name", name),
                 new Claim("Id", id.ToString()),
                 new Claim(ClaimTypes.Role, role),
                 new Claim("Gmail",gmail)

             };


            var token = new JwtSecurityToken(
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(5),
                    signingCredentials: credential
                );

            return tokenHandler.WriteToken(token);
        }
        public async Task<LoginResponseDto> LoginUser(UserLoginDto dto)
        {
            try
            {   // trying to find alumni with given gmail and password
                var user = new UserDetailsDto();
                string token = "";
                bool flag = false;
                if (dto.Role == UserRole.Student)
                {
                    var student = await _dbContext.Students
                        .Where(e => e.Gmail == dto.Email && e.Password == dto.Password)
                        .FirstOrDefaultAsync();
                    if (student == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        token = GenerateToken(student.Id, student.Name, "Student", student.Gmail);
                        user.Id = student.Id;
                        user.Name = student.Name;
                        user.Role = UserRole.Student;
                        user.ImageUrl = student.ImageUrl;
                        user.HeadLine = student.Headline;

                    }
                }
                else if (dto.Role == UserRole.Faculty)
                {
                    var faculty = await _dbContext.Faculties
                        .Where(e => e.Gmail == dto.Email && e.Password == dto.Password)
                        .FirstOrDefaultAsync();
                    if (faculty == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        token = GenerateToken(faculty.Id, faculty.Name, "Faculty", faculty.Gmail);
                        user.Id = faculty.Id;
                        user.Name = faculty.Name;
                        user.Role = UserRole.Faculty;
                        user.ImageUrl = faculty.ImageUrl;
                        user.HeadLine = faculty.Headline;
                    }
                }
                else if (dto.Role == UserRole.Admin)
                {
                    var admin = await _dbContext.Admins
                        .Where(e => e.Gmail == dto.Email && e.Password == dto.Password)
                        .FirstOrDefaultAsync();
                    if (admin == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        user.Id = admin.Id;
                        user.Name = admin.Name;
                        user.Role = UserRole.Admin;
                        user.ImageUrl = admin.ImageUrl;
                        token = GenerateToken(admin.Id, admin.Name, "Admin", admin.Gmail);
                    }
                }
                else
                {
                    throw(new Exception( "Invalid Role"));
                }
                if (flag)
                {
                    throw(new Exception( "Invalid Username and Password"));
                }
                if (token == "")
                {
                    throw (new Exception( "Unable to generate Token"));
                }
                // sending token along with some details
                var loginResponseDto = new LoginResponseDto
                {
                    User = user,
                    Token = token,
                };
                return loginResponseDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
