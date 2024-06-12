using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Divise;
using CSharpFunctionalExtensions;

namespace BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

public interface ICorsoDivisaBuilder
{
    Result<CorsoDivisa> Build(
        CorsoDivisaBoss stage,
        Dictionary<int, Divisa> divise,
        Divisa divisaIstituto,
        // Dictionary<CurrencyPair, Guid> dictKeys,
        Dictionary<CurrencyPair, CorsoDivisa> corsiDivisaActual);
}

public class CorsoDivisaBuilder : ICorsoDivisaBuilder
{
    public Result<CorsoDivisa> Build(
        CorsoDivisaBoss stage,
        Dictionary<int, Divisa> divise,
        Divisa divisaIstituto,
        // Dictionary<CurrencyPair, Guid> dictKeys,
        Dictionary<CurrencyPair, CorsoDivisa> corsiDivisaActual)
    {
        var divisaFromIdString = stage.DIVISA.Trim();

        if (!int.TryParse(divisaFromIdString, out int divisaId))
            return Result.Failure<CorsoDivisa>("DIVISA non è un campo numerico");

        if (!divise.TryGetValue(divisaId, out var divisa))
            return Result.Failure<CorsoDivisa>($"DATELA: {stage.DATELA} DIVISA: {stage.DIVISA} .Non esiste la divisa con id {stage.DIVISA}");

        var corsoRiferimento = Math.Round(Convert.ToDecimal(stage.CORSCR) / divisa.Taglio, 6);
        var corsoInterno = Math.Round(Convert.ToDecimal(stage.CORSCI) / divisa.Taglio, 6);

        var corsoDivisaKey = new CurrencyPair(divisa, divisaIstituto);
        // var corsoDivisaId = corsoDivisaIdManager.GetCorsoDivisaId(corsoDivisaKey, dictKeys);

        corsiDivisaActual.TryGetValue(corsoDivisaKey, out var actualCorsoDivisa);

        //var corsoInternoDailyPerformance = percentualeManager.CalcolaPerformance(corsoInterno, actualCorsoDivisa?.CorsoInterno ?? 0m);
        //var corsoRiferimentoDailyPerformance = percentualeManager.CalcolaPerformance(corsoRiferimento, actualCorsoDivisa?.CorsoRiferimento ?? 0m);

        var result = new CorsoDivisa(corsoDivisaKey, corsoInterno, corsoInterno, corsoInterno, new Period(stage.DATELA, DateTime.MaxValue), actualCorsoDivisa?.CorsoInterno);

        result.CorsoRiferimento = corsoRiferimento;
        result.CorsoInterno = corsoInterno;
        result.DataValutaCorsoInterno = stage.VALUCI;
        result.DataValutaCorsoRiferimento = stage.VALUCR;


        return result;
    }

}