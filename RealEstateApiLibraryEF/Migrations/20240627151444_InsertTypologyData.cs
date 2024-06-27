using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class InsertTypologyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO typologies (Description) values('T0'),('T1'),('T2'),('T3'),('T4'),('T5');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE typologies");
        }
    }
}
