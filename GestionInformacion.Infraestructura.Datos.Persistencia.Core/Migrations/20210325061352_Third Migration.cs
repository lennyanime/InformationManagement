using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Area_AreaOfWorkAreaId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Document_DocumentIDKindOfIdentificationId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AreaOfWorkAreaId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DocumentIDKindOfIdentificationId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AreaOfWorkAreaId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DocumentIDKindOfIdentificationId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AreaId",
                table: "Employee",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DocumentTypeId",
                table: "Employee",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Area_AreaId",
                table: "Employee",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Document_DocumentTypeId",
                table: "Employee",
                column: "DocumentTypeId",
                principalTable: "Document",
                principalColumn: "KindOfIdentificationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Area_AreaId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Document_DocumentTypeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AreaId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DocumentTypeId",
                table: "Employee");

            migrationBuilder.AddColumn<Guid>(
                name: "AreaOfWorkAreaId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentIDKindOfIdentificationId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AreaOfWorkAreaId",
                table: "Employee",
                column: "AreaOfWorkAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DocumentIDKindOfIdentificationId",
                table: "Employee",
                column: "DocumentIDKindOfIdentificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Area_AreaOfWorkAreaId",
                table: "Employee",
                column: "AreaOfWorkAreaId",
                principalTable: "Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Document_DocumentIDKindOfIdentificationId",
                table: "Employee",
                column: "DocumentIDKindOfIdentificationId",
                principalTable: "Document",
                principalColumn: "KindOfIdentificationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
