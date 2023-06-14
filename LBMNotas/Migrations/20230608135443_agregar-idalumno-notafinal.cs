using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class agregaridalumnonotafinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "NotaFinalUnidad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFinalUnidad_AlumnoId",
                table: "NotaFinalUnidad",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFinalUnidad_Alumnos_AlumnoId",
                table: "NotaFinalUnidad",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFinalUnidad_Alumnos_AlumnoId",
                table: "NotaFinalUnidad");

            migrationBuilder.DropIndex(
                name: "IX_NotaFinalUnidad_AlumnoId",
                table: "NotaFinalUnidad");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "NotaFinalUnidad");
        }
    }
}
