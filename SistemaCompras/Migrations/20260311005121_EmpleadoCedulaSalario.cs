using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCompras.Migrations
{
    /// <inheritdoc />
    public partial class EmpleadoCedulaSalario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salario",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Empleados");
        }
    }
}
