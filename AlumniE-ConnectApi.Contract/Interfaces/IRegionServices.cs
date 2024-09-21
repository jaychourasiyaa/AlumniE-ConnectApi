using AlumniE_ConnectApi.Contract.Dtos.RegionDtos;
using AlumniE_ConnectApi.Contract.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IRegionServices
    {
        public Task<List<GetRegionDto>> GetRegionsByParentId(Guid parentId);
    }
}
