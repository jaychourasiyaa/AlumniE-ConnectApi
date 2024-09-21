using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlumniE_ConnectApi.Contract;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Link
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Url { get; set; } 
        public Guid UserId { get; set; }
        
    }
}
