using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.ExperienceDtos
{
    public class AddExperienceDto
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "JobTittle is a required field")]
        public string JobTittle { get; set; }

        [Required(ErrorMessage ="EmployeementType is a required field")]
        [Range(0,5,ErrorMessage ="EmployeeType Should be within 0-5")]
        public EmployeementType EmployeementType { set; get; }

        [Required(ErrorMessage ="Company Name is a required field")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage ="LocationType is a required field")]
        [Range(0,2,ErrorMessage ="LocationType must be within 0-2")]
        public LocationType LocationType { set; get; }

        [Required(ErrorMessage ="Location is a required field") ]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is a required field")]
        public string Description { get; set; }

        [Required(ErrorMessage = "StartDate is a required field")]
        public DateTime StartDate { get; set; }
        public bool Ongoing { get; set; } = true;
        public DateTime ? EndDate { get; set; }
    }
}
