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
        public List<Guid> Tags { get; set; }
        public List<string> ImageUrls { get; set; }
        ICollection<BlogComment> BlogComments { get; set; }
    }
}
