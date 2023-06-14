using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class arreglostblnotafinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFinalUnidad_Unidades_unidadesId",
                table: "NotaFinalUnidad");

            migrationBuilder.DropIndex(
                name: "IX_NotaFinalUnidad_unidadesId",
                table: "NotaFinalUnidad");

            migrationBuilder.DropColumn(
                name: "unidadesId",
                table: "NotaFinalUnidad");

            migrationBuilder.RenameColumn(
                name: "IDUnidad",
                table: "NotaFinalUnidad",
                newName: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFinalUnidad_UnidadId",
                table: "NotaFinalUnidad",
                column: "UnidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFinalUnidad_Unidades_UnidadId",
                table: "NotaFinalUnidad",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFinalUnidad_Unidades_UnidadId",
                table: "NotaFinalUnidad");

            migrationBuilder.DropIndex(
                name: "IX_NotaFinalUnidad_UnidadId",
                table: "NotaFinalUnidad");

            migrationBuilder.RenameColumn(
                name: "UnidadId",
                table: "NotaFinalUnidad",
                newName: "IDUnidad");

            migrationBuilder.AddColumn<int>(
                name: "unidadesId",
                table: "NotaFinalUnidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFinalUnidad_unidadesId",
                table: "NotaFinalUnidad",
                column: "unidadesId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFinalUnidad_Unidades_unidadesId",
                table: "NotaFinalUnidad",
                column: "unidadesId",
                principalTable: "Unidades",
                principalColumn: "Id");
        }
    }
}
