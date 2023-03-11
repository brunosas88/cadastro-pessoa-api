using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroPessoa.API.Migrations
{
    public partial class cpftipocorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "PessoasFisicas",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cpf",
                table: "PessoasFisicas",
                type: "integer",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);
        }
    }
}
