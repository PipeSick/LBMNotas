using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class alumnosnotacreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalificacionAlumno_Alumnos_AlumnoId",
                table: "CalificacionAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_CalificacionAlumno_Etapas_EtapaId",
                table: "CalificacionAlumno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalificacionAlumno",
                table: "CalificacionAlumno");

            migrationBuilder.RenameTable(
                name: "CalificacionAlumno",
                newName: "calificacionAlumnos");

            migrationBuilder.RenameIndex(
                name: "IX_CalificacionAlumno_EtapaId",
                table: "calificacionAlumnos",
                newName: "IX_calificacionAlumnos_EtapaId");

            migrationBuilder.RenameIndex(
                name: "IX_CalificacionAlumno_AlumnoId",
                table: "calificacionAlumnos",
                newName: "IX_calificacionAlumnos_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calificacionAlumnos",
                table: "calificacionAlumnos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_calificacionAlumnos_Alumnos_AlumnoId",
                table: "calificacionAlumnos",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calificacionAlumnos_Etapas_EtapaId",
                table: "calificacionAlumnos",
                column: "EtapaId",
                principalTable: "Etapas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_calificacionAlumnos_Alumnos_AlumnoId",
                table: "calificacionAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_calificacionAlumnos_Etapas_EtapaId",
                table: "calificacionAlumnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calificacionAlumnos",
                table: "calificacionAlumnos");

            migrationBuilder.RenameTable(
                name: "calificacionAlumnos",
                newName: "CalificacionAlumno");

            migrationBuilder.RenameIndex(
                name: "IX_calificacionAlumnos_EtapaId",
                table: "CalificacionAlumno",
                newName: "IX_CalificacionAlumno_EtapaId");

            migrationBuilder.RenameIndex(
                name: "IX_calificacionAlumnos_AlumnoId",
                table: "CalificacionAlumno",
                newName: "IX_CalificacionAlumno_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalificacionAlumno",
                table: "CalificacionAlumno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalificacionAlumno_Alumnos_AlumnoId",
                table: "CalificacionAlumno",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalificacionAlumno_Etapas_EtapaId",
                table: "CalificacionAlumno",
                column: "EtapaId",
                principalTable: "Etapas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
