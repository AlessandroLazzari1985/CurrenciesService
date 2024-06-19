using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Domain.Services.Managers;
using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.Logging;

namespace BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

public interface ICorsoDivisaImporter
{
    void Importa();
    void Cancella();
}

public class CorsoDivisaImporter(
    ILogger<CorsoDivisaImporter> logger,
    ICorsoDivisaBossRepository corsoDivisaBossRepository,
    ICorsoDivisaRepository corsoDivisaRepository,
    ICorsoDivisaService corsoDivisaService,
    ICorsoDivisaBuilder corsoDivisaBuilder,
    IDivisaService divisaService
    ) : ICorsoDivisaImporter
{
    private readonly CompareLogic _compareLogic = new()
    {
        Config = new ComparisonConfig
        {
            MaxDifferences = 1,
            MembersToInclude =
            [
                "BidRate",
                "AskRate"
            ],
            CompareChildren = false,
        }
    };
    
    public void Importa()
    {
        var bossIsEmpty = corsoDivisaBossRepository.Items.FirstOrDefault() == null;

        if (bossIsEmpty)
            return;
        
        var lastLoad = DateTime.FromFileTimeUtc(corsoDivisaRepository.LastLoadUtc());
        var corsoDivisaBoss = corsoDivisaBossRepository.Items.Where(x => x.DATELA > lastLoad).ToList();
        
        List<IGrouping<DateTime, CorsoDivisaBoss>> corsiByDatela = corsoDivisaBoss
            .GroupBy(x => x.DATELA)
            .OrderBy(x => x.Key)
            .ToList();

        corsiByDatela.ForEach(ImportaUltimi);
    }


    private void ImportaUltimi(IGrouping<DateTime, CorsoDivisaBoss> corsiByDatela)
    {
        var ultimiCorsoDivisaBoss = corsiByDatela.ToList();
        var corsiDivisaAttuali = corsoDivisaService.CorsiDivisa.ToList();
            
        // Leggiamo i corsi attuali
        var corsiInterniAttualiByKey = corsiDivisaAttuali.Where(x => x.TipoCorsoDivisa == TipoCorsoDivisa.CorsoInterno).ToDictionary(x => x.CurrencyExchangeRate.CurrencyPair);
        var corsiRiferimentoAttualiByKey = corsiDivisaAttuali.Where(x => x.TipoCorsoDivisa == TipoCorsoDivisa.CorsoRiferimento).ToDictionary(x => x.CurrencyExchangeRate.CurrencyPair);

        // Calcoliamo i nuovi
        var processatiCorsiInterni = ultimiCorsoDivisaBoss.Select(x => corsoDivisaBuilder.BuildCorsoInterno(x, divisaService.DiviseById, divisaService.DivisaIstituto, corsiInterniAttualiByKey)).ToList();
        var processatiCorsiRiferimento = ultimiCorsoDivisaBoss.Select(x => corsoDivisaBuilder.BuildCorsoRiferimento(x, divisaService.DiviseById, divisaService.DivisaIstituto, corsiRiferimentoAttualiByKey)).ToList();

        var errorsCorsiInterni = processatiCorsiInterni.Where(x => x.IsFailure).Select(x => x.Error).ToList();
        var errorsCorsiRiferimento = processatiCorsiRiferimento.Where(x => x.IsFailure).Select(x => x.Error).ToList();

        errorsCorsiInterni.ForEach(x => logger.LogError(x));
        errorsCorsiRiferimento.ForEach(x => logger.LogError(x));
        
        var corsiInterni = processatiCorsiInterni.Where(x => x.IsSuccess).Select(x => x.Value).ToList();
        var corsiRiferimento = processatiCorsiRiferimento.Where(x => x.IsSuccess).Select(x => x.Value).ToList();

        var nuovibyKey = corsiInterni.Union(corsiRiferimento).ToList().ToDictionary(x => new CorsoDivisaKey(x));

        // Se abbiamo riletto per caso un corso che era già presente, non lo aggiorniamo.
        var attualiByKey = corsiDivisaAttuali.ToDictionary(x => new CorsoDivisaKey(x));

        var commonKeys = attualiByKey.Keys.Intersect(nuovibyKey.Keys).ToList();
        var newKeys = nuovibyKey.Keys.Except(commonKeys).ToList();

        var newItems = newKeys.Select(x => nuovibyKey[x]).ToList();
        var oldItemsToUpdate = new List<CorsoDivisa>();
        commonKeys.ForEach(key =>
        {
            var actual = attualiByKey[key];
            var newItem = nuovibyKey[key];

            var compareResult = _compareLogic.Compare(actual.CurrencyExchangeRate, newItem.CurrencyExchangeRate);

            if (compareResult.AreEqual)
                return;

            actual.CurrencyExchangeRate.ValidPeriod = new Period(
                actual.CurrencyExchangeRate.ValidPeriod.StartUtc,
                newItem.CurrencyExchangeRate.ValidPeriod.StartUtc);

            newItems.Add(newItem);
            oldItemsToUpdate.Add(actual);
        });

        corsoDivisaRepository.Update(oldItemsToUpdate);
        corsoDivisaRepository.Insert(newItems);

        logger.LogInformation($"Importati corsi divisa per il {corsiByDatela.Key}");
    }

    public void Cancella()
    {
        corsoDivisaRepository.Delete();
    }
}