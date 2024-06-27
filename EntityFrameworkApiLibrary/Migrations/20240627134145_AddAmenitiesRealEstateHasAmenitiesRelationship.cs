using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenitiesRealEstateHasAmenitiesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_real_estate_has_amenities_amenities_id",
                table: "real_estate_has_amenities",
                column: "amenities_id");

            migrationBuilder.AddForeignKey(
                name: "fk_real_estate_has_amenities_amenities_amenities_id",
                table: "real_estate_has_amenities",
                column: "amenities_id",
                principalTable: "amenities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_real_estate_has_amenities_amenities_amenities_id",
                table: "real_estate_has_amenities");

            migrationBuilder.DropIndex(
                name: "ix_real_estate_has_amenities_amenities_id",
                table: "real_estate_has_amenities");
        }
    }
}
