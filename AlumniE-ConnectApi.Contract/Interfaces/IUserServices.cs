
using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IUserServices
    {
        public Task<GetStudentDto> GetStudentDetails(Guid id);
        public Task<GetFacultyDto> GetFacultyDetails(Guid id);
        public Task<List<IdAndNameDto>> GetAllAdmin();
        public Task<Guid> Add_Student(AddStudentDto dto);
        public Task<Guid> Add_Faculty(AddFacultyDto dto);
        public Task<Guid> Add_Admin(AddAdminDto dto);
        public Task<int> UpdateUser(UpdateUserDto dto);
        public Task<int> ChangeUserPassword(ChangePasswordDto dto);
        public Task<int> ChangeUserProfilePicture(ChangeProfilePictureDto dto);
        public Task<int> Delete_Student(Guid id);
        public Task<int> Delete_Faculty(Guid id);

    }
}
