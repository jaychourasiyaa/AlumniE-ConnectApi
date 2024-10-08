using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public JobType JobType {get;set;}
        public LocationType LocationType { get; set; }
        public string Location {  get; set; }
        public DateTime Deadline { get; set; }
    }
}
