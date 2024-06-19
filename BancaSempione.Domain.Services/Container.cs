using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Domain.Services.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Domain.Services;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Domain_Services(this IServiceCollection services)
    {
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICountryService, CountryService>();

        services.AddScoped<IDivisaService, DivisaService>();
        services.AddScoped<IGruppoDivisaService, GruppoDivisaService>();
        services.AddScoped<ITipoDivisaService, TipoDivisaService>();
        services.AddScoped<ICorsoDivisaService, CorsoDivisaService>();

        return services;
    }
}