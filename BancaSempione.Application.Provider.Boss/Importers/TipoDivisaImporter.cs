using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;

namespace BancaSempione.Application.Provider.Boss.Importers;

public interface ITipoDivisaImporter
{
    void Importa();
    void Cancella();
}

public class TipoDivisaImporter(ITipoDivisaRepository tipoDivisaRepository) : ITipoDivisaImporter
{
    public void Importa()
    {
        var items = TipoDivisa.GetAll();

        tipoDivisaRepository.Merge(items);
    }

    public void Cancella()
    {
        tipoDivisaRepository.Delete();
    }
}