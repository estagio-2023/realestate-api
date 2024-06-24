using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RealEstateTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BuildDate = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SquareMeter = table.Column<int>(type: "integer", nullable: false),
                    EnergyClass = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    RealEstateTypeId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    TypologyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstates_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstates_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstates_RealEstateType_RealEstateTypeId",
                        column: x => x.RealEstateTypeId,
                        principalTable: "RealEstateType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstates_Typology_TypologyId",
                        column: x => x.TypologyId,
                        principalTable: "Typology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitRequest_RealEstateId",
                table: "VisitRequest",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_CityId",
                table: "RealEstates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_CustomerId",
                table: "RealEstates",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_RealEstateTypeId",
                table: "RealEstates",
                column: "RealEstateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_TypologyId",
                table: "RealEstates",
                column: "TypologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitRequest_RealEstates_RealEstateId",
                table: "VisitRequest",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitRequest_RealEstates_RealEstateId",
                table: "VisitRequest");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropIndex(
                name: "IX_VisitRequest_RealEstateId",
                table: "VisitRequest");
        }
    }
}
