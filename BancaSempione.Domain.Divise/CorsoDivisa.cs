using Apsoft.Domain.FinancialData;

namespace BancaSempione.Domain.Divise;

public class CorsoDivisa : CurrencyExchangeRate
{
    public decimal CorsoInterno { get; set; }
    public decimal CorsoRiferimento { get; set; }
    public DateTime DataValutaCorsoInterno { get; set; }
    public DateTime DataValutaCorsoRiferimento { get; set; }

    public CorsoDivisa(CurrencyPair currencyPair, decimal exchangeRate, decimal bidRate, decimal askRate, Period validPeriod, decimal? previousExchangeRate = null) : base(currencyPair, exchangeRate, bidRate, askRate, validPeriod, previousExchangeRate)
    {
    }
}