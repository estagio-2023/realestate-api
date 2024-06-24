using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    /// <inheritdoc />
    public partial class updatedColumnsToLowerCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "real_estate_type",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "real_estate_type",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "customer",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "customer",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "customer",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customer",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "city",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "city",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "amenity",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "amenity",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "agent",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "agent",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "agent",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "agent",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "real_estate_type",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "real_estate_type",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "customer",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "customer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "customer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "customer",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "city",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "city",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "amenity",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "amenity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "agent",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "agent",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "agent",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "agent",
                newName: "Id");
        }
    }
}
