using Apsoft.Domain.FinancialData;
using Apsoft.Domain.Repositories;

namespace Apsoft.Infrastructure.Repositories.Domain;

public class CurrencyRepository : ICurrencyRepository
{
    public IQueryable<Currency> Items => Currency.GetAll().AsQueryable();
}
