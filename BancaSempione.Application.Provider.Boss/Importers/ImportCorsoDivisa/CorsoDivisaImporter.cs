using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

public interface ICorsoDivisaImporter
{
    void ImportUltimi();
    void ImportaStoria();
    void Delete();
}

public class CorsoDivisaImporter(
    ILogger<CorsoDivisaImporter> logger,
    ICorsoDivisaBossRepository corsoDivisaBossRepository,
    ICorsoDivisaRepository corsoDivisaRepository,
    ICorsoDivisaBuilder corsoDivisaBuilder,
    IDivisaService divisaService
    ) : ICorsoDivisaImporter
{
    public void ImportUltimi()
    {
        var ultimaDataDisponibile = corsoDivisaBossRepository.Items.Max(x => x.DATELA);
        var ultimiCorsoDivisaBoss = corsoDivisaBossRepository.Items.Where(x => x.DATELA == ultimaDataDisponibile).ToList();

        var attuali = corsoDivisaRepository.Items.ToList().ToDictionary(x => x.CurrencyPair);
        // var dictKeys = attuali.ToDictionary(x => x.Key, x => x.Value.CorsoDivisaId);
        var processati = ultimiCorsoDivisaBoss.Select(x => corsoDivisaBuilder.Build(x, divisaService.DiviseById, divisaService.DivisaIstituto, attuali)).ToList();

        var errors = processati.Where(x => x.IsFailure).Select(x => x.Error).ToList();
        errors.ForEach(x => logger.LogError(x));

        var valoriCorretti = processati.Where(x => x.IsSuccess).Select(x => x.Value).ToList();


        corsoDivisaRepository.Merge(valoriCorretti);
    }

    public void ImportaStoria()
    {
    }

    public void Delete()
    {
        corsoDivisaRepository.Delete();
    }
}