using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Application.Provider.Boss
{
    public static class Container
    {
        public static IServiceCollection Register_BancaSempione_Application_Provider_Boss(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDivisaImporter, DivisaImporter>();

            return serviceCollection;
        }
    }
}
