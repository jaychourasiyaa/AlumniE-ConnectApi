using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class changedAttributeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy_Name",
                table: "Events",
                newName: "CreatedByName");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy_Name",
                table: "Events",
                newName: "ApprovedByName");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                table: "Admins",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedByName",
                table: "Events",
                newName: "CreatedBy_Name");

            migrationBuilder.RenameColumn(
                name: "ApprovedByName",
                table: "Events",
                newName: "ApprovedBy_Name");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Admins",
                newName: "ProfilePictureUrl");
        }
    }
}
