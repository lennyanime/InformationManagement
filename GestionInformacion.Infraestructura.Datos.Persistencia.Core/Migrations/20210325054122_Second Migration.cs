using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "FirstLastName",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "KindOfPerson",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "SecondLastName",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "SignUpDate",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "FirstLastName",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "KindOfPerson",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "SecondLastName",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "SignUpDate",
                table: "Area");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Document",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "FirstLastName",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdNumber",
                table: "Document",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "KindOfPerson",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondLastName",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SignUpDate",
                table: "Document",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Area",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "FirstLastName",
                table: "Area",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Area",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdNumber",
                table: "Area",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "KindOfPerson",
                table: "Area",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondLastName",
                table: "Area",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Area",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SignUpDate",
                table: "Area",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
