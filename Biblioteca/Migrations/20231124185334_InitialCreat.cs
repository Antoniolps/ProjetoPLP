using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "biblioteca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biblioteca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BibliotecaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_biblioteca_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "biblioteca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "bit", nullable: false),
                    BibliotecaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_livros_biblioteca_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "biblioteca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_livros_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    livroId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    dataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BibliotecaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emprestimos_biblioteca_BibliotecaId",
                        column: x => x.BibliotecaId,
                        principalTable: "biblioteca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_emprestimos_livros_livroId",
                        column: x => x.livroId,
                        principalTable: "livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emprestimos_usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_BibliotecaId",
                table: "emprestimos",
                column: "BibliotecaId");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_livroId",
                table: "emprestimos",
                column: "livroId");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_usuarioId",
                table: "emprestimos",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_livros_BibliotecaId",
                table: "livros",
                column: "BibliotecaId");

            migrationBuilder.CreateIndex(
                name: "IX_livros_UsuarioId",
                table: "livros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_BibliotecaId",
                table: "usuarios",
                column: "BibliotecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimos");

            migrationBuilder.DropTable(
                name: "livros");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "biblioteca");
        }
    }
}
