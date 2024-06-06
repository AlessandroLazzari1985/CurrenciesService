using BancaSempione.Domain.Divise;

namespace BancaSempione.Domain.Repositories;

public interface IGruppoDivisaRepository
{
    // TODO. Nella sua implementazione, bisogna tenere conto della lingua richiesta.
    List<GruppoDivisa> Items { get; }
}