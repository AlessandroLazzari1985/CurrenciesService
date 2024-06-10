using Apsoft.Domain.FinancialData;

namespace BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;

public interface ICorsoDivisaIdManager
{
    Guid GetCorsoDivisaId(CurrencyPair key, Dictionary<CurrencyPair, Guid> dictKeys);
}

public class CorsoDivisaIdManager : ICorsoDivisaIdManager
{
    public Guid GetCorsoDivisaId(CurrencyPair key, Dictionary<CurrencyPair, Guid> dictKeys)
    {
        if (dictKeys.TryGetValue(key, out var result))
            return result;

        var corsoDivisaId = Guid.NewGuid();
        dictKeys.Add(key, corsoDivisaId);
        return corsoDivisaId;
    }
}