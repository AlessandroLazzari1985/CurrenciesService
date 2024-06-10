namespace BancaSempione.Infrastructure.Database.Model;

public class CurrencyPairRecord
{
    public Guid CurrencyPairRecordId { get; set; }
    public int BaseCurrencyId { get; set; }
    public int CounterCurrencyId { get; set; }
}