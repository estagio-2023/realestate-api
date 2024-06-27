using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRealEstateCityRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "real_estates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_city_id",
                table: "real_estates",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_cities_city_id",
                table: "real_estates",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_cities_city_id",
                table: "real_estates");

            migrationBuilder.DropIndex(
                name: "ix_real_estates_city_id",
                table: "real_estates");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "real_estates");
        }
    }
}
