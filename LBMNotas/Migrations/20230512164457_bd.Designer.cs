﻿// <auto-generated />
using LBMNotas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LBMNotas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230512164457_bd")]
    partial class bd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LBMNotas.Models.Alumnos", b =>
                {
                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CursosId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rut");

                    b.HasIndex("CursosId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("LBMNotas.Models.Asignaturas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadesId")
                        .HasColumnType("int");

                    b.Property<int>("cursosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cursosId");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("LBMNotas.Models.CursoAsignatura", b =>
                {
                    b.Property<int>("CursosId")
                        .HasColumnType("int");

                    b.Property<int>("AsignaturasId")
                        .HasColumnType("int");

                    b.HasKey("CursosId", "AsignaturasId");

                    b.HasIndex("AsignaturasId");

                    b.ToTable("CursoAsignaturas");
                });

            modelBuilder.Entity("LBMNotas.Models.Cursos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("LBMNotas.Models.EtapaUnidad", b =>
                {
                    b.Property<int>("UnidadesId")
                        .HasColumnType("int");

                    b.Property<int>("EtapasId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("UnidadesId", "EtapasId");

                    b.HasIndex("EtapasId");

                    b.ToTable("EtapaUnidad");
                });

            modelBuilder.Entity("LBMNotas.Models.Etapas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Nota")
                        .HasColumnType("real");

                    b.Property<int>("Porcentaje")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Etapas");
                });

            modelBuilder.Entity("LBMNotas.Models.NotaFinalUnidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IDUnidad")
                        .HasColumnType("int");

                    b.Property<float>("NotaFinal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IDUnidad")
                        .IsUnique();

                    b.ToTable("NotaFinalUnidad");
                });

            modelBuilder.Entity("LBMNotas.Models.ProfesorAsignatura", b =>
                {
                    b.Property<int>("AsignaturasId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesoresId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("AsignaturasId", "ProfesoresId");

                    b.HasIndex("ProfesoresId");

                    b.ToTable("ProfesorAsignatura");
                });

            modelBuilder.Entity("LBMNotas.Models.Profesores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("LBMNotas.Models.Unidades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AsignaturasID")
                        .HasColumnType("int");

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturasID");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("LBMNotas.Models.Alumnos", b =>
                {
                    b.HasOne("LBMNotas.Models.Cursos", "Cursos")
                        .WithMany("Alumnos")
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("LBMNotas.Models.Asignaturas", b =>
                {
                    b.HasOne("LBMNotas.Models.Cursos", "cursos")
                        .WithMany()
                        .HasForeignKey("cursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cursos");
                });

            modelBuilder.Entity("LBMNotas.Models.CursoAsignatura", b =>
                {
                    b.HasOne("LBMNotas.Models.Asignaturas", "Asignaturas")
                        .WithMany("CursoAsignaturas")
                        .HasForeignKey("AsignaturasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LBMNotas.Models.Cursos", "Cursos")
                        .WithMany("CursoAsignaturas")
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asignaturas");

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("LBMNotas.Models.EtapaUnidad", b =>
                {
                    b.HasOne("LBMNotas.Models.Etapas", "Etapas")
                        .WithMany("EtapasUnidad")
                        .HasForeignKey("EtapasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBMNotas.Models.Unidades", "Unidades")
                        .WithMany("EtapasUnidad")
                        .HasForeignKey("UnidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etapas");

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("LBMNotas.Models.NotaFinalUnidad", b =>
                {
                    b.HasOne("LBMNotas.Models.Unidades", "unidades")
                        .WithOne("notaFinalUnidad")
                        .HasForeignKey("LBMNotas.Models.NotaFinalUnidad", "IDUnidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("unidades");
                });

            modelBuilder.Entity("LBMNotas.Models.ProfesorAsignatura", b =>
                {
                    b.HasOne("LBMNotas.Models.Asignaturas", "Asignaturas")
                        .WithMany("ProfesorAsignaturas")
                        .HasForeignKey("AsignaturasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBMNotas.Models.Profesores", "Profesores")
                        .WithMany("ProfesoresAsignaturas")
                        .HasForeignKey("ProfesoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignaturas");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("LBMNotas.Models.Unidades", b =>
                {
                    b.HasOne("LBMNotas.Models.Asignaturas", "Asignaturas")
                        .WithMany("Unidades")
                        .HasForeignKey("AsignaturasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("LBMNotas.Models.Asignaturas", b =>
                {
                    b.Navigation("CursoAsignaturas");

                    b.Navigation("ProfesorAsignaturas");

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("LBMNotas.Models.Cursos", b =>
                {
                    b.Navigation("Alumnos");

                    b.Navigation("CursoAsignaturas");
                });

            modelBuilder.Entity("LBMNotas.Models.Etapas", b =>
                {
                    b.Navigation("EtapasUnidad");
                });

            modelBuilder.Entity("LBMNotas.Models.Profesores", b =>
                {
                    b.Navigation("ProfesoresAsignaturas");
                });

            modelBuilder.Entity("LBMNotas.Models.Unidades", b =>
                {
                    b.Navigation("EtapasUnidad");

                    b.Navigation("notaFinalUnidad")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
