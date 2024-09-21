using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.CourseDtos
{
    public class AddCourseDto
    {
        public required string Name { get; set; }
        public required decimal Duartion { get; set; }
    }
}
