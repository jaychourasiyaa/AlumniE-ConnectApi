using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class BlogTag
    {
        [Key]
        public Guid Id {  get; set; }
        public Guid BlogId { get; set; }
        public Guid TagId { get; set; }
        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; }
        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; }
    }
}
