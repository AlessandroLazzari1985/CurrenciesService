using BancaSempione.Domain.Divise;

namespace BancaSempione.Domain.Services.Interfaces;

public interface ITipoDivisaService
{
    Dictionary<string, TipoDivisa> TipoDivisaById { get; }
}