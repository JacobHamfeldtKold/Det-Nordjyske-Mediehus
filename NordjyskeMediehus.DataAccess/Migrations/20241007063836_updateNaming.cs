using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordjyskeMediehus.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "people",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "people",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "people",
                newName: "firstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "people",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "people",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "people",
                newName: "FirstName");
        }
    }
}
