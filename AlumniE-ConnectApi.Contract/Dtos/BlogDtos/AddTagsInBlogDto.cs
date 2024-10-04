using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class AddTagsInBlogDto
    {
        [Required]
        public Guid BlogId { get; set; }
        [Required]
        public List<Guid> Tags { get; set; }
    }
}
