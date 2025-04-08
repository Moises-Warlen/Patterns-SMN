using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Patterns.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    cod_assunto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_assunto = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.cod_assunto);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Iten",
                columns: table => new
                {
                    cod_sub = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_sub = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Iten", x => x.cod_sub);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    cod_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ind_admin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.cod_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Postagem",
                columns: table => new
                {
                    cod_post = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    conteudo = table.Column<string>(type: "character varying(20000)", maxLength: 20000, nullable: false),
                    data_post = table.Column<DateTime>(type: "date", nullable: false),
                    cod_assunto = table.Column<int>(type: "integer", nullable: false),
                    cod_sub = table.Column<int>(type: "integer", nullable: false),
                    cod_usuario = table.Column<int>(type: "integer", nullable: false),
                    Assuntocod_assunto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postagem", x => x.cod_post);
                    table.ForeignKey(
                        name: "fk_postagem_assunto",
                        column: x => x.cod_assunto,
                        principalTable: "Assunto",
                        principalColumn: "cod_assunto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postagem_Assunto_Assuntocod_assunto",
                        column: x => x.Assuntocod_assunto,
                        principalTable: "Assunto",
                        principalColumn: "cod_assunto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_postagem_subiten",
                        column: x => x.cod_sub,
                        principalTable: "Sub_Iten",
                        principalColumn: "cod_sub",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_postagem_usuario",
                        column: x => x.cod_usuario,
                        principalTable: "Usuario",
                        principalColumn: "cod_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_Assuntocod_assunto",
                table: "Postagem",
                column: "Assuntocod_assunto");

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_cod_assunto",
                table: "Postagem",
                column: "cod_assunto");

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_cod_sub",
                table: "Postagem",
                column: "cod_sub");

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_cod_usuario",
                table: "Postagem",
                column: "cod_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postagem");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Sub_Iten");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
