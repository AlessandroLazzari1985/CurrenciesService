using Apsoft.Domain.FinancialData;

namespace Apsoft.Infrastructure.Database.Model;

public class ActualCurrencyExchangeRate(
    CurrencyPair currencyPair,
    decimal exchangeRate,
    decimal bidRate,
    decimal askRate,
    Period validPeriod,
    decimal? previousExchangeRate = null)
    : CurrencyExchangeRate(currencyPair, exchangeRate, bidRate, askRate, validPeriod, previousExchangeRate);


public class HistoricalCurrencyExchangeRate(
    CurrencyPair currencyPair,
    decimal exchangeRate,
    decimal bidRate,
    decimal askRate,
    Period validPeriod,
    decimal? previousExchangeRate = null)
    : CurrencyExchangeRate(currencyPair, exchangeRate, bidRate, askRate, validPeriod, previousExchangeRate);