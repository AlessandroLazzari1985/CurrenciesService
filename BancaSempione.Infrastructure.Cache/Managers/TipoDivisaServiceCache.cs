using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Infrastructure.Cache.Core;

namespace BancaSempione.Infrastructure.Cache.Managers;

public class TipoDivisaServiceCache(ITipoDivisaService service, CacheManager cacheManager) : ITipoDivisaService
{
    public Dictionary<string, TipoDivisa> TipoDivisaById =>
        cacheManager.GetFromCache(CacheKeys.TipoDivisaServiceCache.TipoDivisaById, () => service.TipoDivisaById);
}