using BancaSempione.Application.Provider.Boss.Importers;
using BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

namespace BancaSempione.Application.Provider.Boss;

public interface IBossImporter
{
    void Importa();
    void Cancella();
}

public class BossImporter(
    IGruppoDivisaImporter gruppoDivisaImporter, 
    ITipoDivisaImporter tipoDivisaImporter,
    IDivisaImporter divisaImporter,
    ICorsoDivisaImporter corsoDivisaImporter)
    : IBossImporter
{
    public void Importa()
    {
        gruppoDivisaImporter.Importa();
        tipoDivisaImporter.Importa();
        divisaImporter.Importa();
        corsoDivisaImporter.ImportaUltimi();
    }

    public void Cancella()
    {
        gruppoDivisaImporter.Cancella();
        tipoDivisaImporter.Cancella();
        divisaImporter.Cancella();
        corsoDivisaImporter.ImportaUltimi();

    }
}