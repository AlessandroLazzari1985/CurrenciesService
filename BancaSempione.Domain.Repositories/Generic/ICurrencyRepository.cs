using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Domain.Repositories.Core;

namespace BancaSempione.Domain.Repositories.Generic;

public interface ICurrencyRepository : IQueryRepository<Currency>;
