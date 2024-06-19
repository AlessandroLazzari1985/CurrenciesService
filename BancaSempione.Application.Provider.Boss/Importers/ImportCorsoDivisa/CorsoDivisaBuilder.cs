using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Divise.Generic;
using CSharpFunctionalExtensions;

namespace BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

public interface ICorsoDivisaBuilder
{
    Result<CorsoDivisa> BuildCorsoInterno(
        CorsoDivisaBoss stage,
        Dictionary<int, Divisa> divise,
        Divisa divisaIstituto,
        Dictionary<CoppiaDivise, CorsoDivisa> ultimiCorsiInterni);

    Result<CorsoDivisa> BuildCorsoRiferimento(
        CorsoDivisaBoss stage,
        Dictionary<int, Divisa> divise,
        Divisa divisaIstituto,
        Dictionary<CoppiaDivise, CorsoDivisa> ultimiCorsiRiferimento);
}

public class CorsoDivisaBuilder : ICorsoDivisaBuilder
{
    public Result<CorsoDivisa> BuildCorsoInterno(
        CorsoDivisaBoss stage,
        Dictionary<int, Divisa> divise,
        Divisa divisaIstituto,
        Dictionary<CoppiaDivise, CorsoDivisa> ultimiCorsiInterni)
    {
        var divisaResult = GetDivisa(stage, divise);
        if (divisaResult.IsFailure)
            return Result.Failure<CorsoDivisa>(divisaResult.Error);

        var divisa = divisaResult.Value;
        var corsoDivisaKey = new CoppiaDivise(divisa, divisaIstituto);

        var lastExchageRate = GetLastExchageRate(ultimiCorsiInterni, corsoDivisaKey);
        var validPeriod = new Period(stage.DATELA, DateTime.MaxValue);

        var corsoInterno = GetCorsoInterno(stage, divisa);

        var result = new CorsoDivisa(corsoDivisaKey, corsoInterno, corsoInterno, validPeriod, lastExchageRate, TipoCorsoDivisa.CorsoInterno);

        return result;
    }
    
    public Result<CorsoDivisa> BuildCorsoRiferimento(
        CorsoDivisaBoss stage,
        Dictionary<int, Divisa> divise,
        Divisa divisaIstituto,
        Dictionary<CoppiaDivise, CorsoDivisa> ultimiCorsiRiferimento)
    {
        var divisaResult = GetDivisa(stage, divise);
        if (divisaResult.IsFailure)
            return Result.Failure<CorsoDivisa>(divisaResult.Error);

        var divisa = divisaResult.Value;

        var corsoDivisaKey = new CoppiaDivise(divisa, divisaIstituto);

        var lastExchageRate = GetLastExchageRate(ultimiCorsiRiferimento, corsoDivisaKey);

        var validPeriod = new Period(stage.DATELA, DateTime.MaxValue);

        var corsoRiferimento = GetCorsoRiferimento(stage, divisa);
        var result = new CorsoDivisa(corsoDivisaKey, corsoRiferimento, corsoRiferimento, validPeriod, lastExchageRate, TipoCorsoDivisa.CorsoRiferimento);

        return result;
    }

    private decimal GetCorsoInterno(CorsoDivisaBoss stage, Divisa divisa)
    {
        return Math.Round(Convert.ToDecimal(stage.CORSCI) / divisa.Taglio, 6);
    }

    private decimal GetCorsoRiferimento(CorsoDivisaBoss stage, Divisa divisa)
    {
        return Math.Round(Convert.ToDecimal(stage.CORSCR) / divisa.Taglio, 6);
    }

    private Result<Divisa> GetDivisa(CorsoDivisaBoss stage, Dictionary<int, Divisa> divise)
    {
        var divisaFromIdString = stage.DIVISA.Trim();
        if (!int.TryParse(divisaFromIdString, out int divisaId))
            return Result.Failure<Divisa>("DIVISA non è un campo numerico");

        if (!divise.TryGetValue(divisaId, out var divisa))
            return Result.Failure<Divisa>($"DATELA: {stage.DATELA} DIVISA: {stage.DIVISA} .Non esiste la divisa con id {stage.DIVISA}");

        return Result.Success(divisa);
    }

    private static decimal GetLastExchageRate(Dictionary<CoppiaDivise, CorsoDivisa> ultimiCorsiRiferimento, CoppiaDivise corsoDivisaKey)
    {
        ultimiCorsiRiferimento.TryGetValue(corsoDivisaKey, out var actualCorsoDivisa);
        var lastExchageRate = actualCorsoDivisa?.ExchangeRate ?? 0m;
        return lastExchageRate;
    }
}