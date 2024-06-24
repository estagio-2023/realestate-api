using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ColumnsToUpperCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visit_request_agent_agent_id",
                table: "visit_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_typology",
                table: "typology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_city",
                table: "city");

            migrationBuilder.DropPrimaryKey(
                name: "PK_amenity",
                table: "amenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agent",
                table: "agent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_visit_request",
                table: "visit_request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_real_estate_type",
                table: "real_estate_type");

            migrationBuilder.RenameTable(
                name: "typology",
                newName: "Typology");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "city",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "amenity",
                newName: "Amenity");

            migrationBuilder.RenameTable(
                name: "agent",
                newName: "Agent");

            migrationBuilder.RenameTable(
                name: "visit_request",
                newName: "VisitRequest");

            migrationBuilder.RenameTable(
                name: "real_estate_type",
                newName: "RealEstateType");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Typology",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Typology",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Customer",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customer",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "City",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "City",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Amenity",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Amenity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Agent",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Agent",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Agent",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Agent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "VisitRequest",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "VisitRequest",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "VisitRequest",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "VisitRequest",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "VisitRequest",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "confirmed",
                table: "VisitRequest",
                newName: "Confirmed");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "VisitRequest",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "real_estate_id",
                table: "VisitRequest",
                newName: "RealEstateId");

            migrationBuilder.RenameColumn(
                name: "agent_id",
                table: "VisitRequest",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_visit_request_agent_id",
                table: "VisitRequest",
                newName: "IX_VisitRequest_AgentId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "RealEstateType",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RealEstateType",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Typology",
                table: "Typology",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenity",
                table: "Amenity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agent",
                table: "Agent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitRequest",
                table: "VisitRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateType",
                table: "RealEstateType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitRequest_Agent_AgentId",
                table: "VisitRequest",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitRequest_Agent_AgentId",
                table: "VisitRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Typology",
                table: "Typology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenity",
                table: "Amenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agent",
                table: "Agent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitRequest",
                table: "VisitRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstateType",
                table: "RealEstateType");

            migrationBuilder.RenameTable(
                name: "Typology",
                newName: "typology");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "customer");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "city");

            migrationBuilder.RenameTable(
                name: "Amenity",
                newName: "amenity");

            migrationBuilder.RenameTable(
                name: "Agent",
                newName: "agent");

            migrationBuilder.RenameTable(
                name: "VisitRequest",
                newName: "visit_request");

            migrationBuilder.RenameTable(
                name: "RealEstateType",
                newName: "real_estate_type");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "typology",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "typology",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "customer",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "customer",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "customer",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customer",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "city",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "city",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "amenity",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "amenity",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "agent",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "agent",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "agent",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "agent",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "visit_request",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "visit_request",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "visit_request",
                newName: "endTime");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "visit_request",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "visit_request",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Confirmed",
                table: "visit_request",
                newName: "confirmed");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "visit_request",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RealEstateId",
                table: "visit_request",
                newName: "real_estate_id");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "visit_request",
                newName: "agent_id");

            migrationBuilder.RenameIndex(
                name: "IX_VisitRequest_AgentId",
                table: "visit_request",
                newName: "IX_visit_request_agent_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "real_estate_type",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "real_estate_type",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_typology",
                table: "typology",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_city",
                table: "city",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_amenity",
                table: "amenity",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agent",
                table: "agent",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visit_request",
                table: "visit_request",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_real_estate_type",
                table: "real_estate_type",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_visit_request_agent_agent_id",
                table: "visit_request",
                column: "agent_id",
                principalTable: "agent",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
