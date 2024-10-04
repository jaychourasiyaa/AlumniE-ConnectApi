using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class updateidtoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "UsersSkills",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsersSkills",
                newName: "id");
        }
    }
}
