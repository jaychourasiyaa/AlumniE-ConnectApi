using AlumniE_ConnectApi.Contract.Dtos.EventDtos;
using AlumniE_ConnectApi.Contract.Dtos.ExperienceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IExperienceServices
    {
        public Task<int> UpsertExperience(AddExperienceDto dto);
        public Task<List<GetExperienceDto>> GetExperience(Guid id);
    }
}
