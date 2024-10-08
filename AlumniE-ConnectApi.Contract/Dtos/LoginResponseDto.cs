using AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public UserDetailsDto User { get; set; }
    }
}
