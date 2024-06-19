using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaSempione.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CorsoDivisa_BaseCurrencyCode_CounterCurrencyCode_TipoCorsoDivisa_ValidFromUtc",
                schema: "Sempione_Currency",
                table: "CorsoDivisa",
                columns: new[] { "BaseCurrencyCode", "CounterCurrencyCode", "TipoCorsoDivisa", "ValidFromUtc" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CorsoDivisa_BaseCurrencyCode_CounterCurrencyCode_TipoCorsoDivisa_ValidFromUtc",
                schema: "Sempione_Currency",
                table: "CorsoDivisa");
        }
    }
}
