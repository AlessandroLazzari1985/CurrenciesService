using Apsoft.Domain.FinancialData;

namespace BancaSempione.Domain.Divise;

public class Divisa(
    int divisaId,
    string alphabeticCode,
    int numericCode,
    string? name,
    string? symbol,
    int decimalDigits,
    int rounding,
    bool isDivisaIn,
    decimal taglio,
    int gruppoDivisaId,
    string tipoDivisaId)
    : Currency(alphabeticCode, numericCode, name, symbol, decimalDigits, rounding)
{
    public int DivisaId { get; } = divisaId;
    public bool IsDivisaIn { get; } = isDivisaIn;
    public decimal Taglio { get; } = taglio;
    public int GruppoDivisaId { get; } = gruppoDivisaId;
    public string TipoDivisaId { get; } = tipoDivisaId;
}