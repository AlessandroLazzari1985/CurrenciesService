namespace Apsoft.Application.Provider.CurrencyApi.Model;

public class CurrencyDataContainer
{
    public Dictionary<string, CurrencyDetail> Data { get; set; } = new();
}

// ReSharper disable InconsistentNaming
public class CurrencyDetail
{
    public required string Code { get; set; }
    public List<string> Countries { get; set; } = new();
    public int Decimal_digits { get; set; }
    public required string Name { get; set; }
    public required string Name_plural { get; set; }
    public int Rounding { get; set; }
    public string? Symbol { get; set; }
    public string? Symbol_native { get; set; }
    public required string Type { get; set; }
}
