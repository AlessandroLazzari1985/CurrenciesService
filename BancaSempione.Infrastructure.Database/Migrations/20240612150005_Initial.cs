using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaSempione.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sempione_Currency");

            migrationBuilder.CreateTable(
                name: "CorsoDivisa",
                schema: "Sempione_Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoCorsoDivisa = table.Column<int>(type: "int", nullable: false),
                    BaseCurrencyCode = table.Column<int>(type: "int", nullable: false),
                    CounterCurrencyCode = table.Column<int>(type: "int", nullable: false),
                    BidRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    AskRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    PreviousExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ValidFromUtc = table.Column<long>(type: "bigint", nullable: false),
                    ValidToUtc = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoDivisa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisa",
                schema: "Sempione_Currency",
                columns: table => new
                {
                    DivisaId = table.Column<int>(type: "int", nullable: false),
                    AlphabeticCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumericCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DecimalDigits = table.Column<int>(type: "int", nullable: false),
                    Rounding = table.Column<int>(type: "int", nullable: false),
                    IsDivisaIn = table.Column<bool>(type: "bit", nullable: false),
                    Taglio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GruppoDivisaId = table.Column<int>(type: "int", nullable: false),
                    TipoDivisaId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisa", x => x.DivisaId);
                });

            migrationBuilder.CreateTable(
                name: "GruppoDivisa",
                schema: "Sempione_Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruppoDivisa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "Sempione_Currency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDivisa",
                schema: "Sempione_Currency",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDivisa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorsoDivisa_BaseCurrencyCode_CounterCurrencyCode_TipoCorsoDivisa",
                schema: "Sempione_Currency",
                table: "CorsoDivisa",
                columns: new[] { "BaseCurrencyCode", "CounterCurrencyCode", "TipoCorsoDivisa" });

            migrationBuilder.CreateIndex(
                name: "IX_Divisa_AlphabeticCode",
                schema: "Sempione_Currency",
                table: "Divisa",
                column: "AlphabeticCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Divisa_NumericCode",
                schema: "Sempione_Currency",
                table: "Divisa",
                column: "NumericCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorsoDivisa",
                schema: "Sempione_Currency");

            migrationBuilder.DropTable(
                name: "Divisa",
                schema: "Sempione_Currency");

            migrationBuilder.DropTable(
                name: "GruppoDivisa",
                schema: "Sempione_Currency");

            migrationBuilder.DropTable(
                name: "Logs",
                schema: "Sempione_Currency");

            migrationBuilder.DropTable(
                name: "TipoDivisa",
                schema: "Sempione_Currency");
        }
    }
}
