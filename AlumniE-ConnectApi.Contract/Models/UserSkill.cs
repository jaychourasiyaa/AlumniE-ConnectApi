using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class UserSkill
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skill Skill { get; set; }
        public Guid UserId { get; set; }
        
    }
}
