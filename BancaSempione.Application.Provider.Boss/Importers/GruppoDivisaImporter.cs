using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;

namespace BancaSempione.Application.Provider.Boss.Importers;

public interface IGruppoDivisaImporter
{
    void Importa();
    void Cancella();
}

public class GruppoDivisaImporter(IGruppoDivisaRepository gruppoDivisaRepository) : IGruppoDivisaImporter
{
    public void Importa()
    {
        var items = GruppoDivisa.GetAll();

        gruppoDivisaRepository.Merge(items);
    }

    public void Cancella()
    {
        gruppoDivisaRepository.Delete();
    }
}