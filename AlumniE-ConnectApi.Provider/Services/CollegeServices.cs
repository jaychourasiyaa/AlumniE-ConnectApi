using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.CollegeCourseDtos;
using AlumniE_ConnectApi.Contract.Dtos.CollegeDto;
using AlumniE_ConnectApi.Contract.Dtos.CollegeDtos;
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
    public class CollegeServices : ICollegeServices
    {
        private readonly dbContext _dbContext;
        public CollegeServices(dbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<Guid> AddCollege(AddCollegeDto dto)
        {
            try
            {
                var newCollege = new College
                {
                    Name = dto.Name,
                    Domain = dto.Domain,
                    Code = dto.Code,
                    Accreditation = dto.Accreditation,
                    CollegeType = dto.CollegeType,
                    EstablishmentYear = dto.EstablishmentYear,
                    ContactEmails = dto.ContactEmails,
                    ContactNumber = dto.ContactNumber,
                    AuthorityNames = dto.AuthorityName,
                    Address = dto.Address,
                    StateId = dto.StateId,
                    CityId = dto.CityId,
                    NIRF_Ranking = dto.NIRF_Ranking,
                    AdminId = dto.AdminId,
                    Affiliated_UniversityId = dto.Affiliated_UniversityId,
                    Links = dto.Links,
                };
                await _dbContext.Colleges.AddAsync(newCollege);
                await _dbContext.SaveChangesAsync();
                return newCollege.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GetCollegeDto>> GetCollegeByAdminId(Guid adminId)
        {
            try
            {
                var colleges = new List<GetCollegeDto>();
                colleges = await _dbContext.Colleges.Where(c => c.AdminId == adminId)
                   .Select(c => new GetCollegeDto
                   {
                       Id = c.Id,
                       Name = c.Name,
                       CollegeType = c.CollegeType,
                       EstablishmentYear = c.EstablishmentYear,
                       Code = c.Code,
                       Domain = c.Domain,
                       NIRF_Ranking = c.NIRF_Ranking,
                       Admin = c.Admin.Name,
                       Country = c.Country.Name,
                       State = c.State.Name,
                       City = c.City.Name,
                       Address = c.Address,
                       Accreditation = c.Accreditation,
                       Affiliated_University = c.University.Name,
                       AuthorityNames = c.AuthorityNames,
                       ContactEmails = c.ContactEmails,
                       ContactNumber = c.ContactNumber,
                       Links = c.Links,
                       CountryId = c.CountryId,
                       StateId = c.StateId,
                       CityId = c.CityId,
                       Affiliated_UniversityId = c.Affiliated_UniversityId

                   }).AsNoTracking().ToListAsync();
                return colleges;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> AddProvidedCourse(Guid courseId, Guid collegeId)
        {
            try
            {
                var newCollegeCourse = new CollegeCourse
                {
                    CourseId = courseId,
                    CollegeId = collegeId
                };
                await _dbContext.CollegeCourses.AddAsync(newCollegeCourse);
                await _dbContext.SaveChangesAsync();
                return newCollegeCourse.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> AddProvidedBranch(Guid collegeCourseId, Guid branchId)
        {
            try
            {
                var newCollegeCourseBranch = new CollegeCourseBranch
                {
                    CollegeCourseId = collegeCourseId,
                    BranchId = branchId
                };
                await _dbContext.CollegeCourseBranches.AddAsync(newCollegeCourseBranch);
                await _dbContext.SaveChangesAsync();
                return newCollegeCourseBranch.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GetCollegeCourseDto>> GetCoursesByCollege(Guid collegeId)
        {
            try
            {
                var colleges = new List<GetCollegeCourseDto>();
                colleges = await _dbContext.CollegeCourses.Where(c => c.CollegeId == collegeId)
                    .Select(c => new GetCollegeCourseDto
                    {
                        Id = c.Id,
                        CourseId = c.CourseId,
                        Name = c.Course.Name,
                        Duration = c.Course.Duration,
                    }).AsNoTracking().ToListAsync();
                return colleges;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdAndNameDto?> GetCollegeNameAndIdByDomain(string domain)
        {
            try
            {
                var college = await _dbContext.Colleges.Where(c => c.Domain == domain)
                    .Select(c => new IdAndNameDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                return college;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<IdAndNameDto>> GetBranchesUnderCollegeCourse(Guid collegeCourseId)
        {
            try
            {
                var branches = new List<IdAndNameDto>();
                branches = await _dbContext.CollegeCourseBranches.Where(b => b.CollegeCourseId == collegeCourseId)
                    .Select(b => new IdAndNameDto
                    {
                        Id = b.Branch.Id,
                        Name = b.Branch.Name
                    })
                    .AsNoTracking()
                    .ToListAsync();
                return branches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
