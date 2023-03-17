using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroPessoa.API.Migrations
{
    public partial class adicionarcampoEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Enderecos",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Enderecos");
        }
    }
}
