using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.UserDtos
{
    public class AddStudentDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name cannot be less than 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+(\s+[a-zA-Z]+)*$", ErrorMessage = "The Name field can only contain alphabetic characters.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Gmail is a required field")]
        [RegularExpression(@"^[\w\.-]+@[A-Za-z0-9\.-]+\.[A-Za-z]{2,}$", ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Gmail { get; set; } = string.Empty;
        [Required(ErrorMessage = "CollegeId is a required field")]
        public Guid CollegeId { get; set; }
        [Required(ErrorMessage = "CourseId is a required field")]
        public Guid CourseId { get; set; }
        [Required(ErrorMessage = "BranchId is a required field")]
        public Guid BranchId { get; set; }
        [Required(ErrorMessage = "AdmissionYear is a required field")]
        public int AdmissionYear { get; set; }
        [Required(ErrorMessage = "PassoutYear is a required field")]
        public int PassoutYear { get; set; }
        [Required(ErrorMessage = "Password is a required field")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "Password must be at least 6 characters long, contain at least one lowercase letter, one uppercase letter, one number, and one special character.")]
        public string Password { get; set; } = string.Empty;
    }
}
