using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SnakeConvention2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_visit_request_agent_agent_id",
                table: "visit_request");

            migrationBuilder.AddForeignKey(
                name: "fk_visit_request_agent_agent_id",
                table: "visit_request",
                column: "agent_id",
                principalTable: "agent",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_visit_request_agent_agent_id",
                table: "visit_request");

            migrationBuilder.AddForeignKey(
                name: "fk_visit_request_agent_agent_id",
                table: "visit_request",
                column: "agent_id",
                principalTable: "agent",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
