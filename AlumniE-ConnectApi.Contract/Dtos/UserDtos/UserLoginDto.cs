using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.UserDtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is a required field")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is a required field")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is a required field")]
        public UserRole Role { get; set; } = UserRole.Student; 
    }
}
