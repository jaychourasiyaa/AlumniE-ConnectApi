using AlumniE_ConnectApi.Contract.Dtos.BranchDtos;
using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IBranchServices
    {
        public Task<Guid> AddBranch(string name, Guid collegeCourseId);
        public Task<List<GetBranchDto>> GetAllBranches();

    }
}
