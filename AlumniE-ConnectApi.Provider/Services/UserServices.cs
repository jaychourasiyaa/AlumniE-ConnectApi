
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class UserServices : IUserServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public UserServices(dbContext _dbContext, IJwtServices jwtServices)
        {
            this._dbContext = _dbContext;
            this.jwtServices = jwtServices;
        }
        public async Task<Admin> GetUser()
        {
            try
            {
                
                var admin = await _dbContext.Admins.Where(a => a.Name == "Vishwesh Jain").AsNoTracking().FirstOrDefaultAsync();
                return admin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> checkStudentAlreadyExists( string gmail)
        {
            try
            {
                var alreadyExists = await _dbContext.Students.FirstOrDefaultAsync( s=> s.Gmail == gmail );
                if (alreadyExists != null )
                {
                    return true;
                }
                return false;
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> Add_Student(AddStudentDto dto)
        {
            try
            {
                
                var newStudent = new Student
                {
                    Name = dto.Name,
                    Password = dto.Password,
                    Gmail = dto.Gmail,
                    CollegeId = dto.CollegeId,
                    CourseId = dto.CourseId,
                    BranchId = dto.BranchId,
                    AdmissionYear = dto.AdmissionYear,
                    PassoutYear = dto.PassoutYear,

                };
                await _dbContext.Students.AddAsync(newStudent);
                await _dbContext.SaveChangesAsync();
                return newStudent.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> Add_Faculty(AddFacultyDto dto)
        {
            try
            {
                var newFaculty = new Faculty
                {
                    Name = dto.Name,
                    Password = dto.Password,
                    Gmail = dto.Gmail,
                    CollegeId = dto.CollegeId,
                    CourseId = dto.CourseId,
                    BranchId = dto.BranchId,
                    TeachingSince = dto.TeachingSince,

                };
                await _dbContext.Faculties.AddAsync(newFaculty);
                await _dbContext.SaveChangesAsync();
                return newFaculty.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> Add_Admin(AddAdminDto dto)
        {
            try
            {
                var newAdmin = new Admin
                {
                    Name = dto.Name,
                    Password = dto.Password,
                    Gmail = dto.Gmail,
                    MobileNumber = dto.MobileNumber,

                };
                await _dbContext.Admins.AddAsync(newAdmin);
                await _dbContext.SaveChangesAsync();
                return newAdmin.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
