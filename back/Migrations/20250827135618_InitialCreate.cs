using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumComputadores = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroPatrimonio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    NumLugares = table.Column<int>(type: "int", nullable: false),
                    Projetor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alocacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAlocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    NotebookId = table.Column<int>(type: "int", nullable: true),
                    SalaId = table.Column<int>(type: "int", nullable: true),
                    LaboratorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alocacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Laboratorios_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Notebooks_NotebookId",
                        column: x => x.NotebookId,
                        principalTable: "Notebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Cargo", "DataAdmissao", "Matricula", "Nome" },
                values: new object[,]
                {
                    { 1, "Programador Pleno", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567", "João Silva" },
                    { 2, "Analista", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9876543", "Maria Souza" },
                    { 3, "Estagiário", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1111111", "Carlos Pereira" }
                });

            migrationBuilder.InsertData(
                table: "Laboratorios",
                columns: new[] { "Id", "Descricao", "Nome", "NumComputadores" },
                values: new object[,]
                {
                    { 1, "20 PCs Dell Optiplex, Intel i5, 8GB RAM, 256GB SSD, Windows 10", "Lab de Informática 1", 20 },
                    { 2, "25 PCs Lenovo ThinkCentre, Intel i7, 16GB RAM, 512GB SSD, Linux Ubuntu", "Lab de Informática 2", 25 },
                    { 3, "15 PCs HP ProDesk, Intel i5, 16GB RAM, 1TB SSD, Kits Arduino e Raspberry Pi", "Lab de Robótica", 15 }
                });

            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "Id", "DataAquisicao", "Descricao", "NroPatrimonio" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dell Latitude 5420 - Intel i5, 16GB RAM, 512GB SSD", "1234567" },
                    { 2, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lenovo ThinkPad T14 - AMD Ryzen 5, 8GB RAM, 256GB SSD", "9876543" },
                    { 3, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HP EliteBook 840 G7 - Intel i7, 16GB RAM, 1TB SSD", "1111111" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Id", "NumLugares", "Numero", "Projetor" },
                values: new object[,]
                {
                    { 1, 30, 101, true },
                    { 2, 25, 102, false },
                    { 3, 50, 201, true },
                    { 4, 40, 202, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_FuncionarioId",
                table: "Alocacoes",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_LaboratorioId_DataAlocacao",
                table: "Alocacoes",
                columns: new[] { "LaboratorioId", "DataAlocacao" },
                unique: true,
                filter: "[LaboratorioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_NotebookId_DataAlocacao",
                table: "Alocacoes",
                columns: new[] { "NotebookId", "DataAlocacao" },
                unique: true,
                filter: "[NotebookId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_SalaId_DataAlocacao",
                table: "Alocacoes",
                columns: new[] { "SalaId", "DataAlocacao" },
                unique: true,
                filter: "[SalaId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alocacoes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
