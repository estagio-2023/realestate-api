using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRealEstateHasAmenitiesRealEstateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_real_estate_has_amenities_real_estate_id",
                table: "real_estate_has_amenities",
                column: "real_estate_id");

            migrationBuilder.AddForeignKey(
                name: "fk_real_estate_has_amenities_real_estates_real_estate_id",
                table: "real_estate_has_amenities",
                column: "real_estate_id",
                principalTable: "real_estates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_real_estate_has_amenities_real_estates_real_estate_id",
                table: "real_estate_has_amenities");

            migrationBuilder.DropIndex(
                name: "ix_real_estate_has_amenities_real_estate_id",
                table: "real_estate_has_amenities");
        }
    }
}
