using Apsoft.Domain.FinancialData;
using Apsoft.Domain.Repositories;
using Apsoft.Infrastructure.Database;
using Apsoft.Infrastructure.Repositories.Core;

namespace Apsoft.Infrastructure.Repositories.Domain;

public class CurrencyRepository(FinancialDataContext context) : Repository<Currency>(context), ICurrencyRepository;
