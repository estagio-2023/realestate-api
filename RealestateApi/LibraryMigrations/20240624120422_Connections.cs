using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Connections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "pk_real_estates",
                table: "real_estates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_visit_request",
                table: "visit_request");

            migrationBuilder.DropPrimaryKey(
                name: "pk_typology",
                table: "typology");

            migrationBuilder.DropPrimaryKey(
                name: "pk_real_estate_type",
                table: "real_estate_type");

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

            migrationBuilder.RenameTable(
                name: "visit_request",
                newName: "visits_requests");

            migrationBuilder.RenameTable(
                name: "typology",
                newName: "typologies");

            migrationBuilder.RenameTable(
                name: "real_estate_type",
                newName: "realestate_types");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "customers");

            migrationBuilder.RenameTable(
                name: "city",
                newName: "cities");

            migrationBuilder.RenameTable(
                name: "amenity",
                newName: "amenities");

            migrationBuilder.RenameTable(
                name: "agent",
                newName: "agents");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "real_estates",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "real_estates",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "real_estates",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "real_estates",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "real_estates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "real_estates",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "typology_id",
                table: "real_estates",
                newName: "TypologyId");

            migrationBuilder.RenameColumn(
                name: "square_meter",
                table: "real_estates",
                newName: "SquareMeter");

            migrationBuilder.RenameColumn(
                name: "real_estate_type_id",
                table: "real_estates",
                newName: "RealEstateTypeId");

            migrationBuilder.RenameColumn(
                name: "energy_class",
                table: "real_estates",
                newName: "EnergyClass");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "real_estates",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                table: "real_estates",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "build_date",
                table: "real_estates",
                newName: "BuildDate");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_typology_id",
                table: "real_estates",
                newName: "IX_real_estates_TypologyId");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_real_estate_type_id",
                table: "real_estates",
                newName: "IX_real_estates_RealEstateTypeId");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_customer_id",
                table: "real_estates",
                newName: "IX_real_estates_CustomerId");

            migrationBuilder.RenameIndex(
                name: "ix_real_estates_city_id",
                table: "real_estates",
                newName: "IX_real_estates_CityId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "visits_requests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "visits_requests",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "visits_requests",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "confirmed",
                table: "visits_requests",
                newName: "Confirmed");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "visits_requests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_time",
                table: "visits_requests",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "real_estate_id",
                table: "visits_requests",
                newName: "RealEstateId");

            migrationBuilder.RenameColumn(
                name: "end_time",
                table: "visits_requests",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "agent_id",
                table: "visits_requests",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "ix_visit_request_real_estate_id",
                table: "visits_requests",
                newName: "IX_visits_requests_RealEstateId");

            migrationBuilder.RenameIndex(
                name: "ix_visit_request_agent_id",
                table: "visits_requests",
                newName: "IX_visits_requests_AgentId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "typologies",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "typologies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "realestate_types",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "realestate_types",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "customers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "customers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "cities",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "amenities",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "amenities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "agents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "agents",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "agents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "agents",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "real_estates",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "real_estates",
                type: "numeric(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "real_estates",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "real_estates",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "real_estates",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "EnergyClass",
                table: "real_estates",
                type: "character varying(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "visits_requests",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "visits_requests",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "typologies",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "realestate_types",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "customers",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "customers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "customers",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "cities",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "amenities",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "agents",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "agents",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "agents",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_real_estates",
                table: "real_estates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visits_requests",
                table: "visits_requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_typologies",
                table: "typologies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_realestate_types",
                table: "realestate_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_amenities",
                table: "amenities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agents",
                table: "agents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RealEstateHasAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RealEstatelId = table.Column<int>(type: "integer", nullable: false),
                    AmenitiesId = table.Column<int>(type: "integer", nullable: false),
                    RealEstateId = table.Column<int>(type: "integer", nullable: false),
                    AmenityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateHasAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateHasAmenities_amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateHasAmenities_real_estates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "real_estates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateHasAmenities_AmenityId",
                table: "RealEstateHasAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateHasAmenities_RealEstateId",
                table: "RealEstateHasAmenities",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_real_estates_cities_CityId",
                table: "real_estates",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_real_estates_customers_CustomerId",
                table: "real_estates",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_real_estates_realestate_types_RealEstateTypeId",
                table: "real_estates",
                column: "RealEstateTypeId",
                principalTable: "realestate_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_real_estates_typologies_TypologyId",
                table: "real_estates",
                column: "TypologyId",
                principalTable: "typologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visits_requests_agents_AgentId",
                table: "visits_requests",
                column: "AgentId",
                principalTable: "agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visits_requests_real_estates_RealEstateId",
                table: "visits_requests",
                column: "RealEstateId",
                principalTable: "real_estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_real_estates_cities_CityId",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "FK_real_estates_customers_CustomerId",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "FK_real_estates_realestate_types_RealEstateTypeId",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "FK_real_estates_typologies_TypologyId",
                table: "real_estates");

            migrationBuilder.DropForeignKey(
                name: "FK_visits_requests_agents_AgentId",
                table: "visits_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_visits_requests_real_estates_RealEstateId",
                table: "visits_requests");

            migrationBuilder.DropTable(
                name: "RealEstateHasAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_real_estates",
                table: "real_estates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_visits_requests",
                table: "visits_requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_typologies",
                table: "typologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_realestate_types",
                table: "realestate_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_amenities",
                table: "amenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agents",
                table: "agents");

            migrationBuilder.RenameTable(
                name: "visits_requests",
                newName: "visit_request");

            migrationBuilder.RenameTable(
                name: "typologies",
                newName: "typology");

            migrationBuilder.RenameTable(
                name: "realestate_types",
                newName: "real_estate_type");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "customer");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "city");

            migrationBuilder.RenameTable(
                name: "amenities",
                newName: "amenity");

            migrationBuilder.RenameTable(
                name: "agents",
                newName: "agent");

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
                name: "IX_real_estates_TypologyId",
                table: "real_estates",
                newName: "ix_real_estates_typology_id");

            migrationBuilder.RenameIndex(
                name: "IX_real_estates_RealEstateTypeId",
                table: "real_estates",
                newName: "ix_real_estates_real_estate_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_real_estates_CustomerId",
                table: "real_estates",
                newName: "ix_real_estates_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_real_estates_CityId",
                table: "real_estates",
                newName: "ix_real_estates_city_id");

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
                name: "IX_visits_requests_RealEstateId",
                table: "visit_request",
                newName: "ix_visit_request_real_estate_id");

            migrationBuilder.RenameIndex(
                name: "IX_visits_requests_AgentId",
                table: "visit_request",
                newName: "ix_visit_request_agent_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "typology",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "typology",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "real_estate_type",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "real_estate_type",
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

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "real_estates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "real_estates",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(8,2)",
                oldPrecision: 8,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "real_estates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "real_estates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                table: "real_estates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "energy_class",
                table: "real_estates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "visit_request",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "visit_request",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "typology",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "real_estate_type",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "customer",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "customer",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "customer",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "city",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "amenity",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "agent",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "agent",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "agent",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13);

            migrationBuilder.AddPrimaryKey(
                name: "pk_real_estates",
                table: "real_estates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_visit_request",
                table: "visit_request",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_typology",
                table: "typology",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_real_estate_type",
                table: "real_estate_type",
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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_visit_request_real_estates_real_estate_id",
                table: "visit_request",
                column: "real_estate_id",
                principalTable: "real_estates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
