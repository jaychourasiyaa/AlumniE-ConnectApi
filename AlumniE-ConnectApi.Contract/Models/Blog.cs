using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string ? Description { get; set; }
        public List<string> ? MediaUrls { get; set; }
      
        public Guid ?CreatedByStudentId { get; set; }
        [ForeignKey(nameof(CreatedByStudentId))]
        public Student Student { get; set; }
        public Guid ?CreatedByFacultyId { get; set; }
        [ForeignKey(nameof(CreatedByFacultyId))]
        public Faculty Faculty {  get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedOn { get; set; } = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
        public DateTime? UpdatedOn { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
        public virtual ICollection<BlogTag> Tags { get; set; }
    }
}
