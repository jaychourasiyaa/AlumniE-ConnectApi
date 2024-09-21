using AlumniE_ConnectApi.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class College
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Domain { get; set; }
        public required string Code { get; set; }
        public required int EstablishmentYear { get; set; }
        public required CollegeType CollegeType { get; set; }
        public required List<string> ContactNumber { get; set; }
        public required List<string> ContactEmails { get; set; }
        public required List<string> AuthorityNames { get; set; }
        public int? NIRF_Ranking { get; set; }
        public required string Accreditation { get; set; }
        public Guid? AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        public Admin Admin { get; set; }
        public Guid? CountryId { get; set; } = Guid.Parse("578DACF0-E6DE-4AE4-B044-E17C01045CB0");
        [ForeignKey(nameof(CountryId))]
        public Region Country { get; set; }
        public Guid? StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public Region State { get; set; }
        public Guid? CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public Region City { get; set; }
        public required string Address { get; set; }
        public Guid? Affiliated_UniversityId { get; set; }
        [ForeignKey(nameof(Affiliated_UniversityId))]
        public University University { get; set; }
        public List<string>? Links { get; set; }

    }
}
