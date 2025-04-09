using Microsoft.EntityFrameworkCore.Migrations;

namespace Patterns.Migrations
{
    public partial class AtualizaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome_sub",
                table: "Sub_Iten",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "nome_assunto",
                table: "Assunto",
                newName: "nome");

            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "Usuario",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "senha",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Sub_Iten",
                newName: "nome_sub");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Assunto",
                newName: "nome_assunto");
        }
    }
}
