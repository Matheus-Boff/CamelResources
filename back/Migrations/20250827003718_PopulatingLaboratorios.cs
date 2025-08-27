using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingLaboratorios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Laboratorios",
                columns: new[] { "Id", "Descricao", "Nome", "NumComputadores" },
                values: new object[,]
                {
                    { 1, "Laboratório com PCs para aulas de programação", "Lab de Informática 1", 20 },
                    { 2, "Laboratório com PCs para aulas de redes", "Lab de Informática 2", 25 },
                    { 3, "Laboratório especializado em robótica e automação", "Lab de Robótica", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Laboratorios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Laboratorios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Laboratorios",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
