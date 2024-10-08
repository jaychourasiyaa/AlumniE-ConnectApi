﻿// <auto-generated />
using System;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20241006053210_madeJobTable")]
    partial class madeJobTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedByFacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedByStudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrls")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByFacultyId");

                    b.HasIndex("CreatedByStudentId");

                    b.HasIndex("TagId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.BlogComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedByFacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedByStudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CreatedByFacultyId");

                    b.HasIndex("CreatedByStudentId");

                    b.ToTable("BlogsComments");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.BlogTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("TagId");

                    b.ToTable("BlogsTags");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.College", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Accreditation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Affiliated_UniversityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorityNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("CollegeType")
                        .HasColumnType("tinyint");

                    b.Property<string>("ContactEmails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstablishmentYear")
                        .HasColumnType("int");

                    b.Property<string>("Links")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NIRF_Ranking")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("Affiliated_UniversityId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.CollegeCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollegeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CollegeId");

                    b.HasIndex("CourseId");

                    b.ToTable("CollegeCourses");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.CollegeCourseBranch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollegeCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CollegeCourseId");

                    b.ToTable("CollegeCourseBranches");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Duration")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApprovedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banner_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registration_Deadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("EmployeementType")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobTittle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("LocationType")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Ongoing")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollegeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Headline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TeachingSince")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CityId");

                    b.HasIndex("CollegeId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StateId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("JobType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("LocationType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Otp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Otps");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("RegionType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdmissionYear")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollegeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Headline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassoutYear")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CityId");

                    b.HasIndex("CollegeId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StateId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.UserSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("UsersSkills");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Blog", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("CreatedByFacultyId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("CreatedByStudentId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Tag", null)
                        .WithMany("Blogs")
                        .HasForeignKey("TagId");

                    b.Navigation("Faculty");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.BlogComment", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("CreatedByFacultyId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("CreatedByStudentId");

                    b.Navigation("Blog");

                    b.Navigation("Faculty");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.BlogTag", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Blog", "Blog")
                        .WithMany("Tags")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.College", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("Affiliated_UniversityId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("Admin");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("State");

                    b.Navigation("University");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.CollegeCourse", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.College", "College")
                        .WithMany()
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.CollegeCourseBranch", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.CollegeCourse", "CollegeCourse")
                        .WithMany()
                        .HasForeignKey("CollegeCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("CollegeCourse");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Faculty", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.College", "College")
                        .WithMany()
                        .HasForeignKey("CollegeId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("Branch");

                    b.Navigation("City");

                    b.Navigation("College");

                    b.Navigation("Country");

                    b.Navigation("Course");

                    b.Navigation("State");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Region", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Student", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.College", "College")
                        .WithMany()
                        .HasForeignKey("CollegeId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Region", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("Branch");

                    b.Navigation("City");

                    b.Navigation("College");

                    b.Navigation("Country");

                    b.Navigation("Course");

                    b.Navigation("State");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.UserSkill", b =>
                {
                    b.HasOne("AlumniE_ConnectApi.Contract.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Blog", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("AlumniE_ConnectApi.Contract.Models.Tag", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
