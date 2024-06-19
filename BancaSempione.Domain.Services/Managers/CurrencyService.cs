using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Domain.Repositories.Generic;
using BancaSempione.Domain.Services.Interfaces;

namespace BancaSempione.Domain.Services.Managers;

public class CurrencyService(ICurrencyRepository repository) : ICurrencyService
{
    public Dictionary<string, Currency> CurrenciesByAlpha3()
    {
        return repository.Items.ToList().ToDictionary(x => x.AlphabeticCode);
    }

    public Dictionary<int, Currency> CurrenciesByNumeric3()
    {
        return repository.Items.ToList().ToDictionary(x => x.NumericCode);
    }

    public Currency? GetByAlpha3(string alphabeticCode)
    {
        return repository.Items.SingleOrDefault(x => x.AlphabeticCode == alphabeticCode);
    }

    public Currency? ByNumeric3(int numericCode)
    {
        return repository.Items.SingleOrDefault(x => x.NumericCode == numericCode);
    }
}