namespace AlumniE_ConnectApi.Contract.Dtos.UserDtos
{
    public class GetStudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string? SecondaryMail { get; set; }
        public string? Address { get; set; }
        public string? Bio { get; set; }
        public string? ContactNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid? CollegeId { get; set; }
        public string College { get; set; }
        public Guid? CourseId { get; set; }
        public string Course { get; set; }
        public Guid? BranchId { get; set; }
        public string Branch { get; set; }
        public Guid? CountryId { get; set; }
        public string Country { get; set; }
        public Guid? StateId { get; set; }
        public string State { get; set; }
        public Guid? CityId { get; set; }
        public string City { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int AdmissionYear { get; set; }
        public int PassoutYear { get; set; }

    }
}
