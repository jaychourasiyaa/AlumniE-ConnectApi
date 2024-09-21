using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Region
    {
       
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public RegionType RegionType { get; set; }
        public Guid ? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Region Parent { get; set; } 
    }
}
