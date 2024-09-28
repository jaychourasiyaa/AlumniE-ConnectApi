using AlumniE_ConnectApi.Contract.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    
    public class BaseEntity
    {
        public DateTime CreatedOn { get; set; } = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } 
        public Guid? UpdatedBy { get; set; }
    }
    
}
