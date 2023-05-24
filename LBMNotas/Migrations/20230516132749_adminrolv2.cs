using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class adminrolv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT Id from Roles where Id = '1b76fb91-cd66-4ec5-a606-5aeb69c23c91')
                BEGIN
	                INSERT Roles(Id, [Name], [NormalizedName])
	                VALUES ('1b76fb91-cd66-4ec5-a606-5aeb69c23c91','admin','ADMIN')
                END
                ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Roles where Id = '1b76fb91-cd66-4ec5-a606-5aeb69c23c91'");

        }
    }
}
