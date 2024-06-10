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

            
        // Per registrare i repository richiesti da altri progetti
        services.AddScoped<IDivisaRepository, DivisaRepository>();
        services.AddScoped<IDivisaBossRepository, DivisaBossRepository>();
        services.AddScoped<ICorsoDivisaBossRepository, CorsoDivisaBossRepository>();
        services.AddScoped<ITabellaBossRepository, TabellaBossRepository>();
        services.AddScoped<ILogRepository, LogRepository>();

        return services;
    }
}