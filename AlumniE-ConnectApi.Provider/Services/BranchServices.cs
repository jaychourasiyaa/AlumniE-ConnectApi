using AlumniE_ConnectApi.Contract.Dtos.BranchDtos;
using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class BranchServices : IBranchServices
    {
        private dbContext _dbContext;
        private ICollegeServices collegeServices;
        public BranchServices(dbContext _dbContext , ICollegeServices collegeServices)
        {
            this._dbContext = _dbContext;
            this.collegeServices = collegeServices;
        }
        public async Task<Guid> AddBranch(string Name, Guid collegeCourseId)
        {
            try
            {
                var newbranch = new Branch
                {
                    Name = Name,
                };
                await _dbContext.Branches.AddAsync(newbranch);
                await _dbContext.SaveChangesAsync();
                await collegeServices.AddProvidedBranch(collegeCourseId, newbranch.Id);
                await _dbContext.SaveChangesAsync();
                return newbranch.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GetBranchDto>> GetAllBranches()
        {
            try
            {
                var branches = new List<GetBranchDto>();
                branches = await _dbContext.Branches.Select(c => new GetBranchDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    
                }).ToListAsync();
                return branches;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
