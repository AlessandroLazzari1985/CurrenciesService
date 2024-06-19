using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Repositories.Generic;
using BancaSempione.Infrastructure.Repositories.Boss;
using BancaSempione.Infrastructure.Repositories.Domain;
using BancaSempione.Infrastructure.Repositories.Mappers;
using BancaSempione.Infrastructure.Repositories.Records;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Infrastructure.Repositories;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Infrastructure_Repositories(this IServiceCollection services)
    {
        // Mappers
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();

        // Per usi interni a questo progetto
        services.AddScoped<DivisaRecordRepository>();
        services.AddScoped<CorsoDivisaRecordRepository>();


        // Per registrare i repository di del dominio
        services.AddScoped<ILogRepository, LogRepository>();

        services.AddScoped<IGruppoDivisaRepository, GruppoDivisaRepository>();
        services.AddScoped<ITipoDivisaRepository, TipoDivisaRepository>();
        services.AddScoped<IDivisaRepository, DivisaRepository>();
        services.AddScoped<ICorsoDivisaRepository, CorsoDivisaRepository>();

        // Per registrare i repository di Boss
        services.AddScoped<IDivisaBossRepository, DivisaBossRepository>();
        services.AddScoped<ICorsoDivisaBossRepository, CorsoDivisaBossRepository>();
        services.AddScoped<ITabellaBossRepository, TabellaBossRepository>();

        services.AddAutoMapper(typeof(DivisaProfile));
        services.AddAutoMapper(typeof(CorsoDivisaProfile));
        return services;
    }
}