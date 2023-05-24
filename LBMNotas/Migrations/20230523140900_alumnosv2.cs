using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class alumnosv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alumnoCursos_Alumnos_AlumnosRut",
                table: "alumnoCursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_alumnoCursos_AlumnosRut",
                table: "alumnoCursos");

            migrationBuilder.DropColumn(
                name: "AlumnosRut",
                table: "alumnoCursos");

            migrationBuilder.AlterColumn<string>(
                name: "Rut",
                table: "Alumnos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Alumnos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AlumnosId",
                table: "alumnoCursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_alumnoCursos_AlumnosId",
                table: "alumnoCursos",
                column: "AlumnosId");

            migrationBuilder.AddForeignKey(
                name: "FK_alumnoCursos_Alumnos_AlumnosId",
                table: "alumnoCursos",
                column: "AlumnosId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alumnoCursos_Alumnos_AlumnosId",
                table: "alumnoCursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_alumnoCursos_AlumnosId",
                table: "alumnoCursos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "AlumnosId",
                table: "alumnoCursos");

            migrationBuilder.AlterColumn<string>(
                name: "Rut",
                table: "Alumnos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlumnosRut",
                table: "alumnoCursos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "Rut");

            migrationBuilder.CreateIndex(
                name: "IX_alumnoCursos_AlumnosRut",
                table: "alumnoCursos",
                column: "AlumnosRut");

            migrationBuilder.AddForeignKey(
                name: "FK_alumnoCursos_Alumnos_AlumnosRut",
                table: "alumnoCursos",
                column: "AlumnosRut",
                principalTable: "Alumnos",
                principalColumn: "Rut");
        }
    }
}
