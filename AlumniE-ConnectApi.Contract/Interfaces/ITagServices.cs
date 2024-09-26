using AlumniE_ConnectApi.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface ITagServices
    {
        public Task<Guid> AddTag(string name);
        public Task<List<IdAndNameDto>> GetAllTags();
    }
}
