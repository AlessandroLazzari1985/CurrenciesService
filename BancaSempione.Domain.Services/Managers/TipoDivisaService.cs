using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;

namespace BancaSempione.Domain.Services.Managers;

public class TipoDivisaService(ITipoDivisaRepository repository) : ITipoDivisaService
{
    public Dictionary<string, TipoDivisa> TipoDivisaById => repository.Items.ToList().ToDictionary(x => x.Id);
}