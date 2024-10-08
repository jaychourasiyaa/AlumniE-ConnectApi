using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class newOnE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Registration_Deadline",
                table: "Events",
                newName: "RegistrationDeadline");

            migrationBuilder.RenameColumn(
                name: "Banner_Url",
                table: "Events",
                newName: "MediaUrls");

            migrationBuilder.RenameColumn(
                name: "NIRF_Ranking",
                table: "Colleges",
                newName: "NIRFRanking");

            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "Blogs",
                newName: "MediaUrls");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDeadline",
                table: "Events",
                newName: "Registration_Deadline");

            migrationBuilder.RenameColumn(
                name: "MediaUrls",
                table: "Events",
                newName: "Banner_Url");

            migrationBuilder.RenameColumn(
                name: "NIRFRanking",
                table: "Colleges",
                newName: "NIRF_Ranking");

            migrationBuilder.RenameColumn(
                name: "MediaUrls",
                table: "Blogs",
                newName: "ImageUrls");
        }
    }
}
