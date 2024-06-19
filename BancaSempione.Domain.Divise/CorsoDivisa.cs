using BancaSempione.Domain.Divise.Core;
using BancaSempione.Domain.Divise.Generic;

namespace BancaSempione.Domain.Divise;

public class CorsoDivisa : Entity
{
    public CoppiaDivise CoppiaDivise { get; }       // Per leggere id corretto con automapper
    public decimal BidRate { get; }                 // Tasso di acquisto
    public decimal AskRate { get; }                 // Tasso di vendita
    public decimal ExchangeRate { get; }            // Tasso di cambio. Valore di riferimento o media tra Bid e Ask
    public decimal PreviousExchangeRate { get; }    // Tasso di cambio. Valore di riferimento o media tra Bid e Ask
    public decimal Performance { get; }             // 100 * (ExchangeRate - PreviousRate) / PreviousRate
    public decimal Spread => AskRate - BidRate;
    public Period ValidPeriod { get; set;  }        // TODO Controllare se è possibile levare il set!
    public TipoCorsoDivisa TipoCorsoDivisa { get; }

    public CorsoDivisa(CoppiaDivise coppiaDivise, decimal bidRate, decimal askRate, Period validPeriod, decimal previousExchangeRate, TipoCorsoDivisa tipoCorsoDivisa)
    {
        if (bidRate < 0) throw new ArgumentException("Must be > 0.", nameof(bidRate));
        if (askRate < 0) throw new ArgumentException("Must be > 0.", nameof(askRate));

        var exchangeRate = (askRate + bidRate) / 2;

        Id = Guid.NewGuid();
        CoppiaDivise = coppiaDivise ?? throw new ArgumentNullException(nameof(coppiaDivise)); ;
        ExchangeRate = exchangeRate;
        PreviousExchangeRate = previousExchangeRate;
        BidRate = bidRate;
        AskRate = askRate;
        Performance = CalculateRateOfReturn(exchangeRate, previousExchangeRate);
        ValidPeriod = validPeriod ?? throw new ArgumentNullException(nameof(validPeriod));
        TipoCorsoDivisa = tipoCorsoDivisa;
    }

    private static decimal CalculateRateOfReturn(decimal exchangeRate, decimal? previousExchangeRate)
    {
        if (previousExchangeRate == null)
            return 0m;

        if (previousExchangeRate < 0)
            throw new ArgumentException("Previous rate must be > 0.", nameof(previousExchangeRate));

        if (previousExchangeRate == 0)
            return 0m;

        // Calcolo del tasso di rendimento come variazione percentuale del Rate
        return 100 * (exchangeRate - previousExchangeRate.Value) / previousExchangeRate.Value;
    }
}

// TODO: Aggiungere altri tipi di corso
public enum TipoCorsoDivisa
{
    CorsoInterno,
    CorsoRiferimento,
    CorsoFiscale,
}
