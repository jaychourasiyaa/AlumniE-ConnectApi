using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Blog : BaseEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; } 
        public List<Guid> Tags { get; set; } 
        public List<string> ImageUrls {  get; set; } 
        ICollection<BlogComment> BlogComments { get; set; }
         
    }
}
