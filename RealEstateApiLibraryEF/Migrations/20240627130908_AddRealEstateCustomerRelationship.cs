using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class AddRealEstateCustomerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "real_estates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_real_estates_customer_id",
                table: "real_estates",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_real_estates_customers_customer_id",
                table: "real_estates",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_real_estates_customers_customer_id",
                table: "real_estates");

            migrationBuilder.DropIndex(
                name: "ix_real_estates_customer_id",
                table: "real_estates");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "real_estates");
        }
    }
}
