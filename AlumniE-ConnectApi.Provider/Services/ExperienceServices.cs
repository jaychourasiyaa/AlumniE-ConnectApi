using AlumniE_ConnectApi.Contract.Dtos.ExperienceDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class ExperienceServices : IExperienceServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public ExperienceServices(dbContext _dbContext, IJwtServices jwtServices)
        {
            this._dbContext = _dbContext;
            this.jwtServices = jwtServices;
        }
        public async Task<int> UpsertExperience(AddExperienceDto dto )
        {
            try
            {
                var experience = new Experience();
                if(dto.Ongoing == true && dto.EndDate != null)
                {
                    return -1;
                }
                if(dto.Ongoing == false && dto.EndDate == null)
                {
                    return -2;
                }
                if (dto.Id != null)
                {
                    experience = await _dbContext.Experiences.Where(e => e.Id == dto.Id).FirstOrDefaultAsync();
                    if (experience == null)
                    {
                        return -3;
                    }
                    else if( jwtServices.Role != UserRole.Admin && jwtServices.Role != UserRole.Faculty && jwtServices.Id != experience.UserId)
                    {
                        return -4;
                    }
                }
                
                /*experience = new Experience
                {
                    UserId = jwtServices.Id,
                    JobTittle = dto.JobTittle,
                    EmployeementType = dto.EmployeementType,
                    LocationType = dto.LocationType,
                    CompanyName = dto.CompanyName,
                    Location = dto.Location,
                    Description =dto.Description,
                    StartDate = dto.StartDate,
                    Ongoing = dto.Ongoing,
                    EndDate = dto.EndDate,
                };*/
                experience.UserId = jwtServices.Id;
                experience.EndDate = dto.EndDate;
                experience.StartDate = dto.StartDate;
                experience.JobTittle = dto.JobTittle;
                experience.EmployeementType = dto.EmployeementType;
                experience.CompanyName = dto.CompanyName;
                experience.Location = dto.Location;
                experience.LocationType = dto.LocationType;
                experience.Ongoing = dto.Ongoing;
                experience.Description = dto.Description;
                if (dto.Id == null)
                {
                    await _dbContext.Experiences.AddAsync(experience);
                }
                await _dbContext.SaveChangesAsync();
                if(dto.Id != null)
                {
                    return 0;
                }
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<List<GetExperienceDto>> GetExperience(Guid id)
        {
            try
            {
                var experiences = await _dbContext.Experiences.Where(e=> e.UserId == id).
                    Select(e => new GetExperienceDto
                    {
                        Id = e.Id,
                        JobTittle = e.JobTittle,
                        EmployeementType = e.EmployeementType,
                        LocationType = e.LocationType,
                        CompanyName = e.CompanyName,
                        Location = e.Location,
                        Description = e.Description,
                        StartDate = e.StartDate,
                        Ongoing = e.Ongoing,
                        EndDate = e.EndDate,
                    }).ToListAsync();
                return experiences;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
