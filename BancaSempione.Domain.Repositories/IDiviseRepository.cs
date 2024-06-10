using Apsoft.Domain.Repositories.Core;
using BancaSempione.Domain.Divise;

namespace BancaSempione.Domain.Repositories;

public interface IDivisaRepository : IRepository<Divisa>
{
    Dictionary<string, Divisa> DiviseByIsoCode { get; }
    Dictionary<string, Divisa> DiviseIn { get; }
    Dictionary<int, Divisa> DiviseById { get; }
    Divisa DivisaIstituto { get; }
}