using AlumniE_ConnectApi.Contract;
using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Student : BaseUser
    {

        public Guid Id { get; set; }
        public string? ProfilePictureUrl { get; set; } = "https://cdn-icons-png.flaticon.com/512/6596/6596121.png";

        public required int AdmissionYear { get; set; }
        public required int PassoutYear { get; set; }

    }
}
