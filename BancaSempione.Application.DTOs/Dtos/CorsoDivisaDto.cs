namespace BancaSempione.Application.DTOs.Dtos;

public class CorsoDivisaDto
{
    public Guid CorsoDivisaId { get; set; }
    public string BaseCurrencyCode { get; set; } = null!;
    public string CounterCurrencyCode { get; set; } = null!;
    public DivisaDto BaseCurrency { get; set; } = null!;
    public DivisaDto CounterCurrency { get; set; } = null!;
    public decimal BidRate { get; set; }                        // Tasso di vendita
    public decimal AskRate { get; set; }                        // Tasso di vendita
    public decimal ExchangeRate { get; set; }                   // Tasso di cambio. Valore di riferimento o media tra Bid e Ask
    public decimal PreviousExchangeRate { get; set; }           // Tasso di cambio. Valore di riferimento o media tra Bid e Ask
    public decimal Performance { get; set; }                    // 100 * (ExchangeRate - PreviousRate) / PreviousRate
    public decimal Spread => AskRate - BidRate;
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}