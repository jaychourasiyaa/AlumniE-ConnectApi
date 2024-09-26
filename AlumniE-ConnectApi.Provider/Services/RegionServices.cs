using AlumniE_ConnectApi.Contract.Dtos.RegionDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class RegionServices : IRegionServices
    {
        private readonly dbContext _dbContext;
        public RegionServices(dbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<GetRegionDto>> GetRegionsByParentId(Guid ParentId)
        {
            try
            {
                var regions = await _dbContext.Regions
                    .Where(r => r.ParentId == ParentId)
                    .Select(r => new GetRegionDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                    }).AsNoTracking().ToListAsync();
                regions = regions != null ? regions : new List<GetRegionDto>();
                return regions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
