using AlumniE_ConnectApi.Contract.Dtos.JobDtos;
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
    public class JobServices : IJobServices
    {
        private readonly dbContext _dbContext;
        public JobServices(dbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<string> AddJob(AddJobDto dto)
        {
            try
            {
                var newJob = new Job
                {
                    Tittle = dto.Tittle,
                    Description = dto.Description,
                    Deadline = dto.Deadline,
                    Location = dto.Location,
                    LocationType = dto.LocationType,
                    JobType = dto.JobType,
                    CompanyName = dto.CompanyName,

                };
                await _dbContext.Jobs.AddAsync(newJob);
                await _dbContext.SaveChangesAsync();
                return newJob.Id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GetJobDto>> GetJob()
        {
            try
            {
                var currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                var jobs = await _dbContext.Jobs.Where(j => j.Deadline > currentTime)
                    .Select(j => new GetJobDto
                    {
                        Id = j.Id,
                        CompanyName = j.CompanyName,
                        Tittle = j.Tittle,
                        Description = j.Description,
                        JobType = j.JobType,
                        Location = j.Location,
                        LocationType = j.LocationType,
                        Deadline = j.Deadline,
                    }).ToListAsync();
                return jobs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
