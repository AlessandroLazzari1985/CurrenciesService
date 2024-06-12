using Apsoft.Domain.Repositories;
using Apsoft.Infrastructure.Repositories.Domain;
using Apsoft.Infrastructure.Repositories.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Apsoft.Infrastructure.Repositories;

public static class Container
{
    public static IServiceCollection Register_Apsoft_Infrastructure_Repositories(this IServiceCollection services)
    {
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();


        services.AddAutoMapper(typeof(CurrencyExchangeRateProfile));

        return services;
    }
}
