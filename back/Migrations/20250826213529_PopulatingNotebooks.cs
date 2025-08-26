using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingNotebooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "Id", "DataAquisicao", "Descricao", "NroPatrimonio" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notebook para João Silva", "1234567" },
                    { 2, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notebook para Maria Souza", "9876543" },
                    { 3, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notebook para Carlos Pereira", "1111111" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notebooks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notebooks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notebooks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
