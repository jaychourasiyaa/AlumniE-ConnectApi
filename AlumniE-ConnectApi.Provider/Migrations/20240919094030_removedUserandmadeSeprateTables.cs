using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class removedUserandmadeSeprateTables : Migration
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
                newName: "BaseUser");

            migrationBuilder.RenameIndex(
                name: "IX_User_StateId",
                table: "BaseUser",
                newName: "IX_BaseUser_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CourseId",
                table: "BaseUser",
                newName: "IX_BaseUser_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CountryId",
                table: "BaseUser",
                newName: "IX_BaseUser_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CollegeId",
                table: "BaseUser",
                newName: "IX_BaseUser_CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CityId",
                table: "BaseUser",
                newName: "IX_BaseUser_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_User_BranchId",
                table: "BaseUser",
                newName: "IX_BaseUser_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseUser",
                table: "BaseUser",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseUser",
                table: "BaseUser");

            migrationBuilder.RenameTable(
                name: "BaseUser",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_StateId",
                table: "User",
                newName: "IX_User_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CourseId",
                table: "User",
                newName: "IX_User_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CountryId",
                table: "User",
                newName: "IX_User_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CollegeId",
                table: "User",
                newName: "IX_User_CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_CityId",
                table: "User",
                newName: "IX_User_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseUser_BranchId",
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
