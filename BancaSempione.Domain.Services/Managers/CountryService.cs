using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Domain.Repositories.Generic;
using BancaSempione.Domain.Services.Interfaces;

namespace BancaSempione.Domain.Services.Managers;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public Dictionary<string, Country> CuntriesByAlpha2()
    {
        return countryRepository.Items.ToList().ToDictionary(x => x.IsoAlpha2);
    }

    public Dictionary<int, Country> CountriesByNumeric3()
    {
        return countryRepository.Items.ToList().ToDictionary(x => x.IsoNumeric3);
    }

    public Country? GetByAlpha3(string alpha2)
    {
        return countryRepository.Items.ToList().SingleOrDefault(x => x.IsoAlpha2 == alpha2);
    }

    public Country? ByNumeric3(int numeric3)
    {
        return countryRepository.Items.ToList().SingleOrDefault(x => x.IsoNumeric3 == numeric3);
    }
}