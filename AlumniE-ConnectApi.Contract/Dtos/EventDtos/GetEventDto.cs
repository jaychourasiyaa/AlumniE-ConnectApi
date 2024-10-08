using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.EventDtos
{
    public class GetEventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Location { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public EventStatus Status { get; set; } = EventStatus.Created;
        public string? ApprovedByName { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public List<string>? MediaUrls { get; set; }

    }
}
