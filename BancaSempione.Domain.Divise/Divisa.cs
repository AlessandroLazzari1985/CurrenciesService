using BancaSempione.Domain.Divise.Core;

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
    string tipoDivisaId) : ValueObject<Divisa>
{
    #region Campi ISO4217
    public string AlphabeticCode { get; } = alphabeticCode;
    public int NumericCode { get; } = numericCode;
    public string? Name { get; } = name;
    public string? Symbol { get; } = symbol;
    public int DecimalDigits { get; } = decimalDigits;
    public int Rounding { get; } = rounding;
    #endregion

    #region Campi personalizzati Sempione
    public int DivisaId { get; } = divisaId;
    public bool IsDivisaIn { get; } = isDivisaIn;
    public decimal Taglio { get; } = taglio;
    public int GruppoDivisaId { get; } = gruppoDivisaId;
    public string TipoDivisaId { get; } = tipoDivisaId;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DivisaId;
    }
    #endregion
}