using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Cargo", "DataAdmissao", "Matricula", "Nome" },
                values: new object[,]
                {
                    { 1, "Programador Pleno", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567", "João Silva" },
                    { 2, "Analista", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9876543", "Maria Souza" },
                    { 3, "Estagiário", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1111111", "Carlos Pereira" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
