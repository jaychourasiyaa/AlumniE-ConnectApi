using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlumniE_ConnectApi.Contract;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Experience
    {
        public Guid Id { get; set; }
        public Guid  UserId { get; set; }
        public string JobTittle { get; set; }
        // employement type section remaining
        // location type remaining
        public string CompanyName { get; set; } 
        public string Location { get; set; } 
        public string Description { get; set; } 
        public DateOnly StartDate { get; set; }
        public bool CurrentlyWorkingInThisJob { get; set; } = true;
        public DateOnly EndDate { get; set; }
    }
}
