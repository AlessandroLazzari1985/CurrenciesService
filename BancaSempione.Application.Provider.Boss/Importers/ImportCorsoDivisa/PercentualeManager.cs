namespace BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

public interface IPercentualeManager
{
    decimal CalcolaPercentuale(decimal numeratore, decimal denominatore);
    decimal CalcolaPeso(decimal numeratore, decimal denominatore);
    decimal CalcolaPerformance(decimal attuale, decimal precedente);
}

public class PercentualeManager : IPercentualeManager
{
    // Questo limite è stato inserito dopo alcune considerazioni.
    // Boss non memorizza oltre il formato di 15 cifre (9 + 6)
    private readonly decimal _maxValue = 999999999.999999m;

    public decimal CalcolaPerformance(decimal attuale, decimal precedente)
    {
        var delta = attuale - precedente;

        return CalcolaPercentuale(delta, precedente);
    }

    public decimal CalcolaPercentuale(decimal numeratore, decimal denominatore)
    {
        var numeratoreRounded = Math.Round(numeratore, 6, MidpointRounding.ToZero);
        var denominatoreRounded = Math.Round(denominatore, 6, MidpointRounding.ToZero);

        if (denominatoreRounded == 0)
            return 0m;

        var percentuale = 100 * numeratoreRounded / denominatoreRounded;
        var percentualeRounded = Math.Round(percentuale, 6, MidpointRounding.ToZero);
        var percentualeMax = Math.Min(percentualeRounded, _maxValue);
        return percentualeMax;
    }

    public decimal CalcolaPeso(decimal numeratore, decimal denominatore)
    {
        var numeratoreRounded = Math.Round(numeratore, 6, MidpointRounding.ToZero);
        var denominatoreRounded = Math.Round(denominatore, 6, MidpointRounding.ToZero);

        if (denominatoreRounded == 0)
            return 0m;

        return Math.Round(numeratoreRounded / denominatoreRounded, 6);
    }
}