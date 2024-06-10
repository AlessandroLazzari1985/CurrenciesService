using Apsoft.Domain.FinancialData;

namespace BancaSempione.Domain.Divise;

public class CorsoDivisa(
    CurrencyPair currencyPair,
    decimal exchangeRate,
    decimal bidRate,
    decimal askRate,
    Period validPeriod,
    decimal? previousExchangeRate = null)
    : CurrencyExchangeRate(currencyPair, exchangeRate, bidRate, askRate, validPeriod, previousExchangeRate)
{
    public decimal CorsoInterno { get; set; }
    public decimal CorsoRiferimento { get; set; }
    public DateTime DataValutaCorsoInterno { get; set; }
    public DateTime DataValutaCorsoRiferimento { get; set; }
}