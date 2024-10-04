using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class GetBlogDto 
    { 
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<IdAndNameDto> Tags { get; set; }
        public List<string> ImageUrls { get; set; }
        public  UserDetailsDto User { get; set; }
        ICollection<BlogComment> BlogComments { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
   


}
