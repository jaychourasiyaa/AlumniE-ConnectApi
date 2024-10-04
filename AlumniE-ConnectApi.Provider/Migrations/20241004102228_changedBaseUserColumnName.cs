using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class changedBaseUserColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                table: "Students",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ProfileHeadline",
                table: "Students",
                newName: "Headline");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                table: "Faculties",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ProfileHeadline",
                table: "Faculties",
                newName: "Headline");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Students",
                newName: "ProfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "Headline",
                table: "Students",
                newName: "ProfileHeadline");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Faculties",
                newName: "ProfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "Headline",
                table: "Faculties",
                newName: "ProfileHeadline");
        }
    }
}
