using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class AdminRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "Profesores",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Profesores",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Profesores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_UserId",
                table: "Profesores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Users_UserId",
                table: "Profesores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Users_UserId",
                table: "Profesores");

            migrationBuilder.DropIndex(
                name: "IX_Profesores_UserId",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Profesores");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "Profesores",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Profesores",
                newName: "Contraseña");
        }
    }
}
