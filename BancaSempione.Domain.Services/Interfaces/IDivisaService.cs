using BancaSempione.Domain.Divise;

namespace BancaSempione.Domain.Services.Interfaces;

public interface IDivisaService
{
    List<Divisa> Divise { get; }
    Dictionary<string, Divisa> DiviseByIsoCode { get; }
    Dictionary<string, Divisa> DiviseIn { get; }
    Dictionary<int, Divisa> DiviseById { get; }
    Divisa DivisaIstituto { get; }
}