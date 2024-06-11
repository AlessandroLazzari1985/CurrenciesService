using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;

namespace BancaSempione.Domain.Services.Managers;

public class GruppoDivisaService(IGruppoDivisaRepository repository) : IGruppoDivisaService
{
    public Dictionary<int, GruppoDivisa> GruppoDivisaById => repository.Items.ToList().ToDictionary(x => x.Id);
}