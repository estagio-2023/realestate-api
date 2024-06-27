using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkApiLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InsertCityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO Cities (Description) values('Odivelas'),('Seixal'),('Gondomar'),('Terraço'),('Valongo'),('Vila Nova de Gaia'),('Aveiro'),('Braga'),('Coimbra'),('Faro'),('Funchal'),('Guimarães'),('Ponta Delgada'),('Póvoa de Varzim'),('Setúbal'),('Sintra'),('Viana do Castelo'),('Vila Franca de Xira'),('Viseu');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE Cities");
        }
    }
}
