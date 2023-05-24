using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnaIsActiveAUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

        }
    }
}
