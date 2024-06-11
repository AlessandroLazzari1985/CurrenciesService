using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Infrastructure.Cache.Core;

namespace BancaSempione.Infrastructure.Cache.Managers;

public class GruppoDivisaServiceCache(IGruppoDivisaService service, CacheManager cacheManager) : IGruppoDivisaService
{
    public Dictionary<int, GruppoDivisa> GruppoDivisaById => 
        cacheManager.GetFromCache(CacheKeys.GruppoDivisaService.GruppoDivisaById, () => service.GruppoDivisaById);

}