using Microsoft.Extensions.DependencyInjection;

namespace Apsoft.Infrastructure.Repositories;

public static class Container
{
    public static IServiceCollection Register_Apsoft_Infrastructure_Repositories(this IServiceCollection services)
    {
        // Per usi interni a questo progetto
        services.AddScoped<CurrencyRepository>();


        
        
        return services;
    }
}
