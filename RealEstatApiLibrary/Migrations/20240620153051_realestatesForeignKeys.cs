using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class realestatesForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_realestates_city_id",
                table: "realestates",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_realestates_customer_id",
                table: "realestates",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_realestates_realestate_id",
                table: "realestates",
                column: "realestate_id");

            migrationBuilder.CreateIndex(
                name: "IX_realestates_typology_id",
                table: "realestates",
                column: "typology_id");

            migrationBuilder.AddForeignKey(
                name: "FK_realestates_cities_city_id",
                table: "realestates",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_realestates_customers_customer_id",
                table: "realestates",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_realestates_realestate_types_realestate_id",
                table: "realestates",
                column: "realestate_id",
                principalTable: "realestate_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_realestates_typologies_typology_id",
                table: "realestates",
                column: "typology_id",
                principalTable: "typologies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_realestates_cities_city_id",
                table: "realestates");

            migrationBuilder.DropForeignKey(
                name: "FK_realestates_customers_customer_id",
                table: "realestates");

            migrationBuilder.DropForeignKey(
                name: "FK_realestates_realestate_types_realestate_id",
                table: "realestates");

            migrationBuilder.DropForeignKey(
                name: "FK_realestates_typologies_typology_id",
                table: "realestates");

            migrationBuilder.DropIndex(
                name: "IX_realestates_city_id",
                table: "realestates");

            migrationBuilder.DropIndex(
                name: "IX_realestates_customer_id",
                table: "realestates");

            migrationBuilder.DropIndex(
                name: "IX_realestates_realestate_id",
                table: "realestates");

            migrationBuilder.DropIndex(
                name: "IX_realestates_typology_id",
                table: "realestates");
        }
    }
}
