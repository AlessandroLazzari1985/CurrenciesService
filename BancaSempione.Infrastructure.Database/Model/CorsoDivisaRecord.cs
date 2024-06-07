namespace BancaSempione.Infrastructure.Database.Model;

public class CorsoDivisaRecord
{
    public Guid CorsoDivisaRecordId { get; set; }
    public int BaseDivisaId { get; set; }
    public int CounterDivisaId { get; set; }
    public decimal ExchangeRate { get; set; }       // Tasso di cambio. Valore di riferimento o media tra Bid e Ask
    public decimal BidRate { get; set; }            // Tasso di acquisto
    public decimal AskRate { get; set; }            // Tasso di vendita
    public decimal Performance { get; set; }        // 100 * (ExchangeRate - PreviousRate) / PreviousRate
    public decimal Spread { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public long ValidFromUtc { get; set; }
    public long ValidToUtc { get; set; }
}