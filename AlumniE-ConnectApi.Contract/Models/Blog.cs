using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Blog : BaseEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public string Role {  get; set; }
        public string CreatedByName { get; set; }
        public string UserProfilePictureUrl { get; set; }
        public string ?UserProfileHeadline {  get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
        public virtual ICollection<BlogTag> Tags { get; set; }
    }
}
