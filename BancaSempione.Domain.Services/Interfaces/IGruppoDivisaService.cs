using BancaSempione.Domain.Divise;

namespace BancaSempione.Domain.Services.Interfaces;

public interface IGruppoDivisaService
{
    Dictionary<int, GruppoDivisa> GruppoDivisaById { get; }
}