using Apsoft.Domain.Entities;
using Apsoft.Domain.FinancialData;
using Apsoft.Domain.Repositories;
using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Repositories.Boss;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace BancaSempione.Application.Provider.Boss.Importers;

public interface IDivisaImporter
{
    void Importa();
    void Cancella();
}

internal class DivisaImporter(
    ILogger<DivisaImporter> logger,
    ILogRepository logRepository,
    IDivisaRepository divisaRepository,
    ICurrencyRepository currencyRepository,
    IDivisaBossRepository divisaBossRepository,
    ITabellaBossRepository tabellaBossRepository) : IDivisaImporter
{
    private readonly string _codiceTabellaDiviseIn = "BS04";
    private readonly string _codiceEntrataEuro = "I";

    public static List<decimal> TagliDivisa = [1m, 100m, 1000m];


    public void Cancella()
    {
        divisaRepository.Delete();
        logRepository.Delete();
    }

    public void Importa()
    {
        // Leggiamo le divise di Boss e le dividiamo per tipo
        var diviseBoss = divisaBossRepository.Items
            .Where(x => x.UATIPUNI == TipoDivisa.Divise.Id ||
                        x.UATIPUNI == TipoDivisa.MetalliLingottiContabili.Id)
            .ToList();

        // non tutte le divise di Boss sono delle currency reali della ISO4217.
        // Per esempio, i biglietti banca sono divise di Boss, ma non sono delle currency reali.
        // Per questo motivo, dobbiamo filtrare le divise di Boss che sono delle currency reali.

        // Tutte le divise non mappabili con una currency reale della ISO4217 non verranno mappate per ora.
        // Bisogna fare un'analisi per capire se queste divise possono essere mappate con una currency reale della ISO4217.
        // Per ora includo solo DV e LC

        // Le currency ISO 4217
        var diviseEntrateNellEuro = DiviseEntrateNellEuro();
        var gruppoDivisaById = GruppoDivisa.GetAll().ToDictionary(x => x.Id);
        var tipoDivisaById = TipoDivisa.GetAll().ToDictionary(x => x.Id);
        var currencies = currencyRepository.Items.ToList().ToDictionary(x => x.AlphabeticCode);

        var diviseResult = diviseBoss
            .Select(x => MappaDivisa(x, currencies, gruppoDivisaById, tipoDivisaById, diviseEntrateNellEuro))
            .ToList();

        var diviseNonImportate = diviseResult
            .Where(x => x.IsFailure)
            .Select(x => x.Error)
            .ToList();

        diviseNonImportate.ForEach(x => logger.LogWarning(x));

        var divisaDaImportare = diviseResult
            .Where(x => x.IsSuccess)
            .Select(x => x.Value)
            .ToList();

        var diviseByKey = divisaDaImportare.GroupBy(x => x.NumericCode).ToList();

        var diviseDuplicate = diviseByKey
            .Where(x => x.Count() > 1)
            .SelectMany(x => x.ToList())
            .ToList();

        diviseDuplicate.ForEach(x => logger.LogWarning($"Divisa duplicata. {x.AlphabeticCode} {x.NumericCode} {x.DivisaId}"));

        var diviseNonDuplicate = diviseByKey
            .Where(x => x.Count() == 1)
            .Select(x => x.Single())
            .ToList();

        divisaRepository.Merge(diviseNonDuplicate);
    }

    private Result<Divisa> MappaDivisa(
        DivisaBoss divisaBoss,
        Dictionary<string, Currency> currenciesByIsoCode,
        Dictionary<int, GruppoDivisa> gruppoDivisaById,
        Dictionary<string, TipoDivisa> tipoDivisaById,
        List<int> diviseEntrateNellEuro)
    {
        var divisaIdResult = GetDivisaId(divisaBoss);
        var codiceIsoResult = GetCodiceIso(divisaBoss);
        var taglioResult = GetTaglio(divisaBoss);
        var decimaliResult = GetDecimali(divisaBoss);
        var gruppoDivisaResult = GetGruppoDivisa(divisaBoss, gruppoDivisaById);
        var tipoDivisaResult = GetTipoDivisa(divisaBoss, tipoDivisaById);
        var currencyResult = GetCurrency(divisaBoss, currenciesByIsoCode);

        if (divisaIdResult.IsFailure)
            return Result.Failure<Divisa>(divisaIdResult.Error);

        if (codiceIsoResult.IsFailure)
            return Result.Failure<Divisa>(codiceIsoResult.Error);

        if (taglioResult.IsFailure)
            return Result.Failure<Divisa>(taglioResult.Error);

        if (decimaliResult.IsFailure)
            return Result.Failure<Divisa>(decimaliResult.Error);

        if (gruppoDivisaResult.IsFailure)
            return Result.Failure<Divisa>(gruppoDivisaResult.Error);

        if (tipoDivisaResult.IsFailure)
            return Result.Failure<Divisa>(tipoDivisaResult.Error);

        if (currencyResult.IsFailure)
            return Result.Failure<Divisa>(currencyResult.Error);


        var isDivisaIn = diviseEntrateNellEuro.Contains(divisaIdResult.Value);

        return new Divisa(
            divisaId: divisaIdResult.Value,
            alphabeticCode: currencyResult.Value.AlphabeticCode,
            numericCode: currencyResult.Value.NumericCode,
            name: currencyResult.Value.Name,
            symbol: currencyResult.Value.Symbol,
            decimalDigits: currencyResult.Value.DecimalDigits,
            rounding: currencyResult.Value.Rounding,
            isDivisaIn: isDivisaIn,
            taglio: taglioResult.Value,
            gruppoDivisaId: gruppoDivisaResult.Value.Id,
            tipoDivisaId: tipoDivisaResult.Value.Id);
    }

    private Result<Currency> GetCurrency(DivisaBoss divisaBoss, Dictionary<string, Currency> currenciesByIsoCode)
    {
        var isoCode = divisaBoss.UACODISO.TrimOrEmpty();

        if (!currenciesByIsoCode.TryGetValue(isoCode, out var currency))
            return Result.Failure<Currency>($"La divisa non è mappata con una currency reale della ISO4217. ISO Code: [{isoCode}]");

        return currency;
    }

    private Result<int> GetDivisaId(DivisaBoss divisaStage)
    {
        if (divisaStage.UAUNINUM % 1 != 0)
            return Result.Failure<int>($"DivisaBoss [{divisaStage.UAUNINUM}]. UAUNINUM deve essere un valore intero [{divisaStage.UAUNINUM}]");

        return Convert.ToInt32(divisaStage.UAUNINUM);
    }

    private Result<int> GetDecimali(DivisaBoss divisaStage)
    {
        if (divisaStage.UADECIMAL % 1 != 0)
            return Result.Failure<int>($"DivisaBoss [{divisaStage.UAUNINUM}]. UADECIMAL deve essere un valore intero [{divisaStage.UADECIMAL}]");

        return Convert.ToInt32(divisaStage.UADECIMAL);
    }

    private Result<decimal> GetTaglio(DivisaBoss divisaStage)
    {
        if (!TagliDivisa.Contains(divisaStage.UATATAG))
            return Result.Failure<decimal>($"DivisaBoss [{divisaStage.UAUNINUM}]. UATATAG ha un valore inatteso [{divisaStage.UATATAG}]. Valori accettati [{string.Join("; ", TagliDivisa)}]");

        return divisaStage.UATATAG;
    }

    private Result<string> GetCodiceIso(DivisaBoss divisaStage)
    {
        var codice = divisaStage.UACODISO.TrimOrEmpty();

        if (codice.Length > 3)
            return Result.Failure<string>($"DivisaBoss [{divisaStage.UAUNINUM}].UACODISO [{divisaStage.UACODISO}] consente massimo 3 caratteri");

        return codice;
    }

    private Result<GruppoDivisa> GetGruppoDivisa(DivisaBoss divisaBoss, Dictionary<int, GruppoDivisa> gruppoDivisaById)
    {
        var field = divisaBoss.UAGRUPPO;

        if (!int.TryParse(field, NumberStyles.Any, CultureInfo.InvariantCulture, out var gruppoDivisaId))
            return Result.Failure<GruppoDivisa>($"DivisaStage [{divisaBoss.UAUNINUM}]. UAGRUPPO [{field}] non è un valore numerico intero");

        if (!gruppoDivisaById.TryGetValue(gruppoDivisaId, out var gruppoDivisa))
            return Result.Failure<GruppoDivisa>($"DivisaStage [{divisaBoss.UAUNINUM}]. UAGRUPPO ha un valore inatteso [{field}] ");

        return gruppoDivisa;
    }

    private Result<TipoDivisa> GetTipoDivisa(DivisaBoss divisaBoss, Dictionary<string, TipoDivisa> tipoDivisaDictionary)
    {
        var field = divisaBoss.UATIPUNI.TrimOrEmpty();

        if (string.IsNullOrWhiteSpace(field))
            return Result.Failure<TipoDivisa>($"DivisaStage [{divisaBoss.UAUNINUM}]. UATIPUNI è vuoto.");

        if (!tipoDivisaDictionary.TryGetValue(field, out var tipoDivisa))
            return Result.Failure<TipoDivisa>($"DivisaStage [{divisaBoss.UAUNINUM}]. UATIPUNI ha un valore inatteso [{field}]. Valori accettati sono nella tabella TipoDivisa (N051)");

        return tipoDivisa;
    }

    private List<int> DiviseEntrateNellEuro()
    {
        return tabellaBossRepository.Items
            .Where(x => x.TAB == _codiceTabellaDiviseIn)
            .Where(x => x.COL_7 == _codiceEntrataEuro)
            .Select(x => Convert.ToInt32(x.CODE))
            .ToList();
    }
}