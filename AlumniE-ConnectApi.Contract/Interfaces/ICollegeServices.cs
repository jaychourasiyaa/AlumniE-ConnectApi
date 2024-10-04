using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.CollegeCourseDtos;
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
        public Task<List<GetCollegeDto>> GetCollegeByAdminId(Guid adminId);
        public Task<List<GetCollegeCourseDto>> GetCoursesByCollege(Guid collegeId);
        public Task<IdAndNameDto?> GetCollegeNameAndIdByDomain(string domain);
        public Task<List<IdAndNameDto>> GetBranchesUnderCollegeCourse(Guid collegeCourseId);
        public Task<Guid> AddCollege(AddCollegeDto dto);
        public Task<Guid> AddProvidedCourse(Guid collegeId, Guid courseId);
        public Task<Guid> AddProvidedBranch(Guid collegeCourseId, Guid branchId);
       

    }
}
