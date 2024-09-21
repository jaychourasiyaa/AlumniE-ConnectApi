using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class CollegeCourse
    {
        public Guid Id { get; set; }
        public Guid CollegeId { get; set; }
        [ForeignKey(nameof(CollegeId))]
        public College College { get; set; } 
        public Guid CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } 
    }
}
