using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class InsertRealEstate_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO realestate_types (Description) values('Garage'),('Bedroom'),('House'),('Apartment'),('Studio');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE realestate_types");
        }
    }
}