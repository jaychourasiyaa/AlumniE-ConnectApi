using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface ICourseServices
    {
        public Task<List<GetCourseDto>> GetAllCourses();
        public Task<Guid> AddCourse(AddCourseDto dto, Guid collegeId);

    }
}
