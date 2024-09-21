using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.UserDtos
{
    public class AddAdminDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name cannot be less than 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+(\s+[a-zA-Z]+)*$", ErrorMessage = "The Name field can only contain alphabetic characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Gmail is a required field")]
        [RegularExpression(@"^[\w\.-]+@[A-Za-z0-9\.-]+\.[A-Za-z]{2,}$", ErrorMessage = "The Email field is not a valid e-mail address.")]
        public required string Gmail { get; set; }

        [Required(ErrorMessage = "Password is a required field")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "Password must be at least 6 characters long, contain at least one lowercase letter, one uppercase letter, one number, and one special character.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "MobileNumber is a required field")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile cannot be less than 10 number")]

        [RegularExpression(@"^[1-9]\d{9}$", ErrorMessage = "The mobile number must be exactly 10 digits, and the first digit cannot be 0.")]
        public required string MobileNumber { get; set; }
    }
}
