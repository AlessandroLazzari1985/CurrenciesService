using BancaSempione.Application.Provider.Boss.Importers;
using BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Application.Provider.Boss;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Application_Provider_Boss(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBossImporter, BossImporter>();
        
        serviceCollection.AddScoped<IDivisaImporter, DivisaImporter>();
        serviceCollection.AddScoped<IGruppoDivisaImporter, GruppoDivisaImporter>();
        serviceCollection.AddScoped<ITipoDivisaImporter, TipoDivisaImporter>();

        serviceCollection.AddScoped<ICorsoDivisaImporter, CorsoDivisaImporter>();
        serviceCollection.AddScoped<ICorsoDivisaBuilder, CorsoDivisaBuilder>();
        // serviceCollection.AddTransient<ICorsoDivisaIdManager, CorsoDivisaIdManager>();
        serviceCollection.AddTransient<IPercentualeManager, PercentualeManager>();

        return serviceCollection;
    }
}