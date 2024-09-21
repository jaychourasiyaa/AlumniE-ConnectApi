using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public decimal Duration { get; set; }
    }
}
