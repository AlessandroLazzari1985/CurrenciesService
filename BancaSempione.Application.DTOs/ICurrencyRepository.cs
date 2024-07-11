using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Domain.Repositories.Core;

namespace BancaSempione.Application.DTOs;

public interface ICurrencyRepository : IQueryRepository<Currency>;
