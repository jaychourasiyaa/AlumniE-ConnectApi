
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;

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
        public async Task<GetStudentDto> GetStudentDetails(Guid id)
        {
            try
            {
                // currently making fetch all details things will update according to frontend requirement
                var student = await _dbContext.Students.Where(s => s.Id == id)
                    .Select(s => new GetStudentDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Gmail = s.Gmail,
                        CollegeId = s.CollegeId,
                        College = s.College.Name,
                        CourseId = s.CourseId,
                        Course = s.Course.Name,
                        BranchId = s.BranchId,
                        Branch = s.Branch.Name,
                        CountryId = s.CountryId,
                        Country = s.Country.Name,
                        StateId = s.StateId,
                        State = s.State.Name,
                        CityId = s.CityId,
                        City = s.City.Name,
                        AdmissionYear = s.AdmissionYear,
                        PassoutYear = s.PassoutYear,
                        SecondaryMail = s.SecondaryMail,
                        Address = s.Address,
                        Bio = s.Bio,
                        IsActive = s.IsActive,
                        ContactNumber = s.ContactNumber,
                        Password = s.Password,
                        ProfilePictureUrl = s.ProfilePictureUrl
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<GetFacultyDto> GetFacultyDetails(Guid id)
        {
            try
            {
                // currently making fetch all details things will update according to frontend requirement
                var faculty = await _dbContext.Faculties.Where(s => s.Id == id)
                    .Select(s => new GetFacultyDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Gmail = s.Gmail,
                        CollegeId = s.CollegeId,
                        College = s.College.Name,
                        CourseId = s.CourseId,
                        Course = s.Course.Name,
                        BranchId = s.BranchId,
                        Branch = s.Branch.Name,
                        CountryId = s.CountryId,
                        Country = s.Country.Name,
                        StateId = s.StateId,
                        State = s.State.Name,
                        CityId = s.CityId,
                        City = s.City.Name,
                        SecondaryMail = s.SecondaryMail,
                        Address = s.Address,
                        Bio = s.Bio,
                        IsActive = s.IsActive,
                        ContactNumber = s.ContactNumber,
                        Password = s.Password,
                        ProfilePictureUrl = s.ProfilePictureUrl,
                        TeachingSince = s.TeachingSince
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                return faculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> checkStudentAlreadyExists(string gmail)
        {
            try
            {
                var alreadyExists = await _dbContext.Students.FirstOrDefaultAsync(s => s.Gmail == gmail);
                if (alreadyExists != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
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
        public async Task<int> UpdateUser(UpdateUserDto dto)
        {
            try
            {
                if (dto.Role == "Student")
                {
                    var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == dto.Id && x.IsActive);
                    if (student == null)
                    {
                        return -1;
                    }
                    return await ChangeUserDetailsAsync(student, dto);
                }
                else if (dto.Role == "Faculty")
                {
                    var faculty = await _dbContext.Faculties.FirstOrDefaultAsync(x => x.Id == dto.Id && x.IsActive);
                    if (faculty == null)
                    {
                        return -1;
                    }
                    return await ChangeUserDetailsAsync(faculty, dto);
                }
                else
                {
                    return -3;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> ChangeUserPassword(ChangePasswordDto dto, string role)
        {
            try
            {
                if (role == "Student")
                {
                    var student = await _dbContext.Students.Where(s => s.IsActive && s.Id == dto.Id).FirstOrDefaultAsync();
                    return await ChangePasswordAsync(student, dto.PreviousPassword, dto.NewPassword);
                }
                else if (role == "Facutly")
                {
                    var faculty = await _dbContext.Faculties.Where(s => s.IsActive && s.Id == dto.Id).FirstOrDefaultAsync();
                    return await ChangePasswordAsync(faculty, dto.PreviousPassword, dto.NewPassword);
                }
                else if (role == "Admin")
                {
                    var admin = await _dbContext.Admins.Where(s => s.IsActive && s.Id == dto.Id).FirstOrDefaultAsync();
                    return await ChangePasswordAsync(admin, dto.PreviousPassword, dto.NewPassword);
                }
                else
                {
                    return -4;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> ChangeUserProfilePicture(ChangeProfilePictureDto dto)
        {
            try
            {
                if (dto.Role == "Student")
                {
                    var student = await _dbContext.Students.Where(s => s.IsActive && s.Id == dto.Id).FirstOrDefaultAsync();
                    if (student == null)
                    {
                        return -1;
                    }
                    student.ProfilePictureUrl = dto.Url;
                }
                else if (dto.Role == "Facutly")
                {
                    var faculty = await _dbContext.Faculties.Where(s => s.IsActive && s.Id == dto.Id).FirstOrDefaultAsync();
                    if ((faculty == null))
                    {
                        return -1;
                    }
                    faculty.ProfilePictureUrl = dto.Url;
                }
                else if (dto.Role == "Admin")
                {
                    var admin = await _dbContext.Admins.Where(s => s.IsActive && s.Id == dto.Id).FirstOrDefaultAsync();
                    if (admin == null)
                    {
                        return -1;
                    }
                    admin.ProfilePictureUrl = dto.Url;
                }
                else
                {
                    return -2;
                }
                await _dbContext.SaveChangesAsync(); return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<int> ChangePasswordAsync<T>(T user, string? previousPassword, string newPassword)
        {
            try
            {
                if (user == null)
                {
                    return -1; // User not found
                }

                // Use reflection to get the IsActive property
                var isActiveProperty = typeof(T).GetProperty("IsActive");
                var isActive = (bool?)isActiveProperty?.GetValue(user);
                if (isActive != true)
                {
                    return -1; // User is inactive
                }

                // Use reflection to get the Password property
                var passwordProperty = typeof(T).GetProperty("Password");
                var currentPassword = (string?)passwordProperty?.GetValue(user);

                if (!string.IsNullOrEmpty(previousPassword)) // User wants to change the password
                {
                    if (currentPassword != previousPassword)
                    {
                        return -2; // Previous password is incorrect
                    }
                    if (currentPassword == newPassword)
                    {
                        return -3; // New password is the same as the old password
                    }
                    // Update the password using reflection
                    passwordProperty?.SetValue(user, newPassword);
                }
                else // User wants to reset the password (forgot password)
                {
                    if (currentPassword == newPassword)
                    {
                        return -3; // New password is the same as the old password
                    }
                    // Update the password using reflection
                    passwordProperty?.SetValue(user, newPassword);
                }
                await _dbContext.SaveChangesAsync();
                return 1; // Success
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<int> ChangeUserDetailsAsync<T>(T user, UpdateUserDto dto)
        {
            try
            {
                int result = -2;
                if (!string.IsNullOrEmpty(dto.Name))
                {
                    var nameProperty = typeof(T).GetProperty("Name");
                    var nameValue = nameProperty != null ? nameProperty.GetValue(user) : null;
                    string? name = nameValue != null ? nameValue.ToString() : null;
                    if (name != null && name != dto.Name)
                    {
                        nameProperty?.SetValue(user, dto.Name);
                        result = 1;
                    }
                }
                if (dto.CityId != null)
                {
                    var cityIdProperty = typeof(T).GetProperty("CityId");
                    var cityIdValue = cityIdProperty != null ? cityIdProperty.GetValue(user) : null;
                    var cityId = cityIdValue != null ? cityIdValue.ToString() : null;
                    if (cityId != dto.CityId.ToString())
                    {
                        cityIdProperty?.SetValue(user, dto.CityId);
                        result = 1;
                    }
                }
                if (!string.IsNullOrEmpty(dto.ContactNumber))
                {
                    var contactNumberProperty = typeof(T).GetProperty("ContactNumber");
                    var contactNumberProperyValue = contactNumberProperty != null ? contactNumberProperty.GetValue(user) : null;
                    var contactNumber = contactNumberProperyValue != null ? contactNumberProperyValue.ToString() : null;
                    if(contactNumber != dto.ContactNumber)
                    {
                        contactNumberProperty?.SetValue(user, dto.ContactNumber);
                        result = 1;
                    }
                }
                if (!string.IsNullOrEmpty(dto.Bio))
                {
                    var bioProperty = typeof(T).GetProperty("Bio");
                    var bioProperyValue = bioProperty != null ? bioProperty.GetValue(user) : null;
                    var bio = bioProperyValue != null ? bioProperyValue.ToString() : null;
                    if (bio != dto.Bio)
                    {
                        bioProperty?.SetValue(user, dto.Bio);
                        result = 1;
                    }
                }
                if (!string.IsNullOrEmpty(dto.Address))
                {
                    var addressProperty = typeof(T).GetProperty("Address");
                    var addressProperyValue = addressProperty != null ? addressProperty.GetValue(user) : null;
                    var address = addressProperyValue != null ? addressProperyValue.ToString() : null;
                    if( address != dto.Address)
                    {
                        addressProperty?.SetValue(user, dto.Address);
                        result = 1;
                    }
                }
                if (dto.StatedId != null)
                {
                    var stateProperty = typeof(T).GetProperty("StateId");
                    var statePropertyValue = stateProperty != null ? stateProperty.GetValue(user) : null;
                    var stateId = statePropertyValue != null ? statePropertyValue.ToString() : null;
                    if(stateId != dto.StatedId.ToString())
                    {
                        stateProperty?.SetValue(user, dto.StatedId);
                        result = 1;
                    }
                }
                await _dbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
