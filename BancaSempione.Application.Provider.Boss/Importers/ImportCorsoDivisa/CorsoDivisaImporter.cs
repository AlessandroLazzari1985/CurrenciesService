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

        var attuali = corsoDivisaRepository.Items.ToList().ToDictionary(x => x.CurrencyExchangeRate.CurrencyPair);
        var processatiCorsiInterni = ultimiCorsoDivisaBoss.Select(x => corsoDivisaBuilder.BuildCorsoInterno(x, divisaService.DiviseById, divisaService.DivisaIstituto, attuali)).ToList();
        var processatiCorsiRiferimento = ultimiCorsoDivisaBoss.Select(x => corsoDivisaBuilder.BuildCorsoRiferimento(x, divisaService.DiviseById, divisaService.DivisaIstituto, attuali)).ToList();

        var errorsCorsiInterni = processatiCorsiInterni.Where(x => x.IsFailure).Select(x => x.Error).ToList();
        errorsCorsiInterni.ForEach(x => logger.LogError(x));

        var errorsCorsiRiferimento = processatiCorsiRiferimento.Where(x => x.IsFailure).Select(x => x.Error).ToList();
        errorsCorsiRiferimento.ForEach(x => logger.LogError(x));
        
        var corsiInterni = processatiCorsiInterni.Where(x => x.IsSuccess).Select(x => x.Value).ToList();
        var corsiRiferimento = processatiCorsiRiferimento.Where(x => x.IsSuccess).Select(x => x.Value).ToList();

        var corsi = corsiInterni.Union(corsiRiferimento).ToList();

        corsoDivisaRepository.Merge(corsi);
    }

    public void ImportaStoria()
    {
    }

    public void Delete()
    {
        corsoDivisaRepository.Delete();
    }
}