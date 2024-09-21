using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class addedUserStudenFacultyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

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

            migrationBuilder.AddColumn<int>(
                name: "AdmissionYear",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Faculty_Role",
                table: "Users",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassoutYear",
                table: "Users",
                type: "int",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AdmissionYear",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Faculty_Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PassoutYear",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

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
    }
}
