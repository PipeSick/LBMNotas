using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class dbupdatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoAsignaturas");

            migrationBuilder.DropTable(
                name: "EtapaUnidad");

            migrationBuilder.RenameColumn(
                name: "UnidadesId",
                table: "Asignaturas",
                newName: "CursosId");

            migrationBuilder.AddColumn<int>(
                name: "UnidadesId",
                table: "Etapas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_UnidadesId",
                table: "Etapas",
                column: "UnidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_CursosId",
                table: "Asignaturas",
                column: "CursosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_Cursos_CursosId",
                table: "Asignaturas",
                column: "CursosId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Etapas_Unidades_UnidadesId",
                table: "Etapas",
                column: "UnidadesId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Cursos_CursosId",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Etapas_Unidades_UnidadesId",
                table: "Etapas");

            migrationBuilder.DropIndex(
                name: "IX_Etapas_UnidadesId",
                table: "Etapas");

            migrationBuilder.DropIndex(
                name: "IX_Asignaturas_CursosId",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "UnidadesId",
                table: "Etapas");

            migrationBuilder.RenameColumn(
                name: "CursosId",
                table: "Asignaturas",
                newName: "UnidadesId");

            migrationBuilder.CreateTable(
                name: "CursoAsignaturas",
                columns: table => new
                {
                    CursosId = table.Column<int>(type: "int", nullable: false),
                    AsignaturasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoAsignaturas", x => new { x.CursosId, x.AsignaturasId });
                    table.ForeignKey(
                        name: "FK_CursoAsignaturas_Asignaturas_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursoAsignaturas_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EtapaUnidad",
                columns: table => new
                {
                    UnidadesId = table.Column<int>(type: "int", nullable: false),
                    EtapasId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaUnidad", x => new { x.UnidadesId, x.EtapasId });
                    table.ForeignKey(
                        name: "FK_EtapaUnidad_Etapas_EtapasId",
                        column: x => x.EtapasId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtapaUnidad_Unidades_UnidadesId",
                        column: x => x.UnidadesId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoAsignaturas_AsignaturasId",
                table: "CursoAsignaturas",
                column: "AsignaturasId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaUnidad_EtapasId",
                table: "EtapaUnidad",
                column: "EtapasId");
        }
    }
}
