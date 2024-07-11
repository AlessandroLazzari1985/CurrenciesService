using BancaSempione.Application.DTOs.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Application.DTOs
{
    public static class Container
    {
        public static IServiceCollection Register_BancaSempione_Application_DTOs(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(CorsoDivisaDtoProfile));
            serviceCollection.AddAutoMapper(typeof(DivisaDtoProfile));

            return serviceCollection;
        }
    }
}
