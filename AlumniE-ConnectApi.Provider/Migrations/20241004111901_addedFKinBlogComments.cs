using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniE_ConnectApi.Provider.Migrations
{
    /// <inheritdoc />
    public partial class addedFKinBlogComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BlogsComments");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "BlogsComments",
                newName: "CreatedByStudentId");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByFacultyId",
                table: "BlogsComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Role",
                table: "BlogsComments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogsComments_CreatedByFacultyId",
                table: "BlogsComments",
                column: "CreatedByFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsComments_CreatedByStudentId",
                table: "BlogsComments",
                column: "CreatedByStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsComments_Faculties_CreatedByFacultyId",
                table: "BlogsComments",
                column: "CreatedByFacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsComments_Students_CreatedByStudentId",
                table: "BlogsComments",
                column: "CreatedByStudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsComments_Faculties_CreatedByFacultyId",
                table: "BlogsComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsComments_Students_CreatedByStudentId",
                table: "BlogsComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogsComments_CreatedByFacultyId",
                table: "BlogsComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogsComments_CreatedByStudentId",
                table: "BlogsComments");

            migrationBuilder.DropColumn(
                name: "CreatedByFacultyId",
                table: "BlogsComments");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "BlogsComments");

            migrationBuilder.RenameColumn(
                name: "CreatedByStudentId",
                table: "BlogsComments",
                newName: "UpdatedBy");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "BlogsComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
