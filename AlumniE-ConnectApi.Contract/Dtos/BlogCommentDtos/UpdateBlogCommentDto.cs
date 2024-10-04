using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos
{
    public class UpdateBlogCommentDto
    {
        
        [Required (ErrorMessage = "Description is a required")]
        [MinLength (2)]
        public string Comment { get; set; }
    }
}
