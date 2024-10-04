using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class DeleteTagFromBlogDto
    {
        [Required(ErrorMessage ="Blog Id is a required field")]
        public Guid BlogId { get; set; }
        [Required(ErrorMessage = "Tag Id is a required field")]
        public Guid TagId { get; set; }
    }
}
