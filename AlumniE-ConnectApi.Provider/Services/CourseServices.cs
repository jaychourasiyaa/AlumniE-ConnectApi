using AlumniE_ConnectApi.Contract.Dtos.CourseDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly dbContext _dbContext;
        private readonly ICollegeServices collegeServices;
        public CourseServices(dbContext _dbContext, ICollegeServices collegeServices)
        {
            this._dbContext = _dbContext;
            this.collegeServices = collegeServices;
        }
        public async Task<Guid> AddCourse(AddCourseDto dto, Guid colllegeId)
        {
            try
            {
                var newCourse = new Course
                {
                    Name = dto.Name,
                    Duration = dto.Duartion
                };
                await _dbContext.Courses.AddAsync(newCourse);
                await _dbContext.SaveChangesAsync();
                await collegeServices.AddProvidedCourse(newCourse.Id, colllegeId);
                await _dbContext.SaveChangesAsync();
                return newCourse.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GetCourseDto>> GetAllCourses()
        {
            try
            {
                var courses = new List<GetCourseDto>();
                courses = await _dbContext.Courses.Select(c => new GetCourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Duration = c.Duration,
                }).ToListAsync();
                return courses;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
