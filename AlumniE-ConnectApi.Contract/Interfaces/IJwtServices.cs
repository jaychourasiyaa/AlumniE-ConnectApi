using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IJwtServices 
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Gmail {  get; set; }
        public UserRole Role { get; set; }
    }
}
