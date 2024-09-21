using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Admin 
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Gmail { get; set; }
        public required string Password { get; set; }
        public required string MobileNumber { get; set; }
    }
}
