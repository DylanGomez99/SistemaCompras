using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCompras.Migrations
{
    /// <inheritdoc />
    public partial class ArticuloMonto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "Articulos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Articulos");
        }
    }
}
