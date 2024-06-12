using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;
using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.Logging;

namespace BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

public interface ICorsoDivisaImporter
{
    void ImportaUltimi();
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

    public void ImportaUltimi()
    {
        var ultimaDataDisponibile = corsoDivisaBossRepository.Items.Max(x => x.DATELA);
        var ultimiCorsoDivisaBoss = corsoDivisaBossRepository.Items.Where(x => x.DATELA == ultimaDataDisponibile).ToList();

        var attualiByKey = corsoDivisaRepository.Items.ToList().ToDictionary(x => new CorsoDivisaKey(x));
        var corsiInterniAttualiByKey = attualiByKey.Where(x => x.Key.TipoCorsoDivisa == TipoCorsoDivisa.CorsoInterno).ToDictionary(x => x.Key.CurrencyPair, x => x.Value);
        var corsiRiferimentoAttualiByKey = attualiByKey.Where(x => x.Key.TipoCorsoDivisa == TipoCorsoDivisa.CorsoInterno).ToDictionary(x => x.Key.CurrencyPair, x => x.Value);

        var processatiCorsiInterni = ultimiCorsoDivisaBoss.Select(x => corsoDivisaBuilder.BuildCorsoInterno(x, divisaService.DiviseById, divisaService.DivisaIstituto, corsiInterniAttualiByKey)).ToList();
        var processatiCorsiRiferimento = ultimiCorsoDivisaBoss.Select(x => corsoDivisaBuilder.BuildCorsoRiferimento(x, divisaService.DiviseById, divisaService.DivisaIstituto, corsiRiferimentoAttualiByKey)).ToList();

        var errorsCorsiInterni = processatiCorsiInterni.Where(x => x.IsFailure).Select(x => x.Error).ToList();
        errorsCorsiInterni.ForEach(x => logger.LogError(x));

        var errorsCorsiRiferimento = processatiCorsiRiferimento.Where(x => x.IsFailure).Select(x => x.Error).ToList();
        errorsCorsiRiferimento.ForEach(x => logger.LogError(x));
        
        var corsiInterni = processatiCorsiInterni.Where(x => x.IsSuccess).Select(x => x.Value).ToList();
        var corsiRiferimento = processatiCorsiRiferimento.Where(x => x.IsSuccess).Select(x => x.Value).ToList();

        var nuovibyKey = corsiInterni.Union(corsiRiferimento).ToList().ToDictionary(x => new CorsoDivisaKey(x));

        // Se abbiamo riletto per caso un corso che era già presente, non lo aggiorniamo.

        var commonKeys = attualiByKey.Keys.Intersect(nuovibyKey.Keys).ToList();
        var newKeys = nuovibyKey.Keys.Except(commonKeys).ToList();

        var newItems = newKeys.Select(x => nuovibyKey[x]).ToList();
        var oldItemsToUpdate = new List<CorsoDivisa>();
        commonKeys.ForEach(key =>
        {
                var actual = attualiByKey[key];
                var newItem = nuovibyKey[key];

                if (_compareLogic.Compare(actual, newItem).AreEqual)
                    return;

                actual.CurrencyExchangeRate.ValidPeriod = new Period(
                    actual.CurrencyExchangeRate.ValidPeriod.StartUtc,
                    newItem.CurrencyExchangeRate.ValidPeriod.StartUtc);

                newItems.Add(newItem);
                oldItemsToUpdate.Add(actual);
        });

        corsoDivisaRepository.Update(oldItemsToUpdate);
        corsoDivisaRepository.Insert(newItems);
    }


    public void ImportaStoria()
    {
    }

    public void Delete()
    {
        corsoDivisaRepository.Delete();
    }

    public class CorsoDivisaKey(CurrencyPair currencyPair, TipoCorsoDivisa tipoCorsoDivisa) : IEquatable<CorsoDivisaKey>
    {
        public CorsoDivisaKey(CorsoDivisa corsoDivisa) : this(corsoDivisa.CurrencyExchangeRate.CurrencyPair, corsoDivisa.TipoCorsoDivisa) { }

        public CurrencyPair CurrencyPair { get; } = currencyPair;
        public TipoCorsoDivisa TipoCorsoDivisa { get; } = tipoCorsoDivisa;

        public bool Equals(CorsoDivisaKey? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CurrencyPair.Equals(other.CurrencyPair) && TipoCorsoDivisa == other.TipoCorsoDivisa;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CorsoDivisaKey)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CurrencyPair, (int)TipoCorsoDivisa);
        }
    }

}