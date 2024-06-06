using BancaSempione.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Infrastructure.Repositories
{
    public static class Container
    {
        public static IServiceCollection Register_BancaSempione_Infrastructure_Repositories(this IServiceCollection services)
        {
            // Per usi interni a questo progetto
            services.AddScoped<DivisaRecordRepository>();

            
            // Per registrare i repository richiesti da altri progetti
            services.AddScoped<IDivisaRepository, DivisaRepository>();

            return services;
        }
    }
}
