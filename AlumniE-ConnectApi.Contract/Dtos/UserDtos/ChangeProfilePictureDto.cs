using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.UserDtos
{
    public class ChangeProfilePictureDto
    {
        /*[Required(ErrorMessage = "Role is a required field")]
        public UserRole Role { get; set; } = UserRole.Student;
        [Required(ErrorMessage = "Id is a required field")]
        public Guid Id { get; set; }*/
        [Required(ErrorMessage = "Url is a required field")]
        public string Url { get; set; }
    }
}
