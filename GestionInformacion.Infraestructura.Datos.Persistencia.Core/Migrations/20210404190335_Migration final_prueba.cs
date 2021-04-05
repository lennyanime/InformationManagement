using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Migrations
{
    public partial class Migrationfinal_prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "Provider",
                newName: "DocumentNumber");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "Employee",
                newName: "DocumentNumber");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "Client",
                newName: "DocumentNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Provider",
                newName: "IdNumber");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Employee",
                newName: "IdNumber");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Client",
                newName: "IdNumber");
        }
    }
}
