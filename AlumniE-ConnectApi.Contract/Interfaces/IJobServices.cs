using AlumniE_ConnectApi.Contract.Dtos.JobDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IJobServices
    {
        public Task<string> AddJob(AddJobDto dto);
        public Task<List<GetJobDto>> GetJob();
    }
}
