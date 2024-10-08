using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.ExperienceDtos
{
    public class GetExperienceDto
    {
        public Guid Id { get; set; }
        public string JobTittle { get; set; }
        public EmployeementType EmployeementType { set; get; }
        public LocationType LocationType { set; get; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public bool Ongoing { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
