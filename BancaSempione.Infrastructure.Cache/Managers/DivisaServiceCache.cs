using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Infrastructure.Cache.Core;

namespace BancaSempione.Infrastructure.Cache.Managers;

public class DivisaServiceCache(IDivisaService service, CacheManager cacheManager) : IDivisaService
{
    public Dictionary<string, Divisa> DiviseByIsoCode => 
        cacheManager.GetFromCache(CacheKeys.DivisaServiceCacheKeys.DiviseByIsoCode, () => service.DiviseByIsoCode);

    public Dictionary<string, Divisa> DiviseIn => 
        cacheManager.GetFromCache(CacheKeys.DivisaServiceCacheKeys.DiviseIn, () => service.DiviseIn);

    public Dictionary<int, Divisa> DiviseById => 
        cacheManager.GetFromCache(CacheKeys.DivisaServiceCacheKeys.DiviseById, () => service.DiviseById);

    public Divisa DivisaIstituto => 
        cacheManager.GetFromCache(CacheKeys.DivisaServiceCacheKeys.DivisaIstituto, () => service.DivisaIstituto);
}