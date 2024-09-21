using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.CollegeDtos
{
    public class GetCollegeDto
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
        public string Admin { get; set; }
        public Guid? CountryId { get; set; }
        public string Country { get; set; }
        public Guid? StateId { get; set; }
        public string State { get; set; }
        public Guid? CityId { get; set; }
        public string City { get; set; }
        public required string Address { get; set; }
        public Guid? Affiliated_UniversityId { get; set; }
        public string Affiliated_University { get; set; }
        public List<string>? Links { get; set; }
    }
}
