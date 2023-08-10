using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PP.Data.Migrations
{
    public partial class Migra01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    datanascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    funcionario = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projeto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    data_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_previsao_fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    orcamento = table.Column<double>(type: "double precision", nullable: false),
                    risco = table.Column<string>(type: "text", nullable: true),
                    idgerente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projeto", x => x.id);
                    table.ForeignKey(
                        name: "fk_gerente",
                        column: x => x.idgerente,
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "membros",
                columns: table => new
                {
                    idprojeto = table.Column<int>(type: "integer", nullable: false),
                    idpessoa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_membros_projeto", x => x.idprojeto);
                    table.ForeignKey(
                        name: "FK_membros_pessoa_idpessoa",
                        column: x => x.idpessoa,
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_membros_projeto_idprojeto",
                        column: x => x.idprojeto,
                        principalTable: "projeto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_membros_idpessoa",
                table: "membros",
                column: "idpessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projeto_idgerente",
                table: "projeto",
                column: "idgerente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "membros");

            migrationBuilder.DropTable(
                name: "projeto");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
