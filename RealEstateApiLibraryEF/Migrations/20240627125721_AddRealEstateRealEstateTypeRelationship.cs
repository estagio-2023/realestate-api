using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRealEstateRealEstateTypeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "real_estate_type_id",
                table: "real_estates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_real_estate_type_id",
                table: "real_estates",
                column: "real_estate_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_real_estate_types_real_estate_type_id",
                table: "real_estates",
                column: "real_estate_type_id",
                principalTable: "realestate_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_real_estate_types_real_estate_type_id",
                table: "real_estates");

            migrationBuilder.DropIndex(
                name: "ix_real_estates_real_estate_type_id",
                table: "real_estates");

            migrationBuilder.DropColumn(
                name: "real_estate_type_id",
                table: "real_estates");
        }
    }
}
