using BancaSempione.Domain.Divise;

namespace BancaSempione.Domain.Repositories;

public interface ITipoDivisaRepository
{
    // TODO. Nella sua implementazione, bisogna tenere conto della lingua richiesta.
    List<TipoDivisa> Items { get; }
}