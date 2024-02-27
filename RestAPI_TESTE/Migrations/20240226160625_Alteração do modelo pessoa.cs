using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_TESTE.Migrations
{
    /// <inheritdoc />
    public partial class Alteraçãodomodelopessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SexoPessoa",
                table: "Pessoa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SexoPessoa",
                table: "Pessoa");
        }
    }
}
