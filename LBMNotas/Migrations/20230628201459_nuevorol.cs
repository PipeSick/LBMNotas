using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class nuevorol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT Id from Roles where Id = '9b32a8ca-a1ff-425b-b79c-2e6998becbe5')
                BEGIN
	                INSERT Roles(Id, [Name], [NormalizedName])
	                VALUES ('9b32a8ca-a1ff-425b-b79c-2e6998becbe5','tutor','TUTOR')
                END
                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Roles where Id = '9b32a8ca-a1ff-425b-b79c-2e6998becbe5'");

        }
    }
}
