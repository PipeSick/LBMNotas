using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class correcciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFinalUnidad_Unidades_IDUnidad",
                table: "NotaFinalUnidad");

            migrationBuilder.DropIndex(
                name: "IX_NotaFinalUnidad_IDUnidad",
                table: "NotaFinalUnidad");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_NotaFinalUnidad_IDUnidad",
                table: "NotaFinalUnidad",
                column: "IDUnidad",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFinalUnidad_Unidades_IDUnidad",
                table: "NotaFinalUnidad",
                column: "IDUnidad",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
