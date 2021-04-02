using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "job",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "job",
                table: "Employee");
        }
    }
}
