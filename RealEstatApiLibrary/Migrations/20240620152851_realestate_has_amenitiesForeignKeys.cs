using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class realestate_has_amenitiesForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_realestate_has_amenities_amenities_id",
                table: "realestate_has_amenities",
                column: "amenities_id");

            migrationBuilder.CreateIndex(
                name: "IX_realestate_has_amenities_realestate_id",
                table: "realestate_has_amenities",
                column: "realestate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_realestate_has_amenities_amenities_amenities_id",
                table: "realestate_has_amenities",
                column: "amenities_id",
                principalTable: "amenities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_realestate_has_amenities_realestates_realestate_id",
                table: "realestate_has_amenities",
                column: "realestate_id",
                principalTable: "realestates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_realestate_has_amenities_amenities_amenities_id",
                table: "realestate_has_amenities");

            migrationBuilder.DropForeignKey(
                name: "FK_realestate_has_amenities_realestates_realestate_id",
                table: "realestate_has_amenities");

            migrationBuilder.DropIndex(
                name: "IX_realestate_has_amenities_amenities_id",
                table: "realestate_has_amenities");

            migrationBuilder.DropIndex(
                name: "IX_realestate_has_amenities_realestate_id",
                table: "realestate_has_amenities");
        }
    }
}
