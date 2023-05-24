using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LBMNotas.Migrations
{
    /// <inheritdoc />
    public partial class alumnoprofesorrol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT Id from Roles where Id = '86cb14c6-0fb3-4e16-a705-fa847de64558')
                    BEGIN
                          INSERT Roles(Id, [Name], [NormalizedName])
	                      VALUES ('86cb14c6-0fb3-4e16-a705-fa847de64558','profesor','PROFESOR')
                    END
                ");
            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT Id from Roles where Id = '8c7b7f83-f4f9-4081-8d40-dfdb33a7168d')
                        BEGIN
                              INSERT Roles(Id, [Name], [NormalizedName])
	                          VALUES ('8c7b7f83-f4f9-4081-8d40-dfdb33a7168d','alumno','alumno')
                        END
                ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Roles where Id = '8c7b7f83-f4f9-4081-8d40-dfdb33a7168d'");
            migrationBuilder.Sql("DELETE Roles where Id = '86cb14c6-0fb3-4e16-a705-fa847de64558'");
        }
    }
}
