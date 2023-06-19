using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class pruebaprofeasignatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorAsignatura_Profesores_ProfesoresId",
                table: "ProfesorAsignatura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfesorAsignatura",
                table: "ProfesorAsignatura");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Profesores");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProfesoresId",
                table: "ProfesorAsignatura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProfesorAsignatura",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfesorAsignatura",
                table: "ProfesorAsignatura",
                columns: new[] { "UserId", "AsignaturasId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorAsignatura_AsignaturasId",
                table: "ProfesorAsignatura",
                column: "AsignaturasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorAsignatura_Profesores_ProfesoresId",
                table: "ProfesorAsignatura",
                column: "ProfesoresId",
                principalTable: "Profesores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorAsignatura_Users_UserId",
                table: "ProfesorAsignatura",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorAsignatura_Profesores_ProfesoresId",
                table: "ProfesorAsignatura");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorAsignatura_Users_UserId",
                table: "ProfesorAsignatura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfesorAsignatura",
                table: "ProfesorAsignatura");

            migrationBuilder.DropIndex(
                name: "IX_ProfesorAsignatura_AsignaturasId",
                table: "ProfesorAsignatura");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfesorAsignatura");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Profesores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Profesores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ProfesoresId",
                table: "ProfesorAsignatura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfesorAsignatura",
                table: "ProfesorAsignatura",
                columns: new[] { "AsignaturasId", "ProfesoresId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorAsignatura_Profesores_ProfesoresId",
                table: "ProfesorAsignatura",
                column: "ProfesoresId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
