using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddAgentVisitRequestRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_visits_requests_agent_id",
                table: "visits_requests",
                column: "agent_id");

            migrationBuilder.AddForeignKey(
                name: "fk_visits_requests_agents_agent_id",
                table: "visits_requests",
                column: "agent_id",
                principalTable: "agents",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_visits_requests_agents_agent_id",
                table: "visits_requests");

            migrationBuilder.DropIndex(
                name: "ix_visits_requests_agent_id",
                table: "visits_requests");
        }
    }
}
