using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class UpdateBlogDto
    {
        [MaxLength(1000)]
        [MinLength(1)]
        [RegularExpression(@"^(?!\s+$).+", ErrorMessage = "Description should not consist only of spaces.")]
        public string? Description { get; set; }
        public List<Guid>? AddTags { get; set; }
        public List<Guid>? RemoveTags { get; set; }
    }
}
