using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class InsertAmenitiesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO Amenities (Description) values('Laundry'),('Balcony'),('Pool'),('Terrace'),('Storage');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE Amenities");
        }
    }
}
