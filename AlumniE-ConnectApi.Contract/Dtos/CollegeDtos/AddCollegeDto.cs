using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.CollegeDto
{
    public class AddCollegeDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Name cannot be less than 10 characters")]
        [RegularExpression(@"^[a-zA-Z]+(\s+[a-zA-Z]+)*$", ErrorMessage = "The Name field can only contain alphabetic characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Domain is a required field")]
        public string Domain { get; set; }

        [Required(ErrorMessage = "Code is a required field")]
        public string Code { get; set; }

        [Required(ErrorMessage = "StateId is a required field")]
        [RegularExpression(@"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$", ErrorMessage = "Please enter a valid StateId.")]
        public Guid StateId { get; set; }

        [Required(ErrorMessage = "City is a required field")]
        [RegularExpression(@"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$", ErrorMessage = "Please enter a valid CityId.")]
        public Guid CityId { get; set; }

        [Required(ErrorMessage = "Address is a required field")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Establishment is a required field")]
        [RegularExpression(@"^-?\d+$", ErrorMessage = "Please enter a valid Establishment Year.")]
        public int EstablishmentYear { get; set; }

        [Required(ErrorMessage = "CollegeType is a required field")]
        public CollegeType CollegeType { get; set; }

        [Required(ErrorMessage = "ContactNumber is a required field")]
        [MobileNumberValidationAttribute]
        public List<string> ContactNumber { get; set; }

        [Required(ErrorMessage = "Gmail is a required field")]
        public List<string> ContactEmails { get; set; }

        [Required(ErrorMessage = "Authority is a required field")]
        [AlphabeticListValidationAttribute]
        public List<string> AuthorityName { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "The NIRF ranking must contain only digits between 0 and 9.")]
        public int? NIRFRanking { get; set; }

        [Required(ErrorMessage = "Accreditation is a required field")]
        public string Accreditation { get; set; }

        [Required(ErrorMessage = "AdminId is a required field")]
        [RegularExpression(@"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$", ErrorMessage = "Please enter a valid AdminId.")]
        public Guid AdminId { get; set; }

        [RegularExpression(@"^[{(]?[0-9a-fA-F]{8}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{4}[-]?[0-9a-fA-F]{12}[)}]?$", ErrorMessage = "Please enter a valid Affiliated_UniversityId.")]
        public Guid? Affiliated_UniversityId { get; set; }
        public List<string>? Links { get; set; }

    }
}
