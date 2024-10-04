using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.UserDtos
{
    public class UserDetailsDto
    {
        public UserRole Role { get; set; }
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string? HeadLine { get; set; }
    }
}
