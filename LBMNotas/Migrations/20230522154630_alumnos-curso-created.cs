using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class alumnoscursocreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Cursos_CursosId",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Cursos_cursosId",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Users_UserId",
                table: "Profesores");

            migrationBuilder.DropIndex(
                name: "IX_Asignaturas_cursosId",
                table: "Asignaturas");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_CursosId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "cursosId",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Alumnos");

            migrationBuilder.RenameColumn(
                name: "CursosId",
                table: "Alumnos",
                newName: "NumeroLista");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripción",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Profesores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Rut",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Asignaturas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "alumnoCursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnosRut = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CursosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnoCursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alumnoCursos_Alumnos_AlumnosRut",
                        column: x => x.AlumnosRut,
                        principalTable: "Alumnos",
                        principalColumn: "Rut");
                    table.ForeignKey(
                        name: "FK_alumnoCursos_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alumnoCursos_AlumnosRut",
                table: "alumnoCursos",
                column: "AlumnosRut");

            migrationBuilder.CreateIndex(
                name: "IX_alumnoCursos_CursosId",
                table: "alumnoCursos",
                column: "CursosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Users_UserId",
                table: "Profesores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Users_UserId",
                table: "Profesores");

            migrationBuilder.DropTable(
                name: "alumnoCursos");

            migrationBuilder.RenameColumn(
                name: "NumeroLista",
                table: "Alumnos",
                newName: "CursosId");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripción",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Profesores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rut",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Asignaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cursosId",
                table: "Asignaturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Alumnos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_cursosId",
                table: "Asignaturas",
                column: "cursosId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CursosId",
                table: "Alumnos",
                column: "CursosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Cursos_CursosId",
                table: "Alumnos",
                column: "CursosId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_Cursos_cursosId",
                table: "Asignaturas",
                column: "cursosId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Users_UserId",
                table: "Profesores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
