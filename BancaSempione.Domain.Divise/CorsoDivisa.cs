using Apsoft.Domain.FinancialData;

namespace BancaSempione.Domain.Divise;

public class CorsoDivisa(CurrencyExchangeRate currencyExchangeRate, TipoCorsoDivisa tipoCorsoDivisa)
{
    public CurrencyExchangeRate CurrencyExchangeRate { get; } = currencyExchangeRate;
    public TipoCorsoDivisa TipoCorsoDivisa { get; } = tipoCorsoDivisa;
}

public enum TipoCorsoDivisa
{
    CorsoInterno,
    CorsoRiferimento,
    CorsoFiscale,
    // TODO: Aggiungere altri tipi di corso
}
