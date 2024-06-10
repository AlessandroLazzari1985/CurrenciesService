﻿using Apsoft.Domain.Repositories;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Repositories.Boss;
using BancaSempione.Infrastructure.Repositories.Boss;
using BancaSempione.Infrastructure.Repositories.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Infrastructure.Repositories;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Infrastructure_Repositories(this IServiceCollection services)
    {
        // Per usi interni a questo progetto
        services.AddScoped<DivisaRecordRepository>();


        // Per registrare i repository di del dominio
        services.AddScoped<ILogRepository, LogRepository>();

        services.AddScoped<IGruppoDivisaRepository, GruppoDivisaRepository>();
        services.AddScoped<ITipoDivisaRepository, TipoDivisaRepository>();
        services.AddScoped<IDivisaRepository, DivisaRepository>();
        services.AddScoped<ICurrencyPairRepository, CurrencyPairRecordRepository>();
        services.AddScoped<ICorsoDivisaRepository, CorsoDivisaRepository>();

        // Per registrare i repository di Boss
        services.AddScoped<IDivisaBossRepository, DivisaBossRepository>();
        services.AddScoped<ICorsoDivisaBossRepository, CorsoDivisaBossRepository>();
        services.AddScoped<ITabellaBossRepository, TabellaBossRepository>();
        
        
        return services;
    }
}