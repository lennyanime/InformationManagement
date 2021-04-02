using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Migrations
{
    public partial class MigrationFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Document_DocumentIdKindOfIdentificationId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Document_ProviderIdKindOfIdentificationId",
                table: "Provider");

            migrationBuilder.RenameColumn(
                name: "ProviderIdKindOfIdentificationId",
                table: "Provider",
                newName: "ProviderIdTypeIdentificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Provider_ProviderIdKindOfIdentificationId",
                table: "Provider",
                newName: "IX_Provider_ProviderIdTypeIdentificationId");

            migrationBuilder.RenameColumn(
                name: "KindOfIdentificationId",
                table: "Document",
                newName: "TypeIdentificationId");

            migrationBuilder.RenameColumn(
                name: "DocumentIdKindOfIdentificationId",
                table: "Client",
                newName: "DocumentIdTypeIdentificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Client_DocumentIdKindOfIdentificationId",
                table: "Client",
                newName: "IX_Client_DocumentIdTypeIdentificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Document_DocumentIdTypeIdentificationId",
                table: "Client",
                column: "DocumentIdTypeIdentificationId",
                principalTable: "Document",
                principalColumn: "TypeIdentificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Document_ProviderIdTypeIdentificationId",
                table: "Provider",
                column: "ProviderIdTypeIdentificationId",
                principalTable: "Document",
                principalColumn: "TypeIdentificationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Document_DocumentIdTypeIdentificationId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Document_ProviderIdTypeIdentificationId",
                table: "Provider");

            migrationBuilder.RenameColumn(
                name: "ProviderIdTypeIdentificationId",
                table: "Provider",
                newName: "ProviderIdKindOfIdentificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Provider_ProviderIdTypeIdentificationId",
                table: "Provider",
                newName: "IX_Provider_ProviderIdKindOfIdentificationId");

            migrationBuilder.RenameColumn(
                name: "TypeIdentificationId",
                table: "Document",
                newName: "KindOfIdentificationId");

            migrationBuilder.RenameColumn(
                name: "DocumentIdTypeIdentificationId",
                table: "Client",
                newName: "DocumentIdKindOfIdentificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Client_DocumentIdTypeIdentificationId",
                table: "Client",
                newName: "IX_Client_DocumentIdKindOfIdentificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Document_DocumentIdKindOfIdentificationId",
                table: "Client",
                column: "DocumentIdKindOfIdentificationId",
                principalTable: "Document",
                principalColumn: "KindOfIdentificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Document_ProviderIdKindOfIdentificationId",
                table: "Provider",
                column: "ProviderIdKindOfIdentificationId",
                principalTable: "Document",
                principalColumn: "KindOfIdentificationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
