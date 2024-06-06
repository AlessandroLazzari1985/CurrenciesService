using Apsoft.Domain.FinancialData;

namespace Apsoft.Domain.Repositories;

public interface ICountryRepository
{
    IEnumerable<Country> GetAll();
    Dictionary<string, Country> CuntriesByAlpha2();
    Dictionary<int, Country> CountriesByNumeric3();

    Country? GetByAlpha3(string alpha2);
    Country? ByNumeric3(int numeric3);
}

public class CountryRepository : ICountryRepository
{
    public IEnumerable<Country> GetAll()
    {
        return Country.GetAll();
    }

    public Dictionary<string, Country> CuntriesByAlpha2()
    {
        return Country.GetAll().ToDictionary(x => x.IsoAlpha2);
    }

    public Dictionary<int, Country> CountriesByNumeric3()
    {
        return Country.GetAll().ToDictionary(x => x.IsoNumeric3);
    }

    public Country? GetByAlpha3(string alpha2)
    {
        return Country.GetAll().SingleOrDefault(x => x.IsoAlpha2 == alpha2);
    }

    public Country? ByNumeric3(int numeric3)
    {
        return Country.GetAll().SingleOrDefault(x => x.IsoNumeric3 == numeric3);
    }
}
