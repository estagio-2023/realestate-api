using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SnakeConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_City_CityId",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Customer_CustomerId",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_RealEstateType_RealEstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Typology_TypologyId",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitRequest_Agent_AgentId",
                table: "VisitRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitRequest_RealEstates_RealEstateId",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates");

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

            migrationBuilder.RenameTable(
                name: "RealEstates",
                newName: "real_estates");

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
                name: "PhoneNumber",
                table: "agent",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "visit_request",
                newName: "name");

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
                name: "StartTime",
                table: "visit_request",
                newName: "start_time");

            migrationBuilder.RenameColumn(
                name: "RealEstateId",
                table: "visit_request",
                newName: "real_estate_id");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "visit_request",
                newName: "end_time");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "visit_request",
                newName: "agent_id");

            migrationBuilder.RenameIndex(
                name: "IX_VisitRequest_RealEstateId",
                table: "visit_request",
                newName: "ix_visit_request_real_estate_id");

            migrationBuilder.RenameIndex(
                name: "IX_VisitRequest_AgentId",
                table: "visit_request",
                newName: "ix_visit_request_agent_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "real_estate_type",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "real_estate_type",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "real_estates",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "real_estates",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "real_estates",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "real_estates",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "real_estates",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "real_estates",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "TypologyId",
                table: "real_estates",
                newName: "typology_id");

            migrationBuilder.RenameColumn(
                name: "SquareMeter",
                table: "real_estates",
                newName: "square_meter");

            migrationBuilder.RenameColumn(
                name: "RealEstateTypeId",
                table: "real_estates",
                newName: "real_estate_type_id");

            migrationBuilder.RenameColumn(
                name: "EnergyClass",
                table: "real_estates",
                newName: "energy_class");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "real_estates",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "real_estates",
                newName: "city_id");

            migrationBuilder.RenameColumn(
                name: "BuildDate",
                table: "real_estates",
                newName: "build_date");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstates_TypologyId",
                table: "real_estates",
                newName: "ix_real_estates_typology_id");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstates_RealEstateTypeId",
                table: "real_estates",
                newName: "ix_real_estates_real_estate_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstates_CustomerId",
                table: "real_estates",
                newName: "ix_real_estates_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstates_CityId",
                table: "real_estates",
                newName: "ix_real_estates_city_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_typology",
                table: "typology",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_customer",
                table: "customer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_city",
                table: "city",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_amenity",
                table: "amenity",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_agent",
                table: "agent",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_visit_request",
                table: "visit_request",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_real_estate_type",
                table: "real_estate_type",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_real_estates",
                table: "real_estates",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_city_city_id",
                table: "real_estates",
                column: "city_id",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_customer_customer_id",
                table: "real_estates",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_real_estate_type_real_estate_type_id",
                table: "real_estates",
                column: "real_estate_type_id",
                principalTable: "real_estate_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_typology_typology_id",
                table: "real_estates",
                column: "typology_id",
                principalTable: "typology",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_visit_request_agent_agent_id",
                table: "visit_request",
                column: "agent_id",
                principalTable: "agent",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_visit_request_real_estates_real_estate_id",
                table: "visit_request",
                column: "real_estate_id",
                principalTable: "real_estates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_city_city_id",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_customer_customer_id",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_real_estate_type_real_estate_type_id",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_typology_typology_id",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "fk_visit_request_agent_agent_id",
                table: "visit_request");

            migrationBuilder.DropForeignKey(
                name: "fk_visit_request_real_estates_real_estate_id",
                table: "visit_request");

            migrationBuilder.DropPrimaryKey(
                name: "pk_typology",
                table: "typology");

            migrationBuilder.DropPrimaryKey(
                name: "pk_customer",
                table: "customer");

            migrationBuilder.DropPrimaryKey(
                name: "pk_city",
                table: "city");

            migrationBuilder.DropPrimaryKey(
                name: "pk_amenity",
                table: "amenity");

            migrationBuilder.DropPrimaryKey(
                name: "pk_agent",
                table: "agent");

            migrationBuilder.DropPrimaryKey(
                name: "pk_visit_request",
                table: "visit_request");

            migrationBuilder.DropPrimaryKey(
                name: "pk_real_estates",
                table: "real_estates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_real_estate_type",
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
                name: "real_estates",
                newName: "RealEstates");

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
                name: "phone_number",
                table: "Agent",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "VisitRequest",
                newName: "Name");

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
                name: "start_time",
                table: "VisitRequest",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "real_estate_id",
                table: "VisitRequest",
                newName: "RealEstateId");

            migrationBuilder.RenameColumn(
                name: "end_time",
                table: "VisitRequest",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "agent_id",
                table: "VisitRequest",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "ix_visit_request_real_estate_id",
                table: "VisitRequest",
                newName: "IX_VisitRequest_RealEstateId");

            migrationBuilder.RenameIndex(
                name: "ix_visit_request_agent_id",
                table: "VisitRequest",
                newName: "IX_VisitRequest_AgentId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "RealEstates",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "RealEstates",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "RealEstates",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "RealEstates",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RealEstates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "RealEstates",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "typology_id",
                table: "RealEstates",
                newName: "TypologyId");

            migrationBuilder.RenameColumn(
                name: "square_meter",
                table: "RealEstates",
                newName: "SquareMeter");

            migrationBuilder.RenameColumn(
                name: "real_estate_type_id",
                table: "RealEstates",
                newName: "RealEstateTypeId");

            migrationBuilder.RenameColumn(
                name: "energy_class",
                table: "RealEstates",
                newName: "EnergyClass");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "RealEstates",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                table: "RealEstates",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "build_date",
                table: "RealEstates",
                newName: "BuildDate");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_typology_id",
                table: "RealEstates",
                newName: "IX_RealEstates_TypologyId");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_real_estate_type_id",
                table: "RealEstates",
                newName: "IX_RealEstates_RealEstateTypeId");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_customer_id",
                table: "RealEstates",
                newName: "IX_RealEstates_CustomerId");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_city_id",
                table: "RealEstates",
                newName: "IX_RealEstates_CityId");

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
                name: "PK_RealEstates",
                table: "RealEstates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstateType",
                table: "RealEstateType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_City_CityId",
                table: "RealEstates",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Customer_CustomerId",
                table: "RealEstates",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_RealEstateType_RealEstateTypeId",
                table: "RealEstates",
                column: "RealEstateTypeId",
                principalTable: "RealEstateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Typology_TypologyId",
                table: "RealEstates",
                column: "TypologyId",
                principalTable: "Typology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitRequest_Agent_AgentId",
                table: "VisitRequest",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitRequest_RealEstates_RealEstateId",
                table: "VisitRequest",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
