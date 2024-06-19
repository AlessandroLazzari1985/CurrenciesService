using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Domain.Repositories.Generic;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class CurrencyRepository : ICurrencyRepository
{
    public IQueryable<Currency> Items => Currency.GetAll().AsQueryable();
}
