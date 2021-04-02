﻿// <auto-generated />
using System;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20210331013601_Migration Final")]
    partial class MigrationFinal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DominioGI.Administracion.Documento.DocumentTypeEntity", b =>
                {
                    b.Property<Guid>("TypeIdentificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdentificationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeIdentificationId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("DominioGI.Administracion.Personas.EmployeeEntity", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DocumentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("KindOfPerson")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("SignUpDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("job")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AreaId");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DominioGI.Administracion.Personas.ProviderEntity", b =>
                {
                    b.Property<Guid>("IdProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ContactNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("KindOfIdentificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KindOfPerson")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProviderIdTypeIdentificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("SignUpDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("IdProvider");

                    b.HasIndex("ProviderIdTypeIdentificationId");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("DominioGI.Administration.Person.ClientEntity", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DocumentIdTypeIdentificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("IdentificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KindOfPerson")
                        .HasColumnType("int");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("SignUpDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ClientId");

                    b.HasIndex("DocumentIdTypeIdentificationId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("DominioGI.Areas.AreaEntity", b =>
                {
                    b.Property<Guid>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResponsableEmployedId")
                        .HasMaxLength(30)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AreaId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("DominioGI.Administracion.Personas.EmployeeEntity", b =>
                {
                    b.HasOne("DominioGI.Areas.AreaEntity", "Area")
                        .WithMany("AreaEmployees")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DominioGI.Administracion.Documento.DocumentTypeEntity", "DocumentType")
                        .WithMany("EmployeesList")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("DominioGI.Administracion.Personas.ProviderEntity", b =>
                {
                    b.HasOne("DominioGI.Administracion.Documento.DocumentTypeEntity", "ProviderId")
                        .WithMany("ProvidersList")
                        .HasForeignKey("ProviderIdTypeIdentificationId");

                    b.Navigation("ProviderId");
                });

            modelBuilder.Entity("DominioGI.Administration.Person.ClientEntity", b =>
                {
                    b.HasOne("DominioGI.Administracion.Documento.DocumentTypeEntity", "DocumentId")
                        .WithMany("ClientsList")
                        .HasForeignKey("DocumentIdTypeIdentificationId");

                    b.Navigation("DocumentId");
                });

            modelBuilder.Entity("DominioGI.Administracion.Documento.DocumentTypeEntity", b =>
                {
                    b.Navigation("ClientsList");

                    b.Navigation("EmployeesList");

                    b.Navigation("ProvidersList");
                });

            modelBuilder.Entity("DominioGI.Areas.AreaEntity", b =>
                {
                    b.Navigation("AreaEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
