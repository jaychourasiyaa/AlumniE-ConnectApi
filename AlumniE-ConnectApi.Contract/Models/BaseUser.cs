using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class BaseUser
    {
        public required string Name { get; set; }
        public required string Gmail { get; set; }
        public required string Password { get; set; }
        public string? SecondaryMail { get; set; }
        public string? Address { get; set; }
        public string? Bio { get; set; }
        public string? ContactNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid? CollegeId { get; set; }    // CollegeId, CourseId, BranchId is a required feild but making it nullable to 
        [ForeignKey(nameof(CollegeId))]         // handle foreign key constraints , and taking this feild as required in dto
        public College College { get; set; }
        public Guid? CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        public Guid? BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }
        public Guid? CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Region Country { get; set; }
        public Guid? StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public Region State { get; set; }
        public Guid? CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public Region City { get; set; }

    }
}
