using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        /*[Required(ErrorMessage ="Id is a required field")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Role is a required field")]
        public UserRole Role { get;set; } = UserRole.Student;*/
        [RegularExpression(@"^[a-zA-Z]+(\s+[a-zA-Z]+)*$", ErrorMessage = "The Name field can only contain alphabetic characters.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name cannot be less than 2 characters")]
        public string? Name { get; set; }
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Address cannot be less than 10 characters")]
        public string? Address { get; set; }
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Bio cannot be more than 200 characters")]
        public string? Bio { get;set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ProfileHeadline cannot be more than 100 characters")]
        public string? ProfileHeadline { get; set; }
        public Guid? StatedId { get; set; }
        public Guid? CityId { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The Name field can only contain alphabetic characters.")]
        [StringLength( 10, MinimumLength = 10, ErrorMessage = "Contact number must be 10 Digits")]
        public string? ContactNumber { get; set; }
       
    }
}
