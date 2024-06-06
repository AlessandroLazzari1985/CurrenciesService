using Apsoft.Domain.FinancialData;

namespace Apsoft.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> Items { get; }
        Dictionary<string, Currency> CurrenciesByAlpha3();
        Dictionary<int, Currency> CurrenciesByNumeric3();

        Currency? GetByAlpha3(string alphabeticCode);
        Currency? ByNumeric3(int numericCode);
    }

    public class CurrencyRepository : ICurrencyRepository
    {
        public IEnumerable<Currency> Items => Currency.GetAll();
        
        public Dictionary<string, Currency> CurrenciesByAlpha3()
        {
            return Currency.GetAll().ToDictionary(x => x.AlphabeticCode);
        }

        public Dictionary<int, Currency> CurrenciesByNumeric3()
        {
            return Currency.GetAll().ToDictionary(x => x.NumericCode);
        }

        public Currency? GetByAlpha3(string alphabeticCode)
        {
            return Currency.GetAll().SingleOrDefault(x => x.AlphabeticCode == alphabeticCode);
        }

        public Currency? ByNumeric3(int numericCode)
        {
            return Currency.GetAll().SingleOrDefault(x => x.NumericCode == numericCode);
        }
    }
}
