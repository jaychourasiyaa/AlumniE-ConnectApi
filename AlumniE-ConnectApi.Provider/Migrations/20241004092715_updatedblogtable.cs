using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class updatedblogtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatedByFacultyId",
                table: "Blogs",
                column: "CreatedByFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatedByStudentId",
                table: "Blogs",
                column: "CreatedByStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Faculties_CreatedByFacultyId",
                table: "Blogs",
                column: "CreatedByFacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Students_CreatedByStudentId",
                table: "Blogs",
                column: "CreatedByStudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Faculties_CreatedByFacultyId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Students_CreatedByStudentId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CreatedByFacultyId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CreatedByStudentId",
                table: "Blogs");
        }
    }
}
