using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Admin 
    {
        [Key]
        public Guid Id { get; set; }
        public string  ProfilePictureUrl { get; set; } = "https://cdn-icons-png.flaticon.com/512/3934/3934107.png";
        public required string Name { get; set; }
        public required string Gmail { get; set; }
        public required string Password { get; set; }
        public required string MobileNumber { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
