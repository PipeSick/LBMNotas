﻿// <auto-generated />
using System;
using LBMNotas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LBMNotas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LBMNotas.Models.AlumnoCurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlumnosId")
                        .HasColumnType("int");

                    b.Property<int>("CursosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnosId");

                    b.HasIndex("CursosId");

                    b.ToTable("alumnoCursos");
                });

            modelBuilder.Entity("LBMNotas.Models.Alumnos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroLista")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("LBMNotas.Models.Asignaturas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CursosId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursosId");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("LBMNotas.Models.CalificacionAlumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("EtapaId")
                        .HasColumnType("int");

                    b.Property<float>("Nota")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("EtapaId");

                    b.ToTable("calificacionAlumnos");
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

            modelBuilder.Entity("LBMNotas.Models.Etapas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Porcentaje")
                        .HasColumnType("int");

                    b.Property<int>("UnidadesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnidadesId");

                    b.ToTable("Etapas");
                });

            modelBuilder.Entity("LBMNotas.Models.NotaFinalUnidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<float>("NotaFinal")
                        .HasColumnType("real");

                    b.Property<int>("UnidadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("UnidadId");

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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturasID");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("LBMNotas.Models.AlumnoCurso", b =>
                {
                    b.HasOne("LBMNotas.Models.Alumnos", "Alumnos")
                        .WithMany("alumnoCursos")
                        .HasForeignKey("AlumnosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBMNotas.Models.Cursos", "Cursos")
                        .WithMany("alumnoCursos")
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumnos");

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("LBMNotas.Models.Asignaturas", b =>
                {
                    b.HasOne("LBMNotas.Models.Cursos", "Cursos")
                        .WithMany("Asignaturas")
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("LBMNotas.Models.CalificacionAlumno", b =>
                {
                    b.HasOne("LBMNotas.Models.Alumnos", "Alumno")
                        .WithMany("Calificaciones")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBMNotas.Models.Etapas", "Etapa")
                        .WithMany("Calificacion")
                        .HasForeignKey("EtapaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Etapa");
                });

            modelBuilder.Entity("LBMNotas.Models.Etapas", b =>
                {
                    b.HasOne("LBMNotas.Models.Unidades", "Unidades")
                        .WithMany("Etapas")
                        .HasForeignKey("UnidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("LBMNotas.Models.NotaFinalUnidad", b =>
                {
                    b.HasOne("LBMNotas.Models.Alumnos", "Alumno")
                        .WithMany("NotaFinalUnidads")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBMNotas.Models.Unidades", "Unidad")
                        .WithMany("notaFinalUnidad")
                        .HasForeignKey("UnidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Unidad");
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

            modelBuilder.Entity("LBMNotas.Models.Profesores", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
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

            modelBuilder.Entity("LBMNotas.Models.Alumnos", b =>
                {
                    b.Navigation("Calificaciones");

                    b.Navigation("NotaFinalUnidads");

                    b.Navigation("alumnoCursos");
                });

            modelBuilder.Entity("LBMNotas.Models.Asignaturas", b =>
                {
                    b.Navigation("ProfesorAsignaturas");

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("LBMNotas.Models.Cursos", b =>
                {
                    b.Navigation("Asignaturas");

                    b.Navigation("alumnoCursos");
                });

            modelBuilder.Entity("LBMNotas.Models.Etapas", b =>
                {
                    b.Navigation("Calificacion");
                });

            modelBuilder.Entity("LBMNotas.Models.Profesores", b =>
                {
                    b.Navigation("ProfesoresAsignaturas");
                });

            modelBuilder.Entity("LBMNotas.Models.Unidades", b =>
                {
                    b.Navigation("Etapas");

                    b.Navigation("notaFinalUnidad");
                });
#pragma warning restore 612, 618
        }
    }
}
