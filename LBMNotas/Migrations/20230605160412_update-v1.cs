using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class updatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_calificacionAlumnos_EtapaId",
                table: "calificacionAlumnos");

            migrationBuilder.CreateIndex(
                name: "IX_calificacionAlumnos_EtapaId",
                table: "calificacionAlumnos",
                column: "EtapaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_calificacionAlumnos_EtapaId",
                table: "calificacionAlumnos");

            migrationBuilder.CreateIndex(
                name: "IX_calificacionAlumnos_EtapaId",
                table: "calificacionAlumnos",
                column: "EtapaId",
                unique: true);
        }
    }
}
