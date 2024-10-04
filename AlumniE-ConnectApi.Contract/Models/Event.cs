using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Event : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ? Banner_Url { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Location { get; set; }
        public DateTime Registration_Deadline { get; set; }
        public EventStatus Status { get; set; } = EventStatus.Created;
        public string? ApprovedByName { get; set; }
        public string CreatedByName { get; set; }

    }
}
