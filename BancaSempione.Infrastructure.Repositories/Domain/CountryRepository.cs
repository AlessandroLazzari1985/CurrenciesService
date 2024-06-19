using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Domain.Repositories.Generic;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class CountryRepository : ICountryRepository
{
    public IQueryable<Country> Items => Country.GetAll().AsQueryable();
}