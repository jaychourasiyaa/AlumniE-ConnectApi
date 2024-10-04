using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class BlogComment
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid BlogId { get; set; }
        public Guid? CreatedByStudentId { get; set; }
        public Guid? CreatedByFacultyId { get; set; }
        public DateTime CreatedOn { get; set; } = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
        public DateTime? UpdatedOn { get; set; }
        public UserRole Role { get; set; }

        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; }

        [ForeignKey(nameof(CreatedByStudentId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(CreatedByFacultyId))]
        public Faculty Faculty { get; set; }
    }
}
