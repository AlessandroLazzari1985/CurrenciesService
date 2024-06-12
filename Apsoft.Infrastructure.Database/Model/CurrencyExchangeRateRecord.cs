namespace Apsoft.Infrastructure.Database.Model;

public class ActualCurrencyExchangeRate : CurrencyExchangeRateRecord;

public class HistoricalCurrencyExchangeRate : CurrencyExchangeRateRecord;

public class CurrencyExchangeRateRecord
{
    public Guid Id { get; set; }
    public int BaseCurrencyCode { get; set; }
    public int CounterCurrencyCode { get; set; }
    public decimal BidRate { get; set; }
    public decimal AskRate { get; set; }
    public decimal PreviousExchangeRate { get; set; }
    public long ValidFromUtc { get; set; }
    public long ValidToUtc { get; set; }
}