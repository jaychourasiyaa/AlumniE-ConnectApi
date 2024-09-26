using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class AddBlogDto
    {
        public string Description { get; set; } 
        public List<Guid> Tags { get; set; }
        public List<string> ImageUrls { get; set; } 
    }
}
