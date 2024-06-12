using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Infrastructure.Cache.Core;
using BancaSempione.Infrastructure.Cache.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Infrastructure.Cache;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Infrastructure_Cache(this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddSingleton<CacheManager>();
        services.Decorate<IDivisaService, DivisaServiceCache>();
        services.Decorate<IGruppoDivisaService, GruppoDivisaServiceCache>();
        services.Decorate<ITipoDivisaService, TipoDivisaServiceCache>();

        return services;
    }
}