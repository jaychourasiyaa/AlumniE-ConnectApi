using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.JobDtos
{
    public class AddJobDto
    {
        [Required(ErrorMessage = "Job Tittle is a required field")]
        public string Tittle { get; set; }
        [Required(ErrorMessage = "Job Description is a required field")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Company Name is a required field")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "JobType is a required field")]
        public JobType JobType { get; set; }
        [Required(ErrorMessage = "LocationType is a required field")]
        public LocationType LocationType { get; set; }
        [Required(ErrorMessage = "Location is a required field")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Deadline is a required field")]
        public DateTime Deadline { get; set; }

    }
}
