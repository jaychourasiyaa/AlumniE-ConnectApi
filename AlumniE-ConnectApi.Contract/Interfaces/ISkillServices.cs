using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface ISkillServices
    {
        public Task<List<IdAndNameDto>> GetAllSkills();
        public Task<List<IdAndNameDto>> GetSkillsOfUser(Guid id);
        public Task<List<IdAndNameDto>> GetAllSkillsStartsWith(string startsWith);
        public Task<int> AddSkillsOfUser(List<Guid> skills);
        public Task<int> AddSkills(List<string> skilNames);
        public Task<int> DeleteSkillsOfUser(List<Guid> userSkills);
    }
}
