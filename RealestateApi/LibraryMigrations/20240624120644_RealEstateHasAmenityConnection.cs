using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RealEstateHasAmenityConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateHasAmenities_real_estates_RealEstateId",
                table: "RealEstateHasAmenities");

            migrationBuilder.DropColumn(
                name: "RealEstatelId",
                table: "RealEstateHasAmenities");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateHasAmenities_real_estates_RealEstateId",
                table: "RealEstateHasAmenities",
                column: "RealEstateId",
                principalTable: "real_estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateHasAmenities_real_estates_RealEstateId",
                table: "RealEstateHasAmenities");

            migrationBuilder.AddColumn<int>(
                name: "RealEstatelId",
                table: "RealEstateHasAmenities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateHasAmenities_real_estates_RealEstateId",
                table: "RealEstateHasAmenities",
                column: "RealEstateId",
                principalTable: "real_estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
