using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AlumniE_ConnectApi.Contract.Dtos.EventDtos
{
    public class AddEventDto
    {
        [Required(ErrorMessage = "Name is a required feild")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is a required feild")]
        public string? BannerUrl { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "StartDate is a required feild")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "EndDate is a required feild")]
        public DateTime EndDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "StartTime is a required feild")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Registration_Deadline is a required feild")]
        public DateTime Registration_Deadline { get; set; } = DateTime.Now;
        public EventStatus Status { get; set; } = EventStatus.Created;
    }
}
