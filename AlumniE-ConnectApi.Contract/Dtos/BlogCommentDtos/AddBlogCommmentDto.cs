using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos
{
    public class AddBlogCommmentDto
    {
        [Required(ErrorMessage ="BlogId is a required field")]
        public Guid BlogId { get; set; }
        [Required(ErrorMessage = "Comment is a required field")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Comment cannot be less than 2 characters")]
        public string Comment { get; set; }
    }
}
