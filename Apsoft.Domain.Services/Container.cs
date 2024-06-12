using Apsoft.Domain.Services.Interfaces;
using Apsoft.Domain.Services.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Apsoft.Domain.Services;

public static class Container
{
    public static IServiceCollection Register_Apsoft_Domain_Services(this IServiceCollection services)
    {
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICountryService, CountryService>();

        return services;
    }
}