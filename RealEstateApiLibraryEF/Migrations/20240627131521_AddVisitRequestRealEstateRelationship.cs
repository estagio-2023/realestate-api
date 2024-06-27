using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitRequestRealEstateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_visits_requests_real_estate_id",
                table: "visits_requests",
                column: "real_estate_id");

            migrationBuilder.AddForeignKey(
                name: "fk_visits_requests_real_estates_real_estate_id",
                table: "visits_requests",
                column: "real_estate_id",
                principalTable: "real_estates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_visits_requests_real_estates_real_estate_id",
                table: "visits_requests");

            migrationBuilder.DropIndex(
                name: "ix_visits_requests_real_estate_id",
                table: "visits_requests");
        }
    }
}
