using AlumniE_ConnectApi.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IAuthorizationServices
    {
        public Task<string> LoginUser(string gmail, string password, string role);
    }
}
