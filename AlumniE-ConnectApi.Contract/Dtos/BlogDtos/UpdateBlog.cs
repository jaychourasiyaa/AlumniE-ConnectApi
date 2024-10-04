using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class UpdateBlog
    {
        
        [Required]
        [MinLength(2)]
        public string Description { get; set; }
    }
}
