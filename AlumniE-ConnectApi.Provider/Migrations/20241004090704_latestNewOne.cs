using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class latestNewOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserProfileHeadline",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserProfilePictureUrl",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BlogsTags",
                newName: "Id");

            migrationBuilder.AlterColumn<byte>(
                name: "Role",
                table: "Blogs",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByFacultyId",
                table: "Blogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByStudentId",
                table: "Blogs",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByFacultyId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CreatedByStudentId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BlogsTags",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserProfileHeadline",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfilePictureUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
