using AlumniE_ConnectApi.Contract.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class JwtServices : IJwtServices
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Gmail { get; set; }
        public string Role { get; set; }
        public JwtServices(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;
            if( user != null)
            {
                var idClaim = user.Claims.FirstOrDefault(c=> c.Type == "Id")?.Value;
                Id = idClaim != null ?Guid.Parse(idClaim) : new Guid();
                var NameClaim = user.Claims.FirstOrDefault( c=> c.Type == "Name")?.Value;
                Name = NameClaim != null ? NameClaim : string.Empty;
                var GmailClaim = user.Claims.FirstOrDefault(c => c.Type == "Gmail")?.Value;
                Gmail = GmailClaim != null ? GmailClaim : string.Empty;
                var RoleClaim = user.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
                Role = RoleClaim != null ? RoleClaim : string.Empty;
                
            }
        }
    }
}
