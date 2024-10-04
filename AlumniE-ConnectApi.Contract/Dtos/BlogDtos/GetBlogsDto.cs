using AlumniE_ConnectApi.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class GetBlogDto : BaseEntity
    { 
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<IdAndNameDto> Tags { get; set; }
        public List<string> ImageUrls { get; set; }
        public string CreatedByName { get; set; }
        public string UserProfilePictureUrl { get; set; }
        public string? UserProfileHeadLine {  get; set; }
        ICollection<BlogComment> BlogComments { get; set; }
        
    }
}
