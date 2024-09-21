using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class CollegeCourseBranch
    {
        public Guid Id { get; set; }
        public Guid CollegeCourseId { get; set; }

        [ForeignKey(nameof(CollegeCourseId))]
        public CollegeCourse CollegeCourse { get; set; } 
        public Guid BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }
    }
}
