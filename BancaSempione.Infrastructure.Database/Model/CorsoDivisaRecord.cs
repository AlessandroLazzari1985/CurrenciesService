using Apsoft.Infrastructure.Database.Model;
using BancaSempione.Domain.Divise;

namespace BancaSempione.Infrastructure.Database.Model;

public class CorsoDivisaRecord : CurrencyExchangeRateRecord
{
    public TipoCorsoDivisa TipoCorsoDivisa { get; set; }
}