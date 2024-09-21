using AlumniE_ConnectApi.Contract.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IUniversityServices
    {
        public Task<Guid> AddUniversity(string name);
    }
}
