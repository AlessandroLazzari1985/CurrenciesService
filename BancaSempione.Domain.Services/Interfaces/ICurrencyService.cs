using BancaSempione.Domain.Divise.Generic;

namespace BancaSempione.Domain.Services.Interfaces;

public interface ICurrencyService
{
    Dictionary<string, Currency> CurrenciesByAlpha3();
    Dictionary<int, Currency> CurrenciesByNumeric3();
    Currency? GetByAlpha3(string alphabeticCode);
    Currency? ByNumeric3(int numericCode);
}