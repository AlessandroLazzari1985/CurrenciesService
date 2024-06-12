using Apsoft.Domain.FinancialData;
using Apsoft.Domain.Repositories;

namespace Apsoft.Infrastructure.Repositories.Domain;

public class CountryRepository : ICountryRepository
{
    public IQueryable<Country> Items => Country.GetAll().AsQueryable();
}