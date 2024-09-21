using AlumniE_ConnectApi.Contract.Dtos.CollegeDto;
using AlumniE_ConnectApi.Contract.Dtos.CollegeDtos;
using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface ICollegeServices
    {
        public Task<Guid> AddCollege(AddCollegeDto dto);
        public Task<List<GetCollegeDto>> GetCollegeByAdminId(Guid adminId);
        public Task<Guid> AddProvidedCourse(Guid collegeId, Guid courseId);
        public Task<Guid> AddProvidedBranch(Guid collegeCourseId, Guid branchId);
        public Task<List<GetCourseDto>> GetCoursesByCollege(Guid collegeId);

    }
}
