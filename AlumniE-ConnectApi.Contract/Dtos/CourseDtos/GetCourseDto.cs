using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.CourseDtos
{
    public class GetCourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }
    }
}
