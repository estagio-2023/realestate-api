using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "amenities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_amenities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", maxLength: 100, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "realestate_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_realestate_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "typologies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typologies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "real_estates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    zip_code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    build_date = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    square_meter = table.Column<int>(type: "integer", nullable: false),
                    energy_class = table.Column<string>(type: "text", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    real_estate_type_id = table.Column<int>(type: "integer", nullable: false),
                    typology_id = table.Column<int>(type: "integer", nullable: false),
                    amenities_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_real_estates", x => x.id);
                    table.ForeignKey(
                        name: "fk_real_estates_amenities_amenities_id",
                        column: x => x.amenities_id,
                        principalTable: "amenities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_real_estates_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_real_estates_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_real_estates_real_estate_types_real_estate_type_id",
                        column: x => x.real_estate_type_id,
                        principalTable: "realestate_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_real_estates_typologies_typology_id",
                        column: x => x.typology_id,
                        principalTable: "typologies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "realestate_has_amenities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    real_estate_id = table.Column<int>(type: "integer", nullable: false),
                    amenities_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_realestate_has_amenities", x => x.id);
                    table.ForeignKey(
                        name: "fk_realestate_has_amenities_amenities_amenities_id",
                        column: x => x.amenities_id,
                        principalTable: "amenities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_realestate_has_amenities_real_estates_real_estate_id",
                        column: x => x.real_estate_id,
                        principalTable: "real_estates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "visits_requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    agent_id = table.Column<int>(type: "integer", nullable: false),
                    realestate_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_visits_requests", x => x.id);
                    table.ForeignKey(
                        name: "fk_visits_requests_agents_agent_id",
                        column: x => x.agent_id,
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_visits_requests_real_estates_real_estate_id",
                        column: x => x.realestate_id,
                        principalTable: "real_estates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_amenities_id",
                table: "real_estates",
                column: "amenities_id");

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_city_id",
                table: "real_estates",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_customer_id",
                table: "real_estates",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_real_estate_type_id",
                table: "real_estates",
                column: "real_estate_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_typology_id",
                table: "real_estates",
                column: "typology_id");

            migrationBuilder.CreateIndex(
                name: "ix_realestate_has_amenities_amenities_id",
                table: "realestate_has_amenities",
                column: "amenities_id");

            migrationBuilder.CreateIndex(
                name: "ix_realestate_has_amenities_real_estate_id",
                table: "realestate_has_amenities",
                column: "real_estate_id");

            migrationBuilder.CreateIndex(
                name: "ix_visits_requests_agent_id",
                table: "visits_requests",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_visits_requests_real_estate_id",
                table: "visits_requests",
                column: "realestate_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "realestate_has_amenities");

            migrationBuilder.DropTable(
                name: "visits_requests");

            migrationBuilder.DropTable(
                name: "agents");

            migrationBuilder.DropTable(
                name: "real_estates");

            migrationBuilder.DropTable(
                name: "amenities");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "realestate_types");

            migrationBuilder.DropTable(
                name: "typologies");
        }
    }
}
