using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsableEmployedId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 30, nullable: false),
                    IdNumber = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KindOfPerson = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignUpDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    KindOfIdentificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KindOfPerson = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignUpDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.KindOfIdentificationId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentIdKindOfIdentificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNumber = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KindOfPerson = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignUpDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Document_DocumentIdKindOfIdentificationId",
                        column: x => x.DocumentIdKindOfIdentificationId,
                        principalTable: "Document",
                        principalColumn: "KindOfIdentificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KindOfPerson = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaOfWorkAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentIDKindOfIdentificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNumber = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignUpDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Area_AreaOfWorkAreaId",
                        column: x => x.AreaOfWorkAreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Document_DocumentIDKindOfIdentificationId",
                        column: x => x.DocumentIDKindOfIdentificationId,
                        principalTable: "Document",
                        principalColumn: "KindOfIdentificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    IdProvider = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    KindOfIdentificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderIdKindOfIdentificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNumber = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KindOfPerson = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignUpDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.IdProvider);
                    table.ForeignKey(
                        name: "FK_Provider_Document_ProviderIdKindOfIdentificationId",
                        column: x => x.ProviderIdKindOfIdentificationId,
                        principalTable: "Document",
                        principalColumn: "KindOfIdentificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_DocumentIdKindOfIdentificationId",
                table: "Client",
                column: "DocumentIdKindOfIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AreaOfWorkAreaId",
                table: "Employee",
                column: "AreaOfWorkAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DocumentIDKindOfIdentificationId",
                table: "Employee",
                column: "DocumentIDKindOfIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ProviderIdKindOfIdentificationId",
                table: "Provider",
                column: "ProviderIdKindOfIdentificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Document");
        }
    }
}
