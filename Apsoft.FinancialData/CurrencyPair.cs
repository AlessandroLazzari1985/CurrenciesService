using Apsoft.Domain.Entities;

namespace Apsoft.Domain.FinancialData;

public class CurrencyPair(Currency baseCurrency, Currency counterCurrency): ValueObject<CurrencyPair>
{
    public Currency BaseCurrency { get; } = baseCurrency;
    public Currency CounterCurrency { get; } = counterCurrency;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return BaseCurrency;
        yield return CounterCurrency;
    }
}