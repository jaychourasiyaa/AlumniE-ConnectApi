using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        public string GenerateToken(Guid id, string name, string role,string gmail)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                 //new Claim(ClaimTypes.Role, employee.Role.ToString()),
                 new Claim("Name", name),
                 new Claim("Id", id.ToString()),
                 new Claim("Role" , role),
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
        public async Task<string> LoginUser(string gmail, string password, string role)
        {
            try
            {   // trying to find alumni with given gmail and password
                string token = "";
                bool flag = false;
                if (role == "Student")
                {
                    var student = await _dbContext.Students
                                                  .Where(e => e.Gmail == gmail && e.Password == password)
                                                  .FirstOrDefaultAsync();
                    if (student == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        token = GenerateToken(student.Id, student.Name, "Student",student.Gmail);
                    }
                }
                else if (role == "Faculty")
                {
                    var faculty = await _dbContext.Faculties
                                                  .Where(e => e.Gmail == gmail && e.Password == password)
                                                  .FirstOrDefaultAsync();
                    if (faculty == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        token = GenerateToken(faculty.Id, faculty.Name, "Faculty",faculty.Gmail);
                    }
                }
                else if (role == "Admin")
                {
                    var admin = await _dbContext.Admins
                                                  .Where(e => e.Gmail == gmail && e.Password == password)
                                                  .FirstOrDefaultAsync();
                    if (admin == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        token = GenerateToken(admin.Id, admin.Name, "Admin",admin.Gmail);
                    }
                }
                else
                {
                    return "Invalid Role";
                }
                if (flag)
                {
                    return "Invalid Username and Password";
                }
                if (token == "")
                {
                    return "Unable to generate Token";
                }
                // sending token along with some details
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
