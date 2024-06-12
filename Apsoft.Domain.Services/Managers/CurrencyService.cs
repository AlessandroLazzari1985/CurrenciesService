using Apsoft.Domain.FinancialData;
using Apsoft.Domain.Repositories;
using Apsoft.Domain.Services.Interfaces;

namespace Apsoft.Domain.Services.Managers;

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