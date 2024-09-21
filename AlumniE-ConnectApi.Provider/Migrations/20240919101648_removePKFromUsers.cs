using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class removePKFromUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseUser_Branches_BranchId",
                table: "BaseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseUser_Colleges_CollegeId",
                table: "BaseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseUser_Courses_CourseId",
                table: "BaseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseUser_Regions_CityId",
                table: "BaseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseUser_Regions_CountryId",
                table: "BaseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseUser_Regions_StateId",
                table: "BaseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_BaseUser_UserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_BaseUser_UserId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_UserId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseUser",
                table: "BaseUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseUser");

            migrationBuilder.DropColumn(
                name: "TeachingSince",
                table: "BaseUser");

            migrationBuilder.RenameTable(
                name: "BaseUser",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_StateId",
                table: "Students",
                newName: "IX_Students_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CourseId",
                table: "Students",
                newName: "IX_Students_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CountryId",
                table: "Students",
                newName: "IX_Students_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CollegeId",
                table: "Students",
                newName: "IX_Students_CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CityId",
                table: "Students",
                newName: "IX_Students_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_BranchId",
                table: "Students",
                newName: "IX_Students_BranchId");

            migrationBuilder.AlterColumn<int>(
                name: "PassoutYear",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdmissionYear",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeachingSince = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CollegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Faculties_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Faculties_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Faculties_Regions_CityId",
                        column: x => x.CityId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Faculties_Regions_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Faculties_Regions_StateId",
                        column: x => x.StateId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_BranchId",
                table: "Faculties",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_CityId",
                table: "Faculties",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_CollegeId",
                table: "Faculties",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_CountryId",
                table: "Faculties",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_CourseId",
                table: "Faculties",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_StateId",
                table: "Faculties",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Branches_BranchId",
                table: "Students",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Colleges_CollegeId",
                table: "Students",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Regions_CityId",
                table: "Students",
                column: "CityId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Regions_CountryId",
                table: "Students",
                column: "CountryId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Regions_StateId",
                table: "Students",
                column: "StateId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Branches_BranchId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Colleges_CollegeId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Regions_CityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Regions_CountryId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Regions_StateId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "BaseUser");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StateId",
                table: "BaseUser",
                newName: "IX_BaseUser_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseId",
                table: "BaseUser",
                newName: "IX_BaseUser_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CountryId",
                table: "BaseUser",
                newName: "IX_BaseUser_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CollegeId",
                table: "BaseUser",
                newName: "IX_BaseUser_CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CityId",
                table: "BaseUser",
                newName: "IX_BaseUser_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_BranchId",
                table: "BaseUser",
                newName: "IX_BaseUser_BranchId");

            migrationBuilder.AlterColumn<int>(
                name: "PassoutYear",
                table: "BaseUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdmissionYear",
                table: "BaseUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseUser",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeachingSince",
                table: "BaseUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseUser",
                table: "BaseUser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserId",
                table: "Links",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUser_Branches_BranchId",
                table: "BaseUser",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUser_Colleges_CollegeId",
                table: "BaseUser",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUser_Courses_CourseId",
                table: "BaseUser",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUser_Regions_CityId",
                table: "BaseUser",
                column: "CityId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUser_Regions_CountryId",
                table: "BaseUser",
                column: "CountryId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseUser_Regions_StateId",
                table: "BaseUser",
                column: "StateId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_BaseUser_UserId",
                table: "Experiences",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_BaseUser_UserId",
                table: "Links",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
