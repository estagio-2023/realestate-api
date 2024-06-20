using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class visit_requestsForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_visit_requests_agent_id",
                table: "visit_requests",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "IX_visit_requests_realestate_id",
                table: "visit_requests",
                column: "realestate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_visit_requests_agents_agent_id",
                table: "visit_requests",
                column: "agent_id",
                principalTable: "agents",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visit_requests_realestates_realestate_id",
                table: "visit_requests",
                column: "realestate_id",
                principalTable: "realestates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visit_requests_agents_agent_id",
                table: "visit_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_visit_requests_realestates_realestate_id",
                table: "visit_requests");

            migrationBuilder.DropIndex(
                name: "IX_visit_requests_agent_id",
                table: "visit_requests");

            migrationBuilder.DropIndex(
                name: "IX_visit_requests_realestate_id",
                table: "visit_requests");
        }
    }
}
