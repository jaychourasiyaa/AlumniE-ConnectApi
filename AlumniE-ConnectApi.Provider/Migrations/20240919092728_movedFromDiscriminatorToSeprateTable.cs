using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class movedFromDiscriminatorToSeprateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Users_UserId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Colleges_CollegeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Courses_CourseId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Regions_CityId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Regions_CountryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Regions_StateId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Faculty_Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StateId",
                table: "User",
                newName: "IX_User_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CourseId",
                table: "User",
                newName: "IX_User_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CountryId",
                table: "User",
                newName: "IX_User_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CollegeId",
                table: "User",
                newName: "IX_User_CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CityId",
                table: "User",
                newName: "IX_User_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BranchId",
                table: "User",
                newName: "IX_User_BranchId");

            migrationBuilder.AddColumn<string>(
                name: "Accreditation",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Colleges",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Affiliated_UniversityId",
                table: "Colleges",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorityNames",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Colleges",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Colleges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "CollegeType",
                table: "Colleges",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmails",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Colleges",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstablishmentYear",
                table: "Colleges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Links",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NIRF_Ranking",
                table: "Colleges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Colleges",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_AdminId",
                table: "Colleges",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_Affiliated_UniversityId",
                table: "Colleges",
                column: "Affiliated_UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_CityId",
                table: "Colleges",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_CountryId",
                table: "Colleges",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_StateId",
                table: "Colleges",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Admins_AdminId",
                table: "Colleges",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Regions_CityId",
                table: "Colleges",
                column: "CityId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Regions_CountryId",
                table: "Colleges",
                column: "CountryId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Regions_StateId",
                table: "Colleges",
                column: "StateId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Universities_Affiliated_UniversityId",
                table: "Colleges",
                column: "Affiliated_UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_User_UserId",
                table: "Experiences",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_User_UserId",
                table: "Links",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Branches_BranchId",
                table: "User",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Colleges_CollegeId",
                table: "User",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Courses_CourseId",
                table: "User",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Regions_CityId",
                table: "User",
                column: "CityId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Regions_CountryId",
                table: "User",
                column: "CountryId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Regions_StateId",
                table: "User",
                column: "StateId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Admins_AdminId",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Regions_CityId",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Regions_CountryId",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Regions_StateId",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Universities_Affiliated_UniversityId",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_User_UserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_User_UserId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Branches_BranchId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Colleges_CollegeId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Courses_CourseId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Regions_CityId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Regions_CountryId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Regions_StateId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Colleges_AdminId",
                table: "Colleges");

            migrationBuilder.DropIndex(
                name: "IX_Colleges_Affiliated_UniversityId",
                table: "Colleges");

            migrationBuilder.DropIndex(
                name: "IX_Colleges_CityId",
                table: "Colleges");

            migrationBuilder.DropIndex(
                name: "IX_Colleges_CountryId",
                table: "Colleges");

            migrationBuilder.DropIndex(
                name: "IX_Colleges_StateId",
                table: "Colleges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Accreditation",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "Affiliated_UniversityId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "AuthorityNames",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "CollegeType",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "ContactEmails",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "EstablishmentYear",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "Links",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "NIRF_Ranking",
                table: "Colleges");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Colleges");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_StateId",
                table: "Users",
                newName: "IX_Users_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CourseId",
                table: "Users",
                newName: "IX_Users_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CountryId",
                table: "Users",
                newName: "IX_Users_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CollegeId",
                table: "Users",
                newName: "IX_Users_CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CityId",
                table: "Users",
                newName: "IX_Users_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_User_BranchId",
                table: "Users",
                newName: "IX_Users_BranchId");

            migrationBuilder.AddColumn<byte>(
                name: "Faculty_Role",
                table: "Users",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Role",
                table: "Users",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Users_UserId",
                table: "Links",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Colleges_CollegeId",
                table: "Users",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Courses_CourseId",
                table: "Users",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Regions_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Regions_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Regions_StateId",
                table: "Users",
                column: "StateId",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
