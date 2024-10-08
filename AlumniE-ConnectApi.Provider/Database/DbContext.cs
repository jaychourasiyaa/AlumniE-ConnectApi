using AlumniE_ConnectApi.Contract.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Database
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CollegeCourse> CollegeCourses { get; set; }
        public DbSet<CollegeCourseBranch> CollegeCourseBranches { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogsComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogTag> BlogsTags { get; set; }
        public DbSet<UserSkill> UsersSkills { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
