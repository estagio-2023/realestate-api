using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddRealEstateTypologyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "typology_id",
                table: "real_estates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_typology_id",
                table: "real_estates",
                column: "typology_id");

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_typologies_typology_id",
                table: "real_estates",
                column: "typology_id",
                principalTable: "typologies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_typologies_typology_id",
                table: "real_estates");

            migrationBuilder.DropIndex(
                name: "ix_real_estates_typology_id",
                table: "real_estates");

            migrationBuilder.DropColumn(
                name: "typology_id",
                table: "real_estates");
        }
    }
}
