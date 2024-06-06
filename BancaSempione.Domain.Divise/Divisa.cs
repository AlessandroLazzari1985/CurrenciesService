using Apsoft.Domain.FinancialData;

namespace BancaSempione.Domain.Divise
{
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
        int gruppoDivisaCode,
        string tipoDivisaCode)
        : Currency(alphabeticCode, numericCode, name, symbol, decimalDigits, rounding)
    {
        public int DivisaId { get; } = divisaId;
        public bool IsDivisaIn { get; } = isDivisaIn;
        public decimal Taglio { get; } = taglio;
        public int GruppoDivisaCode { get; } = gruppoDivisaCode;
        public string TipoDivisaCode { get; } = tipoDivisaCode;
    }
}
